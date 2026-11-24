using Hotel.Utilitario;
using Hotel.WindowsForms.Models;
using Hotel.WindowsForms.Services;

namespace Hotel.WindowsForms.Controllers
{
    public class HotelAppContext
    {
        public HotelApiClient Api { get; }
        public HotelRealtimeService Realtime { get; }
        public LoginResponseModel? SesionActual { get; set; }

        public HotelAppContext(string apiBaseUrl)
        {
            Api = new HotelApiClient(apiBaseUrl);
            Realtime = new HotelRealtimeService();
        }
    }

    public class AuthMvcController
    {
        private readonly HotelApiClient _api;
        public AuthMvcController(HotelApiClient api) => _api = api;

        public Task<Result<LoginResponseModel>> LoginAsync(LoginRequestModel req) =>
            _api.PostAsync<LoginResponseModel>("api/auth/login", req);

        public Task<Result<LoginResponseModel>> RegistrarHuespedAsync(RegistroHuespedRequestModel req) =>
            _api.PostAsync<LoginResponseModel>("api/auth/registro", req);

        public Task<Result<List<UsuarioModel>>> ListarUsuariosAsync() =>
            _api.GetAsync<List<UsuarioModel>>("api/auth/usuarios");

        public Task<Result<UsuarioModel>> CrearUsuarioAsync(CrearUsuarioRequestModel req) =>
            _api.PostAsync<UsuarioModel>("api/auth/usuarios", req);

        public Task<Result<UsuarioModel>> CambiarEstadoAsync(int id, bool activo) =>
            _api.PatchAsync<UsuarioModel>($"api/auth/usuarios/{id}/estado?activo={activo}");
    }

    public class HabitacionesMvcController
    {
        private readonly HotelApiClient _api;
        public HabitacionesMvcController(HotelApiClient api) => _api = api;

        public Task<Result<List<TipoHabitacionModel>>> ListarTiposAsync() =>
            _api.GetAsync<List<TipoHabitacionModel>>("api/tiposhabitacion");

        public Task<Result<TipoHabitacionModel>> CrearTipoAsync(TipoHabitacionModel dto) =>
            _api.PostAsync<TipoHabitacionModel>("api/tiposhabitacion", dto);

        public Task<Result<TipoHabitacionModel>> ActualizarTipoAsync(TipoHabitacionModel dto) =>
            _api.PutAsync<TipoHabitacionModel>($"api/tiposhabitacion/{dto.Id}", dto);

        public Task<Result<bool>> EliminarTipoAsync(int id) =>
            _api.DeleteAsync<bool>($"api/tiposhabitacion/{id}");

        public Task<Result<List<HabitacionModel>>> ListarHabitacionesAsync(bool soloActivas = false) =>
            _api.GetAsync<List<HabitacionModel>>($"api/habitaciones?soloActivas={soloActivas}");

        public Task<Result<HabitacionModel>> CrearHabitacionAsync(HabitacionModel dto) =>
            _api.PostAsync<HabitacionModel>("api/habitaciones", dto);

        public Task<Result<HabitacionModel>> ActualizarHabitacionAsync(HabitacionModel dto) =>
            _api.PutAsync<HabitacionModel>($"api/habitaciones/{dto.Id}", dto);

        public Task<Result<HabitacionModel>> CambiarEstadoAsync(int id, string estado) =>
            _api.PatchAsync<HabitacionModel>($"api/habitaciones/{id}/estado?estado={Uri.EscapeDataString(estado)}");

        public Task<Result<bool>> DesactivarHabitacionAsync(int id) =>
            _api.DeleteAsync<bool>($"api/habitaciones/{id}");

        public Task<Result<List<HabitacionModel>>> BuscarDisponiblesAsync(DateOnly inicio, DateOnly fin, int huespedes, int? tipoId = null)
        {
            string url = $"api/habitaciones/disponibles?fechaInicio={inicio:yyyy-MM-dd}&fechaFin={fin:yyyy-MM-dd}&huespedes={huespedes}";
            if (tipoId.HasValue) url += $"&tipoHabitacionId={tipoId.Value}";
            return _api.GetAsync<List<HabitacionModel>>(url);
        }
    }

