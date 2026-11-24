using Hotel.WindowsForms.Controllers;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmPrincipal : Form
    {
        private readonly HotelAppContext? _app;
        private readonly ReportesMvcController? _reportesCtrl;
        private readonly ReservacionesMvcController? _resCtrl;
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
            _resCtrl = new ReservacionesMvcController(app.Api);

            ConfigurarPorRol();

            _app.Realtime.EstadoConexionCambiado += OnEstadoRealtime;
            _app.Realtime.DashboardActualizado += OnDashboardRealtime;
        }

        private string RolActual => _app?.SesionActual?.Rol ?? "Administrador";

        private void ConfigurarPorRol()
        {
            var sesion = _app?.SesionActual;
            if (sesion == null) return;

            lblUsuarioRol.Text = $"{sesion.NombreCompleto} ({sesion.Rol})";

            bool esAdmin = sesion.Rol == "Administrador";
            bool esRecep = sesion.Rol == "Recepcionista";
            bool esCliente = sesion.Rol == "Cliente";

            // Menu lateral separado segun el perfil
            btnExplorarSuites.Visible = esCliente;
            btnMisReservas.Visible = esCliente;

            btnHabitaciones.Visible = esAdmin || esRecep;
            btnTiposHabitacion.Visible = esAdmin;
            btnNuevaReserva.Visible = esAdmin || esRecep;
            btnCheckInOut.Visible = esAdmin || esRecep;
            btnClientes.Visible = esAdmin || esRecep;
            btnRestaurante.Visible = true;
            btnPlatillos.Visible = esAdmin;
            btnReportes.Visible = esAdmin;
            btnUsuarios.Visible = esAdmin;

            if (esCliente)
            {
                lblHeroTitulo.Text = $"Bienvenido, {sesion.NombreCompleto}";
                lblHeroSubtitulo.Text = "Portal del Huesped: explora suites disponibles, consulta tu folio y pide Room Service";

                lblTitOcupacion.Text = "MIS RESERVACIONES";
                lblTitLlegadas.Text = "ESTADIAS ACTIVAS";
                lblTitSalidas.Text = "CONSUMOS RESTAURANTE";
                lblTitIngresos.Text = "SALDO PENDIENTE";

                btnAccesoMapa.Text = "Explorar Suites";
                btnAccesoReserva.Text = "Mis Reservaciones";
                btnAccesoCheckIn.Visible = false;
                btnAccesoRestaurante.Text = "Pedir Room Service";
            }
            else if (esRecep)
            {
                lblHeroTitulo.Text = $"Recepcion - {sesion.NombreCompleto}";
                lblHeroSubtitulo.Text = "Operacion diaria de recepcion, check-in/out y control de habitaciones en vivo";
                lblTitIngresos.Text = "COMANDAS EN COCINA";
            }
            else
            {
                lblHeroTitulo.Text = "Panel Ejecutivo - Hotel Costa Dorada";
                lblHeroSubtitulo.Text = "Administracion general, tarifacion, reportes financieros y monitoreo en vivo";
            }
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
            pnlMenuLateral.Width = _menuExpandido ? 236 : 56;
        }

        private void btnCerrarSesion_Click(object? sender, EventArgs e)
        {
            Close();
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

        private void btnExplorarSuites_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmPortalHuesped(_app, 0));
        }

        private void btnMisReservas_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmPortalHuesped(_app, 1));
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

        private void btnUsuarios_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmUsuarios(_app));
        }

        private void btnAccesoMapa_Click(object? sender, EventArgs e)
        {
            if (_app == null) return;
            if (RolActual == "Cliente") AbrirFormulario(new FrmPortalHuesped(_app, 0));
            else AbrirFormulario(new FrmHabitaciones(_app));
        }

        private void btnAccesoReserva_Click(object? sender, EventArgs e)
        {
            if (_app == null) return;
            if (RolActual == "Cliente") AbrirFormulario(new FrmPortalHuesped(_app, 1));
            else AbrirFormulario(new FrmNuevaReservacion(_app));
        }

        private void btnAccesoCheckIn_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmCheckInOut(_app));
        }

        private void btnAccesoRestaurante_Click(object? sender, EventArgs e)
        {
            if (_app != null) AbrirFormulario(new FrmRestauranteHuespedes(_app));
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
                lblAlertaLimpieza.Text = $"Sin conexion con la API en {_app.Api.BaseUrl}.";
            }
        }

        private void ActualizarBadgeConexion(bool conectado)
        {
            if (conectado)
            {
                lblEstadoRealtime.Text = "En Vivo (SignalR)";
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
            if (RolActual == "Cliente")
            {
                if (_resCtrl == null || _app?.SesionActual?.ClienteId is not int clienteId) return;
                var resMis = await _resCtrl.BuscarAsync(clienteId: clienteId);
                if (!resMis.Success || resMis.Data == null) return;

                var lista = resMis.Data;
                var activas = lista.Count(r => r.Estado == "EnCurso");
                var restTotal = lista.Where(r => r.Estado != "Cancelada").Sum(r => r.TotalConsumosRestaurante);
                var saldoTotal = lista.Where(r => r.Estado != "Cancelada").Sum(r => r.SaldoPendiente);

                lblKpiOcupacion.Text = lista.Count.ToString();
                lblKpiLlegadas.Text = activas.ToString();
                lblKpiSalidas.Text = restTotal.ToString("C2");
                lblKpiIngresos.Text = saldoTotal.ToString("C2");

                var enCurso = lista.FirstOrDefault(r => r.Estado == "EnCurso");
                lblAlertaLimpieza.Text = enCurso != null
                    ? $"Estadia activa en Habitacion {enCurso.HabitacionNumero} ({enCurso.Codigo}). Ya puedes cargar pedidos de Room Service a tu folio."
                    : "No tienes una estadia activa en este momento. Usa 'Explorar Suites y Reservar' para planear tu proximo viaje.";
                return;
            }

            if (_reportesCtrl == null) return;
            var res = await _reportesCtrl.ObtenerDashboardAsync();
            if (!res.Success || res.Data == null) return;

            var k = res.Data;
            lblKpiOcupacion.Text = $"{k.PorcentajeOcupacion}% ({k.HabitacionesOcupadas}/{k.TotalHabitacionesActivas})";
            lblKpiLlegadas.Text = k.LlegadasPendientesHoy.ToString();
            lblKpiSalidas.Text = k.SalidasProgramadasHoy.ToString();
            lblKpiIngresos.Text = RolActual == "Administrador"
                ? k.IngresosDelMes.ToString("C2")
                : k.PedidosActivosCocina.ToString();

            lblAlertaLimpieza.Text = k.HabitacionesEnLimpieza > 0
                ? $"Alerta operativa: {k.HabitacionesEnLimpieza} habitacion(es) en limpieza por liberar | {k.PedidosActivosCocina} comanda(s) en cocina."
                : $"Operacion estable: 0 habitaciones en limpieza | Disponibles: {k.HabitacionesDisponibles} | Comandas en cocina: {k.PedidosActivosCocina}.";
        }
    }
}
