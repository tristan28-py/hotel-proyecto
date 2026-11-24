using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmCheckInOut : Form
    {
        private readonly HotelAppContext? _app;
        private readonly ReservacionesMvcController? _ctrl;
        private ReservacionModel? _reservaSel;

        public FrmCheckInOut()
        {
            InitializeComponent();
            cboFiltroEstado.SelectedIndex = 0;
            cboMetodo.SelectedIndex = 0;
            cboComprobante.SelectedIndex = 0;
        }

        public FrmCheckInOut(HotelAppContext app) : this()
        {
            _app = app;
            _ctrl = new ReservacionesMvcController(app.Api);
            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
        }

        private async void FrmCheckInOut_Load(object? sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private void FrmCheckInOut_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_app != null)
                _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await BuscarAsync());
        }

        private async void btnBuscar_Click(object? sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void dgvReservas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservas.Rows[e.RowIndex].DataBoundItem is ReservacionModel r)
            {
                _reservaSel = r;
                await CargarFolioAsync(r.Id);
            }
        }

        private async void btnConfirmar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _reservaSel == null) return;
            var res = await _ctrl.ConfirmarAsync(_reservaSel.Id);
            if (!res.Success) MessageBox.Show(res.Error, "No se pudo confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await BuscarAsync();
        }

        private async void btnCancelar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _reservaSel == null) return;
            if (MessageBox.Show($"Cancelar la reservacion {_reservaSel.Codigo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            var res = await _ctrl.CancelarAsync(_reservaSel.Id, "Cancelada desde recepcion");
            if (!res.Success) MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await BuscarAsync();
        }

        private async void btnCheckIn_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _reservaSel == null) return;
            var res = await _ctrl.CheckInAsync(new CheckInRequestModel
            {
                ReservacionId = _reservaSel.Id,
                LlavesAsignadas = txtLlaves.Text.Trim(),
                Acompanantes = txtAcompanantes.Text.Trim()
            });
            if (!res.Success)
                MessageBox.Show(res.Error, "Check-in rechazado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Check-in completado. Habitacion marcada como Ocupada.", "Check-in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await BuscarAsync();
            }
        }

        private async void btnPagar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _reservaSel == null) return;
            var res = await _ctrl.RegistrarPagoAsync(new PagoModel
            {
                ReservacionId = _reservaSel.Id,
                Monto = numPago.Value,
                MetodoPago = cboMetodo.SelectedItem?.ToString() ?? "Efectivo",
                TipoComprobante = cboComprobante.SelectedItem?.ToString() ?? "Recibo",
                ReferenciaTransaccion = txtRefPago.Text.Trim()
            });
            if (!res.Success)
                MessageBox.Show(res.Error, "Pago rechazado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show($"Pago registrado ({res.Data?.NumeroComprobante}).", "Pago exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await BuscarAsync();
            }
        }

        private async void btnCheckOut_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _reservaSel == null) return;
            var folio = await _ctrl.ObtenerEstadoCuentaAsync(_reservaSel.Id);
            if (!folio.Success || folio.Data == null) return;

            decimal saldoConAjustes = Math.Max(0m, folio.Data.SaldoPendiente + numAjustes.Value);
            var res = await _ctrl.CheckOutAsync(new CheckOutRequestModel
            {
                ReservacionId = _reservaSel.Id,
                AjustesCheckOut = numAjustes.Value,
                Observaciones = txtObsOut.Text.Trim(),
                MontoPagoFinal = saldoConAjustes > 0 ? saldoConAjustes : null,
                MetodoPagoFinal = saldoConAjustes > 0 ? cboMetodo.SelectedItem?.ToString() : null,
                ReferenciaPagoFinal = txtRefPago.Text.Trim(),
                TipoComprobante = cboComprobante.SelectedItem?.ToString() ?? "Factura"
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

            MessageBox.Show("Check-out completado. La habitacion paso a EnLimpieza.", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await BuscarAsync();
        }

        private async Task BuscarAsync()
        {
            if (_ctrl == null) return;
            string? estado = cboFiltroEstado.SelectedItem?.ToString();
            if (estado == "Todos") estado = null;

            var res = await _ctrl.BuscarAsync(txtBuscar.Text.Trim(), estado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvReservas.DataSource = res.Data;

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
            if (_ctrl == null) return;
            var res = await _ctrl.ObtenerEstadoCuentaAsync(reservacionId);
            if (!res.Success || res.Data == null) return;

            var f = res.Data;
            dgvPagos.DataSource = f.Pagos;
            lblResumenFolio.Text =
                $"Reserva: {f.Codigo} | Hab: {f.HabitacionNumero} | Estado: {f.Estado}\r\n" +
                $"Huesped: {f.ClienteNombre}\r\n" +
                $"Hospedaje: {f.CostoHospedaje:C2} | Rest.: {f.TotalRestaurante:C2} | Ajustes: {f.AjustesCheckOut:C2}\r\n" +
                $"TOTAL: {f.TotalGeneral:C2} | PAGADO: {f.TotalPagado:C2}\r\n" +
                $"SALDO PENDIENTE: {f.SaldoPendiente:C2}";

            numPago.Value = Math.Clamp(Math.Max(0m, f.SaldoPendiente), 0m, 100000m);
        }
    }
}
