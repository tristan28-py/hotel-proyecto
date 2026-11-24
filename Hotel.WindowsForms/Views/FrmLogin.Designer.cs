namespace Hotel.WindowsForms.Views
{
    partial class FrmLogin
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
            pnlMarca = new Panel();
            btnDemoCliente = new Button();
            btnDemoRecep = new Button();
            btnDemoAdmin = new Button();
            lblAccesosDemo = new Label();
            lblDescripcionMarca = new Label();
            pnlLineaDorada = new Panel();
            lblSubtituloMarca = new Label();
            lblNombreHotel = new Label();
            pnlDerecho = new Panel();
            tabAuth = new TabControl();
            tabLogin = new TabPage();
            lblEstadoApi = new Label();
            txtApiUrl = new TextBox();
            lblApiUrl = new Label();
            btnIngresar = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblBienvenida = new Label();
            tabRegistro = new TabPage();
            btnRegistrar = new Button();
            txtRegPass = new TextBox();
            txtRegUser = new TextBox();
            txtRegTel = new TextBox();
            txtRegEmail = new TextBox();
            txtRegApellidos = new TextBox();
            txtRegNombres = new TextBox();
            txtRegNumDoc = new TextBox();
            cboRegTipoDoc = new ComboBox();
            lblRegPass = new Label();
            lblRegUser = new Label();
            lblRegTel = new Label();
            lblRegEmail = new Label();
            lblRegApellidos = new Label();
            lblRegNombres = new Label();
            lblRegDoc = new Label();
            pnlMarca.SuspendLayout();
            pnlDerecho.SuspendLayout();
            tabAuth.SuspendLayout();
            tabLogin.SuspendLayout();
            tabRegistro.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMarca
            // 
            pnlMarca.BackColor = Color.FromArgb(15, 30, 54);
            pnlMarca.Controls.Add(btnDemoCliente);
            pnlMarca.Controls.Add(btnDemoRecep);
            pnlMarca.Controls.Add(btnDemoAdmin);
            pnlMarca.Controls.Add(lblAccesosDemo);
            pnlMarca.Controls.Add(lblDescripcionMarca);
            pnlMarca.Controls.Add(pnlLineaDorada);
            pnlMarca.Controls.Add(lblSubtituloMarca);
            pnlMarca.Controls.Add(lblNombreHotel);
            pnlMarca.Dock = DockStyle.Left;
            pnlMarca.Location = new Point(0, 0);
            pnlMarca.Name = "pnlMarca";
            pnlMarca.Size = new Size(370, 560);
            pnlMarca.TabIndex = 0;
            // 
            // btnDemoCliente
            // 
            btnDemoCliente.BackColor = Color.FromArgb(26, 49, 84);
            btnDemoCliente.FlatAppearance.BorderColor = Color.FromArgb(200, 157, 84);
            btnDemoCliente.FlatStyle = FlatStyle.Flat;
            btnDemoCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoCliente.ForeColor = Color.White;
            btnDemoCliente.Location = new Point(32, 464);
            btnDemoCliente.Name = "btnDemoCliente";
            btnDemoCliente.Size = new Size(300, 34);
            btnDemoCliente.TabIndex = 7;
            btnDemoCliente.Text = "Cargar Huesped (cliente / cliente123)";
            btnDemoCliente.UseVisualStyleBackColor = false;
            btnDemoCliente.Click += btnDemoCliente_Click;
            // 
            // btnDemoRecep
            // 
            btnDemoRecep.BackColor = Color.FromArgb(26, 49, 84);
            btnDemoRecep.FlatAppearance.BorderColor = Color.FromArgb(200, 157, 84);
            btnDemoRecep.FlatStyle = FlatStyle.Flat;
            btnDemoRecep.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoRecep.ForeColor = Color.White;
            btnDemoRecep.Location = new Point(32, 422);
            btnDemoRecep.Name = "btnDemoRecep";
            btnDemoRecep.Size = new Size(300, 34);
            btnDemoRecep.TabIndex = 6;
            btnDemoRecep.Text = "Cargar Recepcion (recepcion / recep123)";
            btnDemoRecep.UseVisualStyleBackColor = false;
            btnDemoRecep.Click += btnDemoRecep_Click;
            // 
            // btnDemoAdmin
            // 
            btnDemoAdmin.BackColor = Color.FromArgb(200, 157, 84);
            btnDemoAdmin.FlatAppearance.BorderSize = 0;
            btnDemoAdmin.FlatStyle = FlatStyle.Flat;
            btnDemoAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoAdmin.ForeColor = Color.FromArgb(15, 30, 54);
            btnDemoAdmin.Location = new Point(32, 380);
            btnDemoAdmin.Name = "btnDemoAdmin";
            btnDemoAdmin.Size = new Size(300, 34);
            btnDemoAdmin.TabIndex = 5;
            btnDemoAdmin.Text = "Cargar Administrador (admin / admin123)";
            btnDemoAdmin.UseVisualStyleBackColor = false;
            btnDemoAdmin.Click += btnDemoAdmin_Click;
            // 
            // lblAccesosDemo
            // 
            lblAccesosDemo.AutoSize = true;
            lblAccesosDemo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAccesosDemo.ForeColor = Color.FromArgb(200, 157, 84);
            lblAccesosDemo.Location = new Point(32, 354);
            lblAccesosDemo.Name = "lblAccesosDemo";
            lblAccesosDemo.Size = new Size(171, 15);
            lblAccesosDemo.TabIndex = 4;
            lblAccesosDemo.Text = "CUENTAS DE DEMOSTRACION";
            // 
            // lblDescripcionMarca
            // 
            lblDescripcionMarca.Font = new Font("Segoe UI", 10F);
            lblDescripcionMarca.ForeColor = Color.FromArgb(203, 213, 225);
            lblDescripcionMarca.Location = new Point(32, 168);
            lblDescripcionMarca.Name = "lblDescripcionMarca";
            lblDescripcionMarca.Size = new Size(300, 110);
            lblDescripcionMarca.TabIndex = 3;
            lblDescripcionMarca.Text = "Plataforma integral de reservaciones, recepcion en tiempo real, control de habitaciones, facturacion y servicio gastronomico para huespedes.";
            // 
            // pnlLineaDorada
            // 
            pnlLineaDorada.BackColor = Color.FromArgb(200, 157, 84);
            pnlLineaDorada.Location = new Point(32, 146);
            pnlLineaDorada.Name = "pnlLineaDorada";
            pnlLineaDorada.Size = new Size(76, 4);
            pnlLineaDorada.TabIndex = 2;
            // 
            // lblSubtituloMarca
            // 
            lblSubtituloMarca.AutoSize = true;
            lblSubtituloMarca.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSubtituloMarca.ForeColor = Color.FromArgb(200, 157, 84);
            lblSubtituloMarca.Location = new Point(32, 114);
            lblSubtituloMarca.Name = "lblSubtituloMarca";
            lblSubtituloMarca.Size = new Size(192, 19);
            lblSubtituloMarca.TabIndex = 1;
            lblSubtituloMarca.Text = "RESORT & HOSPITALITY PMS";
            // 
            // lblNombreHotel
            // 
            lblNombreHotel.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblNombreHotel.ForeColor = Color.White;
            lblNombreHotel.Location = new Point(28, 44);
            lblNombreHotel.Name = "lblNombreHotel";
            lblNombreHotel.Size = new Size(310, 68);
            lblNombreHotel.TabIndex = 0;
            lblNombreHotel.Text = "HOTEL\r\nCOSTA DORADA";
            // 
            // pnlDerecho
            // 
            pnlDerecho.BackColor = Color.FromArgb(247, 245, 240);
            pnlDerecho.Controls.Add(tabAuth);
            pnlDerecho.Dock = DockStyle.Fill;
            pnlDerecho.Location = new Point(370, 0);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Padding = new Padding(24);
            pnlDerecho.Size = new Size(490, 560);
            pnlDerecho.TabIndex = 1;
            // 
            // tabAuth
            // 
            tabAuth.Controls.Add(tabLogin);
            tabAuth.Controls.Add(tabRegistro);
            tabAuth.Dock = DockStyle.Fill;
            tabAuth.Font = new Font("Segoe UI", 9.5F);
            tabAuth.Location = new Point(24, 24);
            tabAuth.Name = "tabAuth";
            tabAuth.SelectedIndex = 0;
            tabAuth.Size = new Size(442, 512);
            tabAuth.TabIndex = 0;
            // 
            // tabLogin
            // 
            tabLogin.BackColor = Color.White;
            tabLogin.Controls.Add(lblEstadoApi);
            tabLogin.Controls.Add(txtApiUrl);
            tabLogin.Controls.Add(lblApiUrl);
            tabLogin.Controls.Add(btnIngresar);
            tabLogin.Controls.Add(txtPassword);
            tabLogin.Controls.Add(lblPassword);
            tabLogin.Controls.Add(txtUsuario);
            tabLogin.Controls.Add(lblUsuario);
            tabLogin.Controls.Add(lblBienvenida);
            tabLogin.Location = new Point(4, 25);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(12);
            tabLogin.Size = new Size(434, 483);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "Iniciar Sesion";
            // 
            // lblEstadoApi
            // 
            lblEstadoApi.Font = new Font("Segoe UI", 8.5F);
            lblEstadoApi.ForeColor = Color.FromArgb(100, 116, 139);
            lblEstadoApi.Location = new Point(30, 412);
            lblEstadoApi.Name = "lblEstadoApi";
            lblEstadoApi.Size = new Size(370, 34);
            lblEstadoApi.TabIndex = 8;
            lblEstadoApi.Text = "Listo para iniciar sesion.";
            // 
            // txtApiUrl
            // 
            txtApiUrl.Location = new Point(30, 376);
            txtApiUrl.Name = "txtApiUrl";
            txtApiUrl.Size = new Size(370, 24);
            txtApiUrl.TabIndex = 7;
            txtApiUrl.Text = "http://localhost:5295";
            // 
            // lblApiUrl
            // 
            lblApiUrl.AutoSize = true;
            lblApiUrl.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblApiUrl.ForeColor = Color.FromArgb(100, 116, 139);
            lblApiUrl.Location = new Point(30, 354);
            lblApiUrl.Name = "lblApiUrl";
            lblApiUrl.Size = new Size(165, 15);
            lblApiUrl.TabIndex = 6;
            lblApiUrl.Text = "Servidor API (Local o Azure):";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(15, 30, 54);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(30, 266);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(370, 44);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar al Sistema";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(30, 206);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(370, 26);
            txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(30, 41, 59);
            lblPassword.Location = new Point(30, 182);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 17);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contrasena:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10.5F);
            txtUsuario.Location = new Point(30, 134);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(370, 26);
            txtUsuario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            lblUsuario.Location = new Point(30, 110);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(57, 17);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(15, 30, 54);
            lblBienvenida.Location = new Point(28, 34);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(209, 25);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido de nuevo";
            // 
            // tabRegistro
            // 
            tabRegistro.BackColor = Color.White;
            tabRegistro.Controls.Add(btnRegistrar);
            tabRegistro.Controls.Add(txtRegPass);
            tabRegistro.Controls.Add(txtRegUser);
            tabRegistro.Controls.Add(txtRegTel);
            tabRegistro.Controls.Add(txtRegEmail);
            tabRegistro.Controls.Add(txtRegApellidos);
            tabRegistro.Controls.Add(txtRegNombres);
            tabRegistro.Controls.Add(txtRegNumDoc);
            tabRegistro.Controls.Add(cboRegTipoDoc);
            tabRegistro.Controls.Add(lblRegPass);
            tabRegistro.Controls.Add(lblRegUser);
            tabRegistro.Controls.Add(lblRegTel);
            tabRegistro.Controls.Add(lblRegEmail);
            tabRegistro.Controls.Add(lblRegApellidos);
            tabRegistro.Controls.Add(lblRegNombres);
            tabRegistro.Controls.Add(lblRegDoc);
            tabRegistro.Location = new Point(4, 25);
            tabRegistro.Name = "tabRegistro";
            tabRegistro.Padding = new Padding(12);
            tabRegistro.Size = new Size(434, 483);
            tabRegistro.TabIndex = 1;
            tabRegistro.Text = "Crear Cuenta de Huesped";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(200, 157, 84);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.FromArgb(15, 30, 54);
            btnRegistrar.Location = new Point(24, 392);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(382, 42);
            btnRegistrar.TabIndex = 15;
            btnRegistrar.Text = "Registrarme y Entrar como Huesped";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // txtRegPass
            // 
            txtRegPass.Location = new Point(146, 336);
            txtRegPass.Name = "txtRegPass";
            txtRegPass.PasswordChar = '*';
            txtRegPass.Size = new Size(260, 24);
            txtRegPass.TabIndex = 14;
            // 
            // txtRegUser
            // 
            txtRegUser.Location = new Point(146, 294);
            txtRegUser.Name = "txtRegUser";
            txtRegUser.Size = new Size(260, 24);
            txtRegUser.TabIndex = 13;
            // 
            // txtRegTel
            // 
            txtRegTel.Location = new Point(146, 252);
            txtRegTel.Name = "txtRegTel";
            txtRegTel.Size = new Size(260, 24);
            txtRegTel.TabIndex = 12;
            // 
            // txtRegEmail
            // 
            txtRegEmail.Location = new Point(146, 210);
            txtRegEmail.Name = "txtRegEmail";
            txtRegEmail.Size = new Size(260, 24);
            txtRegEmail.TabIndex = 11;
            // 
            // txtRegApellidos
            // 
            txtRegApellidos.Location = new Point(146, 168);
            txtRegApellidos.Name = "txtRegApellidos";
            txtRegApellidos.Size = new Size(260, 24);
            txtRegApellidos.TabIndex = 10;
            // 
            // txtRegNombres
            // 
            txtRegNombres.Location = new Point(146, 126);
            txtRegNombres.Name = "txtRegNombres";
            txtRegNombres.Size = new Size(260, 24);
            txtRegNombres.TabIndex = 9;
            // 
            // txtRegNumDoc
            // 
            txtRegNumDoc.Location = new Point(256, 84);
            txtRegNumDoc.Name = "txtRegNumDoc";
            txtRegNumDoc.Size = new Size(150, 24);
            txtRegNumDoc.TabIndex = 8;
            // 
            // cboRegTipoDoc
            // 
            cboRegTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRegTipoDoc.FormattingEnabled = true;
            cboRegTipoDoc.Items.AddRange(new object[] { "Cedula", "DNI", "Pasaporte" });
            cboRegTipoDoc.Location = new Point(146, 84);
            cboRegTipoDoc.Name = "cboRegTipoDoc";
            cboRegTipoDoc.Size = new Size(102, 24);
            cboRegTipoDoc.TabIndex = 7;
            // 
            // lblRegPass
            // 
            lblRegPass.AutoSize = true;
            lblRegPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegPass.Location = new Point(24, 339);
            lblRegPass.Name = "lblRegPass";
            lblRegPass.Size = new Size(76, 15);
            lblRegPass.TabIndex = 6;
            lblRegPass.Text = "Contrasena:";
            // 
            // lblRegUser
            // 
            lblRegUser.AutoSize = true;
            lblRegUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegUser.Location = new Point(24, 297);
            lblRegUser.Name = "lblRegUser";
            lblRegUser.Size = new Size(54, 15);
            lblRegUser.TabIndex = 5;
            lblRegUser.Text = "Usuario:";
            // 
            // lblRegTel
            // 
            lblRegTel.AutoSize = true;
            lblRegTel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegTel.Location = new Point(24, 255);
            lblRegTel.Name = "lblRegTel";
            lblRegTel.Size = new Size(61, 15);
            lblRegTel.TabIndex = 4;
            lblRegTel.Text = "Telefono:";
            // 
            // lblRegEmail
            // 
            lblRegEmail.AutoSize = true;
            lblRegEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegEmail.Location = new Point(24, 213);
            lblRegEmail.Name = "lblRegEmail";
            lblRegEmail.Size = new Size(49, 15);
            lblRegEmail.TabIndex = 3;
            lblRegEmail.Text = "Correo:";
            // 
            // lblRegApellidos
            // 
            lblRegApellidos.AutoSize = true;
            lblRegApellidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegApellidos.Location = new Point(24, 171);
            lblRegApellidos.Name = "lblRegApellidos";
            lblRegApellidos.Size = new Size(64, 15);
            lblRegApellidos.TabIndex = 2;
            lblRegApellidos.Text = "Apellidos:";
            // 
            // lblRegNombres
            // 
            lblRegNombres.AutoSize = true;
            lblRegNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegNombres.Location = new Point(24, 129);
            lblRegNombres.Name = "lblRegNombres";
            lblRegNombres.Size = new Size(64, 15);
            lblRegNombres.TabIndex = 1;
            lblRegNombres.Text = "Nombres:";
            // 
            // lblRegDoc
            // 
            lblRegDoc.AutoSize = true;
            lblRegDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegDoc.Location = new Point(24, 87);
            lblRegDoc.Name = "lblRegDoc";
            lblRegDoc.Size = new Size(76, 15);
            lblRegDoc.TabIndex = 0;
            lblRegDoc.Text = "Documento:";
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 560);
            Controls.Add(pnlDerecho);
            Controls.Add(pnlMarca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Costa Dorada - Inicio de Sesion";
            pnlMarca.ResumeLayout(false);
            pnlMarca.PerformLayout();
            pnlDerecho.ResumeLayout(false);
            tabAuth.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            tabLogin.PerformLayout();
            tabRegistro.ResumeLayout(false);
            tabRegistro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMarca;
        private Button btnDemoCliente;
        private Button btnDemoRecep;
        private Button btnDemoAdmin;
        private Label lblAccesosDemo;
        private Label lblDescripcionMarca;
        private Panel pnlLineaDorada;
        private Label lblSubtituloMarca;
        private Label lblNombreHotel;
        private Panel pnlDerecho;
        private TabControl tabAuth;
        private TabPage tabLogin;
        private Label lblEstadoApi;
        private TextBox txtApiUrl;
        private Label lblApiUrl;
        private Button btnIngresar;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblBienvenida;
        private TabPage tabRegistro;
        private Button btnRegistrar;
        private TextBox txtRegPass;
        private TextBox txtRegUser;
        private TextBox txtRegTel;
        private TextBox txtRegEmail;
        private TextBox txtRegApellidos;
        private TextBox txtRegNombres;
        private TextBox txtRegNumDoc;
        private ComboBox cboRegTipoDoc;
        private Label lblRegPass;
        private Label lblRegUser;
        private Label lblRegTel;
        private Label lblRegEmail;
        private Label lblRegApellidos;
        private Label lblRegNombres;
        private Label lblRegDoc;
    }
}
