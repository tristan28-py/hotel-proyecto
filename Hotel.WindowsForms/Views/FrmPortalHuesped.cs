using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmPortalHuesped : Form
    {
        private readonly HotelAppContext? _app;
        private readonly HabitacionesMvcController? _habCtrl;
        private readonly ReservacionesMvcController? _resCtrl;

        private HabitacionModel? _suiteSeleccionada;
        private CotizacionResponseModel? _cotizacionActual;

        public FrmPortalHuesped()
        {
            InitializeComponent();
            dtpEntrada.Value = DateTime.Today.AddDays(1);
            dtpSalida.Value = DateTime.Today.AddDays(3);
            cboMetodo.SelectedIndex = 0;
            UiTheme.ConfigurarColumnas(dgvMisReservas,
                ("Codigo", "Codigo", 18, 110, null),
                ("HabitacionNumero", "Hab.", 10, 55, null),
                ("TipoHabitacionNombre", "Suite", 24, 130, null),
                ("FechaInicio", "Entrada", 14, 85, "dd/MM/yyyy"),
                ("FechaFin", "Salida", 14, 85, "dd/MM/yyyy"),
                ("Estado", "Estado", 12, 95, null),
                ("SaldoPendiente", "Saldo", 12, 85, "C2"));
            UiTheme.ConfigurarColumnas(dgvMisPagos,
                ("FechaPago", "Fecha", 26, 120, "dd/MM/yyyy HH:mm"),
                ("Monto", "Monto", 18, 85, "C2"),
                ("MetodoPago", "Metodo", 24, 110, null),
                ("TipoComprobante", "Tipo", 14, 70, null),
                ("NumeroComprobante", "Comprobante", 18, 100, null));
        }

        public FrmPortalHuesped(HotelAppContext app, int tabInicial = 0) : this()
        {
            _app = app;
            _habCtrl = new HabitacionesMvcController(app.Api);
            _resCtrl = new ReservacionesMvcController(app.Api);
            tabHuesped.SelectedIndex = tabInicial;
            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
        }

        private async void FrmPortalHuesped_Load(object? sender, EventArgs e)
        {
            await BuscarSuitesAsync();
            await CargarMisReservasAsync();
        }

        private void FrmPortalHuesped_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_app != null)
                _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(async () =>
                {
                    await BuscarSuitesAsync();
                    await CargarMisReservasAsync();
                });
            }
        }

        private async void btnBuscarSuites_Click(object? sender, EventArgs e)
        {
            await BuscarSuitesAsync();
        }

        private async void btnConfirmarReserva_Click(object? sender, EventArgs e)
        {
            if (_app?.SesionActual?.ClienteId is not int clienteId || _resCtrl == null)
            {
                MessageBox.Show("Su cuenta no tiene un perfil de huesped vinculado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_suiteSeleccionada == null || _cotizacionActual == null)
            {
                MessageBox.Show("Seleccione una suite de la lista primero.", "Falta seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var req = new CrearReservacionRequestModel
            {
                ClienteId = clienteId,
                HabitacionId = _suiteSeleccionada.Id,
                FechaInicio = DateOnly.FromDateTime(dtpEntrada.Value),
                FechaFin = DateOnly.FromDateTime(dtpSalida.Value),
                HoraLlegadaPactada = new TimeOnly(15, 0),
                CantidadHuespedes = (int)numHuespedes.Value,
                Observaciones = txtObsReserva.Text.Trim(),
                ConfirmarConAnticipo = chkPagarAnticipo.Checked,
                MontoAnticipoPagado = chkPagarAnticipo.Checked ? _cotizacionActual.MontoAnticipoRequerido : null,
                MetodoPagoAnticipo = chkPagarAnticipo.Checked ? cboMetodo.SelectedItem?.ToString() : null,
                ReferenciaPagoAnticipo = chkPagarAnticipo.Checked ? $"WEB-{DateTime.Now:HHmmss}" : null
            };

            var res = await _resCtrl.CrearAsync(req);
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "No se pudo reservar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                await BuscarSuitesAsync();
                return;
            }

            MessageBox.Show(
                $"Reserva confirmada.\nCodigo: {res.Data.Codigo}\nEstado: {res.Data.Estado}\nTotal: {res.Data.CostoTotal:C2}",
                "Gracias por su reserva",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _suiteSeleccionada = null;
            _cotizacionActual = null;
            tabHuesped.SelectedIndex = 1;
            await CargarMisReservasAsync();
            await BuscarSuitesAsync();
        }

        private async void dgvMisReservas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_resCtrl == null || e.RowIndex < 0) return;
            if (dgvMisReservas.Rows[e.RowIndex].DataBoundItem is ReservacionModel r)
            {
                var folio = await _resCtrl.ObtenerEstadoCuentaAsync(r.Id);
                if (folio.Success && folio.Data != null)
                {
                    var f = folio.Data;
                    lblMiFolio.Text =
                        $"Reserva {f.Codigo} | Hab. {f.HabitacionNumero} | Estado: {f.Estado}\r\n" +
                        $"Hospedaje: {f.CostoHospedaje:C2} | Restaurante: {f.TotalRestaurante:C2} | Total: {f.TotalGeneral:C2} | Pagado: {f.TotalPagado:C2} | Saldo: {f.SaldoPendiente:C2}";
                    dgvMisPagos.DataSource = f.Pagos;
                }
            }
        }

        private async Task BuscarSuitesAsync()
        {
            if (_habCtrl == null) return;
            var entrada = DateOnly.FromDateTime(dtpEntrada.Value);
            var salida = DateOnly.FromDateTime(dtpSalida.Value);
            var res = await _habCtrl.BuscarDisponiblesAsync(entrada, salida, (int)numHuespedes.Value);
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            flpSuites.SuspendLayout();
            flpSuites.Controls.Clear();
            foreach (var h in res.Data)
            {
                var card = new Panel
                {
                    Width = 294,
                    Height = 202,
                    BackColor = Color.White,
                    Margin = new Padding(8),
                    BorderStyle = BorderStyle.FixedSingle
                };

                var barra = new Panel { Dock = DockStyle.Top, Height = 8, BackColor = UiTheme.DoradoHotel };
                var lblTipo = new Label
                {
                    Text = $"{h.TipoHabitacionNombre} - Hab. {h.Numero}",
                    Font = new Font("Georgia", 11f, FontStyle.Bold),
                    ForeColor = UiTheme.SidebarFondo,
                    Location = new Point(14, 18),
                    Size = new Size(266, 24),
                    AutoEllipsis = true
                };
                var lblCap = new Label
                {
                    Text = $"Piso {h.Piso} | Hasta {h.CapacidadAdultos} adultos y {h.CapacidadNinos} ninos",
                    ForeColor = UiTheme.TextoSuave,
                    Font = new Font("Segoe UI", 8.5f),
                    Location = new Point(14, 46),
                    Size = new Size(266, 20),
                    AutoEllipsis = true
                };

                var amenidades = new List<string>();
                if (h.TieneVistaMar) amenidades.Add("Vista al Mar");
                if (h.TieneJacuzzi) amenidades.Add("Jacuzzi");
                if (h.TieneWifi6) amenidades.Add("Wi-Fi 6");
                if (h.TieneFrigobar) amenidades.Add("Frigobar");

                var lblAmen = new Label
                {
                    Text = amenidades.Count > 0 ? string.Join(" | ", amenidades) : "Comodidades estandar",
                    ForeColor = Color.FromArgb(21, 128, 61),
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    Location = new Point(14, 70),
                    Size = new Size(266, 36),
                    AutoEllipsis = true
                };

                var lblPrecio = new Label
                {
                    Text = $"{h.PrecioBasePorNoche:C2} / noche",
                    ForeColor = UiTheme.SidebarFondo,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    Location = new Point(14, 114),
                    Size = new Size(266, 26)
                };

                var btnSel = new Button
                {
                    Text = "Cotizar y Seleccionar",
                    Location = new Point(14, 150),
                    Size = new Size(266, 36)
                };
                UiTheme.EstilizarBoton(btnSel, UiTheme.SidebarFondo);
                btnSel.Click += async (_, _) => await SeleccionarSuiteAsync(h);

                card.Controls.AddRange([btnSel, lblPrecio, lblAmen, lblCap, lblTipo, barra]);
                flpSuites.Controls.Add(card);
            }
            flpSuites.ResumeLayout();
        }

        private async Task SeleccionarSuiteAsync(HabitacionModel h)
        {
            if (_app?.SesionActual == null || _resCtrl == null) return;
            _suiteSeleccionada = h;

            var res = await _resCtrl.CotizarAsync(new CotizacionRequestModel
            {
                HabitacionId = h.Id,
                ClienteId = _app.SesionActual.ClienteId,
                FechaInicio = DateOnly.FromDateTime(dtpEntrada.Value),
                FechaFin = DateOnly.FromDateTime(dtpSalida.Value),
                CantidadHuespedes = (int)numHuespedes.Value
            });

            if (!res.Success || res.Data == null)
            {
                lblCotizacionHuesped.Text = res.Error;
                _cotizacionActual = null;
                return;
            }

            _cotizacionActual = res.Data;
            var c = res.Data;
            lblCotizacionHuesped.Text =
                $"Suite {c.HabitacionNumero} ({c.TipoHabitacion})\r\n" +
                $"Noches: {c.Noches} x {c.TarifaBasePorNoche:C2} = {c.SubtotalHospedaje:C2}\r\n" +
                $"Temporada: +{c.RecargoTemporada:C2}\r\n" +
                $"Desc. Frecuente: -{c.DescuentoCliente:C2}\r\n" +
                $"IVA (16%): {c.Impuestos:C2}\r\n" +
                $"TOTAL: {c.CostoTotal:C2}\r\n" +
                $"Anticipo requerido (30%): {c.MontoAnticipoRequerido:C2}";
        }

        private async Task CargarMisReservasAsync()
        {
            if (_app?.SesionActual?.ClienteId is not int clienteId || _resCtrl == null) return;
            var res = await _resCtrl.BuscarAsync(clienteId: clienteId);
            if (res.Success)
                dgvMisReservas.DataSource = res.Data;
        }
    }
}