    public class ClientesMvcController
    {
        private readonly HotelApiClient _api;
        public ClientesMvcController(HotelApiClient api) => _api = api;

        public Task<Result<List<ClienteModel>>> ListarAsync(string? buscar = null)
        {
            string url = string.IsNullOrWhiteSpace(buscar)
                ? "api/clientes"
                : $"api/clientes?buscar={Uri.EscapeDataString(buscar)}";
            return _api.GetAsync<List<ClienteModel>>(url);
        }

        public Task<Result<ClienteHistorialModel>> ObtenerHistorialAsync(int id) =>
            _api.GetAsync<ClienteHistorialModel>($"api/clientes/{id}/historial");

        public Task<Result<ClienteModel>> CrearAsync(ClienteModel dto) =>
            _api.PostAsync<ClienteModel>("api/clientes", dto);

        public Task<Result<ClienteModel>> ActualizarAsync(ClienteModel dto) =>
            _api.PutAsync<ClienteModel>($"api/clientes/{dto.Id}", dto);
    }

    public class ReservacionesMvcController
    {
        private readonly HotelApiClient _api;
        public ReservacionesMvcController(HotelApiClient api) => _api = api;

        public Task<Result<List<ReservacionModel>>> BuscarAsync(string? buscar = null, string? estado = null, DateOnly? desde = null, DateOnly? hasta = null, int? clienteId = null)
        {
            var qs = new List<string>();
            if (!string.IsNullOrWhiteSpace(buscar)) qs.Add($"buscar={Uri.EscapeDataString(buscar)}");
            if (clienteId.HasValue) qs.Add($"clienteId={clienteId.Value}");
            if (!string.IsNullOrWhiteSpace(estado)) qs.Add($"estado={Uri.EscapeDataString(estado)}");
            if (desde.HasValue) qs.Add($"desde={desde.Value:yyyy-MM-dd}");
            if (hasta.HasValue) qs.Add($"hasta={hasta.Value:yyyy-MM-dd}");
            string url = qs.Count > 0 ? $"api/reservaciones?{string.Join("&", qs)}" : "api/reservaciones";
            return _api.GetAsync<List<ReservacionModel>>(url);
        }

        public Task<Result<CotizacionResponseModel>> CotizarAsync(CotizacionRequestModel req) =>
            _api.PostAsync<CotizacionResponseModel>("api/reservaciones/cotizar", req);

        public Task<Result<ReservacionModel>> CrearAsync(CrearReservacionRequestModel req) =>
            _api.PostAsync<ReservacionModel>("api/reservaciones", req);

        public Task<Result<ReservacionModel>> ConfirmarAsync(int id) =>
            _api.PostAsync<ReservacionModel>($"api/reservaciones/{id}/confirmar");

        public Task<Result<ReservacionModel>> CancelarAsync(int id, string? motivo = null)
        {
            string url = string.IsNullOrWhiteSpace(motivo)
                ? $"api/reservaciones/{id}/cancelar"
                : $"api/reservaciones/{id}/cancelar?motivo={Uri.EscapeDataString(motivo)}";
            return _api.PostAsync<ReservacionModel>(url);
        }

        public Task<Result<ReservacionModel>> CheckInAsync(CheckInRequestModel req) =>
            _api.PostAsync<ReservacionModel>("api/reservaciones/checkin", req);

        public Task<Result<EstadoCuentaModel>> CheckOutAsync(CheckOutRequestModel req) =>
            _api.PostAsync<EstadoCuentaModel>("api/reservaciones/checkout", req);

        public Task<Result<EstadoCuentaModel>> ObtenerEstadoCuentaAsync(int id) =>
            _api.GetAsync<EstadoCuentaModel>($"api/reservaciones/{id}/estado-cuenta");

        public Task<Result<PagoModel>> RegistrarPagoAsync(PagoModel pago) =>
            _api.PostAsync<PagoModel>("api/pagos", pago);

