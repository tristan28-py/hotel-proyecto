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
            UiTheme.ConfigurarColumnas(dgvHabitaciones,
                ("Numero", "Hab.", 12, 65, null),
                ("Piso", "Piso", 10, 55, null),
                ("TipoHabitacionNombre", "Tipo de Habitacion", 28, 140, null),
                ("EstadoOperativo", "Estado", 22, 115, null),
                ("PrecioBasePorNoche", "Tarifa / Noche", 18, 100, "C2"),
                ("Activa", "Activa", 10, 60, null));
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
                Color acento = h.Activa ? UiTheme.ColorEstadoHabitacion(h.EstadoOperativo) : Color.DarkGray;

                var card = new Panel
                {
                    Width = 212,
                    Height = 152,
                    Margin = new Padding(8),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };

                var barra = new Panel { Dock = DockStyle.Top, Height = 7, BackColor = acento };
                var lblEstadoBadge = new Label
                {
                    Text = h.EstadoOperativo.ToUpperInvariant(),
                    BackColor = acento,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    Location = new Point(12, 14),
                    AutoSize = true,
                    Padding = new Padding(8, 2, 8, 2)
                };
                var lblNum = new Label
                {
                    Text = $"Hab. {h.Numero}",
                    Font = new Font("Georgia", 13f, FontStyle.Bold),
                    ForeColor = UiTheme.SidebarFondo,
                    Location = new Point(12, 42),
                    Size = new Size(186, 26),
                    AutoEllipsis = true
                };
                var lblTipo = new Label
                {
                    Text = $"{h.TipoHabitacionNombre} - Piso {h.Piso}",
                    Font = new Font("Segoe UI", 8.5f),
                    ForeColor = UiTheme.TextoSuave,
                    Location = new Point(12, 70),
                    Size = new Size(186, 20),
                    AutoEllipsis = true
                };
                var lblTarifa = new Label
                {
                    Text = $"{h.PrecioBasePorNoche:C2} / noche",
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = UiTheme.DoradoHotel,
                    Location = new Point(12, 94),
                    Size = new Size(186, 22)
                };
                var extras = new List<string>();
                if (h.TieneVistaMar) extras.Add("Vista Mar");
                if (h.TieneJacuzzi) extras.Add("Jacuzzi");
                if (h.TieneFrigobar) extras.Add("Frigobar");
                var lblExtras = new Label
                {
                    Text = extras.Count > 0 ? string.Join(" | ", extras) : "Estandar",
                    Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(21, 128, 61),
                    Location = new Point(12, 120),
                    Size = new Size(186, 20),
                    AutoEllipsis = true
                };

                EventHandler onSelect = (_, _) => CargarEnFormulario(h);
                card.Click += onSelect;
                foreach (Control child in new Control[] { barra, lblEstadoBadge, lblNum, lblTipo, lblTarifa, lblExtras })
                {
                    child.Click += onSelect;
                    card.Controls.Add(child);
                }
                flpMapa.Controls.Add(card);
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
