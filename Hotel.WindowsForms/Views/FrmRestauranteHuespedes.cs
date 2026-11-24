using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public partial class FrmRestauranteHuespedes : Form
    {
        private readonly HotelAppContext? _app;
        private readonly RestauranteMvcController? _restCtrl;
        private readonly ReservacionesMvcController? _resCtrl;
        private readonly List<(PlatilloModel Platillo, int Cantidad)> _carrito = new();

        public FrmRestauranteHuespedes()
        {
            InitializeComponent();
        }

        public FrmRestauranteHuespedes(HotelAppContext app) : this()
        {
            _app = app;
            _restCtrl = new RestauranteMvcController(app.Api);
            _resCtrl = new ReservacionesMvcController(app.Api);
            _app.Realtime.RestauranteActualizado += OnTiempoReal;
            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
        }

        private async void FrmRestauranteHuespedes_Load(object? sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private void FrmRestauranteHuespedes_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (_app != null)
            {
                _app.Realtime.RestauranteActualizado -= OnTiempoReal;
                _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
            }
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () => await CargarDatosAsync());
        }

        private async void cboCategoria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarMenuAsync();
        }

        private void rdoRoomService_CheckedChanged(object? sender, EventArgs e)
        {
            txtMesa.Enabled = !rdoRoomService.Checked;
            ActualizarTotalCarrito();
        }

        private void btnLimpiarCarrito_Click(object? sender, EventArgs e)
        {
            _carrito.Clear();
            ActualizarTotalCarrito();
        }

        private async void btnEnviarPedido_Click(object? sender, EventArgs e)
        {
            await EnviarPedidoAsync();
        }

        private async void btnCocina_Click(object? sender, EventArgs e) => await AvanzarComandaAsync("EnCocina");
        private async void btnCamino_Click(object? sender, EventArgs e) => await AvanzarComandaAsync("EnCamino");
        private async void btnEntregado_Click(object? sender, EventArgs e) => await AvanzarComandaAsync("Entregado");

        private async void btnCancelarCmd_Click(object? sender, EventArgs e)
        {
            if (_restCtrl == null || dgvComandas.CurrentRow?.DataBoundItem is not PedidoRestauranteModel ped) return;
            var res = await _restCtrl.CancelarPedidoAsync(ped.Id);
            if (!res.Success) MessageBox.Show(res.Error, "No se puede cancelar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await CargarComandasAsync();
        }

        private async Task CargarDatosAsync()
        {
            if (_restCtrl == null || _resCtrl == null) return;

            var catsRes = await _restCtrl.ListarCategoriasAsync(soloActivas: true);
            var cats = new List<CategoriaPlatilloModel> { new() { Id = 0, Nombre = "-- Todas --" } };
            if (catsRes.Success && catsRes.Data != null) cats.AddRange(catsRes.Data);
            cboCategoria.DataSource = cats;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";

            var enCursoRes = await _resCtrl.BuscarAsync(estado: "EnCurso");
            if (enCursoRes.Success && enCursoRes.Data != null)
            {
                var items = enCursoRes.Data.Select(r => new
                {
                    r.Id,
                    Texto = $"Hab {r.HabitacionNumero} - {r.ClienteNombreCompleto} ({r.Codigo})"
                }).ToList();
                cboEstadiaActiva.DataSource = items;
                cboEstadiaActiva.DisplayMember = "Texto";
                cboEstadiaActiva.ValueMember = "Id";
            }

            await CargarMenuAsync();
            await CargarComandasAsync();
        }

        private async Task CargarMenuAsync()
        {
            if (_restCtrl == null) return;
            int? catId = cboCategoria.SelectedValue is int id && id > 0 ? id : null;
            var res = await _restCtrl.ListarPlatillosAsync(catId, soloDisponibles: true);
            if (!res.Success || res.Data == null) return;

            flpMenu.SuspendLayout();
            flpMenu.Controls.Clear();
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
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 38
                };
                var lblPrecio = new Label
                {
                    Text = $"{p.Precio:C2} | {p.TiempoPreparacionMinutos} min",
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
                flpMenu.Controls.Add(card);
            }
            flpMenu.ResumeLayout();
        }

        private void AgregarAlCarrito(PlatilloModel p)
        {
            int idx = _carrito.FindIndex(x => x.Platillo.Id == p.Id);
            if (idx >= 0) _carrito[idx] = (p, _carrito[idx].Cantidad + 1);
            else _carrito.Add((p, 1));
            ActualizarTotalCarrito();
        }

        private void ActualizarTotalCarrito()
        {
            dgvCarrito.DataSource = _carrito.Select(x => new
            {
                x.Platillo.Nombre,
                x.Cantidad,
                Precio = x.Platillo.Precio,
                Subtotal = x.Platillo.Precio * x.Cantidad
            }).ToList();

            decimal sub = _carrito.Sum(x => x.Platillo.Precio * x.Cantidad);
            decimal recargo = rdoRoomService.Checked ? Math.Round(sub * 0.10m, 2) : 0m;
            lblTotalPedido.Text = $"Subtotal: {sub:C2} | Recargo: {recargo:C2} | Total: {(sub + recargo):C2}";
        }

        private async Task EnviarPedidoAsync()
        {
            if (_restCtrl == null) return;
            if (cboEstadiaActiva.SelectedValue is not int reservaId)
            {
                MessageBox.Show("No hay ninguna habitacion con estadia 'EnCurso' seleccionada.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_carrito.Count == 0)
            {
                MessageBox.Show("Agregue al menos un platillo.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var req = new CrearPedidoRequestModel
            {
                ReservacionId = reservaId,
                FechaHoraDeseada = DateTime.UtcNow,
                EsRoomService = rdoRoomService.Checked,
                NumeroMesa = rdoMesa.Checked ? txtMesa.Text.Trim() : null,
                InstruccionesEspeciales = txtInstrucciones.Text.Trim(),
                Items = _carrito.Select(x => new CrearPedidoItemModel { PlatilloId = x.Platillo.Id, Cantidad = x.Cantidad }).ToList()
            };

            var res = await _restCtrl.CrearPedidoAsync(req);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "No se pudo cargar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _carrito.Clear();
            txtInstrucciones.Clear();
            ActualizarTotalCarrito();
            MessageBox.Show("Pedido enviado a cocina y cargado al folio de la habitacion.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarComandasAsync();
        }

        private async Task CargarComandasAsync()
        {
            if (_restCtrl == null) return;
            var res = await _restCtrl.ListarPedidosAsync();
            if (res.Success) dgvComandas.DataSource = res.Data;
        }

        private async Task AvanzarComandaAsync(string nuevoEstado)
        {
            if (_restCtrl == null || dgvComandas.CurrentRow?.DataBoundItem is not PedidoRestauranteModel ped) return;
            var res = await _restCtrl.CambiarEstadoPedidoAsync(ped.Id, nuevoEstado);
            if (!res.Success) MessageBox.Show(res.Error, "Transicion invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else await CargarComandasAsync();
        }
    }
}
