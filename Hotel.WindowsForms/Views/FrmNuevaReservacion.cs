using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmNuevaReservacion : Form
    {
        private readonly HotelAppContext? _app;
        private readonly HabitacionesMvcController? _habCtrl;
        private readonly ClientesMvcController? _cliCtrl;
        private readonly ReservacionesMvcController? _resCtrl;

        private HabitacionModel? _habSeleccionada;

        public FrmNuevaReservacion()
        {
            InitializeComponent();
            calEntrada.SelectionStart = DateTime.Today;
            calSalida.SelectionStart = DateTime.Today.AddDays(2);
            dtpMatrizDesde.Value = DateTime.Today;
            dtpMatrizHasta.Value = DateTime.Today.AddDays(10);
            cboMetodoPago.SelectedIndex = 0;
        }

        public FrmNuevaReservacion(HotelAppContext app) : this()
        {
            _app = app;
            _habCtrl = new HabitacionesMvcController(app.Api);
            _cliCtrl = new ClientesMvcController(app.Api);
            _resCtrl = new ReservacionesMvcController(app.Api);
            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
        }

        private async void FrmNuevaReservacion_Load(object? sender, EventArgs e)
        {
            await InicializarDatosAsync();
        }

        private void FrmNuevaReservacion_FormClosed(object? sender, FormClosedEventArgs e)
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
                    await BuscarDisponiblesAsync();
                    await CargarMatrizAsync();
                });
            }
        }

        private async void btnBuscarDisp_Click(object? sender, EventArgs e)
        {
            await BuscarDisponiblesAsync();
        }

        private async void dgvDisponibles_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDisponibles.Rows[e.RowIndex].DataBoundItem is HabitacionModel h)
            {
                _habSeleccionada = h;
                await CotizarAsync();
            }
        }

        private async void cboClientes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_habSeleccionada != null)
                await CotizarAsync();
        }

        private async void btnRefrescarCli_Click(object? sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async void btnCrearReserva_Click(object? sender, EventArgs e)
        {
            await CrearReservacionAsync();
        }

        private async void btnCargarMatriz_Click(object? sender, EventArgs e)
        {
            await CargarMatrizAsync();
        }

        private async Task InicializarDatosAsync()
        {
            if (_habCtrl == null) return;
            var tiposRes = await _habCtrl.ListarTiposAsync();
            var listaTipos = new List<TipoHabitacionModel> { new() { Id = 0, Nombre = "-- Todos los tipos --" } };
            if (tiposRes.Success && tiposRes.Data != null) listaTipos.AddRange(tiposRes.Data);
            cboTipo.DataSource = listaTipos;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Id";

            await CargarClientesAsync();
            await BuscarDisponiblesAsync();
            await CargarMatrizAsync();
        }

        private async Task CargarClientesAsync()
        {
            if (_cliCtrl == null) return;
            var cliRes = await _cliCtrl.ListarAsync();
            if (cliRes.Success && cliRes.Data != null)
            {
                cboClientes.DataSource = cliRes.Data;
                cboClientes.DisplayMember = "NombreCompleto";
                cboClientes.ValueMember = "Id";
            }
        }

        private async Task BuscarDisponiblesAsync()
        {
            if (_habCtrl == null) return;
            var entrada = DateOnly.FromDateTime(calEntrada.SelectionStart);
            var salida = DateOnly.FromDateTime(calSalida.SelectionStart);
            int? tipoId = cboTipo.SelectedValue is int id && id > 0 ? id : null;

            var res = await _habCtrl.BuscarDisponiblesAsync(entrada, salida, (int)numHuespedes.Value, tipoId);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Busqueda de disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvDisponibles.DataSource = res.Data;
        }

        private async Task CotizarAsync()
        {
            if (_resCtrl == null || _habSeleccionada == null) return;

            var req = new CotizacionRequestModel
            {
                HabitacionId = _habSeleccionada.Id,
                ClienteId = cboClientes.SelectedValue as int?,
                FechaInicio = DateOnly.FromDateTime(calEntrada.SelectionStart),
                FechaFin = DateOnly.FromDateTime(calSalida.SelectionStart),
                CantidadHuespedes = (int)numHuespedes.Value
            };

            var res = await _resCtrl.CotizarAsync(req);
            if (!res.Success || res.Data == null)
            {
                lblCotizacion.Text = $"No disponible: {res.Error}";
                return;
            }

            var c = res.Data;
            lblCotizacion.Text =
                $"Habitacion: {c.HabitacionNumero} ({c.TipoHabitacion})\r\n" +
                $"Noches: {c.Noches} x {c.TarifaBasePorNoche:C2} = {c.SubtotalHospedaje:C2}\r\n" +
                $"Temporada: {c.DetalleTemporada} (+{c.RecargoTemporada:C2})\r\n" +
                $"Personas extra: +{c.RecargoPersonasExtra:C2} | Desc.: -{c.DescuentoCliente:C2}\r\n" +
                $"IVA (16%): {c.Impuestos:C2}\r\n" +
                $"TOTAL: {c.CostoTotal:C2} | ANTICIPO (30%): {c.MontoAnticipoRequerido:C2}";

            numAnticipo.Value = Math.Clamp(c.MontoAnticipoRequerido, 0, 100000);
        }

        private async Task CrearReservacionAsync()
        {
            if (_resCtrl == null) return;
            if (_habSeleccionada == null)
            {
                MessageBox.Show("Seleccione una habitacion de la lista.", "Falta habitacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboClientes.SelectedValue is not int clienteId)
            {
                MessageBox.Show("Seleccione un cliente.", "Falta cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var req = new CrearReservacionRequestModel
            {
                ClienteId = clienteId,
                HabitacionId = _habSeleccionada.Id,
                FechaInicio = DateOnly.FromDateTime(calEntrada.SelectionStart),
                FechaFin = DateOnly.FromDateTime(calSalida.SelectionStart),
                HoraLlegadaPactada = new TimeOnly(15, 0),
                CantidadHuespedes = (int)numHuespedes.Value,
                Acompanantes = txtAcompanantes.Text.Trim(),
                Observaciones = txtObservaciones.Text.Trim(),
                ConfirmarConAnticipo = chkConfirmarAnticipo.Checked,
                MontoAnticipoPagado = chkConfirmarAnticipo.Checked ? numAnticipo.Value : null,
                MetodoPagoAnticipo = chkConfirmarAnticipo.Checked ? cboMetodoPago.SelectedItem?.ToString() : null,
                ReferenciaPagoAnticipo = chkConfirmarAnticipo.Checked ? txtReferencia.Text.Trim() : null
            };

            var res = await _resCtrl.CrearAsync(req);
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "No se pudo crear la reservacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                await BuscarDisponiblesAsync();
                return;
            }

            MessageBox.Show(
                $"Reservacion creada.\nCodigo: {res.Data.Codigo}\nEstado: {res.Data.Estado}\nTotal: {res.Data.CostoTotal:C2}",
                "Reservacion Guardada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _habSeleccionada = null;
            await BuscarDisponiblesAsync();
            await CargarMatrizAsync();
        }

        private async Task CargarMatrizAsync()
        {
            if (_resCtrl == null) return;
            var inicio = DateOnly.FromDateTime(dtpMatrizDesde.Value);
            var fin = DateOnly.FromDateTime(dtpMatrizHasta.Value);
            var res = await _resCtrl.ObtenerMatrizAsync(inicio, fin);
            if (!res.Success || res.Data == null) return;

            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();
            dgvMatriz.Columns.Add("Hab", "Hab.");
            dgvMatriz.Columns.Add("Tipo", "Tipo");

            if (res.Data.Count > 0)
            {
                foreach (var d in res.Data[0].Dias)
                    dgvMatriz.Columns.Add(d.Fecha.ToString("yyyy-MM-dd"), d.Fecha.ToString("dd/MM"));

                foreach (var fila in res.Data)
                {
                    int idx = dgvMatriz.Rows.Add();
                    var row = dgvMatriz.Rows[idx];
                    row.Cells[0].Value = fila.Numero;
                    row.Cells[1].Value = fila.TipoHabitacion;
                    for (int i = 0; i < fila.Dias.Count; i++)
                    {
                        var dia = fila.Dias[i];
                        var cell = row.Cells[i + 2];
                        cell.Value = dia.CodigoReservacion ?? dia.Estado;
                        cell.Style.BackColor = UiTheme.ColorEstadoHabitacion(dia.Estado);
                        cell.Style.ForeColor = dia.Estado == "EnLimpieza" ? Color.Black : Color.White;
                    }
                }
            }
        }
    }
}
