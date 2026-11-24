using Hotel.WindowsForms.Controllers;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmPrincipal : Form
    {
        private readonly HotelAppContext? _app;
        private readonly ReportesMvcController? _reportesCtrl;
        private Form? _formularioActivo;
        private bool _menuExpandido = true;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public FrmPrincipal(HotelAppContext app) : this()
        {
            _app = app;
            _reportesCtrl = new ReportesMvcController(app.Api);
            txtApiUrl.Text = app.Api.BaseUrl;

            _app.Realtime.EstadoConexionCambiado += OnEstadoRealtime;
            _app.Realtime.DashboardActualizado += OnDashboardRealtime;
        }

        private async void FrmPrincipal_Load(object? sender, EventArgs e)
        {
            if (_app == null) return;
            await ConectarYRefrescarAsync();
        }

        private async void FrmPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_app != null)
                await _app.Realtime.DisposeAsync();
        }

        private void OnEstadoRealtime(bool conectado)
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(() => ActualizarBadgeConexion(conectado));
        }

        private void OnDashboardRealtime()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await CargarDashboardAsync());
        }

        private void btnMenuToggle_Click(object? sender, EventArgs e)
        {
            _menuExpandido = !_menuExpandido;
            pnlMenuLateral.Width = _menuExpandido ? 230 : 54;
        }

        private async void btnReconectar_Click(object? sender, EventArgs e)
        {
            if (_app == null) return;
            _app.Api.ActualizarBaseUrl(txtApiUrl.Text.Trim());
            await ConectarYRefrescarAsync();
        }

        private void btnInicio_Click(object? sender, EventArgs e)
        {
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
                _formularioActivo = null;
            }
            pnlDashboard.Visible = true;
            _ = CargarDashboardAsync();
        }

        private void btnHabitaciones_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmHabitaciones(_app));
        }

        private void btnTiposHabitacion_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmTipoHabitacion(_app));
        }

        private void btnNuevaReserva_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmNuevaReservacion(_app));
        }

        private void btnCheckInOut_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmCheckInOut(_app));
        }

        private void btnClientes_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmClientes(_app));
        }

        private void btnRestaurante_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmRestauranteHuespedes(_app));
        }

        private void btnPlatillos_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmPlatillos(_app));
        }

        private void btnReportes_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmReportesOcupacion(_app));
        }

        private void AbrirFormulario(Form hijo)
        {
            pnlDashboard.Visible = false;
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
            }

            _formularioActivo = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(hijo);
            hijo.Show();
        }

        private async Task ConectarYRefrescarAsync()
        {
            if (_app == null) return;
            bool saludOk = await _app.Api.VerificarSaludAsync();
            if (saludOk)
            {
                await _app.Realtime.ConectarAsync(_app.Api.BaseUrl);
                await CargarDashboardAsync();
            }
            else
            {
                ActualizarBadgeConexion(false);
                lblAlertaLimpieza.Text = $"Sin conexion con la API en {_app.Api.BaseUrl}. Verifique que Hotel.Api este corriendo o cambie la URL.";
            }
        }

        private void ActualizarBadgeConexion(bool conectado)
        {
            if (conectado)
            {
                lblEstadoRealtime.Text = "En Vivo (Conectado)";
                lblEstadoRealtime.BackColor = Color.FromArgb(220, 252, 231);
                lblEstadoRealtime.ForeColor = Color.FromArgb(22, 101, 52);
            }
            else
            {
                lblEstadoRealtime.Text = "Desconectado";
                lblEstadoRealtime.BackColor = Color.FromArgb(254, 226, 226);
                lblEstadoRealtime.ForeColor = Color.FromArgb(153, 27, 27);
            }
        }

        private async Task CargarDashboardAsync()
        {
            if (_reportesCtrl == null) return;
            var res = await _reportesCtrl.ObtenerDashboardAsync();
            if (!res.Success || res.Data == null) return;

            var k = res.Data;
            lblKpiOcupacion.Text = $"{k.PorcentajeOcupacion}% ({k.HabitacionesOcupadas}/{k.TotalHabitacionesActivas})";
            lblKpiLlegadas.Text = k.LlegadasPendientesHoy.ToString();
            lblKpiSalidas.Text = k.SalidasProgramadasHoy.ToString();
            lblKpiIngresos.Text = k.IngresosDelMes.ToString("C2");

            lblAlertaLimpieza.Text = k.HabitacionesEnLimpieza > 0
                ? $"Alerta: Hay {k.HabitacionesEnLimpieza} habitacion(es) en limpieza pendientes de liberar y {k.PedidosActivosCocina} comanda(s) activas en cocina."
                : $"Todo al dia: 0 habitaciones en limpieza | Disponibles: {k.HabitacionesDisponibles} | Pedidos en cocina: {k.PedidosActivosCocina}.";
        }
    }
}
