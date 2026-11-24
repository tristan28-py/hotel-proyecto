using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Helpers;
using Hotel.WindowsForms.Models;

namespace Hotel.WindowsForms.Views
{
    public class FrmNuevaReservacion : Form
    {
        private readonly HotelAppContext _app;
        private readonly HabitacionesMvcController _habCtrl;
        private readonly ClientesMvcController _cliCtrl;
        private readonly ReservacionesMvcController _resCtrl;

        private MonthCalendar _calEntrada = null!;
        private MonthCalendar _calSalida = null!;
        private NumericUpDown _numHuespedes = null!;
        private ComboBox _cboTipo = null!;
        private DataGridView _dgvDisponibles = null!;
        private ComboBox _cboClientes = null!;
        private TextBox _txtAcompanantes = null!;
        private TextBox _txtObservaciones = null!;
        private Label _lblCotizacion = null!;
        private CheckBox _chkConfirmarAnticipo = null!;
        private NumericUpDown _numAnticipo = null!;
        private ComboBox _cboMetodoPago = null!;
        private TextBox _txtReferencia = null!;
        private DataGridView _dgvMatriz = null!;
        private DateTimePicker _dtpMatrizDesde = null!;
        private DateTimePicker _dtpMatrizHasta = null!;

        private HabitacionModel? _habSeleccionada;
        private CotizacionResponseModel? _ultimaCotizacion;

        public FrmNuevaReservacion(HotelAppContext app)
        {
            _app = app;
            _habCtrl = new HabitacionesMvcController(app.Api);
            _cliCtrl = new ClientesMvcController(app.Api);
            _resCtrl = new ReservacionesMvcController(app.Api);
            InicializarComponentes();

            _app.Realtime.ReservacionesActualizadas += OnTiempoReal;
            FormClosed += (_, _) => _app.Realtime.ReservacionesActualizadas -= OnTiempoReal;
            Shown += async (_, _) => await InicializarDatosAsync();
        }

        private void OnTiempoReal()
        {
            if (IsHandleCreated && !IsDisposed)
                BeginInvoke(async () =>
                {
                    await BuscarDisponiblesAsync();
                    await CargarMatrizAsync();
                });
        }

        private void InicializarComponentes()
        {
            Text = "Nueva Reservación y Matriz de Ocupación";
            BackColor = UiTheme.FondoPrincipal;
            Dock = DockStyle.Fill;

            var tabs = new TabControl { Dock = DockStyle.Fill };

            // TAB 1: Asistente de Reserva
            var tabAsistente = new TabPage("Asistente de Nueva Reservación") { BackColor = UiTheme.FondoPrincipal };
            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 630 };

