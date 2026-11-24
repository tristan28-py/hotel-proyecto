using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;

namespace Hotel.WindowsForms.Views
{
    public class FrmPrincipal : Form
    {
        private readonly HotelAppContext _app;
        private readonly ReportesMvcController _reportesCtrl;

        private Panel _pnlSidebar = null!;
        private Panel _pnlContenido = null!;
        private Panel _pnlDashboardHome = null!;
        private Label _lblEstadoRealtime = null!;
        private TextBox _txtApiUrl = null!;
        private Label _lblKpiOcupacion = null!;
        private Label _lblKpiLlegadas = null!;
        private Label _lblKpiSalidas = null!;
        private Label _lblKpiIngresos = null!;
        private Label _lblAlertaLimpieza = null!;
        private Form? _formularioActivo;
        private bool _sidebarExpandido = true;

        public FrmPrincipal(HotelAppContext app)
        {
            _app = app;
            _reportesCtrl = new ReportesMvcController(app.Api);
            InicializarComponentes();

            _app.Realtime.EstadoConexionCambiado += OnEstadoRealtime;
            _app.Realtime.DashboardActualizado += OnDashboardRealtime;
            FormClosing += async (_, _) => await _app.Realtime.DisposeAsync();
            Shown += async (_, _) => await ConectarYRefrescarAsync();
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

        private void InicializarComponentes()
        {
            Text = "Hotel Management System - Recepción y Restaurante en Tiempo Real";
            Size = new Size(1340, 820);
            MinimumSize = new Size(1100, 680);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = UiTheme.FondoPrincipal;

            // Barra superior
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = Color.White,
                Padding = new Padding(12, 8, 12, 8)
            };

            var btnToggleMenu = new Button { Text = "☰", Width = 42, Height = 34, Dock = DockStyle.Left };
            UiTheme.EstilizarBoton(btnToggleMenu, UiTheme.SidebarFondo);
            btnToggleMenu.Click += (_, _) =>
            {
                _sidebarExpandido = !_sidebarExpandido;
                _pnlSidebar.Width = _sidebarExpandido ? 235 : 58;
            };

            var lblTitulo = new Label
            {
                Text = "  HOTEL SUITE CLOUD • Sistema de Recepción en Tiempo Real",
                Dock = DockStyle.Left,
                AutoSize = false,
                Width = 480,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI Semibold", 11.5f, FontStyle.Bold),
                ForeColor = UiTheme.TextoOscuro
            };

            var flpDerecha = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 540, FlowDirection = FlowDirection.RightToLeft };
            _lblEstadoRealtime = new Label
            {
                Text = "● Conectando...",
                AutoSize = true,
                Padding = new Padding(10, 7, 10, 7),
                BackColor = Color.FromArgb(254, 243, 199),
                ForeColor = Color.FromArgb(146, 64, 14),
                Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold)
            };
            var btnConectar = new Button { Text = "Reconectar", Width = 95, Height = 30 };
            UiTheme.EstilizarBoton(btnConectar, UiTheme.Primario);
            btnConectar.Click += async (_, _) =>
            {
                _app.Api.ActualizarBaseUrl(_txtApiUrl.Text.Trim());
                await ConectarYRefrescarAsync();
            };
            _txtApiUrl = new TextBox { Width = 260, Text = _app.Api.BaseUrl };

            flpDerecha.Controls.AddRange([_lblEstadoRealtime, btnConectar, _txtApiUrl]);
            pnlTop.Controls.Add(flpDerecha);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Controls.Add(btnToggleMenu);

