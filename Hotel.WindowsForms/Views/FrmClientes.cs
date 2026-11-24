using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmClientes : Form
    {
        private readonly ClientesMvcController _ctrl;
        private DataGridView _dgvClientes = null!;
        private DataGridView _dgvHistorial = null!;
        private TextBox _txtBuscar = null!;
        private ComboBox _cboTipoDoc = null!;
        private TextBox _txtDoc = null!;
        private TextBox _txtNombres = null!;
        private TextBox _txtApellidos = null!;
        private TextBox _txtNacionalidad = null!;
        private TextBox _txtEmail = null!;
        private TextBox _txtTelefono = null!;
        private TextBox _txtTelEmergencia = null!;
        private TextBox _txtDireccion = null!;
        private TextBox _txtPreferencias = null!;
        private CheckBox _chkFrecuente = null!;
        private Label _lblResumenHist = null!;
        private int _idSeleccionado = 0;

        public FrmClientes(HotelAppContext app)
        {
            _ctrl = new ClientesMvcController(app.Api);
            InicializarComponentes();
            Shown += async (_, _) => await BuscarAsync();
        }

        private void InicializarComponentes()
        {
            Text = "Gestión de Clientes y Huéspedes";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var pnlTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48, Padding = new Padding(12, 8, 12, 6), BackColor = Color.White };
            pnlTop.Controls.Add(new Label { Text = "Buscar por ID, Nombre o Correo:", AutoSize = true, Padding = new Padding(0, 6, 0, 0), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) });
            _txtBuscar = new TextBox { Width = 260 };
            var btnBuscar = new Button { Text = "Buscar", Width = 90, Height = 28 };
            UiTheme.EstilizarBoton(btnBuscar, UiTheme.Primario);
            btnBuscar.Click += async (_, _) => await BuscarAsync();
            pnlTop.Controls.Add(_txtBuscar);
            pnlTop.Controls.Add(btnBuscar);

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 560 };

            var splitIzq = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 300 };
            _dgvClientes = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvClientes);
            _dgvClientes.CellClick += async (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgvClientes.Rows[e.RowIndex].DataBoundItem is ClienteModel c)
                {
                    CargarFormulario(c);
                    await CargarHistorialAsync(c.Id);
                }
            };
            splitIzq.Panel1.Controls.Add(_dgvClientes);

            var pnlHist = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(8) };
            _lblResumenHist = new Label { Text = "Historial de Estadías", Dock = DockStyle.Top, Height = 26, Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold) };
            _dgvHistorial = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvHistorial);
            pnlHist.Controls.Add(_dgvHistorial);
            pnlHist.Controls.Add(_lblResumenHist);
            splitIzq.Panel2.Controls.Add(pnlHist);
            split.Panel1.Controls.Add(splitIzq);

            var pnlForm = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(14), AutoScroll = true };
            var tbl = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, AutoSize = true };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));

            _cboTipoDoc = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboTipoDoc.Items.AddRange(["Cedula", "DNI", "Pasaporte"]);
            _cboTipoDoc.SelectedIndex = 0;
            _txtDoc = new TextBox { Dock = DockStyle.Fill };
            _txtNombres = new TextBox { Dock = DockStyle.Fill };
            _txtApellidos = new TextBox { Dock = DockStyle.Fill };
            _txtNacionalidad = new TextBox { Dock = DockStyle.Fill, Text = "Costarricense" };
            _txtEmail = new TextBox { Dock = DockStyle.Fill };
            _txtTelefono = new TextBox { Dock = DockStyle.Fill };
            _txtTelEmergencia = new TextBox { Dock = DockStyle.Fill };
            _txtDireccion = new TextBox { Dock = DockStyle.Fill };
            _txtPreferencias = new TextBox { Dock = DockStyle.Fill };
            _chkFrecuente = new CheckBox { Text = "Cliente Frecuente (10% desc.)" };

            Agregar(tbl, 0, "Tipo Doc.:", _cboTipoDoc);
            Agregar(tbl, 1, "No. Documento:", _txtDoc);
            Agregar(tbl, 2, "Nombres:", _txtNombres);
            Agregar(tbl, 3, "Apellidos:", _txtApellidos);
            Agregar(tbl, 4, "Nacionalidad:", _txtNacionalidad);
            Agregar(tbl, 5, "Correo:", _txtEmail);
            Agregar(tbl, 6, "Teléfono:", _txtTelefono);
            Agregar(tbl, 7, "Tel. Emergencia:", _txtTelEmergencia);
            Agregar(tbl, 8, "Dirección:", _txtDireccion);
            Agregar(tbl, 9, "Preferencias:", _txtPreferencias);
            Agregar(tbl, 10, "Estado VIP:", _chkFrecuente);

            var flp = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(0, 10, 0, 0) };
            var btnNuevo = new Button { Text = "Nuevo", Width = 95, Height = 34 };
            var btnGuardar = new Button { Text = "Guardar Cliente", Width = 135, Height = 34 };
            UiTheme.EstilizarBoton(btnNuevo, Color.FromArgb(100, 116, 139));
            UiTheme.EstilizarBoton(btnGuardar, UiTheme.Primario);
            btnNuevo.Click += (_, _) => Limpiar();
            btnGuardar.Click += async (_, _) => await GuardarAsync();
            flp.Controls.AddRange([btnNuevo, btnGuardar]);

            pnlForm.Controls.Add(flp);
            pnlForm.Controls.Add(tbl);
            split.Panel2.Controls.Add(pnlForm);

            Controls.Add(split);
            Controls.Add(pnlTop);
        }

        private static void Agregar(TableLayoutPanel t, int row, string lbl, Control c)
        {
            t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            t.Controls.Add(new Label { Text = lbl, AutoSize = true, Padding = new Padding(0, 5, 0, 5), Font = new Font("Segoe UI", 9, FontStyle.Bold) }, 0, row);
            t.Controls.Add(c, 1, row);
        }

        private async Task BuscarAsync()
        {
            var res = await _ctrl.ListarAsync(_txtBuscar.Text.Trim());
            if (res.Success) _dgvClientes.DataSource = res.Data;
            else MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async Task CargarHistorialAsync(int clienteId)
        {
            var res = await _ctrl.ObtenerHistorialAsync(clienteId);
            if (res.Success && res.Data != null)
            {
                _lblResumenHist.Text = $"Estadías completadas: {res.Data.TotalEstadias} | Total facturado acumulado: {res.Data.TotalFacturadoAcumulado:C2}";
                _dgvHistorial.DataSource = res.Data.Reservaciones;
            }
        }

        private void CargarFormulario(ClienteModel c)
        {
            _idSeleccionado = c.Id;
            _cboTipoDoc.SelectedItem = c.TipoDocumento;
            _txtDoc.Text = c.NumeroDocumento;
            _txtNombres.Text = c.Nombres;
            _txtApellidos.Text = c.Apellidos;
            _txtNacionalidad.Text = c.Nacionalidad;
            _txtEmail.Text = c.Email;
            _txtTelefono.Text = c.Telefono;
            _txtTelEmergencia.Text = c.TelefonoEmergencia ?? string.Empty;
            _txtDireccion.Text = c.Direccion ?? string.Empty;
            _txtPreferencias.Text = c.Preferencias ?? string.Empty;
            _chkFrecuente.Checked = c.EsClienteFrecuente;
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            _cboTipoDoc.SelectedIndex = 0;
            _txtDoc.Clear();
            _txtNombres.Clear();
            _txtApellidos.Clear();
            _txtNacionalidad.Text = "Costarricense";
            _txtEmail.Clear();
            _txtTelefono.Clear();
            _txtTelEmergencia.Clear();
            _txtDireccion.Clear();
            _txtPreferencias.Clear();
            _chkFrecuente.Checked = false;
        }

        private async Task GuardarAsync()
        {
            var dto = new ClienteModel
            {
                Id = _idSeleccionado,
                TipoDocumento = _cboTipoDoc.SelectedItem?.ToString() ?? "Cedula",
                NumeroDocumento = _txtDoc.Text.Trim(),
                Nombres = _txtNombres.Text.Trim(),
                Apellidos = _txtApellidos.Text.Trim(),
                Nacionalidad = _txtNacionalidad.Text.Trim(),
                Email = _txtEmail.Text.Trim(),
                Telefono = _txtTelefono.Text.Trim(),
                TelefonoEmergencia = _txtTelEmergencia.Text.Trim(),
                Direccion = _txtDireccion.Text.Trim(),
                Preferencias = _txtPreferencias.Text.Trim(),
                EsClienteFrecuente = _chkFrecuente.Checked
            };

            var res = _idSeleccionado == 0 ? await _ctrl.CrearAsync(dto) : await _ctrl.ActualizarAsync(dto);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            await BuscarAsync();
        }
    }
}
