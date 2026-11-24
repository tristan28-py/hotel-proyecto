using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmTipoHabitacion : Form
    {
        private readonly HabitacionesMvcController? _ctrl;
        private int _idSeleccionado = 0;

        public FrmTipoHabitacion()
        {
            InitializeComponent();
            Helpers.UiTheme.EstilizarGrid(dgvTipos);
        }

        public FrmTipoHabitacion(HotelAppContext app) : this()
        {
            _ctrl = new HabitacionesMvcController(app.Api);
        }

        private async void FrmTipoHabitacion_Load(object? sender, EventArgs e)
        {
            await CargarTiposAsync();
        }

        private async Task CargarTiposAsync()
        {
            if (_ctrl == null) return;
            var res = await _ctrl.ListarTiposAsync();
            if (res.Success)
                dgvTipos.DataSource = res.Data;
            else
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvTipos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTipos.Rows[e.RowIndex].DataBoundItem is TipoHabitacionModel t)
            {
                _idSeleccionado = t.Id;
                txtNombre.Text = t.Nombre;
                txtDescripcion.Text = t.Descripcion ?? string.Empty;
                numAdultos.Value = t.CapacidadAdultos;
                numNinos.Value = t.CapacidadNinos;
                numPrecio.Value = t.PrecioBasePorNoche;
            }
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null) return;

            var dto = new TipoHabitacionModel
            {
                Id = _idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CapacidadAdultos = (int)numAdultos.Value,
                CapacidadNinos = (int)numNinos.Value,
                PrecioBasePorNoche = numPrecio.Value
            };

            var res = _idSeleccionado == 0
                ? await _ctrl.CrearTipoAsync(dto)
                : await _ctrl.ActualizarTipoAsync(dto);

            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarCampos();
            await CargarTiposAsync();
        }

        private async void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (_ctrl == null || _idSeleccionado == 0) return;

            if (MessageBox.Show("Desea eliminar este tipo de habitacion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var res = await _ctrl.EliminarTipoAsync(_idSeleccionado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarCampos();
            await CargarTiposAsync();
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            numAdultos.Value = 2;
            numNinos.Value = 0;
            numPrecio.Value = 100;
        }
    }
}
