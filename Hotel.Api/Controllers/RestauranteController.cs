using Hotel.Api.Hubs;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : ApiControllerBase
    {
        private readonly IRestauranteLN _ln;
        private readonly INotificadorTiempoReal _notificador;

        public RestauranteController(IRestauranteLN ln, INotificadorTiempoReal notificador)
        {
            _ln = ln;
            _notificador = notificador;
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> ListarCategorias([FromQuery] bool soloActivas = false) =>
            ToActionResult(await _ln.ListarCategoriasAsync(soloActivas));

        [HttpPost("categorias")]
        public async Task<IActionResult> GuardarCategoria([FromBody] ETCategoriaPlatillo dto)
        {
            var res = await _ln.GuardarCategoriaAsync(dto);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
            return ToActionResult(res);
        }

        [HttpGet("platillos")]
        public async Task<IActionResult> ListarPlatillos([FromQuery] int? categoriaId = null, [FromQuery] bool soloDisponibles = false) =>
            ToActionResult(await _ln.ListarPlatillosAsync(categoriaId, soloDisponibles));

        [HttpPost("platillos")]
        public async Task<IActionResult> GuardarPlatillo([FromBody] ETPlatillo dto)
        {
            var res = await _ln.GuardarPlatilloAsync(dto);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
            return ToActionResult(res);
        }

        [HttpDelete("platillos/{id:int}")]
        public async Task<IActionResult> DesactivarPlatillo(int id)
        {
            var res = await _ln.DesactivarPlatilloAsync(id);
            if (res.Success) await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
            return ToActionResult(res);
        }

        [HttpGet("pedidos")]
        public async Task<IActionResult> ListarPedidos(
            [FromQuery] int? reservacionId = null,
            [FromQuery] string? estado = null,
            [FromQuery] DateOnly? fecha = null) =>
            ToActionResult(await _ln.ListarPedidosAsync(reservacionId, estado, fecha));

        [HttpPost("pedidos")]
        public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoRestauranteRequestDTO request)
        {
            var res = await _ln.CrearPedidoAsync(request);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }

        [HttpPatch("pedidos/{id:int}/estado")]
        public async Task<IActionResult> CambiarEstadoPedido(int id, [FromQuery] string estado)
        {
            var res = await _ln.CambiarEstadoPedidoAsync(id, estado);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }

        [HttpPost("pedidos/{id:int}/cancelar")]
        public async Task<IActionResult> CancelarPedido(int id)
        {
            var res = await _ln.CancelarPedidoAsync(id);
            if (res.Success)
            {
                await _notificador.NotificarAsync(EventosTiempoReal.RestauranteActualizado);
                await _notificador.NotificarAsync(EventosTiempoReal.DashboardActualizado);
            }
            return ToActionResult(res);
        }
    }
}