            // Menú Lateral
            _pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 235,
                BackColor = UiTheme.SidebarFondo,
                Padding = new Padding(8, 14, 8, 10)
            };

            AgregarBotonMenu("Dashboard (Inicio)", (_, _) => MostrarInicio());
            AgregarBotonMenu("Mapa de Habitaciones", (_, _) => AbrirFormulario(new FrmHabitaciones(_app)));
            AgregarBotonMenu("Tipos de Habitación", (_, _) => AbrirFormulario(new FrmTipoHabitacion(_app)));
            AgregarBotonMenu("Nueva Reservación", (_, _) => AbrirFormulario(new FrmNuevaReservacion(_app)));
            AgregarBotonMenu("Check-in / Out y Pagos", (_, _) => AbrirFormulario(new FrmCheckInOut(_app)));
            AgregarBotonMenu("Clientes y Huéspedes", (_, _) => AbrirFormulario(new FrmClientes(_app)));
            AgregarBotonMenu("Restaurante y Pedidos", (_, _) => AbrirFormulario(new FrmRestauranteHuespedes(_app)));
            AgregarBotonMenu("Catálogo de Platillos", (_, _) => AbrirFormulario(new FrmPlatillos(_app)));
            AgregarBotonMenu("Reportes y Exportación", (_, _) => AbrirFormulario(new FrmReportesOcupacion(_app)));

            // Área central de contenido + Dashboard Home
            _pnlContenido = new Panel { Dock = DockStyle.Fill, BackColor = UiTheme.FondoPrincipal };
            _pnlDashboardHome = ConstruirDashboardHome();
            _pnlContenido.Controls.Add(_pnlDashboardHome);

            Controls.Add(_pnlContenido);
            Controls.Add(_pnlSidebar);
            Controls.Add(pnlTop);
        }

        private void AgregarBotonMenu(string texto, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = "  " + texto,
                Dock = DockStyle.Top,
                Height = 44,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                BackColor = UiTheme.SidebarFondo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = UiTheme.SidebarHover;
            btn.Click += onClick;
            _pnlSidebar.Controls.Add(btn);
            _pnlSidebar.Controls.SetChildIndex(btn, 0);
        }

        private Panel ConstruirDashboardHome()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20), AutoScroll = true };

            var lblBienvenida = new Label
            {
                Text = "Panel de Control Operativo (Dashboard)",
                Font = new Font("Segoe UI", 17, FontStyle.Bold),
                ForeColor = UiTheme.TextoOscuro,
                Dock = DockStyle.Top,
                Height = 42
            };

            _lblAlertaLimpieza = new Label
            {
                Text = "Verificando alertas operativas...",
                Dock = DockStyle.Top,
                Height = 42,
                BackColor = Color.FromArgb(254, 249, 195),
                ForeColor = Color.FromArgb(133, 77, 14),
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 14, 0)
            };

            var flpKpis = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 160,
                Padding = new Padding(0, 16, 0, 10)
            };

            _lblKpiOcupacion = CrearTarjetaKpi(flpKpis, "OCUPACIÓN DEL DÍA", "0%", Color.FromArgb(37, 99, 235));
            _lblKpiLlegadas = CrearTarjetaKpi(flpKpis, "LLEGADAS PENDIENTES HOY", "0", Color.FromArgb(22, 163, 74));
            _lblKpiSalidas = CrearTarjetaKpi(flpKpis, "SALIDAS PROGRAMADAS HOY", "0", Color.FromArgb(234, 88, 12));
            _lblKpiIngresos = CrearTarjetaKpi(flpKpis, "INGRESOS DEL MES", "$0.00", Color.FromArgb(124, 58, 237));

            var flpAccesos = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(0, 10, 0, 0) };
            var btnIrMapa = new Button { Text = "Ver Mapa de Habitaciones", Width = 200, Height = 42 };
            var btnIrReserva = new Button { Text = "+ Nueva Reservación", Width = 185, Height = 42 };
            var btnIrCheckIn = new Button { Text = "Check-in / Check-out", Width = 185, Height = 42 };
            var btnIrRest = new Button { Text = "Restaurante / Room Service", Width = 210, Height = 42 };
            UiTheme.EstilizarBoton(btnIrMapa, UiTheme.SidebarFondo);
            UiTheme.EstilizarBoton(btnIrReserva, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnIrCheckIn, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnIrRest, Color.FromArgb(217, 119, 6));

            btnIrMapa.Click += (_, _) => AbrirFormulario(new FrmHabitaciones(_app));
            btnIrReserva.Click += (_, _) => AbrirFormulario(new FrmNuevaReservacion(_app));
            btnIrCheckIn.Click += (_, _) => AbrirFormulario(new FrmCheckInOut(_app));
            btnIrRest.Click += (_, _) => AbrirFormulario(new FrmRestauranteHuespedes(_app));
            flpAccesos.Controls.AddRange([btnIrMapa, btnIrReserva, btnIrCheckIn, btnIrRest]);

            pnl.Controls.Add(flpAccesos);
            pnl.Controls.Add(flpKpis);
            pnl.Controls.Add(_lblAlertaLimpieza);
            pnl.Controls.Add(lblBienvenida);
            return pnl;
        }

        private static Label CrearTarjetaKpi(FlowLayoutPanel contenedor, string titulo, string valorInicial, Color acento)
        {
            var card = new Panel
            {
                Width = 240,
                Height = 125,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 16, 12),
                Padding = new Padding(14)
            };
            var barra = new Panel { Dock = DockStyle.Left, Width = 6, BackColor = acento };
            var lblTit = new Label
            {
                Text = titulo,
                Dock = DockStyle.Top,
                Height = 28,
                ForeColor = UiTheme.TextoSuave,
                Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold),
                Padding = new Padding(8, 2, 0, 0)
            };
            var lblVal = new Label
            {
                Text = valorInicial,
                Dock = DockStyle.Fill,
                ForeColor = UiTheme.TextoOscuro,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                Padding = new Padding(8, 4, 0, 0)
            };
            card.Controls.Add(lblVal);
            card.Controls.Add(lblTit);
            card.Controls.Add(barra);
            contenedor.Controls.Add(card);
            return lblVal;
        }

        private void MostrarInicio()
        {
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
                _formularioActivo = null;
            }
            _pnlDashboardHome.Visible = true;
            _ = CargarDashboardAsync();
        }

        private void AbrirFormulario(Form hijo)
        {
            _pnlDashboardHome.Visible = false;
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
            }

            _formularioActivo = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            _pnlContenido.Controls.Add(hijo);
            hijo.Show();
        }

        private async Task ConectarYRefrescarAsync()
        {
            bool saludOk = await _app.Api.VerificarSaludAsync();
            if (saludOk)
            {
                await _app.Realtime.ConectarAsync(_app.Api.BaseUrl);
                await CargarDashboardAsync();
            }
            else
            {
                ActualizarBadgeConexion(false);
                _lblAlertaLimpieza.Text = $"⚠ Sin conexión con la API en {_app.Api.BaseUrl}. Verifique que Hotel.Api esté en ejecución o ingrese la URL de Azure.";
            }
        }

        private void ActualizarBadgeConexion(bool conectado)
        {
            if (conectado)
            {
                _lblEstadoRealtime.Text = "● En Vivo (SignalR)";
                _lblEstadoRealtime.BackColor = Color.FromArgb(220, 252, 231);
                _lblEstadoRealtime.ForeColor = Color.FromArgb(22, 101, 52);
            }
            else
            {
                _lblEstadoRealtime.Text = "● Desconectado";
                _lblEstadoRealtime.BackColor = Color.FromArgb(254, 226, 226);
                _lblEstadoRealtime.ForeColor = Color.FromArgb(153, 27, 27);
            }
        }

        private async Task CargarDashboardAsync()
        {
            var res = await _reportesCtrl.ObtenerDashboardAsync();
            if (!res.Success || res.Data == null) return;

            var k = res.Data;
            _lblKpiOcupacion.Text = $"{k.PorcentajeOcupacion}% ({k.HabitacionesOcupadas}/{k.TotalHabitacionesActivas})";
            _lblKpiLlegadas.Text = k.LlegadasPendientesHoy.ToString();
            _lblKpiSalidas.Text = k.SalidasProgramadasHoy.ToString();
            _lblKpiIngresos.Text = k.IngresosDelMes.ToString("C2");

            _lblAlertaLimpieza.Text = k.HabitacionesEnLimpieza > 0
                ? $"⚠ ALERTA OPERATIVA: Hay {k.HabitacionesEnLimpieza} habitación(es) 'EnLimpieza' pendientes de liberar y {k.PedidosActivosCocina} comanda(s) activas en cocina."
                : $"✓ Todo en orden: 0 habitaciones pendientes de limpieza | Disponibles: {k.HabitacionesDisponibles} | Comandas activas en cocina: {k.PedidosActivosCocina}.";
        }
    }
}
