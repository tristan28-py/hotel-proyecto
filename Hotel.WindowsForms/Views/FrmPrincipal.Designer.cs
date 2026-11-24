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
            flpTopDerecha = new FlowLayoutPanel();
            lblEstadoRealtime = new Label();
            lblUsuarioRol = new Label();
            btnCerrarSesion = new Button();
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
            flpAccesos = new FlowLayoutPanel();
            btnAccesoMapa = new Button();
            btnAccesoReserva = new Button();
            btnAccesoCheckIn = new Button();
            btnAccesoRestaurante = new Button();
            tlpKpis = new TableLayoutPanel();
            pnlCardOcupacion = new Panel();
            lblKpiOcupacion = new Label();
            lblTitOcupacion = new Label();
            pnlBordeOcupacion = new Panel();
            pnlCardLlegadas = new Panel();
            lblKpiLlegadas = new Label();
            lblTitLlegadas = new Label();
            pnlBordeLlegadas = new Panel();
            pnlCardSalidas = new Panel();
            lblKpiSalidas = new Label();
            lblTitSalidas = new Label();
            pnlBordeSalidas = new Panel();
            pnlCardIngresos = new Panel();
            lblKpiIngresos = new Label();
            lblTitIngresos = new Label();
            pnlBordeIngresos = new Panel();
            pnlAlertaLimpieza = new Panel();
            lblAlertaLimpieza = new Label();
            pnlHero = new Panel();
            lblHeroSubtitulo = new Label();
            lblHeroTitulo = new Label();
            pnlLineaHero = new Panel();
            pnlSuperior.SuspendLayout();
            flpTopDerecha.SuspendLayout();
            pnlMenuLateral.SuspendLayout();
            pnlContenedor.SuspendLayout();
            pnlDashboard.SuspendLayout();
            flpAccesos.SuspendLayout();
            tlpKpis.SuspendLayout();
            pnlCardOcupacion.SuspendLayout();
            pnlCardLlegadas.SuspendLayout();
            pnlCardSalidas.SuspendLayout();
            pnlCardIngresos.SuspendLayout();
            pnlAlertaLimpieza.SuspendLayout();
            pnlHero.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(flpTopDerecha);
            pnlSuperior.Controls.Add(lblTituloApp);
            pnlSuperior.Controls.Add(btnMenuToggle);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Padding = new Padding(12, 10, 12, 10);
            pnlSuperior.Size = new Size(1320, 58);
            pnlSuperior.TabIndex = 0;
            // 
            // flpTopDerecha
            // 
            flpTopDerecha.AutoSize = true;
            flpTopDerecha.Controls.Add(lblEstadoRealtime);
            flpTopDerecha.Controls.Add(lblUsuarioRol);
            flpTopDerecha.Controls.Add(btnCerrarSesion);
            flpTopDerecha.Dock = DockStyle.Right;
            flpTopDerecha.Location = new Point(772, 10);
            flpTopDerecha.Name = "flpTopDerecha";
            flpTopDerecha.Size = new Size(536, 38);
            flpTopDerecha.TabIndex = 2;
            flpTopDerecha.WrapContents = false;
            // 
            // lblEstadoRealtime
            // 
            lblEstadoRealtime.AutoSize = true;
            lblEstadoRealtime.BackColor = Color.FromArgb(254, 243, 199);
            lblEstadoRealtime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoRealtime.ForeColor = Color.FromArgb(146, 64, 14);
            lblEstadoRealtime.Location = new Point(3, 3);
            lblEstadoRealtime.Margin = new Padding(3, 3, 8, 3);
            lblEstadoRealtime.MinimumSize = new Size(140, 32);
            lblEstadoRealtime.Name = "lblEstadoRealtime";
            lblEstadoRealtime.Padding = new Padding(12, 6, 12, 6);
            lblEstadoRealtime.Size = new Size(140, 32);
            lblEstadoRealtime.TabIndex = 0;
            lblEstadoRealtime.Text = "Conectando...";
            lblEstadoRealtime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuarioRol
            // 
            lblUsuarioRol.AutoSize = true;
            lblUsuarioRol.BackColor = Color.FromArgb(247, 245, 240);
            lblUsuarioRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioRol.ForeColor = Color.FromArgb(15, 30, 54);
            lblUsuarioRol.Location = new Point(151, 3);
            lblUsuarioRol.Margin = new Padding(0, 3, 8, 3);
            lblUsuarioRol.MinimumSize = new Size(220, 32);
            lblUsuarioRol.Name = "lblUsuarioRol";
            lblUsuarioRol.Padding = new Padding(12, 6, 12, 6);
            lblUsuarioRol.Size = new Size(220, 32);
            lblUsuarioRol.TabIndex = 1;
            lblUsuarioRol.Text = "Usuario | Rol";
            lblUsuarioRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(185, 28, 28);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(379, 3);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(154, 32);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblTituloApp
            // 
            lblTituloApp.AutoSize = true;
            lblTituloApp.Font = new Font("Georgia", 13F, FontStyle.Bold);
            lblTituloApp.ForeColor = Color.FromArgb(15, 30, 54);
            lblTituloApp.Location = new Point(82, 18);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(265, 21);
            lblTituloApp.TabIndex = 1;
            lblTituloApp.Text = "HOTEL COSTA DORADA  |  PMS";
            // 
            // btnMenuToggle
            // 
            btnMenuToggle.BackColor = Color.FromArgb(15, 30, 54);
            btnMenuToggle.FlatAppearance.BorderSize = 0;
            btnMenuToggle.FlatStyle = FlatStyle.Flat;
            btnMenuToggle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMenuToggle.ForeColor = Color.FromArgb(200, 157, 84);
            btnMenuToggle.Location = new Point(12, 12);
            btnMenuToggle.Name = "btnMenuToggle";
            btnMenuToggle.Size = new Size(60, 34);
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
            pnlMenuLateral.Size = new Size(242, 722);
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
            btnUsuarios.Padding = new Padding(16, 0, 8, 0);
            btnUsuarios.Size = new Size(242, 44);
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
            btnReportes.Padding = new Padding(16, 0, 8, 0);
            btnReportes.Size = new Size(242, 44);
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
            btnPlatillos.Padding = new Padding(16, 0, 8, 0);
            btnPlatillos.Size = new Size(242, 44);
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
            btnRestaurante.Padding = new Padding(16, 0, 8, 0);
            btnRestaurante.Size = new Size(242, 44);
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
            btnClientes.Padding = new Padding(16, 0, 8, 0);
            btnClientes.Size = new Size(242, 44);
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
            btnCheckInOut.Padding = new Padding(16, 0, 8, 0);
            btnCheckInOut.Size = new Size(242, 44);
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
            btnNuevaReserva.Padding = new Padding(16, 0, 8, 0);
            btnNuevaReserva.Size = new Size(242, 44);
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
            btnTiposHabitacion.Padding = new Padding(16, 0, 8, 0);
            btnTiposHabitacion.Size = new Size(242, 44);
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
            btnHabitaciones.Padding = new Padding(16, 0, 8, 0);
            btnHabitaciones.Size = new Size(242, 44);
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
            btnMisReservas.Padding = new Padding(16, 0, 8, 0);
            btnMisReservas.Size = new Size(242, 44);
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
            btnExplorarSuites.Padding = new Padding(16, 0, 8, 0);
            btnExplorarSuites.Size = new Size(242, 44);
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
            btnInicio.Padding = new Padding(16, 0, 8, 0);
            btnInicio.Size = new Size(242, 58);
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
            pnlContenedor.Location = new Point(242, 58);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(1078, 722);
            pnlContenedor.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            pnlDashboard.AutoScroll = true;
            pnlDashboard.BackColor = Color.FromArgb(247, 245, 240);
            pnlDashboard.Controls.Add(flpAccesos);
            pnlDashboard.Controls.Add(tlpKpis);
            pnlDashboard.Controls.Add(pnlAlertaLimpieza);
            pnlDashboard.Controls.Add(pnlHero);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(24, 20, 24, 20);
            pnlDashboard.Size = new Size(1078, 722);
            pnlDashboard.TabIndex = 0;
            // 
            // flpAccesos
            // 
            flpAccesos.AutoSize = true;
            flpAccesos.Controls.Add(btnAccesoMapa);
            flpAccesos.Controls.Add(btnAccesoReserva);
            flpAccesos.Controls.Add(btnAccesoCheckIn);
            flpAccesos.Controls.Add(btnAccesoRestaurante);
            flpAccesos.Dock = DockStyle.Top;
            flpAccesos.Location = new Point(24, 382);
            flpAccesos.Name = "flpAccesos";
            flpAccesos.Padding = new Padding(0, 18, 0, 8);
            flpAccesos.Size = new Size(1030, 80);
            flpAccesos.TabIndex = 3;
            // 
            // btnAccesoMapa
            // 
            btnAccesoMapa.BackColor = Color.FromArgb(15, 30, 54);
            btnAccesoMapa.FlatAppearance.BorderSize = 0;
            btnAccesoMapa.FlatStyle = FlatStyle.Flat;
            btnAccesoMapa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoMapa.ForeColor = Color.White;
            btnAccesoMapa.Location = new Point(0, 18);
            btnAccesoMapa.Margin = new Padding(0, 0, 14, 10);
            btnAccesoMapa.Name = "btnAccesoMapa";
            btnAccesoMapa.Size = new Size(218, 46);
            btnAccesoMapa.TabIndex = 0;
            btnAccesoMapa.Text = "Mapa de Habitaciones";
            btnAccesoMapa.UseVisualStyleBackColor = false;
            btnAccesoMapa.Click += btnAccesoMapa_Click;
            // 
            // btnAccesoReserva
            // 
            btnAccesoReserva.BackColor = Color.FromArgb(21, 128, 61);
            btnAccesoReserva.FlatAppearance.BorderSize = 0;
            btnAccesoReserva.FlatStyle = FlatStyle.Flat;
            btnAccesoReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoReserva.ForeColor = Color.White;
            btnAccesoReserva.Location = new Point(232, 18);
            btnAccesoReserva.Margin = new Padding(0, 0, 14, 10);
            btnAccesoReserva.Name = "btnAccesoReserva";
            btnAccesoReserva.Size = new Size(218, 46);
            btnAccesoReserva.TabIndex = 1;
            btnAccesoReserva.Text = "+ Nueva Reservacion";
            btnAccesoReserva.UseVisualStyleBackColor = false;
            btnAccesoReserva.Click += btnAccesoReserva_Click;
            // 
            // btnAccesoCheckIn
            // 
            btnAccesoCheckIn.BackColor = Color.FromArgb(30, 64, 175);
            btnAccesoCheckIn.FlatAppearance.BorderSize = 0;
            btnAccesoCheckIn.FlatStyle = FlatStyle.Flat;
            btnAccesoCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoCheckIn.ForeColor = Color.White;
            btnAccesoCheckIn.Location = new Point(464, 18);
            btnAccesoCheckIn.Margin = new Padding(0, 0, 14, 10);
            btnAccesoCheckIn.Name = "btnAccesoCheckIn";
            btnAccesoCheckIn.Size = new Size(218, 46);
            btnAccesoCheckIn.TabIndex = 2;
            btnAccesoCheckIn.Text = "Check-in / Check-out";
            btnAccesoCheckIn.UseVisualStyleBackColor = false;
            btnAccesoCheckIn.Click += btnAccesoCheckIn_Click;
            // 
            // btnAccesoRestaurante
            // 
            btnAccesoRestaurante.BackColor = Color.FromArgb(200, 157, 84);
            btnAccesoRestaurante.FlatAppearance.BorderSize = 0;
            btnAccesoRestaurante.FlatStyle = FlatStyle.Flat;
            btnAccesoRestaurante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoRestaurante.ForeColor = Color.FromArgb(15, 30, 54);
            btnAccesoRestaurante.Location = new Point(696, 18);
            btnAccesoRestaurante.Margin = new Padding(0, 0, 14, 10);
            btnAccesoRestaurante.Name = "btnAccesoRestaurante";
            btnAccesoRestaurante.Size = new Size(234, 46);
            btnAccesoRestaurante.TabIndex = 3;
            btnAccesoRestaurante.Text = "Restaurante / Room Service";
            btnAccesoRestaurante.UseVisualStyleBackColor = false;
            btnAccesoRestaurante.Click += btnAccesoRestaurante_Click;
            // 
            // tlpKpis
            // 
            tlpKpis.ColumnCount = 4;
            tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpis.Controls.Add(pnlCardOcupacion, 0, 0);
            tlpKpis.Controls.Add(pnlCardLlegadas, 1, 0);
            tlpKpis.Controls.Add(pnlCardSalidas, 2, 0);
            tlpKpis.Controls.Add(pnlCardIngresos, 3, 0);
            tlpKpis.Dock = DockStyle.Top;
            tlpKpis.Location = new Point(24, 212);
            tlpKpis.Name = "tlpKpis";
            tlpKpis.Padding = new Padding(0, 14, 0, 0);
            tlpKpis.RowCount = 1;
            tlpKpis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpKpis.Size = new Size(1030, 170);
            tlpKpis.TabIndex = 2;
            // 
            // pnlCardOcupacion
            // 
            pnlCardOcupacion.BackColor = Color.White;
            pnlCardOcupacion.BorderStyle = BorderStyle.FixedSingle;
            pnlCardOcupacion.Controls.Add(lblKpiOcupacion);
            pnlCardOcupacion.Controls.Add(lblTitOcupacion);
            pnlCardOcupacion.Controls.Add(pnlBordeOcupacion);
            pnlCardOcupacion.Dock = DockStyle.Fill;
            pnlCardOcupacion.Location = new Point(0, 14);
            pnlCardOcupacion.Margin = new Padding(0, 0, 14, 0);
            pnlCardOcupacion.Name = "pnlCardOcupacion";
            pnlCardOcupacion.Size = new Size(243, 156);
            pnlCardOcupacion.TabIndex = 0;
            // 
            // lblKpiOcupacion
            // 
            lblKpiOcupacion.Dock = DockStyle.Fill;
            lblKpiOcupacion.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiOcupacion.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiOcupacion.Location = new Point(0, 42);
            lblKpiOcupacion.Name = "lblKpiOcupacion";
            lblKpiOcupacion.Padding = new Padding(14, 6, 14, 6);
            lblKpiOcupacion.Size = new Size(241, 112);
            lblKpiOcupacion.TabIndex = 2;
            lblKpiOcupacion.Text = "0%";
            // 
            // lblTitOcupacion
            // 
            lblTitOcupacion.Dock = DockStyle.Top;
            lblTitOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitOcupacion.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitOcupacion.Location = new Point(0, 6);
            lblTitOcupacion.Name = "lblTitOcupacion";
            lblTitOcupacion.Padding = new Padding(14, 12, 14, 0);
            lblTitOcupacion.Size = new Size(241, 36);
            lblTitOcupacion.TabIndex = 1;
            lblTitOcupacion.Text = "OCUPACION DEL DIA";
            // 
            // pnlBordeOcupacion
            // 
            pnlBordeOcupacion.BackColor = Color.FromArgb(30, 64, 175);
            pnlBordeOcupacion.Dock = DockStyle.Top;
            pnlBordeOcupacion.Location = new Point(0, 0);
            pnlBordeOcupacion.Name = "pnlBordeOcupacion";
            pnlBordeOcupacion.Size = new Size(241, 6);
            pnlBordeOcupacion.TabIndex = 0;
            // 
            // pnlCardLlegadas
            // 
            pnlCardLlegadas.BackColor = Color.White;
            pnlCardLlegadas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardLlegadas.Controls.Add(lblKpiLlegadas);
            pnlCardLlegadas.Controls.Add(lblTitLlegadas);
            pnlCardLlegadas.Controls.Add(pnlBordeLlegadas);
            pnlCardLlegadas.Dock = DockStyle.Fill;
            pnlCardLlegadas.Location = new Point(257, 14);
            pnlCardLlegadas.Margin = new Padding(0, 0, 14, 0);
            pnlCardLlegadas.Name = "pnlCardLlegadas";
            pnlCardLlegadas.Size = new Size(243, 156);
            pnlCardLlegadas.TabIndex = 1;
            // 
            // lblKpiLlegadas
            // 
            lblKpiLlegadas.Dock = DockStyle.Fill;
            lblKpiLlegadas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiLlegadas.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiLlegadas.Location = new Point(0, 42);
            lblKpiLlegadas.Name = "lblKpiLlegadas";
            lblKpiLlegadas.Padding = new Padding(14, 6, 14, 6);
            lblKpiLlegadas.Size = new Size(241, 112);
            lblKpiLlegadas.TabIndex = 2;
            lblKpiLlegadas.Text = "0";
            // 
            // lblTitLlegadas
            // 
            lblTitLlegadas.Dock = DockStyle.Top;
            lblTitLlegadas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitLlegadas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitLlegadas.Location = new Point(0, 6);
            lblTitLlegadas.Name = "lblTitLlegadas";
            lblTitLlegadas.Padding = new Padding(14, 12, 14, 0);
            lblTitLlegadas.Size = new Size(241, 36);
            lblTitLlegadas.TabIndex = 1;
            lblTitLlegadas.Text = "LLEGADAS PENDIENTES HOY";
            // 
            // pnlBordeLlegadas
            // 
            pnlBordeLlegadas.BackColor = Color.FromArgb(21, 128, 61);
            pnlBordeLlegadas.Dock = DockStyle.Top;
            pnlBordeLlegadas.Location = new Point(0, 0);
            pnlBordeLlegadas.Name = "pnlBordeLlegadas";
            pnlBordeLlegadas.Size = new Size(241, 6);
            pnlBordeLlegadas.TabIndex = 0;
            // 
            // pnlCardSalidas
            // 
            pnlCardSalidas.BackColor = Color.White;
            pnlCardSalidas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardSalidas.Controls.Add(lblKpiSalidas);
            pnlCardSalidas.Controls.Add(lblTitSalidas);
            pnlCardSalidas.Controls.Add(pnlBordeSalidas);
            pnlCardSalidas.Dock = DockStyle.Fill;
            pnlCardSalidas.Location = new Point(514, 14);
            pnlCardSalidas.Margin = new Padding(0, 0, 14, 0);
            pnlCardSalidas.Name = "pnlCardSalidas";
            pnlCardSalidas.Size = new Size(243, 156);
            pnlCardSalidas.TabIndex = 2;
            // 
            // lblKpiSalidas
            // 
            lblKpiSalidas.Dock = DockStyle.Fill;
            lblKpiSalidas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiSalidas.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiSalidas.Location = new Point(0, 42);
            lblKpiSalidas.Name = "lblKpiSalidas";
            lblKpiSalidas.Padding = new Padding(14, 6, 14, 6);
            lblKpiSalidas.Size = new Size(241, 112);
            lblKpiSalidas.TabIndex = 2;
            lblKpiSalidas.Text = "0";
            // 
            // lblTitSalidas
            // 
            lblTitSalidas.Dock = DockStyle.Top;
            lblTitSalidas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitSalidas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitSalidas.Location = new Point(0, 6);
            lblTitSalidas.Name = "lblTitSalidas";
            lblTitSalidas.Padding = new Padding(14, 12, 14, 0);
            lblTitSalidas.Size = new Size(241, 36);
            lblTitSalidas.TabIndex = 1;
            lblTitSalidas.Text = "SALIDAS PROGRAMADAS HOY";
            // 
            // pnlBordeSalidas
            // 
            pnlBordeSalidas.BackColor = Color.FromArgb(217, 119, 6);
            pnlBordeSalidas.Dock = DockStyle.Top;
            pnlBordeSalidas.Location = new Point(0, 0);
            pnlBordeSalidas.Name = "pnlBordeSalidas";
            pnlBordeSalidas.Size = new Size(241, 6);
            pnlBordeSalidas.TabIndex = 0;
            // 
            // pnlCardIngresos
            // 
            pnlCardIngresos.BackColor = Color.White;
            pnlCardIngresos.BorderStyle = BorderStyle.FixedSingle;
            pnlCardIngresos.Controls.Add(lblKpiIngresos);
            pnlCardIngresos.Controls.Add(lblTitIngresos);
            pnlCardIngresos.Controls.Add(pnlBordeIngresos);
            pnlCardIngresos.Dock = DockStyle.Fill;
            pnlCardIngresos.Location = new Point(771, 14);
            pnlCardIngresos.Margin = new Padding(0);
            pnlCardIngresos.Name = "pnlCardIngresos";
            pnlCardIngresos.Size = new Size(259, 156);
            pnlCardIngresos.TabIndex = 3;
            // 
            // lblKpiIngresos
            // 
            lblKpiIngresos.Dock = DockStyle.Fill;
            lblKpiIngresos.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiIngresos.ForeColor = Color.FromArgb(15, 30, 54);
            lblKpiIngresos.Location = new Point(0, 42);
            lblKpiIngresos.Name = "lblKpiIngresos";
            lblKpiIngresos.Padding = new Padding(14, 6, 14, 6);
            lblKpiIngresos.Size = new Size(257, 112);
            lblKpiIngresos.TabIndex = 2;
            lblKpiIngresos.Text = "$0.00";
            // 
            // lblTitIngresos
            // 
            lblTitIngresos.Dock = DockStyle.Top;
            lblTitIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitIngresos.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitIngresos.Location = new Point(0, 6);
            lblTitIngresos.Name = "lblTitIngresos";
            lblTitIngresos.Padding = new Padding(14, 12, 14, 0);
            lblTitIngresos.Size = new Size(257, 36);
            lblTitIngresos.TabIndex = 1;
            lblTitIngresos.Text = "INGRESOS DEL MES";
            // 
            // pnlBordeIngresos
            // 
            pnlBordeIngresos.BackColor = Color.FromArgb(200, 157, 84);
            pnlBordeIngresos.Dock = DockStyle.Top;
            pnlBordeIngresos.Location = new Point(0, 0);
            pnlBordeIngresos.Name = "pnlBordeIngresos";
            pnlBordeIngresos.Size = new Size(257, 6);
            pnlBordeIngresos.TabIndex = 0;
            // 
            // pnlAlertaLimpieza
            // 
            pnlAlertaLimpieza.BackColor = Color.FromArgb(254, 249, 195);
            pnlAlertaLimpieza.BorderStyle = BorderStyle.FixedSingle;
            pnlAlertaLimpieza.Controls.Add(lblAlertaLimpieza);
            pnlAlertaLimpieza.Dock = DockStyle.Top;
            pnlAlertaLimpieza.Location = new Point(24, 156);
            pnlAlertaLimpieza.Name = "pnlAlertaLimpieza";
            pnlAlertaLimpieza.Size = new Size(1030, 56);
            pnlAlertaLimpieza.TabIndex = 1;
            // 
            // lblAlertaLimpieza
            // 
            lblAlertaLimpieza.AutoEllipsis = true;
            lblAlertaLimpieza.Dock = DockStyle.Fill;
            lblAlertaLimpieza.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAlertaLimpieza.ForeColor = Color.FromArgb(133, 77, 14);
            lblAlertaLimpieza.Location = new Point(0, 0);
            lblAlertaLimpieza.Name = "lblAlertaLimpieza";
            lblAlertaLimpieza.Padding = new Padding(14, 6, 14, 6);
            lblAlertaLimpieza.Size = new Size(1028, 54);
            lblAlertaLimpieza.TabIndex = 0;
            lblAlertaLimpieza.Text = "Verificando estado operativo del hotel...";
            lblAlertaLimpieza.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHero
            // 
            pnlHero.BackColor = Color.FromArgb(15, 30, 54);
            pnlHero.Controls.Add(lblHeroSubtitulo);
            pnlHero.Controls.Add(lblHeroTitulo);
            pnlHero.Controls.Add(pnlLineaHero);
            pnlHero.Dock = DockStyle.Top;
            pnlHero.Location = new Point(24, 20);
            pnlHero.Name = "pnlHero";
            pnlHero.Padding = new Padding(0, 0, 0, 16);
            pnlHero.Size = new Size(1030, 136);
            pnlHero.TabIndex = 0;
            // 
            // lblHeroSubtitulo
            // 
            lblHeroSubtitulo.AutoSize = true;
            lblHeroSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblHeroSubtitulo.ForeColor = Color.FromArgb(203, 213, 225);
            lblHeroSubtitulo.Location = new Point(28, 76);
            lblHeroSubtitulo.MaximumSize = new Size(920, 0);
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
            lblHeroTitulo.Location = new Point(26, 26);
            lblHeroTitulo.Name = "lblHeroTitulo";
            lblHeroTitulo.Size = new Size(273, 31);
            lblHeroTitulo.TabIndex = 1;
            lblHeroTitulo.Text = "Hotel Costa Dorada";
            // 
            // pnlLineaHero
            // 
            pnlLineaHero.BackColor = Color.FromArgb(200, 157, 84);
            pnlLineaHero.Dock = DockStyle.Bottom;
            pnlLineaHero.Location = new Point(0, 114);
            pnlLineaHero.Name = "pnlLineaHero";
            pnlLineaHero.Size = new Size(1030, 6);
            pnlLineaHero.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 780);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlMenuLateral);
            Controls.Add(pnlSuperior);
            MinimumSize = new Size(1180, 700);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Costa Dorada - Sistema de Gestion Hotelera";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            flpTopDerecha.ResumeLayout(false);
            flpTopDerecha.PerformLayout();
            pnlMenuLateral.ResumeLayout(false);
            pnlContenedor.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            flpAccesos.ResumeLayout(false);
            tlpKpis.ResumeLayout(false);
            pnlCardOcupacion.ResumeLayout(false);
            pnlCardLlegadas.ResumeLayout(false);
            pnlCardSalidas.ResumeLayout(false);
            pnlCardIngresos.ResumeLayout(false);
            pnlAlertaLimpieza.ResumeLayout(false);
            pnlHero.ResumeLayout(false);
            pnlHero.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private FlowLayoutPanel flpTopDerecha;
        private Label lblEstadoRealtime;
        private Label lblUsuarioRol;
        private Button btnCerrarSesion;
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
        private FlowLayoutPanel flpAccesos;
        private Button btnAccesoMapa;
        private Button btnAccesoReserva;
        private Button btnAccesoCheckIn;
        private Button btnAccesoRestaurante;
        private TableLayoutPanel tlpKpis;
        private Panel pnlCardOcupacion;
        private Label lblKpiOcupacion;
        private Label lblTitOcupacion;
        private Panel pnlBordeOcupacion;
        private Panel pnlCardLlegadas;
        private Label lblKpiLlegadas;
        private Label lblTitLlegadas;
        private Panel pnlBordeLlegadas;
        private Panel pnlCardSalidas;
        private Label lblKpiSalidas;
        private Label lblTitSalidas;
        private Panel pnlBordeSalidas;
        private Panel pnlCardIngresos;
        private Label lblKpiIngresos;
        private Label lblTitIngresos;
        private Panel pnlBordeIngresos;
        private Panel pnlAlertaLimpieza;
        private Label lblAlertaLimpieza;
        private Panel pnlHero;
        private Label lblHeroSubtitulo;
        private Label lblHeroTitulo;
        private Panel pnlLineaHero;
    }
}
