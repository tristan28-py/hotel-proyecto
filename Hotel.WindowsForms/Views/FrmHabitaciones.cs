using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmHabitaciones : Form
    {
        private readonly HotelAppContext _app;
        private readonly HabitacionesMvcController _ctrl;

        private FlowLayoutPanel _flpMapa = null!;
        private DataGridView _dgvHabitaciones = null!;
        private ComboBox _cboTipo = null!;
        private ComboBox _cboEstado = null!;
        private TextBox _txtNumero = null!;
        private NumericUpDown _numPiso = null!;
        private CheckBox _chkJacuzzi = null!;
        private CheckBox _chkVistaMar = null!;
        private CheckBox _chkWifi6 = null!;
        private CheckBox _chkFrigobar = null!;
        private TextBox _txtAmenidades = null!;
        private CheckBox _chkActiva = null!;
        private Label _lblSeleccion = null!;
        private int _idSeleccionado = 0;

        public FrmHabitaciones(HotelAppContext app)
        {
            _app = app;
            _ctrl = new HabitacionesMvcController(app.Api);
            InicializarComponentes();

            _app.Realtime.HabitacionesActualizadas += OnTiempoRealHabitaciones;
            FormClosed += (_, _) => _app.Realtime.HabitacionesActualizadas -= OnTiempoRealHabitaciones;
            Shown += async (_, _) => await CargarDatosAsync();
        }

        private void OnTiempoRealHabitaciones()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await CargarHabitacionesAsync());
        }

        private void InicializarComponentes()
        {
            Text = "Mapa y Administración de Habitaciones";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var lblTitulo = new Label
            {
                Text = "Mapa de Habitaciones en Tiempo Real",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = UiTheme.TextoOscuro,
                Dock = DockStyle.Top,
                Height = 38,
                Padding = new Padding(12, 8, 12, 0)
            };

            var pnlLeyenda = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 38,
                Padding = new Padding(12, 4, 12, 4),
                BackColor = Color.White
            };
            pnlLeyenda.Controls.Add(CrearBadgeLeyenda("Disponible", UiTheme.ColorEstadoHabitacion("Disponible")));
            pnlLeyenda.Controls.Add(CrearBadgeLeyenda("Ocupada", UiTheme.ColorEstadoHabitacion("Ocupada")));
            pnlLeyenda.Controls.Add(CrearBadgeLeyenda("EnLimpieza", UiTheme.ColorEstadoHabitacion("EnLimpieza")));
            pnlLeyenda.Controls.Add(CrearBadgeLeyenda("Reservada", UiTheme.ColorEstadoHabitacion("Reservada")));
            pnlLeyenda.Controls.Add(CrearBadgeLeyenda("Mantenimiento/Bloqueada", UiTheme.ColorEstadoHabitacion("EnMantenimiento")));

            var btnRefrescar = new Button { Text = "Actualizar", Width = 100, Height = 28 };
            UiTheme.EstilizarBoton(btnRefrescar, UiTheme.Primario);
            btnRefrescar.Click += async (_, _) => await CargarHabitacionesAsync();
            pnlLeyenda.Controls.Add(btnRefrescar);

            var splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 540
            };

            // Panel izquierdo: Tabs Mapa Visual / Tabla
            var tabs = new TabControl { Dock = DockStyle.Fill };
            var tabMapa = new TabPage("Mapa Visual por Colores") { BackColor = UiTheme.FondoPrincipal };
            _flpMapa = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(12)
            };
            tabMapa.Controls.Add(_flpMapa);

            var tabTabla = new TabPage("Listado Detallado");
            _dgvHabitaciones = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvHabitaciones);
            _dgvHabitaciones.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgvHabitaciones.Rows[e.RowIndex].DataBoundItem is HabitacionModel h)
                    CargarEnFormulario(h);
            };
            tabTabla.Controls.Add(_dgvHabitaciones);

            tabs.TabPages.Add(tabMapa);
            tabs.TabPages.Add(tabTabla);
            splitMain.Panel1.Controls.Add(tabs);

            // Panel derecho: Formulario CRUD + Cambio rápido de estado
            var pnlForm = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(16),
                AutoScroll = true
            };

            _lblSeleccion = new Label
            {
                Text = "Nueva Habitación",
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = UiTheme.TextoOscuro,
                Dock = DockStyle.Top,
                Height = 30
            };

            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true,
                Padding = new Padding(0, 8, 0, 8)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));

            _txtNumero = new TextBox { Dock = DockStyle.Fill };
            _numPiso = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 50, Value = 1 };
            _cboTipo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboEstado = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboEstado.Items.AddRange(["Disponible", "Reservada", "Ocupada", "EnLimpieza", "EnMantenimiento", "Bloqueada"]);
            _cboEstado.SelectedIndex = 0;

            _chkJacuzzi = new CheckBox { Text = "Jacuzzi" };
            _chkVistaMar = new CheckBox { Text = "Vista al Mar" };
            _chkWifi6 = new CheckBox { Text = "Wi-Fi 6", Checked = true };
            _chkFrigobar = new CheckBox { Text = "Frigobar" };
            _chkActiva = new CheckBox { Text = "Habitación Activa", Checked = true };
            _txtAmenidades = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 52 };

            AgregarFila(tbl, 0, "Número:", _txtNumero);
            AgregarFila(tbl, 1, "Piso:", _numPiso);
            AgregarFila(tbl, 2, "Tipo:", _cboTipo);
            AgregarFila(tbl, 3, "Estado:", _cboEstado);

            var flpChecks = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
            flpChecks.Controls.AddRange([_chkJacuzzi, _chkVistaMar, _chkWifi6, _chkFrigobar, _chkActiva]);
            AgregarFila(tbl, 4, "Amenidades:", flpChecks);
            AgregarFila(tbl, 5, "Extras:", _txtAmenidades);

            var flpAcciones = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(0, 8, 0, 8) };
            var btnNuevo = new Button { Text = "Limpiar / Nueva", Width = 120, Height = 34 };
            var btnGuardar = new Button { Text = "Guardar", Width = 110, Height = 34 };
            var btnEstadoRapido = new Button { Text = "Aplicar Estado", Width = 120, Height = 34 };
            var btnDesactivar = new Button { Text = "Desactivar", Width = 100, Height = 34 };

            UiTheme.EstilizarBoton(btnNuevo, Color.FromArgb(100, 116, 139));
            UiTheme.EstilizarBoton(btnGuardar, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnEstadoRapido, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnDesactivar, Color.FromArgb(220, 38, 38));

            btnNuevo.Click += (_, _) => LimpiarFormulario();
            btnGuardar.Click += async (_, _) => await GuardarAsync();
            btnEstadoRapido.Click += async (_, _) => await CambiarEstadoRapidoAsync();
            btnDesactivar.Click += async (_, _) => await DesactivarAsync();

            flpAcciones.Controls.AddRange([btnNuevo, btnGuardar, btnEstadoRapido, btnDesactivar]);

            pnlForm.Controls.Add(flpAcciones);
            pnlForm.Controls.Add(tbl);
            pnlForm.Controls.Add(_lblSeleccion);
            splitMain.Panel2.Controls.Add(pnlForm);

            Controls.Add(splitMain);
            Controls.Add(pnlLeyenda);
            Controls.Add(lblTitulo);
        }

        private static Label CrearBadgeLeyenda(string texto, Color color) => new()
        {
            Text = $"  {texto}  ",
            BackColor = color,
            ForeColor = texto == "EnLimpieza" ? Color.Black : Color.White,
            Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
            AutoSize = true,
            Padding = new Padding(4, 3, 4, 3),
            Margin = new Padding(4, 3, 6, 3)
        };

        private static void AgregarFila(TableLayoutPanel tbl, int fila, string etiqueta, Control ctrl)
        {
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add(new Label
            {
                Text = etiqueta,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Padding = new Padding(0, 6, 0, 6),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
            }, 0, fila);
            tbl.Controls.Add(ctrl, 1, fila);
        }

        private async Task CargarDatosAsync()
        {
            var tiposRes = await _ctrl.ListarTiposAsync();
            if (tiposRes.Success && tiposRes.Data != null)
            {
                _cboTipo.DataSource = tiposRes.Data;
                _cboTipo.DisplayMember = "Nombre";
                _cboTipo.ValueMember = "Id";
            }
            await CargarHabitacionesAsync();
        }

        private async Task CargarHabitacionesAsync()
        {
            var res = await _ctrl.ListarHabitacionesAsync();
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dgvHabitaciones.DataSource = res.Data;

            _flpMapa.SuspendLayout();
            _flpMapa.Controls.Clear();
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
                    Text = $"Hab. {h.Numero}\nPiso {h.Piso} • {h.TipoHabitacionNombre}\n[{h.EstadoOperativo}]\n{h.PrecioBasePorNoche:C2}/noche"
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (_, _) => CargarEnFormulario(h);
                _flpMapa.Controls.Add(btn);
            }
            _flpMapa.ResumeLayout();
        }

        private void CargarEnFormulario(HabitacionModel h)
        {
            _idSeleccionado = h.Id;
            _lblSeleccion.Text = $"Editando Habitación {h.Numero}";
            _txtNumero.Text = h.Numero;
            _numPiso.Value = Math.Clamp(h.Piso, 1, 50);
            _cboTipo.SelectedValue = h.TipoHabitacionId;
            _cboEstado.SelectedItem = h.EstadoOperativo;
            _chkJacuzzi.Checked = h.TieneJacuzzi;
            _chkVistaMar.Checked = h.TieneVistaMar;
            _chkWifi6.Checked = h.TieneWifi6;
            _chkFrigobar.Checked = h.TieneFrigobar;
            _txtAmenidades.Text = h.AmenidadesAdicionales ?? string.Empty;
            _chkActiva.Checked = h.Activa;
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            _lblSeleccion.Text = "Nueva Habitación";
            _txtNumero.Clear();
            _numPiso.Value = 1;
            if (_cboTipo.Items.Count > 0) _cboTipo.SelectedIndex = 0;
            _cboEstado.SelectedItem = "Disponible";
            _chkJacuzzi.Checked = false;
            _chkVistaMar.Checked = false;
            _chkWifi6.Checked = true;
            _chkFrigobar.Checked = false;
            _txtAmenidades.Clear();
            _chkActiva.Checked = true;
        }

        private async Task GuardarAsync()
        {
            if (_cboTipo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de habitación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new HabitacionModel
            {
                Id = _idSeleccionado,
                Numero = _txtNumero.Text.Trim(),
                Piso = (int)_numPiso.Value,
                TipoHabitacionId = (int)_cboTipo.SelectedValue,
                EstadoOperativo = _cboEstado.SelectedItem?.ToString() ?? "Disponible",
                TieneJacuzzi = _chkJacuzzi.Checked,
                TieneVistaMar = _chkVistaMar.Checked,
                TieneWifi6 = _chkWifi6.Checked,
                TieneFrigobar = _chkFrigobar.Checked,
                AmenidadesAdicionales = _txtAmenidades.Text.Trim(),
                Activa = _chkActiva.Checked
            };

            var res = _idSeleccionado == 0
                ? await _ctrl.CrearHabitacionAsync(dto)
                : await _ctrl.ActualizarHabitacionAsync(dto);

            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Habitación guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            await CargarHabitacionesAsync();
        }

        private async Task CambiarEstadoRapidoAsync()
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione primero una habitación del mapa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string estado = _cboEstado.SelectedItem?.ToString() ?? "Disponible";
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
            if (_idSeleccionado == 0) return;
            if (MessageBox.Show("¿Desea desactivar esta habitación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
