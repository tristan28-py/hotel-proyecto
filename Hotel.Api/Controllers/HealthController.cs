using Hotel.AccesoDatos.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly HotelContext _context;

        public HealthController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bool dbOk = await _context.Database.CanConnectAsync();
            return Ok(new
            {
                Servicio = "Hotel.Api",
                Estado = dbOk ? "Saludable" : "SinConexionBD",
                BaseDatosConectada = dbOk,
                FechaUtc = DateTime.UtcNow
            });
        }
    }
}