            // Paso 1 & 2 (Izquierda)
            var pnlIzq = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(12) };
            var pnlFechas = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };

            var grpEntrada = new GroupBox { Text = "1. Fecha Entrada", AutoSize = true };
            _calEntrada = new MonthCalendar { MaxSelectionCount = 1, SelectionStart = DateTime.Today };
            grpEntrada.Controls.Add(_calEntrada);

            var grpSalida = new GroupBox { Text = "Fecha Salida", AutoSize = true };
            _calSalida = new MonthCalendar { MaxSelectionCount = 1, SelectionStart = DateTime.Today.AddDays(2) };
            grpSalida.Controls.Add(_calSalida);

            pnlFechas.Controls.Add(grpEntrada);
            pnlFechas.Controls.Add(grpSalida);

            var pnlFiltros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 46, Padding = new Padding(0, 8, 0, 4) };
            pnlFiltros.Controls.Add(new Label { Text = "Huéspedes:", AutoSize = true, Padding = new Padding(0, 6, 0, 0) });
            _numHuespedes = new NumericUpDown { Minimum = 1, Maximum = 10, Value = 2, Width = 55 };
            pnlFiltros.Controls.Add(_numHuespedes);
            pnlFiltros.Controls.Add(new Label { Text = "Tipo:", AutoSize = true, Padding = new Padding(8, 6, 0, 0) });
            _cboTipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 170 };
            pnlFiltros.Controls.Add(_cboTipo);

            var btnBuscarDisp = new Button { Text = "Buscar Libres", Width = 125, Height = 30 };
            UiTheme.EstilizarBoton(btnBuscarDisp, UiTheme.Primario);
            btnBuscarDisp.Click += async (_, _) => await BuscarDisponiblesAsync();
            pnlFiltros.Controls.Add(btnBuscarDisp);

            _dgvDisponibles = new DataGridView { Dock = DockStyle.Fill };
            UiTheme.EstilizarGrid(_dgvDisponibles);
            _dgvDisponibles.CellClick += async (_, e) =>
            {
                if (e.RowIndex >= 0 && _dgvDisponibles.Rows[e.RowIndex].DataBoundItem is HabitacionModel h)
                {
                    _habSeleccionada = h;
                    await CotizarAsync();
                }
            };

            pnlIzq.Controls.Add(_dgvDisponibles);
            pnlIzq.Controls.Add(pnlFiltros);
            pnlIzq.Controls.Add(pnlFechas);
            split.Panel1.Controls.Add(pnlIzq);

            // Paso 3 & 4 (Derecha: Cliente, Cotización en vivo y Confirmación)
            var pnlDer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(14), AutoScroll = true };
            var lblPaso3 = new Label { Text = "2. Huésped y Cotización en Tiempo Real", Dock = DockStyle.Top, Height = 28, Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold) };

            var pnlCli = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 38 };
            _cboClientes = new ComboBox { Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboClientes.SelectedIndexChanged += async (_, _) => { if (_habSeleccionada != null) await CotizarAsync(); };
            var btnRefrescarCli = new Button { Text = "↻", Width = 34, Height = 28 };
            UiTheme.EstilizarBoton(btnRefrescarCli, Color.FromArgb(100, 116, 139));
            btnRefrescarCli.Click += async (_, _) => await CargarClientesAsync();
            pnlCli.Controls.Add(_cboClientes);
            pnlCli.Controls.Add(btnRefrescarCli);

            _lblCotizacion = new Label
            {
                Dock = DockStyle.Top,
                Height = 175,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Font = new Font("Consolas", 9.5f),
                Text = "Seleccione fechas y una habitación disponible para calcular la cotización en tiempo real."
            };

            _txtAcompanantes = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Nombres de acompañantes (opcional)" };
            _txtObservaciones = new TextBox { Dock = DockStyle.Top, Multiline = true, Height = 46, PlaceholderText = "Observaciones / solicitudes especiales" };

            var grpAnticipo = new GroupBox { Text = "Pago de Anticipo / Seña (30% mínimo para confirmar)", Dock = DockStyle.Top, Height = 135, Padding = new Padding(10) };
            _chkConfirmarAnticipo = new CheckBox { Text = "Registrar pago de anticipo y confirmar inmediatamente", Dock = DockStyle.Top, Checked = true };
            var tblAnt = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            tblAnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tblAnt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            _numAnticipo = new NumericUpDown { Dock = DockStyle.Fill, DecimalPlaces = 2, Maximum = 100000 };
            _cboMetodoPago = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboMetodoPago.Items.AddRange(["TarjetaCredito", "TarjetaDebito", "Efectivo", "TransferenciaBancaria"]);
            _cboMetodoPago.SelectedIndex = 0;
            _txtReferencia = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "No. aprobación / transferencia" };
            tblAnt.Controls.Add(new Label { Text = "Monto Anticipo:", AutoSize = true }, 0, 0);
            tblAnt.Controls.Add(_numAnticipo, 1, 0);
            tblAnt.Controls.Add(new Label { Text = "Método:", AutoSize = true }, 0, 1);
            tblAnt.Controls.Add(_cboMetodoPago, 1, 1);
            tblAnt.Controls.Add(new Label { Text = "Referencia:", AutoSize = true }, 0, 2);
            tblAnt.Controls.Add(_txtReferencia, 1, 2);
            grpAnticipo.Controls.Add(tblAnt);
            grpAnticipo.Controls.Add(_chkConfirmarAnticipo);

            var btnReservar = new Button { Text = "Crear Reservación", Dock = DockStyle.Top, Height = 40 };
            UiTheme.EstilizarBoton(btnReservar, Color.FromArgb(22, 163, 74));
            btnReservar.Click += async (_, _) => await CrearReservacionAsync();

            pnlDer.Controls.Add(btnReservar);
            pnlDer.Controls.Add(grpAnticipo);
            pnlDer.Controls.Add(_txtObservaciones);
            pnlDer.Controls.Add(_txtAcompanantes);
            pnlDer.Controls.Add(_lblCotizacion);
            pnlDer.Controls.Add(pnlCli);
            pnlDer.Controls.Add(lblPaso3);
            split.Panel2.Controls.Add(pnlDer);
            tabAsistente.Controls.Add(split);

            // TAB 2: Matriz Visual de Ocupación
            var tabMatriz = new TabPage("Matriz Visual de Ocupación") { BackColor = UiTheme.FondoPrincipal };
            var pnlMatrizTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 46, Padding = new Padding(10, 8, 10, 4), BackColor = Color.White };
            _dtpMatrizDesde = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today, Width = 110 };
            _dtpMatrizHasta = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(10), Width = 110 };
            var btnCargarMatriz = new Button { Text = "Consultar Matriz", Width = 135, Height = 28 };
            UiTheme.EstilizarBoton(btnCargarMatriz, UiTheme.Primario);
            btnCargarMatriz.Click += async (_, _) => await CargarMatrizAsync();
            pnlMatrizTop.Controls.AddRange([
                new Label { Text = "Desde:", AutoSize = true, Padding = new Padding(0, 5, 0, 0) }, _dtpMatrizDesde,
                new Label { Text = "Hasta:", AutoSize = true, Padding = new Padding(8, 5, 0, 0) }, _dtpMatrizHasta,
                btnCargarMatriz
            ]);

            _dgvMatriz = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells };
            UiTheme.EstilizarGrid(_dgvMatriz);
            _dgvMatriz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabMatriz.Controls.Add(_dgvMatriz);
            tabMatriz.Controls.Add(pnlMatrizTop);

            tabs.TabPages.Add(tabAsistente);
            tabs.TabPages.Add(tabMatriz);
            Controls.Add(tabs);
        }

        private async Task InicializarDatosAsync()
        {
            var tiposRes = await _habCtrl.ListarTiposAsync();
            var listaTipos = new List<TipoHabitacionModel> { new() { Id = 0, Nombre = "-- Todos los tipos --" } };
            if (tiposRes.Success && tiposRes.Data != null) listaTipos.AddRange(tiposRes.Data);
            _cboTipo.DataSource = listaTipos;
            _cboTipo.DisplayMember = "Nombre";
            _cboTipo.ValueMember = "Id";

            await CargarClientesAsync();
            await BuscarDisponiblesAsync();
            await CargarMatrizAsync();
        }

        private async Task CargarClientesAsync()
        {
            var cliRes = await _cliCtrl.ListarAsync();
            if (cliRes.Success && cliRes.Data != null)
            {
                _cboClientes.DataSource = cliRes.Data;
                _cboClientes.DisplayMember = "NombreCompleto";
                _cboClientes.ValueMember = "Id";
            }
        }

        private async Task BuscarDisponiblesAsync()
        {
            var entrada = DateOnly.FromDateTime(_calEntrada.SelectionStart);
            var salida = DateOnly.FromDateTime(_calSalida.SelectionStart);
            int? tipoId = _cboTipo.SelectedValue is int id && id > 0 ? id : null;

            var res = await _habCtrl.BuscarDisponiblesAsync(entrada, salida, (int)_numHuespedes.Value, tipoId);
            if (!res.Success)
            {
                MessageBox.Show(res.Error, "Búsqueda de disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _dgvDisponibles.DataSource = res.Data;
        }

        private async Task CotizarAsync()
        {
            if (_habSeleccionada == null) return;

            var req = new CotizacionRequestModel
            {
                HabitacionId = _habSeleccionada.Id,
                ClienteId = _cboClientes.SelectedValue as int?,
                FechaInicio = DateOnly.FromDateTime(_calEntrada.SelectionStart),
                FechaFin = DateOnly.FromDateTime(_calSalida.SelectionStart),
                CantidadHuespedes = (int)_numHuespedes.Value
            };

            var res = await _resCtrl.CotizarAsync(req);
            if (!res.Success || res.Data == null)
            {
                _lblCotizacion.Text = $"No disponible: {res.Error}";
                _ultimaCotizacion = null;
                return;
            }

            _ultimaCotizacion = res.Data;
            var c = res.Data;
            _lblCotizacion.Text =
                $"Habitación: {c.HabitacionNumero} ({c.TipoHabitacion}) - {(c.Disponible ? "DISPONIBLE" : "OCUPADA")}\r\n" +
                $"Noches: {c.Noches} x {c.TarifaBasePorNoche:C2} = {c.SubtotalHospedaje:C2}\r\n" +
                $"Temporada: {c.DetalleTemporada} (+{c.RecargoTemporada:C2})\r\n" +
                $"Personas extra: +{c.RecargoPersonasExtra:C2} | Desc. Frecuente: -{c.DescuentoCliente:C2}\r\n" +
                $"IVA (16%): {c.Impuestos:C2}\r\n" +
                $"TOTAL PROYECTADO: {c.CostoTotal:C2}  |  ANTICIPO (30%): {c.MontoAnticipoRequerido:C2}";

            _numAnticipo.Value = Math.Clamp(c.MontoAnticipoRequerido, 0, 100000);
        }

        private async Task CrearReservacionAsync()
        {
            if (_habSeleccionada == null)
            {
                MessageBox.Show("Seleccione una habitación de la lista de disponibles.", "Falta habitación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_cboClientes.SelectedValue is not int clienteId)
            {
                MessageBox.Show("Seleccione un cliente.", "Falta cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var req = new CrearReservacionRequestModel
            {
                ClienteId = clienteId,
                HabitacionId = _habSeleccionada.Id,
                FechaInicio = DateOnly.FromDateTime(_calEntrada.SelectionStart),
                FechaFin = DateOnly.FromDateTime(_calSalida.SelectionStart),
                HoraLlegadaPactada = new TimeOnly(15, 0),
                CantidadHuespedes = (int)_numHuespedes.Value,
                Acompanantes = _txtAcompanantes.Text.Trim(),
                Observaciones = _txtObservaciones.Text.Trim(),
                ConfirmarConAnticipo = _chkConfirmarAnticipo.Checked,
                MontoAnticipoPagado = _chkConfirmarAnticipo.Checked ? _numAnticipo.Value : null,
                MetodoPagoAnticipo = _chkConfirmarAnticipo.Checked ? _cboMetodoPago.SelectedItem?.ToString() : null,
                ReferenciaPagoAnticipo = _chkConfirmarAnticipo.Checked ? _txtReferencia.Text.Trim() : null
            };

            var res = await _resCtrl.CrearAsync(req);
            if (!res.Success || res.Data == null)
            {
                MessageBox.Show(res.Error, "No se pudo crear la reservación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                await BuscarDisponiblesAsync();
                return;
            }

            MessageBox.Show(
                $"Reservación creada con éxito.\nCódigo: {res.Data.Codigo}\nEstado: {res.Data.Estado}\nTotal: {res.Data.CostoTotal:C2}",
                "Reservación Confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _habSeleccionada = null;
            await BuscarDisponiblesAsync();
            await CargarMatrizAsync();
        }

        private async Task CargarMatrizAsync()
        {
            var inicio = DateOnly.FromDateTime(_dtpMatrizDesde.Value);
            var fin = DateOnly.FromDateTime(_dtpMatrizHasta.Value);
            var res = await _resCtrl.ObtenerMatrizAsync(inicio, fin);
            if (!res.Success || res.Data == null) return;

            _dgvMatriz.Columns.Clear();
            _dgvMatriz.Rows.Clear();
            _dgvMatriz.Columns.Add("Hab", "Hab.");
            _dgvMatriz.Columns.Add("Tipo", "Tipo");

            if (res.Data.Count > 0)
            {
                foreach (var d in res.Data[0].Dias)
                    _dgvMatriz.Columns.Add(d.Fecha.ToString("yyyy-MM-dd"), d.Fecha.ToString("dd/MM"));

                foreach (var fila in res.Data)
                {
                    int idx = _dgvMatriz.Rows.Add();
                    var row = _dgvMatriz.Rows[idx];
                    row.Cells[0].Value = fila.Numero;
                    row.Cells[1].Value = fila.TipoHabitacion;
                    for (int i = 0; i < fila.Dias.Count; i++)
                    {
                        var dia = fila.Dias[i];
                        var cell = row.Cells[i + 2];
                        cell.Value = dia.CodigoReservacion ?? dia.Estado;
                        cell.Style.BackColor = UiTheme.ColorEstadoHabitacion(dia.Estado);
                        cell.Style.ForeColor = dia.Estado == "EnLimpieza" ? Color.Black : Color.White;
                    }
                }
            }
        }
    }
}
