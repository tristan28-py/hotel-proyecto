namespace Hotel.WindowsForms.Views
{
    partial class FrmUsuarios
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
            dgvUsuarios = new DataGridView();
            pnlFormulario = new Panel();
            btnDesactivar = new Button();
            btnActivar = new Button();
            btnCrear = new Button();
            cboRol = new ComboBox();
            txtNombreCompleto = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblRol = new Label();
            lblNombreCompleto = new Label();
            lblPass = new Label();
            lblUser = new Label();
            lblSubtitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlFormulario.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Georgia", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 30, 54);
            lblTitulo.Location = new Point(16, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(340, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administracion de Usuarios y Roles";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(16, 52);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(600, 560);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnDesactivar);
            pnlFormulario.Controls.Add(btnActivar);
            pnlFormulario.Controls.Add(btnCrear);
            pnlFormulario.Controls.Add(cboRol);
            pnlFormulario.Controls.Add(txtNombreCompleto);
            pnlFormulario.Controls.Add(txtPassword);
            pnlFormulario.Controls.Add(txtUsername);
            pnlFormulario.Controls.Add(lblRol);
            pnlFormulario.Controls.Add(lblNombreCompleto);
            pnlFormulario.Controls.Add(lblPass);
            pnlFormulario.Controls.Add(lblUser);
            pnlFormulario.Controls.Add(lblSubtitulo);
            pnlFormulario.Location = new Point(630, 52);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(375, 560);
            pnlFormulario.TabIndex = 2;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(185, 28, 28);
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.White;
            btnDesactivar.Location = new Point(192, 286);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(162, 34);
            btnDesactivar.TabIndex = 11;
            btnDesactivar.Text = "Desactivar Seleccionado";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnActivar
            // 
            btnActivar.BackColor = Color.FromArgb(21, 128, 61);
            btnActivar.FlatAppearance.BorderSize = 0;
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnActivar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActivar.ForeColor = Color.White;
            btnActivar.Location = new Point(18, 286);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(164, 34);
            btnActivar.TabIndex = 10;
            btnActivar.Text = "Activar Seleccionado";
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += btnActivar_Click;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(15, 30, 54);
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(18, 236);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(336, 38);
            btnCrear.TabIndex = 9;
            btnCrear.Text = "Crear Cuenta de Usuario";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FormattingEnabled = true;
            cboRol.Items.AddRange(new object[] { "Recepcionista", "Administrador", "Cliente" });
            cboRol.Location = new Point(140, 184);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(214, 23);
            cboRol.TabIndex = 8;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(140, 144);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(214, 23);
            txtNombreCompleto.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 104);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(214, 23);
            txtPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(140, 64);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(214, 23);
            txtUsername.TabIndex = 5;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRol.Location = new Point(18, 187);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(33, 17);
            lblRol.TabIndex = 4;
            lblRol.Text = "Rol:";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombreCompleto.Location = new Point(18, 147);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(62, 17);
            lblNombreCompleto.TabIndex = 3;
            lblNombreCompleto.Text = "Nombre:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPass.Location = new Point(18, 107);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(80, 17);
            lblPass.TabIndex = 2;
            lblPass.Text = "Contrasena:";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUser.Location = new Point(18, 67);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(57, 17);
            lblUser.TabIndex = 1;
            lblUser.Text = "Usuario:";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(15, 30, 54);
            lblSubtitulo.Location = new Point(18, 18);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(118, 20);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Nuevo Usuario";
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 240);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlFormulario);
            Controls.Add(dgvUsuarios);
            Controls.Add(lblTitulo);
            Name = "FrmUsuarios";
            Text = "Administracion de Usuarios";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvUsuarios;
        private Panel pnlFormulario;
        private Button btnDesactivar;
        private Button btnActivar;
        private Button btnCrear;
        private ComboBox cboRol;
        private TextBox txtNombreCompleto;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblRol;
        private Label lblNombreCompleto;
        private Label lblPass;
        private Label lblUser;
        private Label lblSubtitulo;
    }
}
