using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmCheckInOut : Form
    {
        private readonly HotelAppContext _app;
        private readonly ReservacionesMvcController _ctrl;

        private TextBox _txtBuscar = null!;
        private ComboBox _cboFiltroEstado = null!;
        private DataGridView _dgvReservas = null!;
        private DataGridView _dgvPagos = null!;
        private Label _lblResumenFolio = null!;
        private TextBox _txtLlaves = null!;
        private TextBox _txtAcompanantes = null!;
        private NumericUpDown _numPago = null!;
        private ComboBox _cboMetodo = null!;
        private ComboBox _cboComprobante = null!;
        private TextBox _txtRefPago = null!;
        private NumericUpDown _numAjustes = null!;
        private TextBox _txtObsOut = null!;
        private ReservacionModel? _reservaSel;

        public FrmCheckInOut(HotelAppContext app)
        {
            _app = app;
            _ctrl = new ReservacionesMvcController(app.Api);
            InicializarComponentes();

            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
            FormClosed += (_, _) => _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
            Shown += async (_, _) => await BuscarAsync();
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await BuscarAsync());
        }

        private void InicializarComponentes()
        {
            Text = "Check-in, Check-out, Pagos y Folio";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var pnlTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48, Padding = new Padding(12, 8, 12, 6), BackColor = Color.White };
            pnlTop.Controls.Add(new Label { Text = "DNI / Código / Habitación:", AutoSize = true, Padding = new Padding(0, 6, 0, 0), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) });
            _txtBuscar = new TextBox { Width = 220 };
            _cboFiltroEstado = new ComboBox { Width = 145, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboFiltroEstado.Items.AddRange(["Todos", "PendientePago", "Confirmada", "EnCurso", "Completada", "Cancelada"]);
            _cboFiltroEstado.SelectedIndex = 0;

            var btnBuscar = new Button { Text = "Buscar", Width = 90, Height = 28 };
            UiTheme.EstilizarBoton(btnBuscar, UiTheme.Primario);
            btnBuscar.Click += async (_, _) => await BuscarAsync();
            pnlTop.Controls.AddRange([_txtBuscar, _cboFiltroEstado, btnBuscar]);

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 590 };

            var splitIzq = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 300 };
            _dgvReservas = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvReservas);
            _dgvReservas.CellClick += async (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgvReservas.Rows[e.RowIndex].DataBoundItem is ReservacionModel r)
                {
                    _reservaSel = r;
                    await CargarFolioAsync(r.Id);
                }
            };
            splitIzq.Panel1.Controls.Add(_dgvReservas);

            var pnlPagos = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(8) };
            pnlPagos.Controls.Add(new Label { Text = "Historial de Pagos y Abonos (inmutable)", Dock = DockStyle.Top, Height = 24, Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold) });
            _dgvPagos = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvPagos);
            pnlPagos.Controls.Add(_dgvPagos);
            splitIzq.Panel2.Controls.Add(pnlPagos);
            split.Panel1.Controls.Add(splitIzq);

            var pnlDer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12), AutoScroll = true };

            _lblResumenFolio = new Label
            {
                Dock = DockStyle.Top,
                Height = 135,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(8),
                Font = new Font("Consolas", 9.2f),
                Text = "Seleccione una reservación para ver su folio y realizar Check-in / Pagos / Check-out."
            };

            // Grupo Check-in
            var grpIn = new GroupBox { Text = "1. Registro de Check-in", Dock = DockStyle.Top, Height = 125, Padding = new Padding(8) };
            _txtLlaves = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Llaves magnéticas (ej. LLAVE-101A)" };
            _txtAcompanantes = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Acompañantes presentes" };
            var flpIn = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 38, Padding = new Padding(0, 6, 0, 0) };
            var btnConfirmar = new Button { Text = "Confirmar Reserva", Width = 140, Height = 30 };
            var btnCheckIn = new Button { Text = "Realizar Check-in", Width = 140, Height = 30 };
            var btnCancelar = new Button { Text = "Cancelar", Width = 85, Height = 30 };
            UiTheme.EstilizarBoton(btnConfirmar, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnCheckIn, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnCancelar, Color.FromArgb(220, 38, 38));
            btnConfirmar.Click += async (_, _) => await ConfirmarAsync();
            btnCheckIn.Click += async (_, _) => await CheckInAsync();
            btnCancelar.Click += async (_, _) => await CancelarAsync();
            flpIn.Controls.AddRange([btnConfirmar, btnCheckIn, btnCancelar]);
            grpIn.Controls.Add(flpIn);
            grpIn.Controls.Add(_txtAcompanantes);
            grpIn.Controls.Add(_txtLlaves);

            // Grupo Pagos Parciales / Totales
            var grpPago = new GroupBox { Text = "2. Registrar Abono / Pago", Dock = DockStyle.Top, Height = 155, Padding = new Padding(8) };
            var tblP = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, Height = 88 };
            tblP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            tblP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            _numPago = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Maximum = 100000 };
            _cboMetodo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboMetodo.Items.AddRange(["Efectivo", "TarjetaCredito", "TarjetaDebito", "TransferenciaBancaria"]);
            _cboMetodo.SelectedIndex = 0;
            _cboComprobante = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboComprobante.Items.AddRange(["Recibo", "Factura"]);
            _cboComprobante.SelectedIndex = 0;
            _txtRefPago = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Referencia transacción" };
            tblP.Controls.Add(new Label { Text = "Monto:", AutoSize = true }, 0, 0);
            tblP.Controls.Add(_numPago, 1, 0);
            tblP.Controls.Add(new Label { Text = "Método:", AutoSize = true }, 0, 1);
            tblP.Controls.Add(_cboMetodo, 1, 1);
            tblP.Controls.Add(new Label { Text = "Referencia:", AutoSize = true }, 0, 2);
            tblP.Controls.Add(_txtRefPago, 1, 2);

            var btnPagar = new Button { Text = "Registrar Abono", Dock = DockStyle.Bottom, Height = 32 };
            UiTheme.EstilizarBoton(btnPagar, UiTheme.Primario);
            btnPagar.Click += async (_, _) => await RegistrarPagoAsync();
            grpPago.Controls.Add(btnPagar);
            grpPago.Controls.Add(tblP);

            // Grupo Check-out
            var grpOut = new GroupBox { Text = "3. Check-out y Liquidación Final", Dock = DockStyle.Top, Height = 165, Padding = new Padding(8) };
            var tblO = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, Height = 88 };
            tblO.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            tblO.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            _numAjustes = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Minimum = -5000, Maximum = 50000 };
            _txtObsOut = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Inspección habitación / minibar" };
            tblO.Controls.Add(new Label { Text = "Ajustes/Minibar:", AutoSize = true }, 0, 0);
            tblO.Controls.Add(_numAjustes, 1, 0);
            tblO.Controls.Add(new Label { Text = "Comprobante:", AutoSize = true }, 0, 1);
            tblO.Controls.Add(_cboComprobante, 1, 1);
            tblO.Controls.Add(new Label { Text = "Observación:", AutoSize = true }, 0, 2);
            tblO.Controls.Add(_txtObsOut, 1, 2);

            var btnCheckOut = new Button { Text = "Finalizar Check-out y Emitir Factura PDF", Dock = DockStyle.Bottom, Height = 34 };
            UiTheme.EstilizarBoton(btnCheckOut, Color.FromArgb(220, 38, 38));
            btnCheckOut.Click += async (_, _) => await CheckOutAsync();
            grpOut.Controls.Add(btnCheckOut);
            grpOut.Controls.Add(tblO);

            pnlDer.Controls.Add(grpOut);
            pnlDer.Controls.Add(grpPago);
            pnlDer.Controls.Add(grpIn);
            pnlDer.Controls.Add(_lblResumenFolio);
            split.Panel2.Controls.Add(pnlDer);

            Controls.Add(split);
            Controls.Add(pnlTop);
        }

        private async Task BuscarAsync()
        {
            string? estado = _cboFiltroEstado.SelectedItem?.ToString();
            if (estado == "Todos") estado = null;

            var res = await _ctrl.BuscarAsync(_txtBuscar.Text.Trim(), estado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _dgvReservas.DataSource = res.Data;
            if (_reservaSel != null)
            {
                var updated = res.Data?.FirstOrDefault(r => r.Id == _reservaSel.Id);
                if (updated != null)
                {
                    _reservaSel = updated;
                    await CargarFolioAsync(updated.Id);
                }
            }
        }

        private async Task CargarFolioAsync(int reservacionId)
        {
            var res = await _ctrl.ObtenerEstadoCuentaAsync(reservacionId);
            if (!res.Success || res.Data == null) return;

            var f = res.Data;
            _dgvPagos.DataSource = f.Pagos;
            _lblResumenFolio.Text =
                $"Reserva: {f.Codigo} | Hab: {f.HabitacionNumero} | Estado: {f.Estado}\r\n" +
                $"Huésped: {f.ClienteNombre}\r\n" +
                $"Hospedaje: {f.CostoHospedaje:C2} | Restaurante: {f.TotalRestaurante:C2} | Ajustes: {f.AjustesCheckOut:C2}\r\n" +
                $"TOTAL GENERAL: {f.TotalGeneral:C2} | PAGADO: {f.TotalPagado:C2}\r\n" +
                $"SALDO PENDIENTE: {f.SaldoPendiente:C2}";

            _numPago.Value = Math.Clamp(Math.Max(0m, f.SaldoPendiente), 0m, 100000m);
        }

        private async Task ConfirmarAsync()
        {
            if (_reservaSel == null) return;
            var res = await _ctrl.ConfirmarAsync(_reservaSel.Id);
            if (!res.Success) MessageBox.Show(res.Error, "No se pudo confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await BuscarAsync();
        }

        private async Task CancelarAsync()
        {
            if (_reservaSel == null) return;
            if (MessageBox.Show($"¿Cancelar la reservación {_reservaSel.Codigo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            var res = await _ctrl.CancelarAsync(_reservaSel.Id, "Cancelada desde recepción");
            if (!res.Success) MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await BuscarAsync();
        }

        private async Task CheckInAsync()
        {
            if (_reservaSel == null) return;
            var res = await _ctrl.CheckInAsync(new CheckInRequestModel
            {
                ReservacionId = _reservaSel.Id,
                LlavesAsignadas = _txtLlaves.Text.Trim(),
                Acompanantes = _txtAcompanantes.Text.Trim()
            });
            if (!res.Success) MessageBox.Show(res.Error, "Check-in rechazado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Check-in completado. Habitación marcada como Ocupada.", "Check-in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await BuscarAsync();
            }
        }

        private async Task RegistrarPagoAsync()
        {
            if (_reservaSel == null) return;
            var res = await _ctrl.RegistrarPagoAsync(new PagoModel
            {
                ReservacionId = _reservaSel.Id,
                Monto = _numPago.Value,
                MetodoPago = _cboMetodo.SelectedItem?.ToString() ?? "Efectivo",
                TipoComprobante = _cboComprobante.SelectedItem?.ToString() ?? "Recibo",
                ReferenciaTransaccion = _txtRefPago.Text.Trim()
            });
            if (!res.Success) MessageBox.Show(res.Error, "Pago rechazado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show($"Pago registrado ({res.Data?.NumeroComprobante}).", "Pago exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await BuscarAsync();
            }
        }

        private async Task CheckOutAsync()
        {
            if (_reservaSel == null) return;
            var folio = await _ctrl.ObtenerEstadoCuentaAsync(_reservaSel.Id);
            if (!folio.Success || folio.Data == null) return;

            decimal saldoConAjustes = Math.Max(0m, folio.Data.SaldoPendiente + _numAjustes.Value);
            var res = await _ctrl.CheckOutAsync(new CheckOutRequestModel
            {
                ReservacionId = _reservaSel.Id,
                AjustesCheckOut = _numAjustes.Value,
                Observaciones = _txtObsOut.Text.Trim(),
                MontoPagoFinal = saldoConAjustes > 0 ? saldoConAjustes : null,
                MetodoPagoFinal = saldoConAjustes > 0 ? _cboMetodo.SelectedItem?.ToString() : null,
                ReferenciaPagoFinal = _txtRefPago.Text.Trim(),
                TipoComprobante = _cboComprobante.SelectedItem?.ToString() ?? "Factura"
            });

            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "Error en Check-out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Factura_{res.Data.Codigo}.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportadorReportes.ExportarFacturaCheckOutPdf(sfd.FileName, res.Data);

            MessageBox.Show("Check-out completado. La habitación pasó a estado 'EnLimpieza'.", "Check-out Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await BuscarAsync();
        }
    }
}
