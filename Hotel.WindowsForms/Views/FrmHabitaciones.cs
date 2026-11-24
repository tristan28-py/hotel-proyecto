using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmHabitaciones : Form
    {
        private readonly HotelAppContext? _app;
        private readonly HabitacionesMvcController? _ctrl;
        private int _idSeleccionado = 0;

        public FrmHabitaciones()
        {
            InitializeComponent();
            cboEstado.SelectedIndex = 0;
        }

        public FrmHabitaciones(HotelAppContext app) : this()
        {
            _app = app;
            _ctrl = new HabitacionesMvcController(app.Api);
            _app.Realtime.HabitacionesActualizadas += OnTiempoRealHabitaciones;
        }

        private async void FrmHabitaciones_Load(object? sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private void FrmHabitaciones_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_app != null)
                _app.Realtime.HabitacionesActualizadas -= OnTiempoRealHabitaciones;
        }

        private void OnTiempoRealHabitaciones()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await CargarHabitacionesAsync());
        }

        private async void btnActualizar_Click(object? sender, EventArgs e)
        {
            await CargarHabitacionesAsync();
        }

        private void dgvHabitaciones_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHabitaciones.Rows[e.RowIndex].DataBoundItem is HabitacionModel h)
                CargarEnFormulario(h);
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private async void btnEstadoRapido_Click(object? sender, EventArgs e)
        {
            await CambiarEstadoRapidoAsync();
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            await DesactivarAsync();
        }

        private async Task CargarDatosAsync()
        {
            if (_ctrl == null) return;
            var tiposRes = await _ctrl.ListarTiposAsync();
            if (tiposRes.Success && tiposRes.Data != null)
            {
                cboTipo.DataSource = tiposRes.Data;
                cboTipo.DisplayMember = "Nombre";
                cboTipo.ValueMember = "Id";
            }
            await CargarHabitacionesAsync();
        }

        private async Task CargarHabitacionesAsync()
        {
            if (_ctrl == null) return;
            var res = await _ctrl.ListarHabitacionesAsync();
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvHabitaciones.DataSource = res.Data;

            flpMapa.SuspendLayout();
            flpMapa.Controls.Clear();
            foreach (var h in res.Data)
            {
                Color fondo = h.Activa ? UiTheme.ColorEstadoHabitacion(h.EstadoOperativo) : Color.DarkGray;
                Color texto = h.EstadoOperativo == "EnLimpieza" ? Color.Black : Color.White;

                var btn = new Button
                {
                    Width = 148,
                    Height = 104,
                    Margin = new Padding(8),
                    BackColor = fondo,
                    ForeColor = texto,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    Text = $"Hab. {h.Numero}\nPiso {h.Piso} - {h.TipoHabitacionNombre}\n[{h.EstadoOperativo}]\n{h.PrecioBasePorNoche:C2}/noche"
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (_, _) => CargarEnFormulario(h);
                flpMapa.Controls.Add(btn);
            }
            flpMapa.ResumeLayout();
        }

        private void CargarEnFormulario(HabitacionModel h)
        {
            _idSeleccionado = h.Id;
            lblSeleccion.Text = $"Editando Habitacion {h.Numero}";
            txtNumero.Text = h.Numero;
            numPiso.Value = Math.Clamp(h.Piso, 1, 50);
            cboTipo.SelectedValue = h.TipoHabitacionId;
            cboEstado.SelectedItem = h.EstadoOperativo;
            chkJacuzzi.Checked = h.TieneJacuzzi;
            chkVistaMar.Checked = h.TieneVistaMar;
            chkWifi6.Checked = h.TieneWifi6;
            chkFrigobar.Checked = h.TieneFrigobar;
            txtAmenidades.Text = h.AmenidadesAdicionales ?? string.Empty;
            chkActiva.Checked = h.Activa;
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            lblSeleccion.Text = "Nueva Habitacion";
            txtNumero.Clear();
            numPiso.Value = 1;
            if (cboTipo.Items.Count > 0) cboTipo.SelectedIndex = 0;
            cboEstado.SelectedItem = "Disponible";
            chkJacuzzi.Checked = false;
            chkVistaMar.Checked = false;
            chkWifi6.Checked = true;
            chkFrigobar.Checked = false;
            txtAmenidades.Clear();
            chkActiva.Checked = true;
        }

        private async Task GuardarAsync()
        {
            if (_ctrl == null) return;
            if (cboTipo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de habitacion.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new HabitacionModel
            {
                Id = _idSeleccionado,
                Numero = txtNumero.Text.Trim(),
                Piso = (int)numPiso.Value,
                TipoHabitacionId = (int)cboTipo.SelectedValue,
                EstadoOperativo = cboEstado.SelectedItem?.ToString() ?? "Disponible",
                TieneJacuzzi = chkJacuzzi.Checked,
                TieneVistaMar = chkVistaMar.Checked,
                TieneWifi6 = chkWifi6.Checked,
                TieneFrigobar = chkFrigobar.Checked,
                AmenidadesAdicionales = txtAmenidades.Text.Trim(),
                Activa = chkActiva.Checked
            };

            var res = _idSeleccionado == 0
                ? await _ctrl.CrearHabitacionAsync(dto)
                : await _ctrl.ActualizarHabitacionAsync(dto);

            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Habitacion guardada correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            await CargarHabitacionesAsync();
        }

        private async Task CambiarEstadoRapidoAsync()
        {
            if (_ctrl == null || _idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione primero una habitacion del mapa.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string estado = cboEstado.SelectedItem?.ToString() ?? "Disponible";
            var res = await _ctrl.CambiarEstadoAsync(_idSeleccionado, estado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await CargarHabitacionesAsync();
        }

        private async Task DesactivarAsync()
        {
            if (_ctrl == null || _idSeleccionado == 0) return;
            if (MessageBox.Show("Desea desactivar esta habitacion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var res = await _ctrl.DesactivarHabitacionAsync(_idSeleccionado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LimpiarFormulario();
            await CargarHabitacionesAsync();
        }
    }
}
