using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmPlatillos : Form
    {
        private readonly RestauranteMvcController? _ctrl;
        private int _platilloId = 0;

        public FrmPlatillos()
        {
            InitializeComponent();
        }

        public FrmPlatillos(HotelAppContext app) : this()
        {
            _ctrl = new RestauranteMvcController(app.Api);
        }

        private async void FrmPlatillos_Load(object? sender, EventArgs e)
        {
            await CargarTodoAsync();
        }

        private void dgvPlatillos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPlatillos.Rows[e.RowIndex].DataBoundItem is PlatilloModel p)
            {
                _platilloId = p.Id;
                cboCategoria.SelectedValue = p.CategoriaId;
                txtNombre.Text = p.Nombre;
                txtDesc.Text = p.Descripcion ?? string.Empty;
                numPrecio.Value = p.Precio;
                numTiempo.Value = p.TiempoPreparacionMinutos;
                chkDisponible.Checked = p.Disponible;
            }
        }

        private async void btnAddCat_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || string.IsNullOrWhiteSpace(txtNuevaCat.Text)) return;
            var res = await _ctrl.GuardarCategoriaAsync(new CategoriaPlatilloModel { Nombre = txtNuevaCat.Text.Trim(), Activo = true });
            if (!res.Success)
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                txtNuevaCat.Clear();
                await CargarTodoAsync();
            }
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            Limpiar();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || cboCategoria.SelectedValue is not int catId) return;
            var res = await _ctrl.GuardarPlatilloAsync(new PlatilloModel
            {
                Id = _platilloId,
                CategoriaId = catId,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDesc.Text.Trim(),
                Precio = numPrecio.Value,
                TiempoPreparacionMinutos = (int)numTiempo.Value,
                Disponible = chkDisponible.Checked,
                Activo = true
            });
            if (!res.Success)
                MessageBox.Show(res.Error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Limpiar();
                await CargarTodoAsync();
            }
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _platilloId == 0) return;
            var res = await _ctrl.DesactivarPlatilloAsync(_platilloId);
            if (!res.Success)
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Limpiar();
                await CargarTodoAsync();
            }
        }

        private async Task CargarTodoAsync()
        {
            if (_ctrl == null) return;
            var cats = await _ctrl.ListarCategoriasAsync();
            if (cats.Success && cats.Data != null)
            {
                cboCategoria.DataSource = cats.Data;
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "Id";
            }

            var plats = await _ctrl.ListarPlatillosAsync();
            if (plats.Success)
                dgvPlatillos.DataSource = plats.Data;
        }

        private void Limpiar()
        {
            _platilloId = 0;
            txtNombre.Clear();
            txtDesc.Clear();
            numPrecio.Value = 10;
            numTiempo.Value = 15;
            chkDisponible.Checked = true;
        }
    }
}
