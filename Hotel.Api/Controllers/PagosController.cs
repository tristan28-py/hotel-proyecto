using Hotel.Api.Hubs;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class PagosController : ApiControllerBase
    {
        private readonly IPagoLN _ln;
        private readonly INotificadorTiempoReal _notificador;

        public PagosController(IPagoLN ln, INotificadorTiempoReal notificador)
        {
            _ln = ln;
            _notificador = notificador;
        }

        [HttpGet("reservacion/{reservacionId:int}")]
        public async Task<IActionResult> ListarPorReservacion(int reservacionId) =>
            ToActionResult(await _ln.ListarPorReservacionAsync(reservacionId));

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] ETPago dto)
        {
            var res = await _ln.RegistrarPagoAsync(dto);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.ReservacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.HabitacionesActualizadas);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }
    }
}
