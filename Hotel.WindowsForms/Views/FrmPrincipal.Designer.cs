namespace Hotel.WindowsForms.Views
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            pnlSuperior = new Panel();
            btnCerrarSesion = new Button();
            lblUsuarioRol = new Label();
            lblEstadoRealtime = new Label();
            lblTituloApp = new Label();
            btnMenuToggle = new Button();
            pnlMenuLateral = new Panel();
            btnUsuarios = new Button();
            btnReportes = new Button();
            btnPlatillos = new Button();
            btnRestaurante = new Button();
            btnClientes = new Button();
            btnCheckInOut = new Button();
            btnNuevaReserva = new Button();
            btnTiposHabitacion = new Button();
            btnHabitaciones = new Button();
            btnMisReservas = new Button();
            btnExplorarSuites = new Button();
            btnInicio = new Button();
            pnlContenedor = new Panel();
            pnlDashboard = new Panel();
            pnlHero = new Panel();
            lblHeroSubtitulo = new Label();
            lblHeroTitulo = new Label();
            pnlLineaHero = new Panel();
            btnAccesoRestaurante = new Button();
            btnAccesoCheckIn = new Button();
            btnAccesoReserva = new Button();
            btnAccesoMapa = new Button();
            pnlCardIngresos = new Panel();
            pnlBordeIngresos = new Panel();
            lblKpiIngresos = new Label();
            lblTitIngresos = new Label();
            pnlCardSalidas = new Panel();
            pnlBordeSalidas = new Panel();
            lblKpiSalidas = new Label();
            lblTitSalidas = new Label();
            pnlCardLlegadas = new Panel();
            pnlBordeLlegadas = new Panel();
            lblKpiLlegadas = new Label();
            lblTitLlegadas = new Label();
            pnlCardOcupacion = new Panel();
            pnlBordeOcupacion = new Panel();
            lblKpiOcupacion = new Label();
            lblTitOcupacion = new Label();
            pnlAlertaLimpieza = new Panel();
            lblAlertaLimpieza = new Label();
            pnlSuperior.SuspendLayout();
            pnlMenuLateral.SuspendLayout();
            pnlContenedor.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlHero.SuspendLayout();
            pnlCardIngresos.SuspendLayout();
            pnlCardSalidas.SuspendLayout();
            pnlCardLlegadas.SuspendLayout();
            pnlCardOcupacion.SuspendLayout();
            pnlAlertaLimpieza.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(btnCerrarSesion);
            pnlSuperior.Controls.Add(lblUsuarioRol);
            pnlSuperior.Controls.Add(lblEstadoRealtime);
            pnlSuperior.Controls.Add(lblTituloApp);
            pnlSuperior.Controls.Add(btnMenuToggle);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1264, 58);
            pnlSuperior.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(185, 28, 28);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1136, 14);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(114, 30);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblUsuarioRol
            // 
            lblUsuarioRol.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuarioRol.BackColor = Color.FromArgb(247, 245, 240);
            lblUsuarioRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioRol.ForeColor = Color.FromArgb(15, 30, 54);
            lblUsuarioRol.Location = new Point(844, 14);
            lblUsuarioRol.Name = "lblUsuarioRol";
            lblUsuarioRol.Size = new Size(282, 30);
            lblUsuarioRol.TabIndex = 3;
            lblUsuarioRol.Text = "Usuario | Rol";
            lblUsuarioRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstadoRealtime
            // 
            lblEstadoRealtime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEstadoRealtime.BackColor = Color.FromArgb(254, 243, 199);
            lblEstadoRealtime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoRealtime.ForeColor = Color.FromArgb(146, 64, 14);
            lblEstadoRealtime.Location = new Point(666, 14);
            lblEstadoRealtime.Name = "lblEstadoRealtime";
            lblEstadoRealtime.Size = new Size(168, 30);
            lblEstadoRealtime.TabIndex = 2;
            lblEstadoRealtime.Text = "Conectando...";
            lblEstadoRealtime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloApp
            // 
            lblTituloApp.AutoSize = true;
            lblTituloApp.Font = new Font("Georgia", 13F, FontStyle.Bold);
            lblTituloApp.ForeColor = Color.FromArgb(15, 30, 54);
            lblTituloApp.Location = new Point(68, 17);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(340, 21);
            lblTituloApp.TabIndex = 1;
            lblTituloApp.Text = "HOTEL COSTA DORADA  |  PMS";
            // 
            // btnMenuToggle
            // 
            btnMenuToggle.BackColor = Color.FromArgb(15, 30, 54);
            btnMenuToggle.FlatAppearance.BorderSize = 0;
            btnMenuToggle.FlatStyle = FlatStyle.Flat;
            btnMenuToggle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuToggle.ForeColor = Color.FromArgb(200, 157, 84);
            btnMenuToggle.Location = new Point(12, 12);
            btnMenuToggle.Name = "btnMenuToggle";
            btnMenuToggle.Size = new Size(46, 34);
            btnMenuToggle.TabIndex = 0;
            btnMenuToggle.Text = "Menu";
            btnMenuToggle.UseVisualStyleBackColor = false;
            btnMenuToggle.Click += btnMenuToggle_Click;
            // 
            // pnlMenuLateral
            // 
            pnlMenuLateral.BackColor = Color.FromArgb(15, 30, 54);
            pnlMenuLateral.Controls.Add(btnUsuarios);
            pnlMenuLateral.Controls.Add(btnReportes);
            pnlMenuLateral.Controls.Add(btnPlatillos);
            pnlMenuLateral.Controls.Add(btnRestaurante);
            pnlMenuLateral.Controls.Add(btnClientes);
            pnlMenuLateral.Controls.Add(btnCheckInOut);
            pnlMenuLateral.Controls.Add(btnNuevaReserva);
            pnlMenuLateral.Controls.Add(btnTiposHabitacion);
            pnlMenuLateral.Controls.Add(btnHabitaciones);
            pnlMenuLateral.Controls.Add(btnMisReservas);
            pnlMenuLateral.Controls.Add(btnExplorarSuites);
            pnlMenuLateral.Controls.Add(btnInicio);
            pnlMenuLateral.Dock = DockStyle.Left;
            pnlMenuLateral.Location = new Point(0, 58);
            pnlMenuLateral.Name = "pnlMenuLateral";
            pnlMenuLateral.Size = new Size(236, 683);
            pnlMenuLateral.TabIndex = 1;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(15, 30, 54);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.FromArgb(200, 157, 84);
            btnUsuarios.Location = new Point(0, 498);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(14, 0, 0, 0);
            btnUsuarios.Size = new Size(236, 44);
            btnUsuarios.TabIndex = 11;
            btnUsuarios.Text = "Usuarios y Roles";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(15, 30, 54);
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(0, 454);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(14, 0, 0, 0);
            btnReportes.Size = new Size(236, 44);
            btnReportes.TabIndex = 10;
            btnReportes.Text = "Reportes y Exportacion";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnPlatillos
            // 
            btnPlatillos.BackColor = Color.FromArgb(15, 30, 54);
            btnPlatillos.Dock = DockStyle.Top;
            btnPlatillos.FlatAppearance.BorderSize = 0;
            btnPlatillos.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnPlatillos.FlatStyle = FlatStyle.Flat;
            btnPlatillos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPlatillos.ForeColor = Color.White;
            btnPlatillos.Location = new Point(0, 410);
            btnPlatillos.Name = "btnPlatillos";
            btnPlatillos.Padding = new Padding(14, 0, 0, 0);
            btnPlatillos.Size = new Size(236, 44);
            btnPlatillos.TabIndex = 9;
            btnPlatillos.Text = "Catalogo de Platillos";
            btnPlatillos.TextAlign = ContentAlignment.MiddleLeft;
            btnPlatillos.UseVisualStyleBackColor = false;
            btnPlatillos.Click += btnPlatillos_Click;
            // 
            // btnRestaurante
            // 
            btnRestaurante.BackColor = Color.FromArgb(15, 30, 54);
            btnRestaurante.Dock = DockStyle.Top;
            btnRestaurante.FlatAppearance.BorderSize = 0;
            btnRestaurante.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnRestaurante.FlatStyle = FlatStyle.Flat;
            btnRestaurante.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRestaurante.ForeColor = Color.White;
            btnRestaurante.Location = new Point(0, 366);
            btnRestaurante.Name = "btnRestaurante";
            btnRestaurante.Padding = new Padding(14, 0, 0, 0);
            btnRestaurante.Size = new Size(236, 44);
            btnRestaurante.TabIndex = 8;
            btnRestaurante.Text = "Restaurante / Room Service";
            btnRestaurante.TextAlign = ContentAlignment.MiddleLeft;
            btnRestaurante.UseVisualStyleBackColor = false;
            btnRestaurante.Click += btnRestaurante_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(15, 30, 54);
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(0, 322);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(14, 0, 0, 0);
            btnClientes.Size = new Size(236, 44);
            btnClientes.TabIndex = 7;
            btnClientes.Text = "Clientes y Huespedes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnCheckInOut
            // 
            btnCheckInOut.BackColor = Color.FromArgb(15, 30, 54);
            btnCheckInOut.Dock = DockStyle.Top;
            btnCheckInOut.FlatAppearance.BorderSize = 0;
            btnCheckInOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnCheckInOut.FlatStyle = FlatStyle.Flat;
            btnCheckInOut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCheckInOut.ForeColor = Color.White;
            btnCheckInOut.Location = new Point(0, 278);
            btnCheckInOut.Name = "btnCheckInOut";
            btnCheckInOut.Padding = new Padding(14, 0, 0, 0);
            btnCheckInOut.Size = new Size(236, 44);
            btnCheckInOut.TabIndex = 6;
            btnCheckInOut.Text = "Check-in / Out y Pagos";
            btnCheckInOut.TextAlign = ContentAlignment.MiddleLeft;
            btnCheckInOut.UseVisualStyleBackColor = false;
            btnCheckInOut.Click += btnCheckInOut_Click;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.BackColor = Color.FromArgb(15, 30, 54);
            btnNuevaReserva.Dock = DockStyle.Top;
            btnNuevaReserva.FlatAppearance.BorderSize = 0;
            btnNuevaReserva.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnNuevaReserva.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNuevaReserva.ForeColor = Color.White;
            btnNuevaReserva.Location = new Point(0, 234);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Padding = new Padding(14, 0, 0, 0);
            btnNuevaReserva.Size = new Size(236, 44);
            btnNuevaReserva.TabIndex = 5;
            btnNuevaReserva.Text = "Nueva Reservacion";
            btnNuevaReserva.TextAlign = ContentAlignment.MiddleLeft;
            btnNuevaReserva.UseVisualStyleBackColor = false;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // btnTiposHabitacion
            // 
            btnTiposHabitacion.BackColor = Color.FromArgb(15, 30, 54);
            btnTiposHabitacion.Dock = DockStyle.Top;
            btnTiposHabitacion.FlatAppearance.BorderSize = 0;
            btnTiposHabitacion.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnTiposHabitacion.FlatStyle = FlatStyle.Flat;
            btnTiposHabitacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTiposHabitacion.ForeColor = Color.White;
            btnTiposHabitacion.Location = new Point(0, 190);
            btnTiposHabitacion.Name = "btnTiposHabitacion";
            btnTiposHabitacion.Padding = new Padding(14, 0, 0, 0);
            btnTiposHabitacion.Size = new Size(236, 44);
            btnTiposHabitacion.TabIndex = 4;
            btnTiposHabitacion.Text = "Tipos de Habitacion";
            btnTiposHabitacion.TextAlign = ContentAlignment.MiddleLeft;
            btnTiposHabitacion.UseVisualStyleBackColor = false;
            btnTiposHabitacion.Click += btnTiposHabitacion_Click;
            // 
            // btnHabitaciones
            // 
            btnHabitaciones.BackColor = Color.FromArgb(15, 30, 54);
            btnHabitaciones.Dock = DockStyle.Top;
            btnHabitaciones.FlatAppearance.BorderSize = 0;
            btnHabitaciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnHabitaciones.FlatStyle = FlatStyle.Flat;
            btnHabitaciones.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHabitaciones.ForeColor = Color.White;
            btnHabitaciones.Location = new Point(0, 146);
            btnHabitaciones.Name = "btnHabitaciones";
            btnHabitaciones.Padding = new Padding(14, 0, 0, 0);
            btnHabitaciones.Size = new Size(236, 44);
            btnHabitaciones.TabIndex = 3;
            btnHabitaciones.Text = "Mapa de Habitaciones";
            btnHabitaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnHabitaciones.UseVisualStyleBackColor = false;
            btnHabitaciones.Click += btnHabitaciones_Click;
            // 
            // btnMisReservas
            // 
            btnMisReservas.BackColor = Color.FromArgb(15, 30, 54);
            btnMisReservas.Dock = DockStyle.Top;
            btnMisReservas.FlatAppearance.BorderSize = 0;
            btnMisReservas.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnMisReservas.FlatStyle = FlatStyle.Flat;
            btnMisReservas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMisReservas.ForeColor = Color.White;
            btnMisReservas.Location = new Point(0, 102);
            btnMisReservas.Name = "btnMisReservas";
            btnMisReservas.Padding = new Padding(14, 0, 0, 0);
            btnMisReservas.Size = new Size(236, 44);
            btnMisReservas.TabIndex = 2;
            btnMisReservas.Text = "Mis Reservaciones y Folio";
            btnMisReservas.TextAlign = ContentAlignment.MiddleLeft;
            btnMisReservas.UseVisualStyleBackColor = false;
            btnMisReservas.Click += btnMisReservas_Click;
            // 
            // btnExplorarSuites
            // 
            btnExplorarSuites.BackColor = Color.FromArgb(15, 30, 54);
            btnExplorarSuites.Dock = DockStyle.Top;
            btnExplorarSuites.FlatAppearance.BorderSize = 0;
            btnExplorarSuites.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 49, 84);
            btnExplorarSuites.FlatStyle = FlatStyle.Flat;
            btnExplorarSuites.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExplorarSuites.ForeColor = Color.White;
            btnExplorarSuites.Location = new Point(0, 58);
            btnExplorarSuites.Name = "btnExplorarSuites";
            btnExplorarSuites.Padding = new Padding(14, 0, 0, 0);
            btnExplorarSuites.Size = new Size(236, 44);
            btnExplorarSuites.TabIndex = 1;
            btnExplorarSuites.Text = "Explorar Suites y Reservar";
            btnExplorarSuites.TextAlign = ContentAlignment.MiddleLeft;
            btnExplorarSuites.UseVisualStyleBackColor = false;
            btnExplorarSuites.Click += btnExplorarSuites_Click;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(200, 157, 84);
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.FromArgb(15, 30, 54);
            btnInicio.Location = new Point(0, 0);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(14, 0, 0, 0);
            btnInicio.Size = new Size(236, 58);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "Inicio (Panel Principal)";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(247, 245, 240);
            pnlContenedor.Controls.Add(pnlDashboard);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(236, 58);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(1028, 683);
            pnlContenedor.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(247, 245, 240);
            pnlDashboard.Controls.Add(btnAccesoRestaurante);
            pnlDashboard.Controls.Add(btnAccesoCheckIn);
            pnlDashboard.Controls.Add(btnAccesoReserva);
            pnlDashboard.Controls.Add(btnAccesoMapa);
            pnlDashboard.Controls.Add(pnlCardIngresos);
            pnlDashboard.Controls.Add(pnlCardSalidas);
            pnlDashboard.Controls.Add(pnlCardLlegadas);
            pnlDashboard.Controls.Add(pnlCardOcupacion);
            pnlDashboard.Controls.Add(pnlAlertaLimpieza);
            pnlDashboard.Controls.Add(pnlHero);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1028, 683);
            pnlDashboard.TabIndex = 0;
            // 
            // pnlHero
            // 
            pnlHero.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHero.BackColor = Color.FromArgb(15, 30, 54);
            pnlHero.Controls.Add(lblHeroSubtitulo);
            pnlHero.Controls.Add(lblHeroTitulo);
            pnlHero.Controls.Add(pnlLineaHero);
            pnlHero.Location = new Point(24, 18);
            pnlHero.Name = "pnlHero";
            pnlHero.Size = new Size(976, 122);
            pnlHero.TabIndex = 0;
            // 
            // lblHeroSubtitulo
            // 
            lblHeroSubtitulo.AutoSize = true;
            lblHeroSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblHeroSubtitulo.ForeColor = Color.FromArgb(203, 213, 225);
            lblHeroSubtitulo.Location = new Point(26, 74);
            lblHeroSubtitulo.Name = "lblHeroSubtitulo";
            lblHeroSubtitulo.Size = new Size(445, 19);
            lblHeroSubtitulo.TabIndex = 2;
            lblHeroSubtitulo.Text = "Gestion hotelera sincronizada en tiempo real con SignalR y SQL Server";
            // 
            // lblHeroTitulo
            // 
            lblHeroTitulo.AutoSize = true;
            lblHeroTitulo.Font = new Font("Georgia", 20F, FontStyle.Bold);
            lblHeroTitulo.ForeColor = Color.White;
            lblHeroTitulo.Location = new Point(24, 24);
            lblHeroTitulo.Name = "lblHeroTitulo";
            lblHeroTitulo.Size = new Size(340, 31);
            lblHeroTitulo.TabIndex = 1;
            lblHeroTitulo.Text = "Hotel Costa Dorada";
            // 
            // pnlLineaHero
            // 
            pnlLineaHero.BackColor = Color.FromArgb(200, 157, 84);
            pnlLineaHero.Dock = DockStyle.Bottom;
            pnlLineaHero.Location = new Point(0, 116);
            pnlLineaHero.Name = "pnlLineaHero";
            pnlLineaHero.Size = new Size(976, 6);
            pnlLineaHero.TabIndex = 0;
            // 
            // btnAccesoRestaurante
            // 
            btnAccesoRestaurante.BackColor = Color.FromArgb(200, 157, 84);
            btnAccesoRestaurante.FlatAppearance.BorderSize = 0;
            btnAccesoRestaurante.FlatStyle = FlatStyle.Flat;
            btnAccesoRestaurante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoRestaurante.ForeColor = Color.FromArgb(15, 30, 54);
            btnAccesoRestaurante.Location = new Point(664, 368);
            btnAccesoRestaurante.Name = "btnAccesoRestaurante";
            btnAccesoRestaurante.Size = new Size(216, 48);
            btnAccesoRestaurante.TabIndex = 9;
            btnAccesoRestaurante.Text = "Restaurante / Room Service";
            btnAccesoRestaurante.UseVisualStyleBackColor = false;
            btnAccesoRestaurante.Click += btnAccesoRestaurante_Click;
            // 
            // btnAccesoCheckIn
            // 
            btnAccesoCheckIn.BackColor = Color.FromArgb(30, 64, 175);
            btnAccesoCheckIn.FlatAppearance.BorderSize = 0;
            btnAccesoCheckIn.FlatStyle = FlatStyle.Flat;
            btnAccesoCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoCheckIn.ForeColor = Color.White;
            btnAccesoCheckIn.Location = new Point(450, 368);
            btnAccesoCheckIn.Name = "btnAccesoCheckIn";
            btnAccesoCheckIn.Size = new Size(200, 48);
            btnAccesoCheckIn.TabIndex = 8;
            btnAccesoCheckIn.Text = "Check-in / Check-out";
            btnAccesoCheckIn.UseVisualStyleBackColor = false;
            btnAccesoCheckIn.Click += btnAccesoCheckIn_Click;
            // 
            // btnAccesoReserva
            // 
            btnAccesoReserva.BackColor = Color.FromArgb(21, 128, 61);
            btnAccesoReserva.FlatAppearance.BorderSize = 0;
            btnAccesoReserva.FlatStyle = FlatStyle.Flat;
            btnAccesoReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoReserva.ForeColor = Color.White;
            btnAccesoReserva.Location = new Point(238, 368);
            btnAccesoReserva.Name = "btnAccesoReserva";
            btnAccesoReserva.Size = new Size(198, 48);
            btnAccesoReserva.TabIndex = 7;
            btnAccesoReserva.Text = "+ Nueva Reservacion";
            btnAccesoReserva.UseVisualStyleBackColor = false;
            btnAccesoReserva.Click += btnAccesoReserva_Click;
            // 
            // btnAccesoMapa
            // 
            btnAccesoMapa.BackColor = Color.FromArgb(15, 30, 54);
            btnAccesoMapa.FlatAppearance.BorderSize = 0;
            btnAccesoMapa.FlatStyle = FlatStyle.Flat;
            btnAccesoMapa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoMapa.ForeColor = Color.White;
            btnAccesoMapa.Location = new Point(24, 368);
            btnAccesoMapa.Name = "btnAccesoMapa";
            btnAccesoMapa.Size = new Size(200, 48);
            btnAccesoMapa.TabIndex = 6;
            btnAccesoMapa.Text = "Mapa de Habitaciones";
            btnAccesoMapa.UseVisualStyleBackColor = false;
            btnAccesoMapa.Click += btnAccesoMapa_Click;
            // 
            // pnlCardIngresos
            // 
            pnlCardIngresos.BackColor = Color.White;
            pnlCardIngresos.BorderStyle = BorderStyle.FixedSingle;
            pnlCardIngresos.Controls.Add(pnlBordeIngresos);
            pnlCardIngresos.Controls.Add(lblKpiIngresos);
            pnlCardIngresos.Controls.Add(lblTitIngresos);
            pnlCardIngresos.Location = new Point(768, 212);
            pnlCardIngresos.Name = "pnlCardIngresos";
            pnlCardIngresos.Size = new Size(232, 130);
            pnlCardIngresos.TabIndex = 5;
            // 
            // pnlBordeIngresos
            // 
            pnlBordeIngresos.BackColor = Color.FromArgb(200, 157, 84);
            pnlBordeIngresos.Dock = DockStyle.Top;
            pnlBordeIngresos.Location = new Point(0, 0);
            pnlBordeIngresos.Name = "pnlBordeIngresos";
            pnlBordeIngresos.Size = new Size(230, 6);
            pnlBordeIngresos.TabIndex = 0;
            // 
            // lblKpiIngresos
            // 
            lblKpiIngresos.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiIngresos.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiIngresos.Location = new Point(16, 52);
            lblKpiIngresos.Name = "lblKpiIngresos";
            lblKpiIngresos.Size = new Size(202, 58);
            lblKpiIngresos.TabIndex = 2;
            lblKpiIngresos.Text = "$0.00";
            // 
            // lblTitIngresos
            // 
            lblTitIngresos.AutoSize = true;
            lblTitIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitIngresos.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitIngresos.Location = new Point(16, 20);
            lblTitIngresos.Name = "lblTitIngresos";
            lblTitIngresos.Size = new Size(124, 15);
            lblTitIngresos.TabIndex = 1;
            lblTitIngresos.Text = "INGRESOS DEL MES";
            // 
            // pnlCardSalidas
            // 
            pnlCardSalidas.BackColor = Color.White;
            pnlCardSalidas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardSalidas.Controls.Add(pnlBordeSalidas);
            pnlCardSalidas.Controls.Add(lblKpiSalidas);
            pnlCardSalidas.Controls.Add(lblTitSalidas);
            pnlCardSalidas.Location = new Point(520, 212);
            pnlCardSalidas.Name = "pnlCardSalidas";
            pnlCardSalidas.Size = new Size(232, 130);
            pnlCardSalidas.TabIndex = 4;
            // 
            // pnlBordeSalidas
            // 
            pnlBordeSalidas.BackColor = Color.FromArgb(217, 119, 6);
            pnlBordeSalidas.Dock = DockStyle.Top;
            pnlBordeSalidas.Location = new Point(0, 0);
            pnlBordeSalidas.Name = "pnlBordeSalidas";
            pnlBordeSalidas.Size = new Size(230, 6);
            pnlBordeSalidas.TabIndex = 0;
            // 
            // lblKpiSalidas
            // 
            lblKpiSalidas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiSalidas.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiSalidas.Location = new Point(16, 52);
            lblKpiSalidas.Name = "lblKpiSalidas";
            lblKpiSalidas.Size = new Size(202, 58);
            lblKpiSalidas.TabIndex = 2;
            lblKpiSalidas.Text = "0";
            // 
            // lblTitSalidas
            // 
            lblTitSalidas.AutoSize = true;
            lblTitSalidas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitSalidas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitSalidas.Location = new Point(16, 20);
            lblTitSalidas.Name = "lblTitSalidas";
            lblTitSalidas.Size = new Size(167, 15);
            lblTitSalidas.TabIndex = 1;
            lblTitSalidas.Text = "SALIDAS PROGRAMADAS HOY";
            // 
            // pnlCardLlegadas
            // 
            pnlCardLlegadas.BackColor = Color.White;
            pnlCardLlegadas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardLlegadas.Controls.Add(pnlBordeLlegadas);
            pnlCardLlegadas.Controls.Add(lblKpiLlegadas);
            pnlCardLlegadas.Controls.Add(lblTitLlegadas);
            pnlCardLlegadas.Location = new Point(272, 212);
            pnlCardLlegadas.Name = "pnlCardLlegadas";
            pnlCardLlegadas.Size = new Size(232, 130);
            pnlCardLlegadas.TabIndex = 3;
            // 
            // pnlBordeLlegadas
            // 
            pnlBordeLlegadas.BackColor = Color.FromArgb(21, 128, 61);
            pnlBordeLlegadas.Dock = DockStyle.Top;
            pnlBordeLlegadas.Location = new Point(0, 0);
            pnlBordeLlegadas.Name = "pnlBordeLlegadas";
            pnlBordeLlegadas.Size = new Size(230, 6);
            pnlBordeLlegadas.TabIndex = 0;
            // 
            // lblKpiLlegadas
            // 
            lblKpiLlegadas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiLlegadas.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiLlegadas.Location = new Point(16, 52);
            lblKpiLlegadas.Name = "lblKpiLlegadas";
            lblKpiLlegadas.Size = new Size(202, 58);
            lblKpiLlegadas.TabIndex = 2;
            lblKpiLlegadas.Text = "0";
            // 
            // lblTitLlegadas
            // 
            lblTitLlegadas.AutoSize = true;
            lblTitLlegadas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitLlegadas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitLlegadas.Location = new Point(16, 20);
            lblTitLlegadas.Name = "lblTitLlegadas";
            lblTitLlegadas.Size = new Size(165, 15);
            lblTitLlegadas.TabIndex = 1;
            lblTitLlegadas.Text = "LLEGADAS PENDIENTES HOY";
            // 
            // pnlCardOcupacion
            // 
            pnlCardOcupacion.BackColor = Color.White;
            pnlCardOcupacion.BorderStyle = BorderStyle.FixedSingle;
            pnlCardOcupacion.Controls.Add(pnlBordeOcupacion);
            pnlCardOcupacion.Controls.Add(lblKpiOcupacion);
            pnlCardOcupacion.Controls.Add(lblTitOcupacion);
            pnlCardOcupacion.Location = new Point(24, 212);
            pnlCardOcupacion.Name = "pnlCardOcupacion";
            pnlCardOcupacion.Size = new Size(232, 130);
            pnlCardOcupacion.TabIndex = 2;
            // 
            // pnlBordeOcupacion
            // 
            pnlBordeOcupacion.BackColor = Color.FromArgb(30, 64, 175);
            pnlBordeOcupacion.Dock = DockStyle.Top;
            pnlBordeOcupacion.Location = new Point(0, 0);
            pnlBordeOcupacion.Name = "pnlBordeOcupacion";
            pnlBordeOcupacion.Size = new Size(230, 6);
            pnlBordeOcupacion.TabIndex = 0;
            // 
            // lblKpiOcupacion
            // 
            lblKpiOcupacion.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiOcupacion.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiOcupacion.Location = new Point(16, 52);
            lblKpiOcupacion.Name = "lblKpiOcupacion";
            lblKpiOcupacion.Size = new Size(202, 58);
            lblKpiOcupacion.TabIndex = 2;
            lblKpiOcupacion.Text = "0%";
            // 
            // lblTitOcupacion
            // 
            lblTitOcupacion.AutoSize = true;
            lblTitOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitOcupacion.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitOcupacion.Location = new Point(16, 20);
            lblTitOcupacion.Name = "lblTitOcupacion";
            lblTitOcupacion.Size = new Size(131, 15);
            lblTitOcupacion.TabIndex = 1;
            lblTitOcupacion.Text = "OCUPACION DEL DIA";
            // 
            // pnlAlertaLimpieza
            // 
            pnlAlertaLimpieza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlertaLimpieza.BackColor = Color.FromArgb(254, 249, 195);
            pnlAlertaLimpieza.BorderStyle = BorderStyle.FixedSingle;
            pnlAlertaLimpieza.Controls.Add(lblAlertaLimpieza);
            pnlAlertaLimpieza.Location = new Point(24, 154);
            pnlAlertaLimpieza.Name = "pnlAlertaLimpieza";
            pnlAlertaLimpieza.Size = new Size(976, 42);
            pnlAlertaLimpieza.TabIndex = 1;
            // 
            // lblAlertaLimpieza
            // 
            lblAlertaLimpieza.Dock = DockStyle.Fill;
            lblAlertaLimpieza.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAlertaLimpieza.ForeColor = Color.FromArgb(133, 77, 14);
            lblAlertaLimpieza.Location = new Point(0, 0);
            lblAlertaLimpieza.Name = "lblAlertaLimpieza";
            lblAlertaLimpieza.Padding = new Padding(12, 0, 12, 0);
            lblAlertaLimpieza.Size = new Size(974, 40);
            lblAlertaLimpieza.TabIndex = 0;
            lblAlertaLimpieza.Text = "Verificando estado operativo del hotel...";
            lblAlertaLimpieza.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 741);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlMenuLateral);
            Controls.Add(pnlSuperior);
            MinimumSize = new Size(1050, 650);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Costa Dorada - Sistema de Gestion Hotelera";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlMenuLateral.ResumeLayout(false);
            pnlContenedor.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlHero.ResumeLayout(false);
            pnlHero.PerformLayout();
            pnlCardIngresos.ResumeLayout(false);
            pnlCardIngresos.PerformLayout();
            pnlCardSalidas.ResumeLayout(false);
            pnlCardSalidas.PerformLayout();
            pnlCardLlegadas.ResumeLayout(false);
            pnlCardLlegadas.PerformLayout();
            pnlCardOcupacion.ResumeLayout(false);
            pnlCardOcupacion.PerformLayout();
            pnlAlertaLimpieza.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private Button btnCerrarSesion;
        private Label lblUsuarioRol;
        private Label lblEstadoRealtime;
        private Label lblTituloApp;
        private Button btnMenuToggle;
        private Panel pnlMenuLateral;
        private Button btnUsuarios;
        private Button btnReportes;
        private Button btnPlatillos;
        private Button btnRestaurante;
        private Button btnClientes;
        private Button btnCheckInOut;
        private Button btnNuevaReserva;
        private Button btnTiposHabitacion;
        private Button btnHabitaciones;
        private Button btnMisReservas;
        private Button btnExplorarSuites;
        private Button btnInicio;
        private Panel pnlContenedor;
        private Panel pnlDashboard;
        private Panel pnlHero;
        private Label lblHeroSubtitulo;
        private Label lblHeroTitulo;
        private Panel pnlLineaHero;
        private Button btnAccesoRestaurante;
        private Button btnAccesoCheckIn;
        private Button btnAccesoReserva;
        private Button btnAccesoMapa;
        private Panel pnlCardIngresos;
        private Panel pnlBordeIngresos;
        private Label lblKpiIngresos;
        private Label lblTitIngresos;
        private Panel pnlCardSalidas;
        private Panel pnlBordeSalidas;
        private Label lblKpiSalidas;
        private Label lblTitSalidas;
        private Panel pnlCardLlegadas;
        private Panel pnlBordeLlegadas;
        private Label lblKpiLlegadas;
        private Label lblTitLlegadas;
        private Panel pnlCardOcupacion;
        private Panel pnlBordeOcupacion;
        private Label lblKpiOcupacion;
        private Label lblTitOcupacion;
        private Panel pnlAlertaLimpieza;
        private Label lblAlertaLimpieza;
    }
}
