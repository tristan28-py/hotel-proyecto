namespace Hotel.WindowsForms.Views
{
    partial class FrmClientes
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
            pnlBusqueda = new Panel();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            dgvClientes = new DataGridView();
            pnlHistorial = new Panel();
            dgvHistorial = new DataGridView();
            lblResumenHist = new Label();
            pnlFormulario = new Panel();
            btnGuardar = new Button();
            btnNuevo = new Button();
            chkFrecuente = new CheckBox();
            txtPreferencias = new TextBox();
            txtDireccion = new TextBox();
            txtTelEmergencia = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtNacionalidad = new TextBox();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            txtDoc = new TextBox();
            cboTipoDoc = new ComboBox();
            lblPreferencias = new Label();
            lblDireccion = new Label();
            lblTelEmergencia = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            lblNacionalidad = new Label();
            lblApellidos = new Label();
            lblNombres = new Label();
            lblNumDoc = new Label();
            lblTipoDoc = new Label();
            lblTituloForm = new Label();
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            pnlFormulario.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBusqueda.BackColor = Color.White;
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblBuscar);
            pnlBusqueda.Location = new Point(14, 12);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(996, 46);
            pnlBusqueda.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(492, 9);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(96, 28);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(220, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(262, 23);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBuscar.Location = new Point(14, 15);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(197, 17);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar por ID, Nombre o Correo:";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(14, 66);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(605, 315);
            dgvClientes.TabIndex = 1;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // pnlHistorial
            // 
            pnlHistorial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlHistorial.BackColor = Color.White;
            pnlHistorial.BorderStyle = BorderStyle.FixedSingle;
            pnlHistorial.Controls.Add(dgvHistorial);
            pnlHistorial.Controls.Add(lblResumenHist);
            pnlHistorial.Location = new Point(14, 389);
            pnlHistorial.Name = "pnlHistorial";
            pnlHistorial.Size = new Size(605, 235);
            pnlHistorial.TabIndex = 2;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(0, 28);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(603, 205);
            dgvHistorial.TabIndex = 1;
            // 
            // lblResumenHist
            // 
            lblResumenHist.Dock = DockStyle.Top;
            lblResumenHist.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResumenHist.Location = new Point(0, 0);
            lblResumenHist.Name = "lblResumenHist";
            lblResumenHist.Padding = new Padding(8, 5, 8, 0);
            lblResumenHist.Size = new Size(603, 28);
            lblResumenHist.TabIndex = 0;
            lblResumenHist.Text = "Historial de Estadias del Cliente";
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(btnNuevo);
            pnlFormulario.Controls.Add(chkFrecuente);
            pnlFormulario.Controls.Add(txtPreferencias);
            pnlFormulario.Controls.Add(txtDireccion);
            pnlFormulario.Controls.Add(txtTelEmergencia);
            pnlFormulario.Controls.Add(txtTelefono);
            pnlFormulario.Controls.Add(txtEmail);
            pnlFormulario.Controls.Add(txtNacionalidad);
            pnlFormulario.Controls.Add(txtApellidos);
            pnlFormulario.Controls.Add(txtNombres);
            pnlFormulario.Controls.Add(txtDoc);
            pnlFormulario.Controls.Add(cboTipoDoc);
            pnlFormulario.Controls.Add(lblPreferencias);
            pnlFormulario.Controls.Add(lblDireccion);
            pnlFormulario.Controls.Add(lblTelEmergencia);
            pnlFormulario.Controls.Add(lblTelefono);
            pnlFormulario.Controls.Add(lblEmail);
            pnlFormulario.Controls.Add(lblNacionalidad);
            pnlFormulario.Controls.Add(lblApellidos);
            pnlFormulario.Controls.Add(lblNombres);
            pnlFormulario.Controls.Add(lblNumDoc);
            pnlFormulario.Controls.Add(lblTipoDoc);
            pnlFormulario.Controls.Add(lblTituloForm);
            pnlFormulario.Location = new Point(630, 66);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(380, 558);
            pnlFormulario.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(138, 468);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 36);
            btnGuardar.TabIndex = 23;
            btnGuardar.Text = "Guardar Cliente";
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
            btnNuevo.Location = new Point(16, 468);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 36);
            btnNuevo.TabIndex = 22;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // chkFrecuente
            // 
            chkFrecuente.AutoSize = true;
            chkFrecuente.Location = new Point(138, 430);
            chkFrecuente.Name = "chkFrecuente";
            chkFrecuente.Size = new Size(192, 19);
            chkFrecuente.TabIndex = 21;
            chkFrecuente.Text = "Cliente Frecuente (10% desc.)";
            chkFrecuente.UseVisualStyleBackColor = true;
            // 
            // txtPreferencias
            // 
            txtPreferencias.Location = new Point(138, 392);
            txtPreferencias.Name = "txtPreferencias";
            txtPreferencias.Size = new Size(220, 23);
            txtPreferencias.TabIndex = 20;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(138, 356);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(220, 23);
            txtDireccion.TabIndex = 19;
            // 
            // txtTelEmergencia
            // 
            txtTelEmergencia.Location = new Point(138, 320);
            txtTelEmergencia.Name = "txtTelEmergencia";
            txtTelEmergencia.Size = new Size(220, 23);
            txtTelEmergencia.TabIndex = 18;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(138, 284);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(220, 23);
            txtTelefono.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(138, 248);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 16;
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(138, 212);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(220, 23);
            txtNacionalidad.TabIndex = 15;
            txtNacionalidad.Text = "Costarricense";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(138, 176);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(220, 23);
            txtApellidos.TabIndex = 14;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(138, 140);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(220, 23);
            txtNombres.TabIndex = 13;
            // 
            // txtDoc
            // 
            txtDoc.Location = new Point(138, 104);
            txtDoc.Name = "txtDoc";
            txtDoc.Size = new Size(220, 23);
            txtDoc.TabIndex = 12;
            // 
            // cboTipoDoc
            // 
            cboTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDoc.FormattingEnabled = true;
            cboTipoDoc.Items.AddRange(new object[] { "Cedula", "DNI", "Pasaporte" });
            cboTipoDoc.Location = new Point(138, 68);
            cboTipoDoc.Name = "cboTipoDoc";
            cboTipoDoc.Size = new Size(220, 23);
            cboTipoDoc.TabIndex = 11;
            // 
            // lblPreferencias
            // 
            lblPreferencias.AutoSize = true;
            lblPreferencias.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreferencias.Location = new Point(16, 395);
            lblPreferencias.Name = "lblPreferencias";
            lblPreferencias.Size = new Size(84, 15);
            lblPreferencias.TabIndex = 10;
            lblPreferencias.Text = "Preferencias:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDireccion.Location = new Point(16, 359);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(65, 15);
            lblDireccion.TabIndex = 9;
            lblDireccion.Text = "Direccion:";
            // 
            // lblTelEmergencia
            // 
            lblTelEmergencia.AutoSize = true;
            lblTelEmergencia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelEmergencia.Location = new Point(16, 323);
            lblTelEmergencia.Name = "lblTelEmergencia";
            lblTelEmergencia.Size = new Size(105, 15);
            lblTelEmergencia.TabIndex = 8;
            lblTelEmergencia.Text = "Tel. Emergencia:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.Location = new Point(16, 287);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(61, 15);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Telefono:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(16, 251);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Correo:";
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNacionalidad.Location = new Point(16, 215);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(88, 15);
            lblNacionalidad.TabIndex = 5;
            lblNacionalidad.Text = "Nacionalidad:";
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellidos.Location = new Point(16, 179);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(64, 15);
            lblApellidos.TabIndex = 4;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.Location = new Point(16, 143);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(64, 15);
            lblNombres.TabIndex = 3;
            lblNombres.Text = "Nombres:";
            // 
            // lblNumDoc
            // 
            lblNumDoc.AutoSize = true;
            lblNumDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumDoc.Location = new Point(16, 107);
            lblNumDoc.Name = "lblNumDoc";
            lblNumDoc.Size = new Size(99, 15);
            lblNumDoc.TabIndex = 2;
            lblNumDoc.Text = "No. Documento:";
            // 
            // lblTipoDoc
            // 
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoDoc.Location = new Point(16, 71);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(66, 15);
            lblTipoDoc.TabIndex = 1;
            lblTipoDoc.Text = "Tipo Doc.:";
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(30, 41, 59);
            lblTituloForm.Location = new Point(16, 18);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(138, 20);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Datos del Cliente";
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlHistorial);
            Controls.Add(dgvClientes);
            Controls.Add(pnlBusqueda);
            Name = "FrmClientes";
            Text = "Gestion de Clientes y Huespedes";
            Load += FrmClientes_Load;
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView dgvClientes;
        private Panel pnlHistorial;
        private DataGridView dgvHistorial;
        private Label lblResumenHist;
        private Panel pnlFormulario;
        private Button btnGuardar;
        private Button btnNuevo;
        private CheckBox chkFrecuente;
        private TextBox txtPreferencias;
        private TextBox txtDireccion;
        private TextBox txtTelEmergencia;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtNacionalidad;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private TextBox txtDoc;
        private ComboBox cboTipoDoc;
        private Label lblPreferencias;
        private Label lblDireccion;
        private Label lblTelEmergencia;
        private Label lblTelefono;
        private Label lblEmail;
        private Label lblNacionalidad;
        private Label lblApellidos;
        private Label lblNombres;
        private Label lblNumDoc;
        private Label lblTipoDoc;
        private Label lblTituloForm;
    }
}
