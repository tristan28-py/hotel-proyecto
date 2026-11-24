using System.Globalization;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.Enums;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.Utilitario;

namespace Hotel.LogicaNegocio.Implementaciones
{
    public class ReporteLN : IReporteLN
    {
        private readonly IUnidadTrabajoEF _uow;

        public ReporteLN(IUnidadTrabajoEF uow)
        {
            _uow = uow;
        }

        public async Task<Result<DashboardKpiDTO>> ObtenerDashboardKpisAsync()
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            DateTime inicioMes = new(hoy.Year, hoy.Month, 1);
            DateTime finMes = inicioMes.AddMonths(1);

            var habsRes = await _uow.THabitacion.EjecutarConsultaAsync(q =>
                q.Where(h => h.Activa)
                 .GroupBy(h => h.EstadoOperativo)
                 .Select(g => new { Estado = g.Key, Cantidad = g.Count() }));

            if (!habsRes.Success) return Result<DashboardKpiDTO>.Fail(habsRes.Error, habsRes.StatusCode);

            var conteos = habsRes.Data!.ToDictionary(x => x.Estado, x => x.Cantidad);
            int totalActivas = conteos.Values.Sum();
            int disponibles = conteos.GetValueOrDefault(EstadoHabitacion.Disponible);
            int ocupadas = conteos.GetValueOrDefault(EstadoHabitacion.Ocupada);
            int reservadas = conteos.GetValueOrDefault(EstadoHabitacion.Reservada);
            int enLimpieza = conteos.GetValueOrDefault(EstadoHabitacion.EnLimpieza);
            int enMantenimiento = conteos.GetValueOrDefault(EstadoHabitacion.EnMantenimiento);

            var llegadasRes = await _uow.TReservacion.ContarAsync(r =>
                r.Estado == EstadoReservacion.Confirmada && r.FechaInicio == hoy);
            var salidasRes = await _uow.TReservacion.ContarAsync(r =>
                r.Estado == EstadoReservacion.EnCurso && r.FechaFin == hoy);

            var ingresosMesRes = await _uow.TPago.EjecutarConsultaAsync(q =>
                q.Where(p => p.FechaPago >= inicioMes && p.FechaPago < finMes)
                 .Select(p => p.Monto));

            var cocinaRes = await _uow.TPedidoRestaurante.ContarAsync(p =>
                p.EstadoPedido == EstadoPedidoConst.Recibido ||
                p.EstadoPedido == EstadoPedidoConst.EnCocina ||
                p.EstadoPedido == EstadoPedidoConst.EnCamino);

            decimal pctOcupacion = totalActivas > 0
                ? Math.Round((decimal)ocupadas / totalActivas * 100m, 1)
                : 0m;

            return Result<DashboardKpiDTO>.Ok(new DashboardKpiDTO
            {
                TotalHabitacionesActivas = totalActivas,
                HabitacionesDisponibles = disponibles,
                HabitacionesOcupadas = ocupadas,
                HabitacionesReservadas = reservadas,
                HabitacionesEnLimpieza = enLimpieza,
                HabitacionesEnMantenimiento = enMantenimiento,
                PorcentajeOcupacion = pctOcupacion,
                LlegadasPendientesHoy = llegadasRes.Data ?? 0,
                SalidasProgramadasHoy = salidasRes.Data ?? 0,
                IngresosDelMes = ingresosMesRes.Data?.Sum() ?? 0m,
                PedidosActivosCocina = cocinaRes.Data ?? 0
            });
        }

        public async Task<Result<IEnumerable<ResumenMensualOcupacionDTO>>> ObtenerResumenMensualAsync(int anio)
        {
            var res = await _uow.TReservacion.EjecutarConsultaAsync(q =>
                q.Where(r => r.FechaInicio.Year == anio && r.Estado != EstadoReservacion.Cancelada)
                 .GroupBy(r => new { r.FechaInicio.Year, r.FechaInicio.Month })
                 .Select(g => new ResumenMensualOcupacionDTO
                 {
                     Anio = g.Key.Year,
                     Mes = g.Key.Month,
                     CantidadReservaciones = g.Count(),
                     TotalFacturado = g.Sum(r => r.CostoTotal + r.AjustesCheckOut)
                 })
                 .OrderBy(x => x.Mes));

            if (!res.Success) return Result<IEnumerable<ResumenMensualOcupacionDTO>>.Fail(res.Error, res.StatusCode);

            var cultura = new CultureInfo("es-ES");
            foreach (var item in res.Data!)
                item.MesNombre = cultura.DateTimeFormat.GetMonthName(item.Mes);

            return Result<IEnumerable<ResumenMensualOcupacionDTO>>.Ok(res.Data!);
        }