        public Task<Result<List<MatrizOcupacionHabitacionModel>>> ObtenerMatrizAsync(DateOnly inicio, DateOnly fin) =>
            _api.GetAsync<List<MatrizOcupacionHabitacionModel>>($"api/reservaciones/matriz-ocupacion?fechaInicio={inicio:yyyy-MM-dd}&fechaFin={fin:yyyy-MM-dd}");
    }

    public class RestauranteMvcController
    {
        private readonly HotelApiClient _api;
        public RestauranteMvcController(HotelApiClient api) => _api = api;

        public Task<Result<List<CategoriaPlatilloModel>>> ListarCategoriasAsync(bool soloActivas = false) =>
            _api.GetAsync<List<CategoriaPlatilloModel>>($"api/restaurante/categorias?soloActivas={soloActivas}");

        public Task<Result<CategoriaPlatilloModel>> GuardarCategoriaAsync(CategoriaPlatilloModel dto) =>
            _api.PostAsync<CategoriaPlatilloModel>("api/restaurante/categorias", dto);

        public Task<Result<List<PlatilloModel>>> ListarPlatillosAsync(int? categoriaId = null, bool soloDisponibles = false)
        {
            string url = $"api/restaurante/platillos?soloDisponibles={soloDisponibles}";
            if (categoriaId.HasValue) url += $"&categoriaId={categoriaId.Value}";
            return _api.GetAsync<List<PlatilloModel>>(url);
        }

        public Task<Result<PlatilloModel>> GuardarPlatilloAsync(PlatilloModel dto) =>
            _api.PostAsync<PlatilloModel>("api/restaurante/platillos", dto);

        public Task<Result<bool>> DesactivarPlatilloAsync(int id) =>
            _api.DeleteAsync<bool>($"api/restaurante/platillos/{id}");

        public Task<Result<List<PedidoRestauranteModel>>> ListarPedidosAsync(int? reservacionId = null, string? estado = null)
        {
            var qs = new List<string>();
            if (reservacionId.HasValue) qs.Add($"reservacionId={reservacionId.Value}");
            if (!string.IsNullOrWhiteSpace(estado)) qs.Add($"estado={Uri.EscapeDataString(estado)}");
            string url = qs.Count > 0 ? $"api/restaurante/pedidos?{string.Join("&", qs)}" : "api/restaurante/pedidos";
            return _api.GetAsync<List<PedidoRestauranteModel>>(url);
        }

        public Task<Result<PedidoRestauranteModel>> CrearPedidoAsync(CrearPedidoRequestModel req) =>
            _api.PostAsync<PedidoRestauranteModel>("api/restaurante/pedidos", req);

        public Task<Result<PedidoRestauranteModel>> CambiarEstadoPedidoAsync(int id, string estado) =>
            _api.PatchAsync<PedidoRestauranteModel>($"api/restaurante/pedidos/{id}/estado?estado={Uri.EscapeDataString(estado)}");

        public Task<Result<PedidoRestauranteModel>> CancelarPedidoAsync(int id) =>
            _api.PostAsync<PedidoRestauranteModel>($"api/restaurante/pedidos/{id}/cancelar");
    }

    public class ReportesMvcController
    {
        private readonly HotelApiClient _api;
        public ReportesMvcController(HotelApiClient api) => _api = api;

        public Task<Result<DashboardKpiModel>> ObtenerDashboardAsync() =>
            _api.GetAsync<DashboardKpiModel>("api/reportes/dashboard");

        public Task<Result<List<ResumenMensualOcupacionModel>>> ObtenerOcupacionMensualAsync(int anio) =>
            _api.GetAsync<List<ResumenMensualOcupacionModel>>($"api/reportes/ocupacion-mensual/{anio}");

        public Task<Result<ReporteIngresosModel>> ObtenerIngresosAsync(DateOnly inicio, DateOnly fin) =>
            _api.GetAsync<ReporteIngresosModel>($"api/reportes/ingresos?fechaInicio={inicio:yyyy-MM-dd}&fechaFin={fin:yyyy-MM-dd}");

        public Task<Result<List<PlatilloMasSolicitadoModel>>> ObtenerPlatillosTopAsync(int top = 10) =>
            _api.GetAsync<List<PlatilloMasSolicitadoModel>>($"api/reportes/platillos-top?top={top}");
    }
}
