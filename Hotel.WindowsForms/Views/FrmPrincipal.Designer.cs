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
            lblEstadoRealtime = new Label();
            btnReconectar = new Button();
            txtApiUrl = new TextBox();
            lblServidor = new Label();
            lblTituloApp = new Label();
            btnMenuToggle = new Button();
            pnlMenuLateral = new Panel();
            btnReportes = new Button();
            btnPlatillos = new Button();
            btnRestaurante = new Button();
            btnClientes = new Button();
            btnCheckInOut = new Button();
            btnNuevaReserva = new Button();
            btnTiposHabitacion = new Button();
            btnHabitaciones = new Button();
            btnInicio = new Button();
            pnlContenedor = new Panel();
            pnlDashboard = new Panel();
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
            lblTituloDashboard = new Label();
            pnlSuperior.SuspendLayout();
            pnlMenuLateral.SuspendLayout();
            pnlContenedor.SuspendLayout();
            pnlDashboard.SuspendLayout();
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
            pnlSuperior.Controls.Add(lblEstadoRealtime);
            pnlSuperior.Controls.Add(btnReconectar);
            pnlSuperior.Controls.Add(txtApiUrl);
            pnlSuperior.Controls.Add(lblServidor);
            pnlSuperior.Controls.Add(lblTituloApp);
            pnlSuperior.Controls.Add(btnMenuToggle);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1264, 56);
            pnlSuperior.TabIndex = 0;
            // 
            // lblEstadoRealtime
            // 
            lblEstadoRealtime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEstadoRealtime.BackColor = Color.FromArgb(254, 243, 199);
            lblEstadoRealtime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoRealtime.ForeColor = Color.FromArgb(146, 64, 14);
            lblEstadoRealtime.Location = new Point(1082, 13);
            lblEstadoRealtime.Name = "lblEstadoRealtime";
            lblEstadoRealtime.Size = new Size(168, 30);
            lblEstadoRealtime.TabIndex = 5;
            lblEstadoRealtime.Text = "Conectando...";
            lblEstadoRealtime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReconectar
            // 
            btnReconectar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReconectar.BackColor = Color.FromArgb(37, 99, 235);
            btnReconectar.FlatAppearance.BorderSize = 0;
            btnReconectar.FlatStyle = FlatStyle.Flat;
            btnReconectar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReconectar.ForeColor = Color.White;
            btnReconectar.Location = new Point(975, 13);
            btnReconectar.Name = "btnReconectar";
            btnReconectar.Size = new Size(98, 30);
            btnReconectar.TabIndex = 4;
            btnReconectar.Text = "Conectar";
            btnReconectar.UseVisualStyleBackColor = false;
            btnReconectar.Click += btnReconectar_Click;
            // 
            // txtApiUrl
            // 
            txtApiUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtApiUrl.Font = new Font("Segoe UI", 9.5F);
            txtApiUrl.Location = new Point(724, 15);
            txtApiUrl.Name = "txtApiUrl";
            txtApiUrl.Size = new Size(243, 24);
            txtApiUrl.TabIndex = 3;
            txtApiUrl.Text = "http://localhost:5295";
            // 
            // lblServidor
            // 
            lblServidor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblServidor.AutoSize = true;
            lblServidor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServidor.ForeColor = Color.FromArgb(71, 85, 105);
            lblServidor.Location = new Point(665, 18);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(56, 15);
            lblServidor.TabIndex = 2;
            lblServidor.Text = "API URL:";
            // 
            // lblTituloApp
            // 
            lblTituloApp.AutoSize = true;
            lblTituloApp.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloApp.ForeColor = Color.FromArgb(30, 41, 59);
            lblTituloApp.Location = new Point(62, 16);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(340, 21);
            lblTituloApp.TabIndex = 1;
            lblTituloApp.Text = "Sistema de Reservaciones y Gestion Hotelera";
            // 
            // btnMenuToggle
            // 
            btnMenuToggle.BackColor = Color.FromArgb(18, 32, 54);
            btnMenuToggle.FlatAppearance.BorderSize = 0;
            btnMenuToggle.FlatStyle = FlatStyle.Flat;
            btnMenuToggle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMenuToggle.ForeColor = Color.White;
            btnMenuToggle.Location = new Point(12, 11);
            btnMenuToggle.Name = "btnMenuToggle";
            btnMenuToggle.Size = new Size(42, 34);
            btnMenuToggle.TabIndex = 0;
            btnMenuToggle.Text = "Menu";
            btnMenuToggle.UseVisualStyleBackColor = false;
            btnMenuToggle.Click += btnMenuToggle_Click;
            // 
            // pnlMenuLateral
            // 
            pnlMenuLateral.BackColor = Color.FromArgb(18, 32, 54);
            pnlMenuLateral.Controls.Add(btnReportes);
            pnlMenuLateral.Controls.Add(btnPlatillos);
            pnlMenuLateral.Controls.Add(btnRestaurante);
            pnlMenuLateral.Controls.Add(btnClientes);
            pnlMenuLateral.Controls.Add(btnCheckInOut);
            pnlMenuLateral.Controls.Add(btnNuevaReserva);
            pnlMenuLateral.Controls.Add(btnTiposHabitacion);
            pnlMenuLateral.Controls.Add(btnHabitaciones);
            pnlMenuLateral.Controls.Add(btnInicio);
            pnlMenuLateral.Dock = DockStyle.Left;
            pnlMenuLateral.Location = new Point(0, 56);
            pnlMenuLateral.Name = "pnlMenuLateral";
            pnlMenuLateral.Size = new Size(230, 685);
            pnlMenuLateral.TabIndex = 1;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(18, 32, 54);
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(8, 376);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(214, 42);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes y Exportacion";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnPlatillos
            // 
            btnPlatillos.BackColor = Color.FromArgb(18, 32, 54);
            btnPlatillos.FlatAppearance.BorderSize = 0;
            btnPlatillos.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnPlatillos.FlatStyle = FlatStyle.Flat;
            btnPlatillos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPlatillos.ForeColor = Color.White;
            btnPlatillos.Location = new Point(8, 331);
            btnPlatillos.Name = "btnPlatillos";
            btnPlatillos.Size = new Size(214, 42);
            btnPlatillos.TabIndex = 7;
            btnPlatillos.Text = "Catalogo de Platillos";
            btnPlatillos.TextAlign = ContentAlignment.MiddleLeft;
            btnPlatillos.UseVisualStyleBackColor = false;
            btnPlatillos.Click += btnPlatillos_Click;
            // 
            // btnRestaurante
            // 
            btnRestaurante.BackColor = Color.FromArgb(18, 32, 54);
            btnRestaurante.FlatAppearance.BorderSize = 0;
            btnRestaurante.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnRestaurante.FlatStyle = FlatStyle.Flat;
            btnRestaurante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRestaurante.ForeColor = Color.White;
            btnRestaurante.Location = new Point(8, 286);
            btnRestaurante.Name = "btnRestaurante";
            btnRestaurante.Size = new Size(214, 42);
            btnRestaurante.TabIndex = 6;
            btnRestaurante.Text = "Restaurante y Pedidos";
            btnRestaurante.TextAlign = ContentAlignment.MiddleLeft;
            btnRestaurante.UseVisualStyleBackColor = false;
            btnRestaurante.Click += btnRestaurante_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(18, 32, 54);
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(8, 241);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(214, 42);
            btnClientes.TabIndex = 5;
            btnClientes.Text = "Clientes y Huespedes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnCheckInOut
            // 
            btnCheckInOut.BackColor = Color.FromArgb(18, 32, 54);
            btnCheckInOut.FlatAppearance.BorderSize = 0;
            btnCheckInOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnCheckInOut.FlatStyle = FlatStyle.Flat;
            btnCheckInOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckInOut.ForeColor = Color.White;
            btnCheckInOut.Location = new Point(8, 196);
            btnCheckInOut.Name = "btnCheckInOut";
            btnCheckInOut.Size = new Size(214, 42);
            btnCheckInOut.TabIndex = 4;
            btnCheckInOut.Text = "Check-in / Out y Pagos";
            btnCheckInOut.TextAlign = ContentAlignment.MiddleLeft;
            btnCheckInOut.UseVisualStyleBackColor = false;
            btnCheckInOut.Click += btnCheckInOut_Click;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.BackColor = Color.FromArgb(18, 32, 54);
            btnNuevaReserva.FlatAppearance.BorderSize = 0;
            btnNuevaReserva.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnNuevaReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevaReserva.ForeColor = Color.White;
            btnNuevaReserva.Location = new Point(8, 151);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(214, 42);
            btnNuevaReserva.TabIndex = 3;
            btnNuevaReserva.Text = "Nueva Reservacion";
            btnNuevaReserva.TextAlign = ContentAlignment.MiddleLeft;
            btnNuevaReserva.UseVisualStyleBackColor = false;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // btnTiposHabitacion
            // 
            btnTiposHabitacion.BackColor = Color.FromArgb(18, 32, 54);
            btnTiposHabitacion.FlatAppearance.BorderSize = 0;
            btnTiposHabitacion.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnTiposHabitacion.FlatStyle = FlatStyle.Flat;
            btnTiposHabitacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTiposHabitacion.ForeColor = Color.White;
            btnTiposHabitacion.Location = new Point(8, 106);
            btnTiposHabitacion.Name = "btnTiposHabitacion";
            btnTiposHabitacion.Size = new Size(214, 42);
            btnTiposHabitacion.TabIndex = 2;
            btnTiposHabitacion.Text = "Tipos de Habitacion";
            btnTiposHabitacion.TextAlign = ContentAlignment.MiddleLeft;
            btnTiposHabitacion.UseVisualStyleBackColor = false;
            btnTiposHabitacion.Click += btnTiposHabitacion_Click;
            // 
            // btnHabitaciones
            // 
            btnHabitaciones.BackColor = Color.FromArgb(18, 32, 54);
            btnHabitaciones.FlatAppearance.BorderSize = 0;
            btnHabitaciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 52, 84);
            btnHabitaciones.FlatStyle = FlatStyle.Flat;
            btnHabitaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHabitaciones.ForeColor = Color.White;
            btnHabitaciones.Location = new Point(8, 61);
            btnHabitaciones.Name = "btnHabitaciones";
            btnHabitaciones.Size = new Size(214, 42);
            btnHabitaciones.TabIndex = 1;
            btnHabitaciones.Text = "Mapa de Habitaciones";
            btnHabitaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnHabitaciones.UseVisualStyleBackColor = false;
            btnHabitaciones.Click += btnHabitaciones_Click;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(37, 99, 235);
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(8, 16);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(214, 42);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "Dashboard (Inicio)";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(243, 246, 250);
            pnlContenedor.Controls.Add(pnlDashboard);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(230, 56);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(1034, 685);
            pnlContenedor.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(243, 246, 250);
            pnlDashboard.Controls.Add(btnAccesoRestaurante);
            pnlDashboard.Controls.Add(btnAccesoCheckIn);
            pnlDashboard.Controls.Add(btnAccesoReserva);
            pnlDashboard.Controls.Add(btnAccesoMapa);
            pnlDashboard.Controls.Add(pnlCardIngresos);
            pnlDashboard.Controls.Add(pnlCardSalidas);
            pnlDashboard.Controls.Add(pnlCardLlegadas);
            pnlDashboard.Controls.Add(pnlCardOcupacion);
            pnlDashboard.Controls.Add(pnlAlertaLimpieza);
            pnlDashboard.Controls.Add(lblTituloDashboard);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1034, 685);
            pnlDashboard.TabIndex = 0;
            // 
            // btnAccesoRestaurante
            // 
            btnAccesoRestaurante.BackColor = Color.FromArgb(217, 119, 6);
            btnAccesoRestaurante.FlatAppearance.BorderSize = 0;
            btnAccesoRestaurante.FlatStyle = FlatStyle.Flat;
            btnAccesoRestaurante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoRestaurante.ForeColor = Color.White;
            btnAccesoRestaurante.Location = new Point(628, 282);
            btnAccesoRestaurante.Name = "btnAccesoRestaurante";
            btnAccesoRestaurante.Size = new Size(205, 44);
            btnAccesoRestaurante.TabIndex = 9;
            btnAccesoRestaurante.Text = "Restaurante / Pedidos";
            btnAccesoRestaurante.UseVisualStyleBackColor = false;
            btnAccesoRestaurante.Click += btnRestaurante_Click;
            // 
            // btnAccesoCheckIn
            // 
            btnAccesoCheckIn.BackColor = Color.FromArgb(37, 99, 235);
            btnAccesoCheckIn.FlatAppearance.BorderSize = 0;
            btnAccesoCheckIn.FlatStyle = FlatStyle.Flat;
            btnAccesoCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoCheckIn.ForeColor = Color.White;
            btnAccesoCheckIn.Location = new Point(428, 282);
            btnAccesoCheckIn.Name = "btnAccesoCheckIn";
            btnAccesoCheckIn.Size = new Size(186, 44);
            btnAccesoCheckIn.TabIndex = 8;
            btnAccesoCheckIn.Text = "Check-in / Check-out";
            btnAccesoCheckIn.UseVisualStyleBackColor = false;
            btnAccesoCheckIn.Click += btnCheckInOut_Click;
            // 
            // btnAccesoReserva
            // 
            btnAccesoReserva.BackColor = Color.FromArgb(22, 163, 74);
            btnAccesoReserva.FlatAppearance.BorderSize = 0;
            btnAccesoReserva.FlatStyle = FlatStyle.Flat;
            btnAccesoReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoReserva.ForeColor = Color.White;
            btnAccesoReserva.Location = new Point(228, 282);
            btnAccesoReserva.Name = "btnAccesoReserva";
            btnAccesoReserva.Size = new Size(186, 44);
            btnAccesoReserva.TabIndex = 7;
            btnAccesoReserva.Text = "+ Nueva Reservacion";
            btnAccesoReserva.UseVisualStyleBackColor = false;
            btnAccesoReserva.Click += btnNuevaReserva_Click;
            // 
            // btnAccesoMapa
            // 
            btnAccesoMapa.BackColor = Color.FromArgb(18, 32, 54);
            btnAccesoMapa.FlatAppearance.BorderSize = 0;
            btnAccesoMapa.FlatStyle = FlatStyle.Flat;
            btnAccesoMapa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccesoMapa.ForeColor = Color.White;
            btnAccesoMapa.Location = new Point(24, 282);
            btnAccesoMapa.Name = "btnAccesoMapa";
            btnAccesoMapa.Size = new Size(190, 44);
            btnAccesoMapa.TabIndex = 6;
            btnAccesoMapa.Text = "Ver Mapa Habitaciones";
            btnAccesoMapa.UseVisualStyleBackColor = false;
            btnAccesoMapa.Click += btnHabitaciones_Click;
            // 
            // pnlCardIngresos
            // 
            pnlCardIngresos.BackColor = Color.White;
            pnlCardIngresos.Controls.Add(pnlBordeIngresos);
            pnlCardIngresos.Controls.Add(lblKpiIngresos);
            pnlCardIngresos.Controls.Add(lblTitIngresos);
            pnlCardIngresos.Location = new Point(756, 128);
            pnlCardIngresos.Name = "pnlCardIngresos";
            pnlCardIngresos.Size = new Size(230, 125);
            pnlCardIngresos.TabIndex = 5;
            // 
            // pnlBordeIngresos
            // 
            pnlBordeIngresos.BackColor = Color.FromArgb(124, 58, 237);
            pnlBordeIngresos.Dock = DockStyle.Left;
            pnlBordeIngresos.Location = new Point(0, 0);
            pnlBordeIngresos.Name = "pnlBordeIngresos";
            pnlBordeIngresos.Size = new Size(7, 125);
            pnlBordeIngresos.TabIndex = 0;
            // 
            // lblKpiIngresos
            // 
            lblKpiIngresos.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiIngresos.ForeColor = Color.FromArgb(30, 41, 59);
            lblKpiIngresos.Location = new Point(16, 48);
            lblKpiIngresos.Name = "lblKpiIngresos";
            lblKpiIngresos.Size = new Size(205, 58);
            lblKpiIngresos.TabIndex = 2;
            lblKpiIngresos.Text = "$0.00";
            // 
            // lblTitIngresos
            // 
            lblTitIngresos.AutoSize = true;
            lblTitIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitIngresos.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitIngresos.Location = new Point(18, 16);
            lblTitIngresos.Name = "lblTitIngresos";
            lblTitIngresos.Size = new Size(124, 15);
            lblTitIngresos.TabIndex = 1;
            lblTitIngresos.Text = "INGRESOS DEL MES";
            // 
            // pnlCardSalidas
            // 
            pnlCardSalidas.BackColor = Color.White;
            pnlCardSalidas.Controls.Add(pnlBordeSalidas);
            pnlCardSalidas.Controls.Add(lblKpiSalidas);
            pnlCardSalidas.Controls.Add(lblTitSalidas);
            pnlCardSalidas.Location = new Point(512, 128);
            pnlCardSalidas.Name = "pnlCardSalidas";
            pnlCardSalidas.Size = new Size(230, 125);
            pnlCardSalidas.TabIndex = 4;
            // 
            // pnlBordeSalidas
            // 
            pnlBordeSalidas.BackColor = Color.FromArgb(234, 88, 12);
            pnlBordeSalidas.Dock = DockStyle.Left;
            pnlBordeSalidas.Location = new Point(0, 0);
            pnlBordeSalidas.Name = "pnlBordeSalidas";
            pnlBordeSalidas.Size = new Size(7, 125);
            pnlBordeSalidas.TabIndex = 0;
            // 
            // lblKpiSalidas
            // 
            lblKpiSalidas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiSalidas.ForeColor = Color.FromArgb(30, 41, 59);
            lblKpiSalidas.Location = new Point(16, 48);
            lblKpiSalidas.Name = "lblKpiSalidas";
            lblKpiSalidas.Size = new Size(205, 58);
            lblKpiSalidas.TabIndex = 2;
            lblKpiSalidas.Text = "0";
            // 
            // lblTitSalidas
            // 
            lblTitSalidas.AutoSize = true;
            lblTitSalidas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitSalidas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitSalidas.Location = new Point(18, 16);
            lblTitSalidas.Name = "lblTitSalidas";
            lblTitSalidas.Size = new Size(167, 15);
            lblTitSalidas.TabIndex = 1;
            lblTitSalidas.Text = "SALIDAS PROGRAMADAS HOY";
            // 
            // pnlCardLlegadas
            // 
            pnlCardLlegadas.BackColor = Color.White;
            pnlCardLlegadas.Controls.Add(pnlBordeLlegadas);
            pnlCardLlegadas.Controls.Add(lblKpiLlegadas);
            pnlCardLlegadas.Controls.Add(lblTitLlegadas);
            pnlCardLlegadas.Location = new Point(268, 128);
            pnlCardLlegadas.Name = "pnlCardLlegadas";
            pnlCardLlegadas.Size = new Size(230, 125);
            pnlCardLlegadas.TabIndex = 3;
            // 
            // pnlBordeLlegadas
            // 
            pnlBordeLlegadas.BackColor = Color.FromArgb(22, 163, 74);
            pnlBordeLlegadas.Dock = DockStyle.Left;
            pnlBordeLlegadas.Location = new Point(0, 0);
            pnlBordeLlegadas.Name = "pnlBordeLlegadas";
            pnlBordeLlegadas.Size = new Size(7, 125);
            pnlBordeLlegadas.TabIndex = 0;
            // 
            // lblKpiLlegadas
            // 
            lblKpiLlegadas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiLlegadas.ForeColor = Color.FromArgb(30, 41, 59);
            lblKpiLlegadas.Location = new Point(16, 48);
            lblKpiLlegadas.Name = "lblKpiLlegadas";
            lblKpiLlegadas.Size = new Size(205, 58);
            lblKpiLlegadas.TabIndex = 2;
            lblKpiLlegadas.Text = "0";
            // 
            // lblTitLlegadas
            // 
            lblTitLlegadas.AutoSize = true;
            lblTitLlegadas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitLlegadas.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitLlegadas.Location = new Point(18, 16);
            lblTitLlegadas.Name = "lblTitLlegadas";
            lblTitLlegadas.Size = new Size(165, 15);
            lblTitLlegadas.TabIndex = 1;
            lblTitLlegadas.Text = "LLEGADAS PENDIENTES HOY";
            // 
            // pnlCardOcupacion
            // 
            pnlCardOcupacion.BackColor = Color.White;
            pnlCardOcupacion.Controls.Add(pnlBordeOcupacion);
            pnlCardOcupacion.Controls.Add(lblKpiOcupacion);
            pnlCardOcupacion.Controls.Add(lblTitOcupacion);
            pnlCardOcupacion.Location = new Point(24, 128);
            pnlCardOcupacion.Name = "pnlCardOcupacion";
            pnlCardOcupacion.Size = new Size(230, 125);
            pnlCardOcupacion.TabIndex = 2;
            // 
            // pnlBordeOcupacion
            // 
            pnlBordeOcupacion.BackColor = Color.FromArgb(37, 99, 235);
            pnlBordeOcupacion.Dock = DockStyle.Left;
            pnlBordeOcupacion.Location = new Point(0, 0);
            pnlBordeOcupacion.Name = "pnlBordeOcupacion";
            pnlBordeOcupacion.Size = new Size(7, 125);
            pnlBordeOcupacion.TabIndex = 0;
            // 
            // lblKpiOcupacion
            // 
            lblKpiOcupacion.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKpiOcupacion.ForeColor = Color.FromArgb(30, 41, 59);
            lblKpiOcupacion.Location = new Point(16, 48);
            lblKpiOcupacion.Name = "lblKpiOcupacion";
            lblKpiOcupacion.Size = new Size(205, 58);
            lblKpiOcupacion.TabIndex = 2;
            lblKpiOcupacion.Text = "0%";
            // 
            // lblTitOcupacion
            // 
            lblTitOcupacion.AutoSize = true;
            lblTitOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitOcupacion.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitOcupacion.Location = new Point(18, 16);
            lblTitOcupacion.Name = "lblTitOcupacion";
            lblTitOcupacion.Size = new Size(131, 15);
            lblTitOcupacion.TabIndex = 1;
            lblTitOcupacion.Text = "OCUPACION DEL DIA";
            // 
            // pnlAlertaLimpieza
            // 
            pnlAlertaLimpieza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlertaLimpieza.BackColor = Color.FromArgb(254, 249, 195);
            pnlAlertaLimpieza.Controls.Add(lblAlertaLimpieza);
            pnlAlertaLimpieza.Location = new Point(24, 68);
            pnlAlertaLimpieza.Name = "pnlAlertaLimpieza";
            pnlAlertaLimpieza.Size = new Size(962, 42);
            pnlAlertaLimpieza.TabIndex = 1;
            // 
            // lblAlertaLimpieza
            // 
            lblAlertaLimpieza.Dock = DockStyle.Fill;
            lblAlertaLimpieza.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlertaLimpieza.ForeColor = Color.FromArgb(133, 77, 14);
            lblAlertaLimpieza.Location = new Point(0, 0);
            lblAlertaLimpieza.Name = "lblAlertaLimpieza";
            lblAlertaLimpieza.Padding = new Padding(12, 0, 12, 0);
            lblAlertaLimpieza.Size = new Size(962, 42);
            lblAlertaLimpieza.TabIndex = 0;
            lblAlertaLimpieza.Text = "Verificando estado del hotel...";
            lblAlertaLimpieza.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloDashboard
            // 
            lblTituloDashboard.AutoSize = true;
            lblTituloDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloDashboard.ForeColor = Color.FromArgb(30, 41, 59);
            lblTituloDashboard.Location = new Point(24, 22);
            lblTituloDashboard.Name = "lblTituloDashboard";
            lblTituloDashboard.Size = new Size(276, 30);
            lblTituloDashboard.TabIndex = 0;
            lblTituloDashboard.Text = "Panel de Control (Dashboard)";
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
            Text = "Hotel Management System - Recepcion en Tiempo Real";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlMenuLateral.ResumeLayout(false);
            pnlContenedor.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
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
        private Label lblEstadoRealtime;
        private Button btnReconectar;
        private TextBox txtApiUrl;
        private Label lblServidor;
        private Label lblTituloApp;
        private Button btnMenuToggle;
        private Panel pnlMenuLateral;
        private Button btnReportes;
        private Button btnPlatillos;
        private Button btnRestaurante;
        private Button btnClientes;
        private Button btnCheckInOut;
        private Button btnNuevaReserva;
        private Button btnTiposHabitacion;
        private Button btnHabitaciones;
        private Button btnInicio;
        private Panel pnlContenedor;
        private Panel pnlDashboard;
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
        private Label lblTituloDashboard;
    }
}
