using Hotel.Api.Hubs;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class HabitacionesController : ApiControllerBase
    {
        private readonly IHabitacionLN _ln;
        private readonly INotificadorTiempoReal _notificador;

        public HabitacionesController(IHabitacionLN ln, INotificadorTiempoReal notificador)
        {
            _ln = ln;
            _notificador = notificador;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] bool soloActivas = false) =>
            ToActionResult(await _ln.ListarAsync(soloActivas));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id) =>
            ToActionResult(await _ln.ObtenerPorIdAsync(id));

        [HttpGet("disponibles")]
        public async Task<IActionResult> BuscarDisponibles(
            [FromQuery] DateOnly fechaInicio,
            [FromQuery] DateOnly fechaFin,
            [FromQuery] int huespedes = 1,
            [FromQuery] int? tipoHabitacionId = null) =>
            ToActionResult(await _ln.BuscarDisponiblesAsync(fechaInicio, fechaFin, huespedes, tipoHabitacionId));

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ETHabitacion dto)
        {
            var res = await _ln.InsertarAsync(dto);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ETHabitacion dto)
        {
            dto.Id = id;
            var res = await _ln.ModificarAsync(dto);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }

        [HttpPatch("{id:int}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromQuery] string estado)
        {
            var res = await _ln.CambiarEstadoOperativoAsync(id, estado);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            var res = await _ln.DesactivarAsync(id);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }
    }
}
