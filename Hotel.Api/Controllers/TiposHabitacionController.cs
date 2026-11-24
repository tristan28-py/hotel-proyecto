using Hotel.Api.Hubs;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class TiposHabitacionController : ApiControllerBase
    {
        private readonly ITipoHabitacionLN _ln;
        private readonly INotificadorTiempoReal _notificador;

        public TiposHabitacionController(ITipoHabitacionLN ln, INotificadorTiempoReal notificador)
        {
            _ln = ln;
            _notificador = notificador;
        }

        [HttpGet]
        public async Task<IActionResult> Listar() => ToActionResult(await _ln.ListarAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id) => ToActionResult(await _ln.ObtenerPorIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ETTipoHabitacion dto)
        {
            var res = await _ln.InsertarAsync(dto);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
            return ToActionResult(res);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ETTipoHabitacion dto)
        {
            dto.Id = id;
            var res = await _ln.ModificarAsync(dto);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
            return ToActionResult(res);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = await _ln.EliminarAsync(id);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
            return ToActionResult(res);
        }
    }
}
