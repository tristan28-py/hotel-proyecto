using Hotel.Dominio.InterfazLN;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReportesController : ApiControllerBase
    {
        private readonly IReporteLN _ln;

        public ReportesController(IReporteLN ln)
        {
            _ln = ln;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard() =>
            ToActionResult(await _ln.ObtenerDashboardKpisAsync());

        [HttpGet("ocupacion-mensual/{anio:int}")]
        public async Task<IActionResult> OcupacionMensual(int anio) =>
            ToActionResult(await _ln.ObtenerResumenMensualAsync(anio));

        [HttpGet("ingresos")]
        public async Task<IActionResult> Ingresos([FromQuery] DateOnly fechaInicio, [FromQuery] DateOnly fechaFin) =>
            ToActionResult(await _ln.ObtenerReporteIngresosAsync(fechaInicio, fechaFin));

        [HttpGet("platillos-top")]
        public async Task<IActionResult> PlatillosTop([FromQuery] int top = 10) =>
            ToActionResult(await _ln.ObtenerPlatillosMasSolicitadosAsync(top));
    }
}
