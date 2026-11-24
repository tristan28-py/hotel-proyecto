using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmClientes : Form
    {
        private readonly ClientesMvcController? _ctrl;
        private int _idSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
            cboTipoDoc.SelectedIndex = 0;
        }

        public FrmClientes(HotelAppContext app) : this()
        {
            _ctrl = new ClientesMvcController(app.Api);
        }

        private async void FrmClientes_Load(object? sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void btnBuscar_Click(object? sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void dgvClientes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Rows[e.RowIndex].DataBoundItem is ClienteModel c)
            {
                CargarFormulario(c);
                await CargarHistorialAsync(c.Id);
            }
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            Limpiar();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private async Task BuscarAsync()
        {
            if (_ctrl == null) return;
            var res = await _ctrl.ListarAsync(txtBuscar.Text.Trim());
            if (res.Success)
                dgvClientes.DataSource = res.Data;
            else
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async Task CargarHistorialAsync(int clienteId)
        {
            if (_ctrl == null) return;
            var res = await _ctrl.ObtenerHistorialAsync(clienteId);
            if (res.Success && res.Data != null)
            {
                lblResumenHist.Text = $"Estadias completadas: {res.Data.TotalEstadias} | Total facturado: {res.Data.TotalFacturadoAcumulado:C2}";
                dgvHistorial.DataSource = res.Data.Reservaciones;
            }
        }

        private void CargarFormulario(ClienteModel c)
        {
            _idSeleccionado = c.Id;
            cboTipoDoc.SelectedItem = c.TipoDocumento;
            txtDoc.Text = c.NumeroDocumento;
            txtNombres.Text = c.Nombres;
            txtApellidos.Text = c.Apellidos;
            txtNacionalidad.Text = c.Nacionalidad;
            txtEmail.Text = c.Email;
            txtTelefono.Text = c.Telefono;
            txtTelEmergencia.Text = c.TelefonoEmergencia ?? string.Empty;
            txtDireccion.Text = c.Direccion ?? string.Empty;
            txtPreferencias.Text = c.Preferencias ?? string.Empty;
            chkFrecuente.Checked = c.EsClienteFrecuente;
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            cboTipoDoc.SelectedIndex = 0;
            txtDoc.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtNacionalidad.Text = "Costarricense";
            txtEmail.Clear();
            txtTelefono.Clear();
            txtTelEmergencia.Clear();
            txtDireccion.Clear();
            txtPreferencias.Clear();
            chkFrecuente.Checked = false;
        }

        private async Task GuardarAsync()
        {
            if (_ctrl == null) return;
            var dto = new ClienteModel
            {
                Id = _idSeleccionado,
                TipoDocumento = cboTipoDoc.SelectedItem?.ToString() ?? "Cedula",
                NumeroDocumento = txtDoc.Text.Trim(),
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Nacionalidad = txtNacionalidad.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                TelefonoEmergencia = txtTelEmergencia.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Preferencias = txtPreferencias.Text.Trim(),
                EsClienteFrecuente = chkFrecuente.Checked
            };

            var res = _idSeleccionado == 0 ? await _ctrl.CrearAsync(dto) : await _ctrl.ActualizarAsync(dto);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Cliente guardado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            await BuscarAsync();
        }
    }
}
