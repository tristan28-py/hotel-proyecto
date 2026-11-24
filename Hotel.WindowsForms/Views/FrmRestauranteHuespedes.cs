using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmRestauranteHuespedes : Form
    {
        private readonly HotelAppContext _app;
        private readonly RestauranteMvcController _restCtrl;
        private readonly ReservacionesMvcController _resCtrl;

        private ComboBox _cboEstadiaActiva = null!;
        private ComboBox _cboCategoria = null!;
        private FlowLayoutPanel _flpMenu = null!;
        private DataGridView _dgvCarrito = null!;
        private DataGridView _dgvComandas = null!;
        private RadioButton _rdoRoomService = null!;
        private RadioButton _rdoMesa = null!;
        private TextBox _txtMesa = null!;
        private TextBox _txtInstrucciones = null!;
        private Label _lblTotalPedido = null!;

        private readonly List<(PlatilloModel Platillo, int Cantidad)> _carrito = new();

        public FrmRestauranteHuespedes(HotelAppContext app)
        {
            _app = app;
            _restCtrl = new RestauranteMvcController(app.Api);
            _resCtrl = new ReservacionesMvcController(app.Api);
            InicializarComponentes();

            _app.Realtime.RestauranteActualizado += OnTiempoReal;
            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
            FormClosed += (_, _) =>
            {
                _app.Realtime.RestauranteActualizado -= OnTiempoReal;
                _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
            };
            Shown += async (_, _) => await CargarDatosAsync();
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await CargarDatosAsync());
        }

        private void InicializarComponentes()
        {
            Text = "Restaurante, Room Service y Comandas en Vivo";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 560 };

            // Panel Izquierdo: Menú Visual de Platillos
            var pnlMenuWrap = new Panel { Dock = DockStyle.Fill, BackColor = UiTheme.FondoPrincipal, Padding = new Padding(8) };
            var pnlFiltro = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42, BackColor = Color.White, Padding = new Padding(8, 6, 8, 4) };
            pnlFiltro.Controls.Add(new Label { Text = "Categoría:", AutoSize = true, Padding = new Padding(0, 6, 0, 0), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) });
            _cboCategoria = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboCategoria.SelectedIndexChanged += async (_, _) => await CargarMenuAsync();
            pnlFiltro.Controls.Add(_cboCategoria);

            _flpMenu = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(6) };
            pnlMenuWrap.Controls.Add(_flpMenu);
            pnlMenuWrap.Controls.Add(pnlFiltro);
            split.Panel1.Controls.Add(pnlMenuWrap);

            // Panel Derecho: Carrito + Cargo a Habitación + Comandas en vivo
            var splitDer = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 350 };

            var pnlPedido = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12), AutoScroll = true };
            var lblHab = new Label { Text = "Huésped con Estadía Activa ('EnCurso'):", Dock = DockStyle.Top, Height = 22, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) };
            _cboEstadiaActiva = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };

            var flpMod = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 34, Padding = new Padding(0, 4, 0, 0) };
            _rdoRoomService = new RadioButton { Text = "Room Service (+10%)", Checked = true, AutoSize = true };
            _rdoMesa = new RadioButton { Text = "Mesa Salón", AutoSize = true };
            _txtMesa = new TextBox { Width = 90, PlaceholderText = "Mesa #", Enabled = false };
            _rdoRoomService.CheckedChanged += (_, _) => { _txtMesa.Enabled = !_rdoRoomService.Checked; ActualizarTotalCarrito(); };
            flpMod.Controls.AddRange([_rdoRoomService, _rdoMesa, _txtMesa]);

            _txtInstrucciones = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Instrucciones especiales para cocina" };
            _dgvCarrito = new DataGridView { Dock = DockStyle.Fill, Height = 120 };
            UiTheme.EstilizarGrid(_dgvCarrito);

            var pnlPie = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 44, Padding = new Padding(0, 6, 0, 0) };
            _lblTotalPedido = new Label { Text = "Total: $0.00", AutoSize = true, Font = new Font("Segoe UI", 10.5f, FontStyle.Bold), Padding = new Padding(0, 6, 12, 0) };
            var btnLimpiar = new Button { Text = "Vaciar", Width = 80, Height = 32 };
            var btnEnviar = new Button { Text = "Cargar a Habitación", Width = 175, Height = 32 };
            UiTheme.EstilizarBoton(btnLimpiar, Color.FromArgb(100, 116, 139));
            UiTheme.EstilizarBoton(btnEnviar, Color.FromArgb(22, 163, 74));
            btnLimpiar.Click += (_, _) => { _carrito.Clear(); ActualizarTotalCarrito(); };
            btnEnviar.Click += async (_, _) => await EnviarPedidoAsync();
            pnlPie.Controls.AddRange([_lblTotalPedido, btnLimpiar, btnEnviar]);

            pnlPedido.Controls.Add(_dgvCarrito);
            pnlPedido.Controls.Add(_txtInstrucciones);
            pnlPedido.Controls.Add(flpMod);
            pnlPedido.Controls.Add(_cboEstadiaActiva);
            pnlPedido.Controls.Add(lblHab);
            pnlPedido.Controls.Add(pnlPie);
            splitDer.Panel1.Controls.Add(pnlPedido);

            // Panel inferior: Control de Comandas en Tiempo Real
            var pnlComandas = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10) };
            var flpCmdBtns = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 38 };
            var btnCocina = new Button { Text = "-> EnCocina", Width = 100, Height = 28 };
            var btnCamino = new Button { Text = "-> EnCamino", Width = 100, Height = 28 };
            var btnEntregado = new Button { Text = "-> Entregado", Width = 105, Height = 28 };
            var btnCancelar = new Button { Text = "Cancelar", Width = 85, Height = 28 };
            UiTheme.EstilizarBoton(btnCocina, Color.FromArgb(234, 179, 8), Color.Black);
            UiTheme.EstilizarBoton(btnCamino, UiTheme.Primario);
            UiTheme.EstilizarBoton(btnEntregado, Color.FromArgb(22, 163, 74));
            UiTheme.EstilizarBoton(btnCancelar, Color.FromArgb(220, 38, 38));

            btnCocina.Click += async (_, _) => await AvanzarComandaAsync("EnCocina");
            btnCamino.Click += async (_, _) => await AvanzarComandaAsync("EnCamino");
            btnEntregado.Click += async (_, _) => await AvanzarComandaAsync("Entregado");
            btnCancelar.Click += async (_, _) => await CancelarComandaAsync();
            flpCmdBtns.Controls.AddRange([
                new Label { Text = "Comandas:", AutoSize = true, Padding = new Padding(0, 6, 6, 0), Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) },
                btnCocina, btnCamino, btnEntregado, btnCancelar
            ]);

            _dgvComandas = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvComandas);
            pnlComandas.Controls.Add(_dgvComandas);
            pnlComandas.Controls.Add(flpCmdBtns);
            splitDer.Panel2.Controls.Add(pnlComandas);

            split.Panel2.Controls.Add(splitDer);
            Controls.Add(split);
        }

        private async Task CargarDatosAsync()
        {
            var catsRes = await _restCtrl.ListarCategoriasAsync(soloActivas: true);
            var cats = new List<CategoriaPlatilloModel> { new() { Id = 0, Nombre = "-- Todas --" } };
            if (catsRes.Success && catsRes.Data != null) cats.AddRange(catsRes.Data);
            _cboCategoria.DataSource = cats;
            _cboCategoria.DisplayMember = "Nombre";
            _cboCategoria.ValueMember = "Id";

            var enCursoRes = await _resCtrl.BuscarAsync(estado: "EnCurso");
            if (enCursoRes.Success && enCursoRes.Data != null)
            {
                var items = enCursoRes.Data.Select(r => new
                {
                    r.Id,
                    Texto = $"Hab {r.HabitacionNumero} - {r.ClienteNombreCompleto} ({r.Codigo})"
                }).ToList();
                _cboEstadiaActiva.DataSource = items;
                _cboEstadiaActiva.DisplayMember = "Texto";
                _cboEstadiaActiva.ValueMember = "Id";
            }

            await CargarMenuAsync();
            await CargarComandasAsync();
        }

        private async Task CargarMenuAsync()
        {
            int? catId = _cboCategoria.SelectedValue is int id && id > 0 ? id : null;
            var res = await _restCtrl.ListarPlatillosAsync(catId, soloDisponibles: true);
            if (!res.Success || res.Data == null) return;

            _flpMenu.SuspendLayout();
            _flpMenu.Controls.Clear();
            foreach (var p in res.Data)
            {
                var card = new Panel
                {
                    Width = 240,
                    Height = 135,
                    BackColor = Color.White,
                    Margin = new Padding(6),
                    Padding = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                var lblNombre = new Label
                {
                    Text = $"{p.Nombre}\n[{p.CategoriaNombre}]",
                    Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 38
                };
                var lblPrecio = new Label
                {
                    Text = $"{p.Precio:C2} • {p.TiempoPreparacionMinutos} min",
                    ForeColor = UiTheme.Primario,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 22
                };
                var lblDesc = new Label
                {
                    Text = p.Descripcion ?? string.Empty,
                    ForeColor = UiTheme.TextoSuave,
                    Font = new Font("Segoe UI", 8f),
                    Dock = DockStyle.Fill
                };
                var btnAgregar = new Button { Text = "+ Agregar al Pedido", Dock = DockStyle.Bottom, Height = 28 };
                UiTheme.EstilizarBoton(btnAgregar, UiTheme.Primario);
                btnAgregar.Click += (_, _) => AgregarAlCarrito(p);

                card.Controls.Add(lblDesc);
                card.Controls.Add(lblPrecio);
                card.Controls.Add(lblNombre);
                card.Controls.Add(btnAgregar);
                _flpMenu.Controls.Add(card);
            }
            _flpMenu.ResumeLayout();
        }

        private void AgregarAlCarrito(PlatilloModel p)
        {
            int idx = _carrito.FindIndex(x => x.Platillo.Id == p.Id);
            if (idx >= 0)
                _carrito[idx] = (p, _carrito[idx].Cantidad + 1);
            else
                _carrito.Add((p, 1));

            ActualizarTotalCarrito();
        }

        private void ActualizarTotalCarrito()
        {
            _dgvCarrito.DataSource = _carrito.Select(x => new
            {
                x.Platillo.Nombre,
                x.Cantidad,
                Precio = x.Platillo.Precio,
                Subtotal = x.Platillo.Precio * x.Cantidad
            }).ToList();

            decimal sub = _carrito.Sum(x => x.Platillo.Precio * x.Cantidad);
            decimal recargo = _rdoRoomService.Checked ? Math.Round(sub * 0.10m, 2) : 0m;
            _lblTotalPedido.Text = $"Subtotal: {sub:C2} | Recargo: {recargo:C2} | Total: {(sub + recargo):C2}";
        }

        private async Task EnviarPedidoAsync()
        {
            if (_cboEstadiaActiva.SelectedValue is not int reservaId)
            {
                MessageBox.Show("No hay ninguna habitación con estadía 'EnCurso' seleccionada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_carrito.Count == 0)
            {
                MessageBox.Show("Agregue al menos un platillo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var req = new CrearPedidoRequestModel
            {
                ReservacionId = reservaId,
                FechaHoraDeseada = DateTime.UtcNow,
                EsRoomService = _rdoRoomService.Checked,
                NumeroMesa = _rdoMesa.Checked ? _txtMesa.Text.Trim() : null,
                InstruccionesEspeciales = _txtInstrucciones.Text.Trim(),
                Items = _carrito.Select(x => new CrearPedidoItemModel { PlatilloId = x.Platillo.Id, Cantidad = x.Cantidad }).ToList()
            };

            var res = await _restCtrl.CrearPedidoAsync(req);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "No se pudo cargar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _carrito.Clear();
            _txtInstrucciones.Clear();
            ActualizarTotalCarrito();
            MessageBox.Show("Pedido enviado a cocina y cargado al folio de la habitación.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarComandasAsync();
        }

        private async Task CargarComandasAsync()
        {
            var res = await _restCtrl.ListarPedidosAsync();
            if (res.Success) _dgvComandas.DataSource = res.Data;
        }

        private async Task AvanzarComandaAsync(string nuevoEstado)
        {
            if (_dgvComandas.CurrentRow?.DataBoundItem is not PedidoRestauranteModel ped) return;
            var res = await _restCtrl.CambiarEstadoPedidoAsync(ped.Id, nuevoEstado);
            if (!res.Success) MessageBox.Show(res.Error, "Transición inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await CargarComandasAsync();
        }

        private async Task CancelarComandaAsync()
        {
            if (_dgvComandas.CurrentRow?.DataBoundItem is not PedidoRestauranteModel ped) return;
            var res = await _restCtrl.CancelarPedidoAsync(ped.Id);
            if (!res.Success) MessageBox.Show(res.Error, "No se puede cancelar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await CargarComandasAsync();
        }
    }
}
