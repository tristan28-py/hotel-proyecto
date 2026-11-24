namespace Hotel.WindowsForms.Views
{
    partial class FrmHabitaciones
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
            lblTitulo = new Label();
            pnlLeyenda = new Panel();
            btnActualizar = new Button();
            lblLegMantenimiento = new Label();
            lblLegReservada = new Label();
            lblLegLimpieza = new Label();
            lblLegOcupada = new Label();
            lblLegDisponible = new Label();
            tabHabitaciones = new TabControl();
            tabMapa = new TabPage();
            flpMapa = new FlowLayoutPanel();
            tabListado = new TabPage();
            dgvHabitaciones = new DataGridView();
            pnlFormulario = new Panel();
            btnDesactivar = new Button();
            btnEstadoRapido = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtAmenidades = new TextBox();
            chkActiva = new CheckBox();
            chkFrigobar = new CheckBox();
            chkWifi6 = new CheckBox();
            chkVistaMar = new CheckBox();
            chkJacuzzi = new CheckBox();
            cboEstado = new ComboBox();
            cboTipo = new ComboBox();
            numPiso = new NumericUpDown();
            txtNumero = new TextBox();
            lblAmenidades = new Label();
            lblEstado = new Label();
            lblTipo = new Label();
            lblPiso = new Label();
            lblNumero = new Label();
            lblSeleccion = new Label();
            pnlLeyenda.SuspendLayout();
            tabHabitaciones.SuspendLayout();
            tabMapa.SuspendLayout();
            tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHabitaciones).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPiso).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitulo.Location = new Point(14, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mapa y Administracion de Habitaciones";
            // 
            // pnlLeyenda
            // 
            pnlLeyenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLeyenda.BackColor = Color.White;
            pnlLeyenda.Controls.Add(btnActualizar);
            pnlLeyenda.Controls.Add(lblLegMantenimiento);
            pnlLeyenda.Controls.Add(lblLegReservada);
            pnlLeyenda.Controls.Add(lblLegLimpieza);
            pnlLeyenda.Controls.Add(lblLegOcupada);
            pnlLeyenda.Controls.Add(lblLegDisponible);
            pnlLeyenda.Location = new Point(14, 42);
            pnlLeyenda.Name = "pnlLeyenda";
            pnlLeyenda.Size = new Size(996, 40);
            pnlLeyenda.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BackColor = Color.FromArgb(37, 99, 235);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(884, 6);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 28);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblLegMantenimiento
            // 
            lblLegMantenimiento.BackColor = Color.FromArgb(107, 114, 128);
            lblLegMantenimiento.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegMantenimiento.ForeColor = Color.White;
            lblLegMantenimiento.Location = new Point(408, 8);
            lblLegMantenimiento.Name = "lblLegMantenimiento";
            lblLegMantenimiento.Size = new Size(170, 24);
            lblLegMantenimiento.TabIndex = 4;
            lblLegMantenimiento.Text = "Mantenimiento / Bloqueada";
            lblLegMantenimiento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegReservada
            // 
            lblLegReservada.BackColor = Color.FromArgb(37, 99, 235);
            lblLegReservada.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegReservada.ForeColor = Color.White;
            lblLegReservada.Location = new Point(308, 8);
            lblLegReservada.Name = "lblLegReservada";
            lblLegReservada.Size = new Size(92, 24);
            lblLegReservada.TabIndex = 3;
            lblLegReservada.Text = "Reservada";
            lblLegReservada.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegLimpieza
            // 
            lblLegLimpieza.BackColor = Color.FromArgb(234, 179, 8);
            lblLegLimpieza.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegLimpieza.ForeColor = Color.Black;
            lblLegLimpieza.Location = new Point(206, 8);
            lblLegLimpieza.Name = "lblLegLimpieza";
            lblLegLimpieza.Size = new Size(94, 24);
            lblLegLimpieza.TabIndex = 2;
            lblLegLimpieza.Text = "EnLimpieza";
            lblLegLimpieza.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegOcupada
            // 
            lblLegOcupada.BackColor = Color.FromArgb(220, 38, 38);
            lblLegOcupada.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegOcupada.ForeColor = Color.White;
            lblLegOcupada.Location = new Point(112, 8);
            lblLegOcupada.Name = "lblLegOcupada";
            lblLegOcupada.Size = new Size(86, 24);
            lblLegOcupada.TabIndex = 1;
            lblLegOcupada.Text = "Ocupada";
            lblLegOcupada.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegDisponible
            // 
            lblLegDisponible.BackColor = Color.FromArgb(22, 163, 74);
            lblLegDisponible.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegDisponible.ForeColor = Color.White;
            lblLegDisponible.Location = new Point(12, 8);
            lblLegDisponible.Name = "lblLegDisponible";
            lblLegDisponible.Size = new Size(92, 24);
            lblLegDisponible.TabIndex = 0;
            lblLegDisponible.Text = "Disponible";
            lblLegDisponible.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabHabitaciones
            // 
            tabHabitaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabHabitaciones.Controls.Add(tabMapa);
            tabHabitaciones.Controls.Add(tabListado);
            tabHabitaciones.Location = new Point(14, 90);
            tabHabitaciones.Name = "tabHabitaciones";
            tabHabitaciones.SelectedIndex = 0;
            tabHabitaciones.Size = new Size(612, 535);
            tabHabitaciones.TabIndex = 2;
            // 
            // tabMapa
            // 
            tabMapa.BackColor = Color.FromArgb(243, 246, 250);
            tabMapa.Controls.Add(flpMapa);
            tabMapa.Location = new Point(4, 24);
            tabMapa.Name = "tabMapa";
            tabMapa.Padding = new Padding(3);
            tabMapa.Size = new Size(604, 507);
            tabMapa.TabIndex = 0;
            tabMapa.Text = "Mapa Visual por Colores";
            // 
            // flpMapa
            // 
            flpMapa.AutoScroll = true;
            flpMapa.Dock = DockStyle.Fill;
            flpMapa.Location = new Point(3, 3);
            flpMapa.Name = "flpMapa";
            flpMapa.Padding = new Padding(8);
            flpMapa.Size = new Size(598, 501);
            flpMapa.TabIndex = 0;
            // 
            // tabListado
            // 
            tabListado.Controls.Add(dgvHabitaciones);
            tabListado.Location = new Point(4, 24);
            tabListado.Name = "tabListado";
            tabListado.Padding = new Padding(3);
            tabListado.Size = new Size(604, 507);
            tabListado.TabIndex = 1;
            tabListado.Text = "Listado Detallado";
            tabListado.UseVisualStyleBackColor = true;
            // 
            // dgvHabitaciones
            // 
            dgvHabitaciones.AllowUserToAddRows = false;
            dgvHabitaciones.AllowUserToDeleteRows = false;
            dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHabitaciones.BackgroundColor = Color.White;
            dgvHabitaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHabitaciones.Dock = DockStyle.Fill;
            dgvHabitaciones.Location = new Point(3, 3);
            dgvHabitaciones.MultiSelect = false;
            dgvHabitaciones.Name = "dgvHabitaciones";
            dgvHabitaciones.ReadOnly = true;
            dgvHabitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHabitaciones.Size = new Size(598, 501);
            dgvHabitaciones.TabIndex = 0;
            dgvHabitaciones.CellClick += dgvHabitaciones_CellClick;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnDesactivar);
            pnlFormulario.Controls.Add(btnEstadoRapido);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(btnNuevo);
            pnlFormulario.Controls.Add(txtAmenidades);
            pnlFormulario.Controls.Add(chkActiva);
            pnlFormulario.Controls.Add(chkFrigobar);
            pnlFormulario.Controls.Add(chkWifi6);
            pnlFormulario.Controls.Add(chkVistaMar);
            pnlFormulario.Controls.Add(chkJacuzzi);
            pnlFormulario.Controls.Add(cboEstado);
            pnlFormulario.Controls.Add(cboTipo);
            pnlFormulario.Controls.Add(numPiso);
            pnlFormulario.Controls.Add(txtNumero);
            pnlFormulario.Controls.Add(lblAmenidades);
            pnlFormulario.Controls.Add(lblEstado);
            pnlFormulario.Controls.Add(lblTipo);
            pnlFormulario.Controls.Add(lblPiso);
            pnlFormulario.Controls.Add(lblNumero);
            pnlFormulario.Controls.Add(lblSeleccion);
            pnlFormulario.Location = new Point(638, 90);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(372, 535);
            pnlFormulario.TabIndex = 3;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(220, 38, 38);
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.White;
            btnDesactivar.Location = new Point(192, 412);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(158, 34);
            btnDesactivar.TabIndex = 19;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnEstadoRapido
            // 
            btnEstadoRapido.BackColor = Color.FromArgb(22, 163, 74);
            btnEstadoRapido.FlatAppearance.BorderSize = 0;
            btnEstadoRapido.FlatStyle = FlatStyle.Flat;
            btnEstadoRapido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEstadoRapido.ForeColor = Color.White;
            btnEstadoRapido.Location = new Point(18, 412);
            btnEstadoRapido.Name = "btnEstadoRapido";
            btnEstadoRapido.Size = new Size(162, 34);
            btnEstadoRapido.TabIndex = 18;
            btnEstadoRapido.Text = "Cambiar Estado";
            btnEstadoRapido.UseVisualStyleBackColor = false;
            btnEstadoRapido.Click += btnEstadoRapido_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(192, 368);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(158, 34);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(100, 116, 139);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(18, 368);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(162, 34);
            btnNuevo.TabIndex = 16;
            btnNuevo.Text = "Nueva / Limpiar";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtAmenidades
            // 
            txtAmenidades.Location = new Point(118, 294);
            txtAmenidades.Multiline = true;
            txtAmenidades.Name = "txtAmenidades";
            txtAmenidades.Size = new Size(232, 56);
            txtAmenidades.TabIndex = 15;
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Checked = true;
            chkActiva.CheckState = CheckState.Checked;
            chkActiva.Location = new Point(222, 258);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(121, 19);
            chkActiva.TabIndex = 14;
            chkActiva.Text = "Habitacion Activa";
            chkActiva.UseVisualStyleBackColor = true;
            // 
            // chkFrigobar
            // 
            chkFrigobar.AutoSize = true;
            chkFrigobar.Location = new Point(118, 258);
            chkFrigobar.Name = "chkFrigobar";
            chkFrigobar.Size = new Size(71, 19);
            chkFrigobar.TabIndex = 13;
            chkFrigobar.Text = "Frigobar";
            chkFrigobar.UseVisualStyleBackColor = true;
            // 
            // chkWifi6
            // 
            chkWifi6.AutoSize = true;
            chkWifi6.Checked = true;
            chkWifi6.CheckState = CheckState.Checked;
            chkWifi6.Location = new Point(18, 258);
            chkWifi6.Name = "chkWifi6";
            chkWifi6.Size = new Size(62, 19);
            chkWifi6.TabIndex = 12;
            chkWifi6.Text = "Wi-Fi 6";
            chkWifi6.UseVisualStyleBackColor = true;
            // 
            // chkVistaMar
            // 
            chkVistaMar.AutoSize = true;
            chkVistaMar.Location = new Point(118, 230);
            chkVistaMar.Name = "chkVistaMar";
            chkVistaMar.Size = new Size(92, 19);
            chkVistaMar.TabIndex = 11;
            chkVistaMar.Text = "Vista al Mar";
            chkVistaMar.UseVisualStyleBackColor = true;
            // 
            // chkJacuzzi
            // 
            chkJacuzzi.AutoSize = true;
            chkJacuzzi.Location = new Point(18, 230);
            chkJacuzzi.Name = "chkJacuzzi";
            chkJacuzzi.Size = new Size(64, 19);
            chkJacuzzi.TabIndex = 10;
            chkJacuzzi.Text = "Jacuzzi";
            chkJacuzzi.UseVisualStyleBackColor = true;
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Disponible", "Reservada", "Ocupada", "EnLimpieza", "EnMantenimiento", "Bloqueada" });
            cboEstado.Location = new Point(118, 184);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(232, 23);
            cboEstado.TabIndex = 9;
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(118, 144);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(232, 23);
            cboTipo.TabIndex = 8;
            // 
            // numPiso
            // 
            numPiso.Location = new Point(118, 104);
            numPiso.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numPiso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPiso.Name = "numPiso";
            numPiso.Size = new Size(232, 23);
            numPiso.TabIndex = 7;
            numPiso.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(118, 64);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(232, 23);
            txtNumero.TabIndex = 6;
            // 
            // lblAmenidades
            // 
            lblAmenidades.AutoSize = true;
            lblAmenidades.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAmenidades.Location = new Point(18, 297);
            lblAmenidades.Name = "lblAmenidades";
            lblAmenidades.Size = new Size(51, 17);
            lblAmenidades.TabIndex = 5;
            lblAmenidades.Text = "Extras:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstado.Location = new Point(18, 187);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(54, 17);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTipo.Location = new Point(18, 147);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(40, 17);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPiso.Location = new Point(18, 106);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(38, 17);
            lblPiso.TabIndex = 2;
            lblPiso.Text = "Piso:";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNumero.Location = new Point(18, 67);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(61, 17);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Numero:";
            // 
            // lblSeleccion
            // 
            lblSeleccion.AutoSize = true;
            lblSeleccion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSeleccion.ForeColor = Color.FromArgb(30, 41, 59);
            lblSeleccion.Location = new Point(18, 18);
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.Size = new Size(138, 20);
            lblSeleccion.TabIndex = 0;
            lblSeleccion.Text = "Nueva Habitacion";
            // 
            // FrmHabitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlFormulario);
            Controls.Add(tabHabitaciones);
            Controls.Add(pnlLeyenda);
            Controls.Add(lblTitulo);
            Name = "FrmHabitaciones";
            Text = "Mapa y Administracion de Habitaciones";
            FormClosed += FrmHabitaciones_FormClosed;
            Load += FrmHabitaciones_Load;
            pnlLeyenda.ResumeLayout(false);
            tabHabitaciones.ResumeLayout(false);
            tabMapa.ResumeLayout(false);
            tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHabitaciones).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPiso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlLeyenda;
        private Button btnActualizar;
        private Label lblLegMantenimiento;
        private Label lblLegReservada;
        private Label lblLegLimpieza;
        private Label lblLegOcupada;
        private Label lblLegDisponible;
        private TabControl tabHabitaciones;
        private TabPage tabMapa;
        private FlowLayoutPanel flpMapa;
        private TabPage tabListado;
        private DataGridView dgvHabitaciones;
        private Panel pnlFormulario;
        private Button btnDesactivar;
        private Button btnEstadoRapido;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtAmenidades;
        private CheckBox chkActiva;
        private CheckBox chkFrigobar;
        private CheckBox chkWifi6;
        private CheckBox chkVistaMar;
        private CheckBox chkJacuzzi;
        private ComboBox cboEstado;
        private ComboBox cboTipo;
        private NumericUpDown numPiso;
        private TextBox txtNumero;
        private Label lblAmenidades;
        private Label lblEstado;
        private Label lblTipo;
        private Label lblPiso;
        private Label lblNumero;
        private Label lblSeleccion;
    }
}
