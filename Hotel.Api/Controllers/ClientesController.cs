using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : ApiControllerBase
    {
        private readonly IClienteLN _ln;

        public ClientesController(IClienteLN ln)
        {
            _ln = ln;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] string? buscar = null)
        {
            var res = string.IsNullOrWhiteSpace(buscar)
                ? await _ln.ListarAsync()
                : await _ln.BuscarAsync(buscar);
            return ToActionResult(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id) => ToActionResult(await _ln.ObtenerPorIdAsync(id));

        [HttpGet("{id:int}/historial")]
        public async Task<IActionResult> ObtenerHistorial(int id) => ToActionResult(await _ln.ObtenerHistorialAsync(id));

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ETCliente dto) => ToActionResult(await _ln.InsertarAsync(dto));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ETCliente dto)
        {
            dto.Id = id;
            return ToActionResult(await _ln.ModificarAsync(dto));
        }
    }
}
