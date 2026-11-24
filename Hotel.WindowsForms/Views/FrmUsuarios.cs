using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmUsuarios : Form
    {
        private readonly AuthMvcController? _ctrl;
        private int _usuarioSelId = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
            cboRol.SelectedIndex = 0;
            UiTheme.ConfigurarColumnas(dgvUsuarios,
                ("Username", "Usuario", 22, 100, null),
                ("NombreCompleto", "Nombre Completo", 36, 160, null),
                ("Rol", "Rol", 20, 100, null),
                ("Activo", "Activo", 10, 60, null),
                ("FechaCreacion", "Creado", 12, 95, "dd/MM/yyyy"));
        }

        public FrmUsuarios(HotelAppContext app) : this()
        {
            _ctrl = new AuthMvcController(app.Api);
        }

        private async void FrmUsuarios_Load(object? sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsuarios.Rows[e.RowIndex].DataBoundItem is UsuarioModel u)
                _usuarioSelId = u.Id;
        }

        private async void btnCrear_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null) return;
            var res = await _ctrl.CrearUsuarioAsync(new CrearUsuarioRequestModel
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                Rol = cboRol.SelectedItem?.ToString() ?? "Recepcionista"
            });

            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtUsername.Clear();
            txtPassword.Clear();
            txtNombreCompleto.Clear();
            await CargarAsync();
        }

        private async void btnActivar_Click(object? sender, EventArgs e) => await CambiarEstadoAsync(true);
        private async void btnDesactivar_Click(object? sender, EventArgs e) => await CambiarEstadoAsync(false);

        private async Task CambiarEstadoAsync(bool activo)
        {
            if (_ctrl == null || _usuarioSelId == 0) return;
            var res = await _ctrl.CambiarEstadoAsync(_usuarioSelId, activo);
            if (!res.Success) MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await CargarAsync();
        }

        private async Task CargarAsync()
        {
            if (_ctrl == null) return;
            var res = await _ctrl.ListarUsuariosAsync();
            if (res.Success) dgvUsuarios.DataSource = res.Data;
        }
    }
}
