using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiControllerBase
    {
        private readonly IAuthLN _ln;

        public AuthController(IAuthLN ln)
        {
            _ln = ln;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var res = await _ln.LoginAsync(request);
            if (!res.Success && res.StatusCode == 401) return Unauthorized(res);
            if (!res.Success && res.StatusCode == 403) return StatusCode(403, res);
            return ToActionResult(res);
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroHuespedRequestDTO request) =>
            ToActionResult(await _ln.RegistrarHuespedAsync(request));

        [HttpGet("usuarios")]
        public async Task<IActionResult> ListarUsuarios() =>
            ToActionResult(await _ln.ListarUsuariosAsync());

        [HttpPost("usuarios")]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioRequestDTO request) =>
            ToActionResult(await _ln.CrearUsuarioAsync(request));

        [HttpPatch("usuarios/{id:int}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromQuery] bool activo) =>
            ToActionResult(await _ln.CambiarEstadoAsync(id, activo));
    }
}
