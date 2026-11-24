using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmTipoHabitacion : Form
    {
        private readonly HabitacionesMvcController _ctrl;
        private DataGridView _dgv = null!;
        private TextBox _txtNombre = null!;
        private TextBox _txtDescripcion = null!;
        private NumericUpDown _numAdultos = null!;
        private NumericUpDown _numNinos = null!;
        private NumericUpDown _numPrecio = null!;
        private int _idSeleccionado = 0;

        public FrmTipoHabitacion(HotelAppContext app)
        {
            _ctrl = new HabitacionesMvcController(app.Api);
            InicializarComponentes();
            Shown += async (_, _) => await CargarAsync();
        }

        private void InicializarComponentes()
        {
            Text = "Tipos de Habitación";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var lbl = new Label
            {
                Text = "Catálogo de Tipos de Habitación",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = UiTheme.TextoOscuro,
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(12, 8, 12, 0)
            };

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 520 };

            _dgv = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgv);
            _dgv.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgv.Rows[e.RowIndex].DataBoundItem is TipoHabitacionModel t)
                {
                    _idSeleccionado = t.Id;
                    _txtNombre.Text = t.Nombre;
                    _txtDescripcion.Text = t.Descripcion ?? string.Empty;
                    _numAdultos.Value = t.CapacidadAdultos;
                    _numNinos.Value = t.CapacidadNinos;
                    _numPrecio.Value = t.PrecioBasePorNoche;
                }
            };
            split.Panel1.Controls.Add(_dgv);

            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(16) };
            var tbl = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 2, AutoSize = true };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));

            _txtNombre = new TextBox { Dock = DockStyle.Fill };
            _txtDescripcion = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 60 };
            _numAdultos = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 10, Value = 2 };
            _numNinos = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 0, Maximum = 10, Value = 1 };
            _numPrecio = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 10000, DecimalPlaces = 2, Value = 100 };

            Agregar(tbl, 0, "Nombre:", _txtNombre);
            Agregar(tbl, 1, "Descripción:", _txtDescripcion);
            Agregar(tbl, 2, "Cap. Adultos:", _numAdultos);
            Agregar(tbl, 3, "Cap. Niños:", _numNinos);
            Agregar(tbl, 4, "Precio/Noche:", _numPrecio);

            var flp = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(0, 12, 0, 0) };
            var btnNuevo = new Button { Text = "Nuevo", Width = 95, Height = 34 };
            var btnGuardar = new Button { Text = "Guardar", Width = 105, Height = 34 };
            var btnEliminar = new Button { Text = "Eliminar", Width = 95, Height = 34 };

            UiTheme.EstilizarBoton(btnNuevo, Color.FromArgb(100, 116, 139));
            UiTheme.EstilizarBoton(btnGuardar, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnEliminar, Color.FromArgb(220, 38, 38));

            btnNuevo.Click += (_, _) => Limpiar();
            btnGuardar.Click += async (_, _) => await GuardarAsync();
            btnEliminar.Click += async (_, _) => await EliminarAsync();

            flp.Controls.AddRange([btnNuevo, btnGuardar, btnEliminar]);
            pnl.Controls.Add(flp);
            pnl.Controls.Add(tbl);
            split.Panel2.Controls.Add(pnl);

            Controls.Add(split);
            Controls.Add(lbl);
        }

        private static void Agregar(TableLayoutPanel t, int row, string lbl, Control c)
        {
            t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            t.Controls.Add(new Label { Text = lbl, AutoSize = true, Padding = new Padding(0, 6, 0, 6), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) }, 0, row);
            t.Controls.Add(c, 1, row);
        }

        private async Task CargarAsync()
        {
            var res = await _ctrl.ListarTiposAsync();
            if (res.Success) _dgv.DataSource = res.Data;
            else MessageBox.Show(res.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Limpiar()
        {
            _idSeleccionado = 0;
            _txtNombre.Clear();
            _txtDescripcion.Clear();
            _numAdultos.Value = 2;
            _numNinos.Value = 0;
            _numPrecio.Value = 100;
        }

        private async Task GuardarAsync()
        {
            var dto = new TipoHabitacionModel
            {
                Id = _idSeleccionado,
                Nombre = _txtNombre.Text.Trim(),
                Descripcion = _txtDescripcion.Text.Trim(),
                CapacidadAdultos = (int)_numAdultos.Value,
                CapacidadNinos = (int)_numNinos.Value,
                PrecioBasePorNoche = _numPrecio.Value
            };

            var res = _idSeleccionado == 0 ? await _ctrl.CrearTipoAsync(dto) : await _ctrl.ActualizarTipoAsync(dto);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Limpiar();
            await CargarAsync();
        }

        private async Task EliminarAsync()
        {
            if (_idSeleccionado == 0) return;
            if (MessageBox.Show("¿Eliminar este tipo de habitación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var res = await _ctrl.EliminarTipoAsync(_idSeleccionado);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Limpiar();
            await CargarAsync();
        }
    }
}
