using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmPlatillos : Form
    {
        private readonly RestauranteMvcController _ctrl;
        private DataGridView _dgvPlatillos = null!;
        private ComboBox _cboCategoria = null!;
        private TextBox _txtNombre = null!;
        private TextBox _txtDesc = null!;
        private NumericUpDown _numPrecio = null!;
        private NumericUpDown _numTiempo = null!;
        private CheckBox _chkDisponible = null!;
        private TextBox _txtNuevaCat = null!;
        private int _platilloId = 0;

        public FrmPlatillos(HotelAppContext app)
        {
            _ctrl = new RestauranteMvcController(app.Api);
            InicializarComponentes();
            Shown += async (_, _) => await CargarTodoAsync();
        }

        private void InicializarComponentes()
        {
            Text = "Mantenimiento de Categorías y Platillos";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 540 };
            _dgvPlatillos = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvPlatillos);
            _dgvPlatillos.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgvPlatillos.Rows[e.RowIndex].DataBoundItem is PlatilloModel p)
                {
                    _platilloId = p.Id;
                    _cboCategoria.SelectedValue = p.CategoriaId;
                    _txtNombre.Text = p.Nombre;
                    _txtDesc.Text = p.Descripcion ?? string.Empty;
                    _numPrecio.Value = p.Precio;
                    _numTiempo.Value = p.TiempoPreparacionMinutos;
                    _chkDisponible.Checked = p.Disponible;
                }
            };
            split.Panel1.Controls.Add(_dgvPlatillos);

            var pnlDer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(14), AutoScroll = true };
            var grpCat = new GroupBox { Text = "Agregar Categoría de Menú", Dock = DockStyle.Top, Height = 75, Padding = new Padding(8) };
            var flpCat = new FlowLayoutPanel { Dock = DockStyle.Fill };
            _txtNuevaCat = new TextBox { Width = 200, PlaceholderText = "Nombre categoría" };
            var btnAddCat = new Button { Text = "Agregar", Width = 85, Height = 28 };
            UiTheme.EstilizarBoton(btnAddCat, UiTheme.Primario);
            btnAddCat.Click += async (_, _) => await AgregarCategoriaAsync();
            flpCat.Controls.AddRange([_txtNuevaCat, btnAddCat]);
            grpCat.Controls.Add(flpCat);

            var tbl = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, AutoSize = true, Padding = new Padding(0, 10, 0, 10) };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));

            _cboCategoria = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _txtNombre = new TextBox { Dock = DockStyle.Fill };
            _txtDesc = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 55 };
            _numPrecio = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Minimum = 0.5m, Maximum = 10000, Value = 12 };
            _numTiempo = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 180, Value = 15 };
            _chkDisponible = new CheckBox { Text = "Disponible para pedidos", Checked = true };

            Agregar(tbl, 0, "Categoría:", _cboCategoria);
            Agregar(tbl, 1, "Nombre:", _txtNombre);
            Agregar(tbl, 2, "Descripción:", _txtDesc);
            Agregar(tbl, 3, "Precio:", _numPrecio);
            Agregar(tbl, 4, "Prep. (min):", _numTiempo);
            Agregar(tbl, 5, "Estado:", _chkDisponible);

            var flpBtn = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
            var btnNuevo = new Button { Text = "Nuevo", Width = 90, Height = 34 };
            var btnGuardar = new Button { Text = "Guardar Platillo", Width = 135, Height = 34 };
            var btnDesactivar = new Button { Text = "Desactivar", Width = 100, Height = 34 };
            UiTheme.EstilizarBoton(btnNuevo, Color.FromArgb(100, 116, 139));
            UiTheme.EstilizarBoton(btnGuardar, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnDesactivar, Color.FromArgb(220, 38, 38));
            btnNuevo.Click += (_, _) => Limpiar();
            btnGuardar.Click += async (_, _) => await GuardarPlatilloAsync();
            btnDesactivar.Click += async (_, _) => await DesactivarAsync();
            flpBtn.Controls.AddRange([btnNuevo, btnGuardar, btnDesactivar]);

            pnlDer.Controls.Add(flpBtn);
            pnlDer.Controls.Add(tbl);
            pnlDer.Controls.Add(grpCat);
            split.Panel2.Controls.Add(pnlDer);

            Controls.Add(split);
        }

        private static void Agregar(TableLayoutPanel t, int row, string lbl, Control c)
        {
            t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            t.Controls.Add(new Label { Text = lbl, AutoSize = true, Padding = new Padding(0, 6, 0, 6), Font = new Font("Segoe UI", 9, FontStyle.Bold) }, 0, row);
            t.Controls.Add(c, 1, row);
        }

        private async Task CargarTodoAsync()
        {
            var cats = await _ctrl.ListarCategoriasAsync();
            if (cats.Success && cats.Data != null)
            {
                _cboCategoria.DataSource = cats.Data;
                _cboCategoria.DisplayMember = "Nombre";
                _cboCategoria.ValueMember = "Id";
            }

            var plats = await _ctrl.ListarPlatillosAsync();
            if (plats.Success) _dgvPlatillos.DataSource = plats.Data;
        }

        private void Limpiar()
        {
            _platilloId = 0;
            _txtNombre.Clear();
            _txtDesc.Clear();
            _numPrecio.Value = 10;
            _numTiempo.Value = 15;
            _chkDisponible.Checked = true;
        }

        private async Task AgregarCategoriaAsync()
        {
            if (string.IsNullOrWhiteSpace(_txtNuevaCat.Text)) return;
            var res = await _ctrl.GuardarCategoriaAsync(new CategoriaPlatilloModel { Nombre = _txtNuevaCat.Text.Trim(), Activo = true });
            if (!res.Success) MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                _txtNuevaCat.Clear();
                await CargarTodoAsync();
            }
        }

        private async Task GuardarPlatilloAsync()
        {
            if (_cboCategoria.SelectedValue is not int catId) return;
            var res = await _ctrl.GuardarPlatilloAsync(new PlatilloModel
            {
                Id = _platilloId,
                CategoriaId = catId,
                Nombre = _txtNombre.Text.Trim(),
                Descripcion = _txtDesc.Text.Trim(),
                Precio = _numPrecio.Value,
                TiempoPreparacionMinutos = (int)_numTiempo.Value,
                Disponible = _chkDisponible.Checked,
                Activo = true
            });
            if (!res.Success) MessageBox.Show(res.Error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Limpiar();
                await CargarTodoAsync();
            }
        }

        private async Task DesactivarAsync()
        {
            if (_platilloId == 0) return;
            var res = await _ctrl.DesactivarPlatilloAsync(_platilloId);
            if (!res.Success) MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Limpiar();
                await CargarTodoAsync();
            }
        }
    }
}
