using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmReportesOcupacion : Form
    {
        private readonly ReportesMvcController? _ctrl;
        private List<ResumenMensualOcupacionModel> _mensual = new();
        private ReporteIngresosModel? _ingresos;
        private List<PlatilloMasSolicitadoModel> _platillosTop = new();

        public FrmReportesOcupacion()
        {
            InitializeComponent();
            dtpInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFin.Value = DateTime.Today;
            numAnio.Value = DateTime.Today.Year;
        }

        public FrmReportesOcupacion(HotelAppContext app) : this()
        {
            _ctrl = new ReportesMvcController(app.Api);
        }

        private async void FrmReportesOcupacion_Load(object? sender, EventArgs e)
        {
            await CargarReportesAsync();
        }

        private async void btnGenerar_Click(object? sender, EventArgs e)
        {
            await CargarReportesAsync();
        }

        private void btnExcel_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = $"ReporteHotel_{DateTime.Now:yyyyMMdd}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportadorReportes.ExportarExcel(sfd.FileName, _mensual, _ingresos, _platillosTop);
                MessageBox.Show("Reporte exportado a Excel correctamente.", "Exportacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdf_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = $"ReporteHotel_{DateTime.Now:yyyyMMdd}.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportadorReportes.ExportarPdf(sfd.FileName, _mensual, _ingresos, _platillosTop);
                MessageBox.Show("Reporte exportado a PDF correctamente.", "Exportacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task CargarReportesAsync()
        {
            if (_ctrl == null) return;
            var inicio = DateOnly.FromDateTime(dtpInicio.Value);
            var fin = DateOnly.FromDateTime(dtpFin.Value);

            var resMensual = await _ctrl.ObtenerOcupacionMensualAsync((int)numAnio.Value);
            if (resMensual.Success && resMensual.Data != null)
            {
                _mensual = resMensual.Data;
                dgvMensual.DataSource = _mensual;
            }

            var resIng = await _ctrl.ObtenerIngresosAsync(inicio, fin);
            if (resIng.Success && resIng.Data != null)
            {
                _ingresos = resIng.Data;
                lblResumenIngresos.Text =
                    $"Pagos recibidos: {_ingresos.TotalPagosRecibidos:C2} | Hospedaje proyectado: {_ingresos.TotalHospedajeProyectado:C2} | Restaurante: {_ingresos.TotalConsumosRestaurante:C2}";
                dgvIngresos.DataSource = _ingresos.DetallePagos;
            }

            var resTop = await _ctrl.ObtenerPlatillosTopAsync(10);
            if (resTop.Success && resTop.Data != null)
            {
                _platillosTop = resTop.Data;
                dgvPlatillosTop.DataSource = _platillosTop;
            }

            pnlGrafico.Invalidate();
        }

        private void pnlGrafico_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            using var fontTitulo = new Font("Segoe UI", 11, FontStyle.Bold);
            using var fontLabel = new Font("Segoe UI", 8.5f);
            g.DrawString($"Facturacion Mensual {numAnio.Value}", fontTitulo, Brushes.DarkSlateGray, 16, 10);

            if (_mensual.Count == 0)
            {
                g.DrawString("Sin datos registrados para el ano seleccionado.", fontLabel, Brushes.Gray, 16, 45);
                return;
            }

            decimal maxMonto = Math.Max(1m, _mensual.Max(m => m.TotalFacturado));
            int areaX = 40;
            int areaY = 42;
            int areaW = Math.Max(200, pnlGrafico.Width - 80);
            int areaH = Math.Max(80, pnlGrafico.Height - 85);

            int barW = Math.Max(28, Math.Min(70, areaW / Math.Max(1, _mensual.Count) - 16));
            using var brushBarra = new SolidBrush(UiTheme.Primario);

            for (int i = 0; i < _mensual.Count; i++)
            {
                var item = _mensual[i];
                int h = (int)(item.TotalFacturado / maxMonto * areaH);
                int x = areaX + i * (barW + 18);
                int y = areaY + (areaH - h);

                g.FillRectangle(brushBarra, x, y, barW, h);
                g.DrawString(item.TotalFacturado.ToString("C0"), fontLabel, Brushes.Black, x, Math.Max(30, y - 16));
                string mesCorto = item.MesNombre.Length > 3 ? item.MesNombre[..3].ToUpper() : item.MesNombre;
                g.DrawString($"{mesCorto} ({item.CantidadReservaciones})", fontLabel, Brushes.DimGray, x, areaY + areaH + 6);
            }
        }
    }
}
