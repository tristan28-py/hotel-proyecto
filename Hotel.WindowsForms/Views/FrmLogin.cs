using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmLogin : Form
    {
        private readonly HotelAppContext? _app;
        private readonly AuthMvcController? _authCtrl;

        public FrmLogin()
        {
            InitializeComponent();
            cboRegTipoDoc.SelectedIndex = 0;
        }

        public FrmLogin(HotelAppContext app) : this()
        {
            _app = app;
            _authCtrl = new AuthMvcController(app.Api);
            txtApiUrl.Text = app.Api.BaseUrl;
        }

        private void btnDemoAdmin_Click(object? sender, EventArgs e)
        {
            tabAuth.SelectedIndex = 0;
            txtUsuario.Text = "admin";
            txtPassword.Text = "admin123";
        }

        private void btnDemoRecep_Click(object? sender, EventArgs e)
        {
            tabAuth.SelectedIndex = 0;
            txtUsuario.Text = "recepcion";
            txtPassword.Text = "recep123";
        }

        private void btnDemoCliente_Click(object? sender, EventArgs e)
        {
            tabAuth.SelectedIndex = 0;
            txtUsuario.Text = "cliente";
            txtPassword.Text = "cliente123";
        }

        private async void btnIngresar_Click(object? sender, EventArgs e)
        {
            if (_app == null || _authCtrl == null) return;

            btnIngresar.Enabled = false;
            lblEstadoApi.Text = "Validando credenciales en el servidor...";

            _app.Api.ActualizarBaseUrl(txtApiUrl.Text.Trim());

            var res = await _authCtrl.LoginAsync(new LoginRequestModel
            {
                Username = txtUsuario.Text.Trim(),
                Password = txtPassword.Text
            });

            btnIngresar.Enabled = true;

            if (!res.Success || res.Data == null)
            {
                lblEstadoApi.Text = res.Error;
                MessageBox.Show(res.Error, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AbrirPrincipal(res.Data);
        }

        private async void btnRegistrar_Click(object? sender, EventArgs e)
        {
            if (_app == null || _authCtrl == null) return;

            btnRegistrar.Enabled = false;
            _app.Api.ActualizarBaseUrl(txtApiUrl.Text.Trim());

            var res = await _authCtrl.RegistrarHuespedAsync(new RegistroHuespedRequestModel
            {
                Username = txtRegUser.Text.Trim(),
                Password = txtRegPass.Text,
                TipoDocumento = cboRegTipoDoc.SelectedItem?.ToString() ?? "Cedula",
                NumeroDocumento = txtRegNumDoc.Text.Trim(),
                Nombres = txtRegNombres.Text.Trim(),
                Apellidos = txtRegApellidos.Text.Trim(),
                Email = txtRegEmail.Text.Trim(),
                Telefono = txtRegTel.Text.Trim()
            });

            btnRegistrar.Enabled = true;

            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "No se pudo completar el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Cuenta creada correctamente. Bienvenido al hotel.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AbrirPrincipal(res.Data);
        }

        private void AbrirPrincipal(LoginResponseModel sesion)
        {
            if (_app == null) return;
            _app.SesionActual = sesion;
            txtPassword.Clear();
            lblEstadoApi.Text = "Sesion iniciada.";

            Hide();
            using var frmPrincipal = new FrmPrincipal(_app);
            frmPrincipal.ShowDialog();
            _app.SesionActual = null;
            Show();
        }
    }
}
