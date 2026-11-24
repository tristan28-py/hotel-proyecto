using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmReportesOcupacion : Form
    {
        private readonly ReportesMvcController _ctrl;
        private DateTimePicker _dtpInicio = null!;
        private DateTimePicker _dtpFin = null!;
        private NumericUpDown _numAnio = null!;
        private DataGridView _dgvMensual = null!;
        private DataGridView _dgvIngresos = null!;
        private DataGridView _dgvPlatillosTop = null!;
        private Panel _pnlGrafico = null!;
        private Label _lblResumenIngresos = null!;

        private List<ResumenMensualOcupacionModel> _mensual = new();
        private ReporteIngresosModel? _ingresos;
        private List<PlatilloMasSolicitadoModel> _platillosTop = new();

        public FrmReportesOcupacion(HotelAppContext app)
        {
            _ctrl = new ReportesMvcController(app.Api);
            InicializarComponentes();
            Shown += async (_, _) => await CargarReportesAsync();
        }

        private void InicializarComponentes()
        {
            Text = "Reportes Gerenciales, Gráficos y Exportación";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var pnlFiltros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White, Padding = new Padding(12, 10, 12, 6) };
            _dtpInicio = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), Width = 110 };
            _dtpFin = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today, Width = 110 };
            _numAnio = new NumericUpDown { Minimum = 2020, Maximum = 2035, Value = DateTime.Today.Year, Width = 70 };

            var btnGenerar = new Button { Text = "Generar Reportes", Width = 140, Height = 30 };
            var btnExcel = new Button { Text = "Exportar Excel", Width = 125, Height = 30 };
            var btnPdf = new Button { Text = "Exportar PDF", Width = 120, Height = 30 };
            UiTheme.EstilizarBoton(btnGenerar, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnExcel, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnPdf, Color.FromArgb(220, 38, 38));

            btnGenerar.Click += async (_, _) => await CargarReportesAsync();
            btnExcel.Click += (_, _) => ExportarExcel();
            btnPdf.Click += (_, _) => ExportarPdf();

            pnlFiltros.Controls.AddRange([
                new Label { Text = "Desde:", AutoSize = true, Padding = new Padding(0, 5, 0, 0) }, _dtpInicio,
                new Label { Text = "Hasta:", AutoSize = true, Padding = new Padding(6, 5, 0, 0) }, _dtpFin,
                new Label { Text = "Año:", AutoSize = true, Padding = new Padding(6, 5, 0, 0) }, _numAnio,
                btnGenerar, btnExcel, btnPdf
            ]);

            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 240 };

            _pnlGrafico = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12) };
            _pnlGrafico.Paint += PnlGrafico_Paint;
            split.Panel1.Controls.Add(_pnlGrafico);

            var tabs = new TabControl { Dock = DockStyle.Fill };
            var tabMensual = new TabPage("Ocupación por Mes (LINQ GroupBy)");
            _dgvMensual = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvMensual);
            tabMensual.Controls.Add(_dgvMensual);

            var tabIngresos = new TabPage("Ingresos y Pagos Recibidos");
            _lblResumenIngresos = new Label { Dock = DockStyle.Top, Height = 32, BackColor = Color.White, Padding = new Padding(8, 6, 8, 0), Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold) };
            _dgvIngresos = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvIngresos);
            tabIngresos.Controls.Add(_dgvIngresos);
            tabIngresos.Controls.Add(_lblResumenIngresos);

            var tabPlatillos = new TabPage("Platillos Más Solicitados (Top 10)");
            _dgvPlatillosTop = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvPlatillosTop);
            tabPlatillos.Controls.Add(_dgvPlatillosTop);

            tabs.TabPages.AddRange([tabMensual, tabIngresos, tabPlatillos]);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
            Controls.Add(pnlFiltros);
        }

        private async Task CargarReportesAsync()
        {
            var inicio = DateOnly.FromDateTime(_dtpInicio.Value);
            var fin = DateOnly.FromDateTime(_dtpFin.Value);

            var resMensual = await _ctrl.ObtenerOcupacionMensualAsync((int)_numAnio.Value);
            if (resMensual.Success && resMensual.Data != null)
            {
                _mensual = resMensual.Data;
                _dgvMensual.DataSource = _mensual;
            }

            var resIng = await _ctrl.ObtenerIngresosAsync(inicio, fin);
            if (resIng.Success && resIng.Data != null)
            {
                _ingresos = resIng.Data;
                _lblResumenIngresos.Text =
                    $"Pagos recibidos: {_ingresos.TotalPagosRecibidos:C2} | Hospedaje proyectado: {_ingresos.TotalHospedajeProyectado:C2} | Restaurante: {_ingresos.TotalConsumosRestaurante:C2}";
                _dgvIngresos.DataSource = _ingresos.DetallePagos;
            }

            var resTop = await _ctrl.ObtenerPlatillosTopAsync(10);
            if (resTop.Success && resTop.Data != null)
            {
                _platillosTop = resTop.Data;
                _dgvPlatillosTop.DataSource = _platillosTop;
            }

            _pnlGrafico.Invalidate();
        }

        private void PnlGrafico_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            using var fontTitulo = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            using var fontLabel = new Font("Segoe UI", 8.5f);
            g.DrawString($"Gráfico Estadístico: Facturación Mensual {_numAnio.Value}", fontTitulo, Brushes.DarkSlateGray, 16, 10);

            if (_mensual.Count == 0)
            {
                g.DrawString("Sin datos registrados para el año seleccionado.", fontLabel, Brushes.Gray, 16, 45);
                return;
            }

            decimal maxMonto = Math.Max(1m, _mensual.Max(m => m.TotalFacturado));
            int areaX = 40;
            int areaY = 42;
            int areaW = Math.Max(200, _pnlGrafico.Width - 80);
            int areaH = Math.Max(80, _pnlGrafico.Height - 85);

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

        private void ExportarExcel()
        {
            using var sfd = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = $"ReporteHotel_{DateTime.Now:yyyyMMdd}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportadorReportes.ExportarExcel(sfd.FileName, _mensual, _ingresos, _platillosTop);
                MessageBox.Show("Reporte exportado a Excel correctamente.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportarPdf()
        {
            using var sfd = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = $"ReporteHotel_{DateTime.Now:yyyyMMdd}.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportadorReportes.ExportarPdf(sfd.FileName, _mensual, _ingresos, _platillosTop);
                MessageBox.Show("Reporte exportado a PDF correctamente.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