        public async Task<Result<ReporteIngresosDTO>> ObtenerReporteIngresosAsync(DateOnly fechaInicio, DateOnly fechaFin)
        {
            if (fechaInicio > fechaFin)
                return Result<ReporteIngresosDTO>.Fail("La fecha inicio debe ser menor o igual a la fecha fin.", 400);

            DateTime dtInicio = fechaInicio.ToDateTime(TimeOnly.MinValue);
            DateTime dtFinExclusivo = fechaFin.AddDays(1).ToDateTime(TimeOnly.MinValue);

            var pagosRes = await _uow.TPago.EjecutarConsultaAsync(q =>
                q.Where(p => p.FechaPago >= dtInicio && p.FechaPago < dtFinExclusivo)
                 .OrderByDescending(p => p.FechaPago)
                 .Select(p => new ETPago
                 {
                     Id = p.Id,
                     ReservacionId = p.ReservacionId,
                     CodigoReservacion = p.Reservacion.Codigo,
                     Monto = p.Monto,
                     MetodoPago = p.MetodoPago,
                     FechaPago = p.FechaPago,
                     ReferenciaTransaccion = p.ReferenciaTransaccion,
                     TipoComprobante = p.TipoComprobante,
                     NumeroComprobante = p.NumeroComprobante,
                     Notas = p.Notas
                 }));

            if (!pagosRes.Success) return Result<ReporteIngresosDTO>.Fail(pagosRes.Error, pagosRes.StatusCode);

            var hospRes = await _uow.TReservacion.EjecutarConsultaAsync(q =>
                q.Where(r => r.Estado != EstadoReservacion.Cancelada && r.FechaInicio >= fechaInicio && r.FechaInicio <= fechaFin)
                 .GroupBy(_ => 1)
                 .Select(g => g.Sum(r => r.CostoTotal + r.AjustesCheckOut)));

            var restRes = await _uow.TPedidoRestaurante.EjecutarConsultaAsync(q =>
                q.Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado && p.FechaPedido >= dtInicio && p.FechaPedido < dtFinExclusivo)
                 .GroupBy(_ => 1)
                 .Select(g => g.Sum(p => p.Total)));

            var detalle = pagosRes.Data!;
            return Result<ReporteIngresosDTO>.Ok(new ReporteIngresosDTO
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                TotalPagosRecibidos = detalle.Sum(p => p.Monto),
                TotalHospedajeProyectado = hospRes.Data?.FirstOrDefault() ?? 0m,
                TotalConsumosRestaurante = restRes.Data?.FirstOrDefault() ?? 0m,
                CantidadTransacciones = detalle.Count,
                DetallePagos = detalle
            });
        }

        public async Task<Result<IEnumerable<PlatilloMasSolicitadoDTO>>> ObtenerPlatillosMasSolicitadosAsync(int top = 10)
        {
            if (top <= 0) top = 10;

            var res = await _uow.TDetallePedido.EjecutarConsultaAsync(q =>
                q.Where(d => d.Pedido.EstadoPedido != EstadoPedidoConst.Cancelado)
                 .GroupBy(d => new { d.PlatilloId, d.Platillo.Nombre, Categoria = d.Platillo.Categoria.Nombre })
                 .Select(g => new PlatilloMasSolicitadoDTO
                 {
                     PlatilloId = g.Key.PlatilloId,
                     Nombre = g.Key.Nombre,
                     Categoria = g.Key.Categoria,
                     CantidadTotalSolicitada = g.Sum(x => x.Cantidad),
                     MontoTotalGenerado = g.Sum(x => x.Subtotal)
                 })
                 .OrderByDescending(x => x.CantidadTotalSolicitada)
                 .Take(top));

            if (!res.Success) return Result<IEnumerable<PlatilloMasSolicitadoDTO>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<PlatilloMasSolicitadoDTO>>.Ok(res.Data!);
        }
    }
}
