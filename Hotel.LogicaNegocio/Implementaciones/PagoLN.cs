using System.Data;
using AutoMapper;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.Enums;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.Utilitario;

namespace Hotel.LogicaNegocio.Implementaciones
{
    public class PagoLN : IPagoLN
    {
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public PagoLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETPago>>> ListarPorReservacionAsync(int reservacionId)
        {
            var res = await _uow.TPago.EjecutarConsultaAsync(q =>
                q.Where(p => p.ReservacionId == reservacionId)
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

            if (!res.Success) return Result<IEnumerable<ETPago>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETPago>>.Ok(res.Data!);
        }

        public async Task<Result<ETPago>> RegistrarPagoAsync(ETPago dto)
        {
            if (dto.Monto <= 0)
                return Result<ETPago>.Fail("El monto del pago debe ser mayor que cero.", 400);

            if (!MetodoPagoConst.Todos.Contains(dto.MetodoPago))
                return Result<ETPago>.Fail($"Método de pago inválido: '{dto.MetodoPago}'.", 400);

            string tipoComp = string.IsNullOrWhiteSpace(dto.TipoComprobante)
                ? TipoComprobanteConst.Recibo
                : dto.TipoComprobante;
            if (!TipoComprobanteConst.Todos.Contains(tipoComp))
                return Result<ETPago>.Fail("Tipo de comprobante inválido (Recibo o Factura).", 400);

            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                var resReserva = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == dto.ReservacionId, ["Habitacion"]);
                if (!resReserva.Success || resReserva.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPago>.Fail("Reservación no encontrada.", 404);
                }

                var reserva = resReserva.Data;
                if (reserva.Estado == EstadoReservacion.Cancelada)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPago>.Fail("No se pueden registrar pagos sobre una reservación cancelada.", 400);
                }

                var pedidosRes = await _uow.TPedidoRestaurante.EjecutarConsultaAsync(q =>
                    q.Where(p => p.ReservacionId == reserva.Id && p.EstadoPedido != EstadoPedidoConst.Cancelado)
                     .Select(p => p.Total));
                decimal totalRestaurante = pedidosRes.Data?.Sum() ?? 0m;

                var pagosRes = await _uow.TPago.EjecutarConsultaAsync(q =>
                    q.Where(p => p.ReservacionId == reserva.Id).Select(p => p.Monto));
                decimal pagadoPrevio = pagosRes.Data?.Sum() ?? 0m;
                int numPagos = pagosRes.Data?.Count ?? 0;

                decimal totalGeneral = reserva.CostoTotal + totalRestaurante + reserva.AjustesCheckOut;
                decimal saldoPendiente = Math.Round(totalGeneral - pagadoPrevio, 2);

                if (dto.Monto > saldoPendiente)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPago>.Fail(
                        $"El monto ({dto.Monto:C2}) excede el saldo pendiente de la reservación ({saldoPendiente:C2}).", 400);
                }

                var pago = new Pago
                {
                    ReservacionId = reserva.Id,
                    Monto = Math.Round(dto.Monto, 2),
                    MetodoPago = dto.MetodoPago,
                    FechaPago = DateTime.UtcNow,
                    ReferenciaTransaccion = dto.ReferenciaTransaccion?.Trim(),
                    TipoComprobante = tipoComp,
                    NumeroComprobante = string.IsNullOrWhiteSpace(dto.NumeroComprobante)
                        ? $"{(tipoComp == TipoComprobanteConst.Factura ? "FAC" : "REC")}-{reserva.Id:D4}-{numPagos + 1}"
                        : dto.NumeroComprobante.Trim(),
                    Notas = dto.Notas?.Trim()
                };

                var insPago = await _uow.TPago.InsertarAsync(pago);
                if (!insPago.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPago>.Fail(insPago.Error, insPago.StatusCode);
                }

                decimal nuevoTotalPagado = pagadoPrevio + pago.Monto;

                // Confirmar automáticamente si estaba PendientePago y alcanzó el anticipo mínimo
                if (reserva.Estado == EstadoReservacion.PendientePago &&
                    nuevoTotalPagado >= reserva.MontoAnticipoRequerido)
                {
                    var colisiones = await _uow.TReservacion.ContarAsync(r =>
                        r.Id != reserva.Id &&
                        r.HabitacionId == reserva.HabitacionId &&
                        (r.Estado == EstadoReservacion.Confirmada || r.Estado == EstadoReservacion.EnCurso) &&
                        r.FechaInicio < reserva.FechaFin &&
                        r.FechaFin > reserva.FechaInicio);

                    if (colisiones.Success && (colisiones.Data ?? 0) > 0)
                    {
                        await _uow.RollbackAsync();
                        return Result<ETPago>.Fail("La habitación ya fue confirmada para otra reserva en las mismas fechas.", 409);
                    }

                    reserva.Estado = EstadoReservacion.Confirmada;
                    await _uow.TReservacion.ModificarAsync(reserva);

                    if (reserva.Habitacion.EstadoOperativo == EstadoHabitacion.Disponible)
                    {
                        reserva.Habitacion.EstadoOperativo = EstadoHabitacion.Reservada;
                        await _uow.THabitacion.ModificarAsync(reserva.Habitacion);
                    }
                }

                await _uow.CompletarTranAsync();

                var dtoSalida = _mapper.Map<ETPago>(pago);
                dtoSalida.CodigoReservacion = reserva.Codigo;
                return Result<ETPago>.Ok(dtoSalida, 201);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETPago>.Fail(ex.Message, 500);
            }
        }
    }
}
