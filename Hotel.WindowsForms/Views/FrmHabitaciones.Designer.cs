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
            flpLeyenda = new FlowLayoutPanel();
            lblLegDisponible = new Label();
            lblLegOcupada = new Label();
            lblLegLimpieza = new Label();
            lblLegReservada = new Label();
            lblLegMantenimiento = new Label();
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
            flpLeyenda.SuspendLayout();
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
            lblTitulo.Font = new Font("Georgia", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 30, 54);
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(348, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mapa y Administracion de Habitaciones";
            // 
            // pnlLeyenda
            // 
            pnlLeyenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLeyenda.BackColor = Color.White;
            pnlLeyenda.BorderStyle = BorderStyle.FixedSingle;
            pnlLeyenda.Controls.Add(btnActualizar);
            pnlLeyenda.Controls.Add(flpLeyenda);
            pnlLeyenda.Location = new Point(16, 44);
            pnlLeyenda.Name = "pnlLeyenda";
            pnlLeyenda.Size = new Size(1042, 46);
            pnlLeyenda.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BackColor = Color.FromArgb(15, 30, 54);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(920, 7);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // flpLeyenda
            // 
            flpLeyenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpLeyenda.Controls.Add(lblLegDisponible);
            flpLeyenda.Controls.Add(lblLegOcupada);
            flpLeyenda.Controls.Add(lblLegLimpieza);
            flpLeyenda.Controls.Add(lblLegReservada);
            flpLeyenda.Controls.Add(lblLegMantenimiento);
            flpLeyenda.Location = new Point(6, 6);
            flpLeyenda.Name = "flpLeyenda";
            flpLeyenda.Size = new Size(904, 34);
            flpLeyenda.TabIndex = 0;
            // 
            // lblLegDisponible
            // 
            lblLegDisponible.AutoSize = true;
            lblLegDisponible.BackColor = Color.FromArgb(21, 128, 61);
            lblLegDisponible.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegDisponible.ForeColor = Color.White;
            lblLegDisponible.Location = new Point(3, 3);
            lblLegDisponible.Margin = new Padding(3, 3, 6, 3);
            lblLegDisponible.Name = "lblLegDisponible";
            lblLegDisponible.Padding = new Padding(10, 4, 10, 4);
            lblLegDisponible.Size = new Size(85, 23);
            lblLegDisponible.TabIndex = 0;
            lblLegDisponible.Text = "Disponible";
            // 
            // lblLegOcupada
            // 
            lblLegOcupada.AutoSize = true;
            lblLegOcupada.BackColor = Color.FromArgb(185, 28, 28);
            lblLegOcupada.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegOcupada.ForeColor = Color.White;
            lblLegOcupada.Location = new Point(97, 3);
            lblLegOcupada.Margin = new Padding(3, 3, 6, 3);
            lblLegOcupada.Name = "lblLegOcupada";
            lblLegOcupada.Padding = new Padding(10, 4, 10, 4);
            lblLegOcupada.Size = new Size(74, 23);
            lblLegOcupada.TabIndex = 1;
            lblLegOcupada.Text = "Ocupada";
            // 
            // lblLegLimpieza
            // 
            lblLegLimpieza.AutoSize = true;
            lblLegLimpieza.BackColor = Color.FromArgb(217, 119, 6);
            lblLegLimpieza.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegLimpieza.ForeColor = Color.White;
            lblLegLimpieza.Location = new Point(180, 3);
            lblLegLimpieza.Margin = new Padding(3, 3, 6, 3);
            lblLegLimpieza.Name = "lblLegLimpieza";
            lblLegLimpieza.Padding = new Padding(10, 4, 10, 4);
            lblLegLimpieza.Size = new Size(87, 23);
            lblLegLimpieza.TabIndex = 2;
            lblLegLimpieza.Text = "EnLimpieza";
            // 
            // lblLegReservada
            // 
            lblLegReservada.AutoSize = true;
            lblLegReservada.BackColor = Color.FromArgb(29, 78, 216);
            lblLegReservada.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegReservada.ForeColor = Color.White;
            lblLegReservada.Location = new Point(276, 3);
            lblLegReservada.Margin = new Padding(3, 3, 6, 3);
            lblLegReservada.Name = "lblLegReservada";
            lblLegReservada.Padding = new Padding(10, 4, 10, 4);
            lblLegReservada.Size = new Size(82, 23);
            lblLegReservada.TabIndex = 3;
            lblLegReservada.Text = "Reservada";
            // 
            // lblLegMantenimiento
            // 
            lblLegMantenimiento.AutoSize = true;
            lblLegMantenimiento.BackColor = Color.FromArgb(75, 85, 99);
            lblLegMantenimiento.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblLegMantenimiento.ForeColor = Color.White;
            lblLegMantenimiento.Location = new Point(367, 3);
            lblLegMantenimiento.Margin = new Padding(3, 3, 6, 3);
            lblLegMantenimiento.Name = "lblLegMantenimiento";
            lblLegMantenimiento.Padding = new Padding(10, 4, 10, 4);
            lblLegMantenimiento.Size = new Size(176, 23);
            lblLegMantenimiento.TabIndex = 4;
            lblLegMantenimiento.Text = "Mantenimiento / Bloqueada";
            // 
            // tabHabitaciones
            // 
            tabHabitaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabHabitaciones.Controls.Add(tabMapa);
            tabHabitaciones.Controls.Add(tabListado);
            tabHabitaciones.Location = new Point(16, 98);
            tabHabitaciones.Name = "tabHabitaciones";
            tabHabitaciones.SelectedIndex = 0;
            tabHabitaciones.Size = new Size(646, 578);
            tabHabitaciones.TabIndex = 2;
            // 
            // tabMapa
            // 
            tabMapa.BackColor = Color.FromArgb(247, 245, 240);
            tabMapa.Controls.Add(flpMapa);
            tabMapa.Location = new Point(4, 24);
            tabMapa.Name = "tabMapa";
            tabMapa.Padding = new Padding(4);
            tabMapa.Size = new Size(638, 550);
            tabMapa.TabIndex = 0;
            tabMapa.Text = "Mapa Visual por Colores";
            // 
            // flpMapa
            // 
            flpMapa.AutoScroll = true;
            flpMapa.Dock = DockStyle.Fill;
            flpMapa.Location = new Point(4, 4);
            flpMapa.Name = "flpMapa";
            flpMapa.Padding = new Padding(8);
            flpMapa.Size = new Size(630, 542);
            flpMapa.TabIndex = 0;
            // 
            // tabListado
            // 
            tabListado.Controls.Add(dgvHabitaciones);
            tabListado.Location = new Point(4, 24);
            tabListado.Name = "tabListado";
            tabListado.Padding = new Padding(4);
            tabListado.Size = new Size(638, 550);
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
            dgvHabitaciones.Location = new Point(4, 4);
            dgvHabitaciones.MultiSelect = false;
            dgvHabitaciones.Name = "dgvHabitaciones";
            dgvHabitaciones.ReadOnly = true;
            dgvHabitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHabitaciones.Size = new Size(630, 542);
            dgvHabitaciones.TabIndex = 0;
            dgvHabitaciones.CellClick += dgvHabitaciones_CellClick;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlFormulario.AutoScroll = true;
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
            pnlFormulario.Location = new Point(674, 98);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Padding = new Padding(12);
            pnlFormulario.Size = new Size(384, 578);
            pnlFormulario.TabIndex = 3;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(185, 28, 28);
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.White;
            btnDesactivar.Location = new Point(196, 434);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(166, 36);
            btnDesactivar.TabIndex = 19;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnEstadoRapido
            // 
            btnEstadoRapido.BackColor = Color.FromArgb(21, 128, 61);
            btnEstadoRapido.FlatAppearance.BorderSize = 0;
            btnEstadoRapido.FlatStyle = FlatStyle.Flat;
            btnEstadoRapido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEstadoRapido.ForeColor = Color.White;
            btnEstadoRapido.Location = new Point(18, 434);
            btnEstadoRapido.Name = "btnEstadoRapido";
            btnEstadoRapido.Size = new Size(168, 36);
            btnEstadoRapido.TabIndex = 18;
            btnEstadoRapido.Text = "Cambiar Estado";
            btnEstadoRapido.UseVisualStyleBackColor = false;
            btnEstadoRapido.Click += btnEstadoRapido_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(15, 30, 54);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(196, 386);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(166, 36);
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
            btnNuevo.Location = new Point(18, 386);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(168, 36);
            btnNuevo.TabIndex = 16;
            btnNuevo.Text = "Nueva / Limpiar";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtAmenidades
            // 
            txtAmenidades.Location = new Point(120, 304);
            txtAmenidades.Multiline = true;
            txtAmenidades.Name = "txtAmenidades";
            txtAmenidades.Size = new Size(242, 62);
            txtAmenidades.TabIndex = 15;
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Checked = true;
            chkActiva.CheckState = CheckState.Checked;
            chkActiva.Location = new Point(226, 266);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(121, 19);
            chkActiva.TabIndex = 14;
            chkActiva.Text = "Habitacion Activa";
            chkActiva.UseVisualStyleBackColor = true;
            // 
            // chkFrigobar
            // 
            chkFrigobar.AutoSize = true;
            chkFrigobar.Location = new Point(120, 266);
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
            chkWifi6.Location = new Point(18, 266);
            chkWifi6.Name = "chkWifi6";
            chkWifi6.Size = new Size(62, 19);
            chkWifi6.TabIndex = 12;
            chkWifi6.Text = "Wi-Fi 6";
            chkWifi6.UseVisualStyleBackColor = true;
            // 
            // chkVistaMar
            // 
            chkVistaMar.AutoSize = true;
            chkVistaMar.Location = new Point(120, 236);
            chkVistaMar.Name = "chkVistaMar";
            chkVistaMar.Size = new Size(92, 19);
            chkVistaMar.TabIndex = 11;
            chkVistaMar.Text = "Vista al Mar";
            chkVistaMar.UseVisualStyleBackColor = true;
            // 
            // chkJacuzzi
            // 
            chkJacuzzi.AutoSize = true;
            chkJacuzzi.Location = new Point(18, 236);
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
            cboEstado.Location = new Point(120, 190);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(242, 23);
            cboEstado.TabIndex = 9;
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(120, 148);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(242, 23);
            cboTipo.TabIndex = 8;
            // 
            // numPiso
            // 
            numPiso.Location = new Point(120, 108);
            numPiso.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numPiso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPiso.Name = "numPiso";
            numPiso.Size = new Size(242, 23);
            numPiso.TabIndex = 7;
            numPiso.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(120, 68);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(242, 23);
            txtNumero.TabIndex = 6;
            // 
            // lblAmenidades
            // 
            lblAmenidades.AutoSize = true;
            lblAmenidades.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAmenidades.Location = new Point(18, 307);
            lblAmenidades.Name = "lblAmenidades";
            lblAmenidades.Size = new Size(51, 17);
            lblAmenidades.TabIndex = 5;
            lblAmenidades.Text = "Extras:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstado.Location = new Point(18, 193);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(54, 17);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTipo.Location = new Point(18, 151);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(40, 17);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPiso.Location = new Point(18, 110);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(38, 17);
            lblPiso.TabIndex = 2;
            lblPiso.Text = "Piso:";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNumero.Location = new Point(18, 71);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(61, 17);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Numero:";
            // 
            // lblSeleccion
            // 
            lblSeleccion.AutoSize = true;
            lblSeleccion.Font = new Font("Georgia", 11.5F, FontStyle.Bold);
            lblSeleccion.ForeColor = Color.FromArgb(15, 30, 54);
            lblSeleccion.Location = new Point(18, 20);
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.Size = new Size(148, 19);
            lblSeleccion.TabIndex = 0;
            lblSeleccion.Text = "Nueva Habitacion";
            // 
            // FrmHabitaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 240);
            ClientSize = new Size(1074, 690);
            Controls.Add(pnlFormulario);
            Controls.Add(tabHabitaciones);
            Controls.Add(pnlLeyenda);
            Controls.Add(lblTitulo);
            Name = "FrmHabitaciones";
            Text = "Mapa y Administracion de Habitaciones";
            FormClosed += FrmHabitaciones_FormClosed;
            Load += FrmHabitaciones_Load;
            pnlLeyenda.ResumeLayout(false);
            flpLeyenda.ResumeLayout(false);
            flpLeyenda.PerformLayout();
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
        private FlowLayoutPanel flpLeyenda;
        private Label lblLegDisponible;
        private Label lblLegOcupada;
        private Label lblLegLimpieza;
        private Label lblLegReservada;
        private Label lblLegMantenimiento;
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
