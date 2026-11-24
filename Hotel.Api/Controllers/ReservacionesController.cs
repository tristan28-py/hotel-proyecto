using Hotel.Api.Hubs;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReservacionesController : ApiControllerBase
    {
        private readonly IReservacionLN _ln;
        private readonly INotificadorTiempoReal _notificador;

        public ReservacionesController(IReservacionLN ln, INotificadorTiempoReal notificador)
        {
            _ln = ln;
            _notificador = notificador;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(
            [FromQuery] string? buscar = null,
            [FromQuery] int? clienteId = null,
            [FromQuery] int? habitacionId = null,
            [FromQuery] string? estado = null,
            [FromQuery] DateOnly? desde = null,
            [FromQuery] DateOnly? hasta = null) =>
            ToActionResult(await _ln.BuscarAsync(buscar, clienteId, habitacionId, estado, desde, hasta));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id) => ToActionResult(await _ln.ObtenerPorIdAsync(id));

        [HttpGet("codigo/{codigo}")]
        public async Task<IActionResult> ObtenerPorCodigo(string codigo) => ToActionResult(await _ln.ObtenerPorCodigoAsync(codigo));

        [HttpGet("{id:int}/estado-cuenta")]
        public async Task<IActionResult> ObtenerEstadoCuenta(int id) => ToActionResult(await _ln.ObtenerEstadoCuentaAsync(id));

        [HttpGet("matriz-ocupacion")]
        public async Task<IActionResult> ObtenerMatriz([FromQuery] DateOnly fechaInicio, [FromQuery] DateOnly fechaFin) =>
            ToActionResult(await _ln.ObtenerMatrizOcupacionAsync(fechaInicio, fechaFin));

        [HttpPost("cotizar")]
        public async Task<IActionResult> Cotizar([FromBody] CotizacionRequestDTO request) =>
            ToActionResult(await _ln.CotizarAsync(request));

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearReservacionRequestDTO request)
        {
            var res = await _ln.CrearReservacionAsync(request);
            if (res.Success) await NotificarCambiosReserva();
            return ToActionResult(res);
        }

        [HttpPost("{id:int}/confirmar")]
        public async Task<IActionResult> Confirmar(int id)
        {
            var res = await _ln.ConfirmarReservacionAsync(id);
            if (res.Success) await NotificarCambiosReserva();
            return ToActionResult(res);
        }

        [HttpPost("{id:int}/cancelar")]
        public async Task<IActionResult> Cancelar(int id, [FromQuery] string? motivo = null)
        {
            var res = await _ln.CancelarReservacionAsync(id, motivo);
            if (res.Success) await NotificarCambiosReserva();
            return ToActionResult(res);
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] CheckInRequestDTO request)
        {
            var res = await _ln.RegistrarCheckInAsync(request);
            if (res.Success) await NotificarCambiosReserva();
            return ToActionResult(res);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckOut([FromBody] CheckOutRequestDTO request)
        {
            var res = await _ln.RegistrarCheckOutAsync(request);
            if (res.Success) await NotificarCambiosReserva();
            return ToActionResult(res);
        }

        private async Task NotificarCambiosReserva()
        {
            await _notificador.NotificarAsync(EventosTiempoReal.ReservacionesActualizadas);
            await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
            await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
        }
    }
}
