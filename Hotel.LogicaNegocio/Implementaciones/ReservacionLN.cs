using System.Data;
using AutoMapper;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.Enums;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.Dominio.ReglasNegocio;
using Hotel.Utilitario;

namespace Hotel.LogicaNegocio.Implementaciones
{
    public class ReservacionLN : IReservacionLN
    {
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public ReservacionLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETReservacion>>> BuscarAsync(
            string? codigoODocumento = null,
            int? clienteId = null,
            int? habitacionId = null,
            string? estado = null,
            DateOnly? desde = null,
            DateOnly? hasta = null)
        {
            string term = (codigoODocumento ?? string.Empty).Trim().ToLowerInvariant();

            var res = await _uow.TReservacion.EjecutarConsultaAsync(q =>
            {
                if (!string.IsNullOrEmpty(term))
                {
                    q = q.Where(r =>
                        r.Codigo.ToLower().Contains(term) ||
                        r.Cliente.NumeroDocumento.ToLower().Contains(term) ||
                        r.Cliente.Nombres.ToLower().Contains(term) ||
                        r.Cliente.Apellidos.ToLower().Contains(term) ||
                        r.Habitacion.Numero.ToLower().Contains(term));
                }
                if (clienteId.HasValue) q = q.Where(r => r.ClienteId == clienteId.Value);
                if (habitacionId.HasValue) q = q.Where(r => r.HabitacionId == habitacionId.Value);
                if (!string.IsNullOrWhiteSpace(estado)) q = q.Where(r => r.Estado == estado);
                if (desde.HasValue) q = q.Where(r => r.FechaFin > desde.Value);
                if (hasta.HasValue) q = q.Where(r => r.FechaInicio < hasta.Value);

                return q.OrderByDescending(r => r.FechaCreacion)
                        .Select(r => new ETReservacion
                        {
                            Id = r.Id,
                            Codigo = r.Codigo,
                            ClienteId = r.ClienteId,
                            ClienteNombreCompleto = r.Cliente.Nombres + " " + r.Cliente.Apellidos,
                            ClienteDocumento = r.Cliente.TipoDocumento + ": " + r.Cliente.NumeroDocumento,
                            HabitacionId = r.HabitacionId,
                            HabitacionNumero = r.Habitacion.Numero,
                            TipoHabitacionNombre = r.Habitacion.TipoHabitacion.Nombre,
                            FechaInicio = r.FechaInicio,
                            FechaFin = r.FechaFin,
                            HoraLlegadaPactada = r.HoraLlegadaPactada,
                            Estado = r.Estado,
                            CantidadHuespedes = r.CantidadHuespedes,
                            SubtotalHospedaje = r.SubtotalHospedaje,
                            RecargoTemporada = r.RecargoTemporada,
                            RecargoPersonasExtra = r.RecargoPersonasExtra,
                            DescuentoCliente = r.DescuentoCliente,
                            Impuestos = r.Impuestos,
                            AjustesCheckOut = r.AjustesCheckOut,
                            CostoTotal = r.CostoTotal,
                            MontoAnticipoRequerido = r.MontoAnticipoRequerido,
                            TotalPagado = r.Pagos.Sum(p => (decimal?)p.Monto) ?? 0m,
                            TotalConsumosRestaurante = r.PedidosRestaurantes
                                .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                                .Sum(p => (decimal?)p.Total) ?? 0m,
                            SaldoPendiente = (r.CostoTotal + r.AjustesCheckOut +
                                (r.PedidosRestaurantes
                                    .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                                    .Sum(p => (decimal?)p.Total) ?? 0m))
                                - (r.Pagos.Sum(p => (decimal?)p.Monto) ?? 0m),
                            FechaCheckInReal = r.FechaCheckInReal,
                            FechaCheckOutReal = r.FechaCheckOutReal,
                            Acompanantes = r.Acompanantes,
                            LlavesAsignadas = r.LlavesAsignadas,
                            Observaciones = r.Observaciones,
                            FechaCreacion = r.FechaCreacion
                        });
            });

            if (!res.Success) return Result<IEnumerable<ETReservacion>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETReservacion>>.Ok(res.Data!);
        }

        public async Task<Result<ETReservacion>> ObtenerPorIdAsync(int id)
        {
            var res = await _uow.TReservacion.EjecutarPrimeroAsync(q =>
                q.Where(r => r.Id == id)
                 .Select(r => new ETReservacion
                 {
                     Id = r.Id,
                     Codigo = r.Codigo,
                     ClienteId = r.ClienteId,
                     ClienteNombreCompleto = r.Cliente.Nombres + " " + r.Cliente.Apellidos,
                     ClienteDocumento = r.Cliente.TipoDocumento + ": " + r.Cliente.NumeroDocumento,
                     HabitacionId = r.HabitacionId,
                     HabitacionNumero = r.Habitacion.Numero,
                     TipoHabitacionNombre = r.Habitacion.TipoHabitacion.Nombre,
                     FechaInicio = r.FechaInicio,
                     FechaFin = r.FechaFin,
                     HoraLlegadaPactada = r.HoraLlegadaPactada,
                     Estado = r.Estado,
                     CantidadHuespedes = r.CantidadHuespedes,
                     SubtotalHospedaje = r.SubtotalHospedaje,
                     RecargoTemporada = r.RecargoTemporada,
                     RecargoPersonasExtra = r.RecargoPersonasExtra,
                     DescuentoCliente = r.DescuentoCliente,
                     Impuestos = r.Impuestos,
                     AjustesCheckOut = r.AjustesCheckOut,
                     CostoTotal = r.CostoTotal,
                     MontoAnticipoRequerido = r.MontoAnticipoRequerido,
                     TotalPagado = r.Pagos.Sum(p => (decimal?)p.Monto) ?? 0m,
                     TotalConsumosRestaurante = r.PedidosRestaurantes
                         .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                         .Sum(p => (decimal?)p.Total) ?? 0m,
                     SaldoPendiente = (r.CostoTotal + r.AjustesCheckOut +
                         (r.PedidosRestaurantes
                             .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                             .Sum(p => (decimal?)p.Total) ?? 0m))
                         - (r.Pagos.Sum(p => (decimal?)p.Monto) ?? 0m),
                     FechaCheckInReal = r.FechaCheckInReal,
                     FechaCheckOutReal = r.FechaCheckOutReal,
                     Acompanantes = r.Acompanantes,
                     LlavesAsignadas = r.LlavesAsignadas,
                     Observaciones = r.Observaciones,
                     FechaCreacion = r.FechaCreacion
                 }));

            if (!res.Success) return Result<ETReservacion>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<ETReservacion>.Fail("Reservación no encontrada.", 404);
            return Result<ETReservacion>.Ok(res.Data);
        }

        public async Task<Result<ETReservacion>> ObtenerPorCodigoAsync(string codigo)
        {
            string cod = (codigo ?? string.Empty).Trim().ToUpperInvariant();
            var match = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Codigo.ToUpper() == cod);
            if (!match.Success) return Result<ETReservacion>.Fail(match.Error, match.StatusCode);
            if (match.Data == null) return Result<ETReservacion>.Fail($"No existe una reservación con código '{codigo}'.", 404);
            return await ObtenerPorIdAsync(match.Data.Id);
        }

        public async Task<Result<CotizacionResponseDTO>> CotizarAsync(CotizacionRequestDTO request)
        {
            try
            {
                _ = new RangoFechas(request.FechaInicio, request.FechaFin);
            }
            catch (ArgumentException ex)
            {
                return Result<CotizacionResponseDTO>.Fail(ex.Message, 400);
            }

            if (request.FechaInicio < DateOnly.FromDateTime(DateTime.Today))
                return Result<CotizacionResponseDTO>.Fail("No se permiten reservaciones con fecha de entrada en el pasado.", 400);

            if (request.CantidadHuespedes <= 0)
                return Result<CotizacionResponseDTO>.Fail("La cantidad de huéspedes debe ser mayor que cero.", 400);

            var habRes = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == request.HabitacionId, ["TipoHabitacion"]);
            if (!habRes.Success) return Result<CotizacionResponseDTO>.Fail(habRes.Error, habRes.StatusCode);
            if (habRes.Data == null) return Result<CotizacionResponseDTO>.Fail("Habitación no encontrada.", 404);

            var hab = habRes.Data;
            int capacidadTotal = hab.TipoHabitacion.CapacidadAdultos + hab.TipoHabitacion.CapacidadNinos;
            if (request.CantidadHuespedes > capacidadTotal)
                return Result<CotizacionResponseDTO>.Fail(
                    $"La habitación {hab.Numero} admite máximo {capacidadTotal} huéspedes.", 400);

            bool esClienteFrecuente = false;
            if (request.ClienteId.HasValue)
            {
                var cliRes = await _uow.TCliente.ObtenerEntidadAsync(c => c.Id == request.ClienteId.Value);
                if (cliRes.Success && cliRes.Data != null)
                    esClienteFrecuente = cliRes.Data.EsClienteFrecuente;
            }

            bool disponible = hab.Activa &&
                hab.EstadoOperativo != EstadoHabitacion.EnMantenimiento &&
                hab.EstadoOperativo != EstadoHabitacion.Bloqueada;

            string? motivo = disponible ? null : $"La habitación {hab.Numero} está en estado '{hab.EstadoOperativo}'.";

            if (disponible)
            {
                var traslapes = await _uow.TReservacion.ContarAsync(r =>
                    r.HabitacionId == hab.Id &&
                    r.Estado != EstadoReservacion.Cancelada &&
                    r.Estado != EstadoReservacion.Completada &&
                    r.FechaInicio < request.FechaFin &&
                    r.FechaFin > request.FechaInicio);

                if (traslapes.Success && (traslapes.Data ?? 0) > 0)
                {
                    disponible = false;
                    motivo = $"La habitación {hab.Numero} ya tiene una reservación que se cruza con las fechas solicitadas.";
                }
            }

            var calculo = CalculadoraTarifas.Calcular(
                request.FechaInicio,
                request.FechaFin,
                hab.TipoHabitacion.PrecioBasePorNoche,
                hab.TipoHabitacion.CapacidadAdultos,
                request.CantidadHuespedes,
                esClienteFrecuente);

            return Result<CotizacionResponseDTO>.Ok(new CotizacionResponseDTO
            {
                HabitacionId = hab.Id,
                HabitacionNumero = hab.Numero,
                TipoHabitacion = hab.TipoHabitacion.Nombre,
                Disponible = disponible,
                MensajeDisponibilidad = motivo ?? "Disponible para el período seleccionado.",
                Noches = calculo.Noches,
                TarifaBasePorNoche = calculo.TarifaBasePorNoche,
                SubtotalHospedaje = calculo.SubtotalHospedaje,
                RecargoTemporada = calculo.RecargoTemporada,
                RecargoPersonasExtra = calculo.RecargoPersonasExtra,
                DescuentoCliente = calculo.DescuentoCliente,
                Impuestos = calculo.Impuestos,
                CostoTotal = calculo.CostoTotal,
                MontoAnticipoRequerido = calculo.MontoAnticipoRequerido,
                DetalleTemporada = calculo.DetalleTemporada
            });
        }

        public async Task<Result<ETReservacion>> CrearReservacionAsync(CrearReservacionRequestDTO request)
        {
            try
            {
                _ = new RangoFechas(request.FechaInicio, request.FechaFin);
            }
            catch (ArgumentException ex)
            {
                return Result<ETReservacion>.Fail(ex.Message, 400);
            }

            if (request.FechaInicio < DateOnly.FromDateTime(DateTime.Today))
                return Result<ETReservacion>.Fail("No se permiten reservaciones con fecha de entrada anterior a hoy.", 400);

            if (request.CantidadHuespedes <= 0)
                return Result<ETReservacion>.Fail("La cantidad de huéspedes debe ser mayor que cero.", 400);

            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                var clienteRes = await _uow.TCliente.ObtenerEntidadAsync(c => c.Id == request.ClienteId);
                if (!clienteRes.Success || clienteRes.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("El cliente seleccionado no existe.", 404);
                }

                var habRes = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == request.HabitacionId, ["TipoHabitacion"]);
                if (!habRes.Success || habRes.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("La habitación seleccionada no existe.", 404);
                }

                var hab = habRes.Data;
                if (!hab.Activa || hab.EstadoOperativo is EstadoHabitacion.EnMantenimiento or EstadoHabitacion.Bloqueada)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"La habitación {hab.Numero} no está habilitada para reservas (estado: {hab.EstadoOperativo}).", 409);
                }

                int capMax = hab.TipoHabitacion.CapacidadAdultos + hab.TipoHabitacion.CapacidadNinos;
                if (request.CantidadHuespedes > capMax)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"La cantidad de huéspedes ({request.CantidadHuespedes}) supera la capacidad máxima de la habitación ({capMax}).", 400);
                }

                // Re-verificación atómica de disponibilidad en servidor dentro de transacción Serializable
                var colisiones = await _uow.TReservacion.ContarAsync(r =>
                    r.HabitacionId == hab.Id &&
                    r.Estado != EstadoReservacion.Cancelada &&
                    r.Estado != EstadoReservacion.Completada &&
                    r.FechaInicio < request.FechaFin &&
                    r.FechaFin > request.FechaInicio);

                if (!colisiones.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(colisiones.Error, colisiones.StatusCode);
                }

                if ((colisiones.Data ?? 0) > 0)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"Conflicto de disponibilidad: la habitación {hab.Numero} acaba de ser reservada para ese rango de fechas.", 409);
                }

                var calculo = CalculadoraTarifas.Calcular(
                    request.FechaInicio,
                    request.FechaFin,
                    hab.TipoHabitacion.PrecioBasePorNoche,
                    hab.TipoHabitacion.CapacidadAdultos,
                    request.CantidadHuespedes,
                    clienteRes.Data.EsClienteFrecuente);

                string estadoInicial = EstadoReservacion.PendientePago;
                if (request.ConfirmarConAnticipo)
                {
                    decimal pagado = request.MontoAnticipoPagado ?? 0m;
                    if (pagado < calculo.MontoAnticipoRequerido)
                    {
                        await _uow.RollbackAsync();
                        return Result<ETReservacion>.Fail(
                            $"Para confirmar se requiere un anticipo mínimo de {calculo.MontoAnticipoRequerido:C2}.", 400);
                    }
                    if (pagado > calculo.CostoTotal)
                    {
                        await _uow.RollbackAsync();
                        return Result<ETReservacion>.Fail("El anticipo no puede superar el costo total de la reservación.", 400);
                    }
                    if (string.IsNullOrWhiteSpace(request.MetodoPagoAnticipo) || !MetodoPagoConst.Todos.Contains(request.MetodoPagoAnticipo))
                    {
                        await _uow.RollbackAsync();
                        return Result<ETReservacion>.Fail("Método de pago inválido para el anticipo.", 400);
                    }
                    estadoInicial = EstadoReservacion.Confirmada;
                }

                string codigo = await GenerarCodigoUnicoAsync();

                var nuevaReserva = new Reservacione
                {
                    Codigo = codigo,
                    ClienteId = request.ClienteId,
                    HabitacionId = request.HabitacionId,
                    FechaInicio = request.FechaInicio,
                    FechaFin = request.FechaFin,
                    HoraLlegadaPactada = request.HoraLlegadaPactada,
                    Estado = estadoInicial,
                    CantidadHuespedes = request.CantidadHuespedes,
                    SubtotalHospedaje = calculo.SubtotalHospedaje,
                    RecargoTemporada = calculo.RecargoTemporada,
                    RecargoPersonasExtra = calculo.RecargoPersonasExtra,
                    DescuentoCliente = calculo.DescuentoCliente,
                    Impuestos = calculo.Impuestos,
                    AjustesCheckOut = 0m,
                    CostoTotal = calculo.CostoTotal,
                    MontoAnticipoRequerido = calculo.MontoAnticipoRequerido,
                    Acompanantes = request.Acompanantes?.Trim(),
                    Observaciones = request.Observaciones?.Trim(),
                    FechaCreacion = DateTime.UtcNow
                };

                var insRes = await _uow.TReservacion.InsertarAsync(nuevaReserva);
                if (!insRes.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(insRes.Error, insRes.StatusCode);
                }

                if (request.ConfirmarConAnticipo && request.MontoAnticipoPagado > 0)
                {
                    var pago = new Pago
                    {
                        ReservacionId = nuevaReserva.Id,
                        Monto = request.MontoAnticipoPagado.Value,
                        MetodoPago = request.MetodoPagoAnticipo!,
                        FechaPago = DateTime.UtcNow,
                        ReferenciaTransaccion = request.ReferenciaPagoAnticipo?.Trim(),
                        TipoComprobante = TipoComprobanteConst.Recibo,
                        NumeroComprobante = $"REC-{nuevaReserva.Id:D4}-1",
                        Notas = "Anticipo inicial al crear reservación"
                    };

                    var insPago = await _uow.TPago.InsertarAsync(pago);
                    if (!insPago.Success)
                    {
                        await _uow.RollbackAsync();
                        return Result<ETReservacion>.Fail(insPago.Error, insPago.StatusCode);
                    }

                    if (hab.EstadoOperativo == EstadoHabitacion.Disponible)
                    {
                        hab.EstadoOperativo = EstadoHabitacion.Reservada;
                        await _uow.THabitacion.ModificarAsync(hab);
                    }
                }

                await _uow.CompletarTranAsync();
                return await ObtenerPorIdAsync(nuevaReserva.Id);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETReservacion>.Fail($"Error al crear la reservación: {ex.Message}", 500);
            }
        }

        public async Task<Result<ETReservacion>> ConfirmarReservacionAsync(int reservacionId)
        {
            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                var res = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == reservacionId, ["Habitacion"]);
                if (!res.Success || res.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("Reservación no encontrada.", 404);
                }

                var reserva = res.Data;
                if (reserva.Estado != EstadoReservacion.PendientePago)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail($"Solo se pueden confirmar reservaciones en estado 'PendientePago'. Estado actual: {reserva.Estado}.", 400);
                }

                var colisiones = await _uow.TReservacion.ContarAsync(r =>
                    r.Id != reserva.Id &&
                    r.HabitacionId == reserva.HabitacionId &&
                    (r.Estado == EstadoReservacion.Confirmada || r.Estado == EstadoReservacion.EnCurso) &&
                    r.FechaInicio < reserva.FechaFin &&
                    r.FechaFin > reserva.FechaInicio);

                if (colisiones.Success && (colisiones.Data ?? 0) > 0)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("Existe otra reservación confirmada o en curso que se traslapa con estas fechas.", 409);
                }

                var totalPagadoList = await _uow.TPago.EjecutarConsultaAsync(q =>
                    q.Where(p => p.ReservacionId == reserva.Id).Select(p => p.Monto));
                decimal pagado = totalPagadoList.Data?.Sum() ?? 0m;

                if (pagado < reserva.MontoAnticipoRequerido)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"No cumple con la seña mínima requerida ({reserva.MontoAnticipoRequerido:C2}). Pagado actual: {pagado:C2}.", 400);
                }

                reserva.Estado = EstadoReservacion.Confirmada;
                await _uow.TReservacion.ModificarAsync(reserva);

                if (reserva.Habitacion.EstadoOperativo == EstadoHabitacion.Disponible)
                {
                    reserva.Habitacion.EstadoOperativo = EstadoHabitacion.Reservada;
                    await _uow.THabitacion.ModificarAsync(reserva.Habitacion);
                }

                await _uow.CompletarTranAsync();
                return await ObtenerPorIdAsync(reserva.Id);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETReservacion>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<ETReservacion>> CancelarReservacionAsync(int reservacionId, string? motivo = null)
        {
            await _uow.EmpezarTransaccionAsync(IsolationLevel.ReadCommitted);
            try
            {
                var res = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == reservacionId, ["Habitacion"]);
                if (!res.Success || res.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("Reservación no encontrada.", 404);
                }

                var reserva = res.Data;
                if (reserva.Estado is EstadoReservacion.Completada or EstadoReservacion.Cancelada)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail($"No es posible cancelar una reservación en estado '{reserva.Estado}'.", 400);
                }
                if (reserva.Estado == EstadoReservacion.EnCurso)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("No se puede cancelar una estadía en curso; debe realizar el Check-out.", 400);
                }

                reserva.Estado = EstadoReservacion.Cancelada;
                if (!string.IsNullOrWhiteSpace(motivo))
                    reserva.Observaciones = string.IsNullOrWhiteSpace(reserva.Observaciones)
                        ? $"Cancelación: {motivo.Trim()}"
                        : $"{reserva.Observaciones} | Cancelación: {motivo.Trim()}";

                await _uow.TReservacion.ModificarAsync(reserva);

                if (reserva.Habitacion.EstadoOperativo == EstadoHabitacion.Reservada)
                {
                    var otrasConfirmadas = await _uow.TReservacion.ContarAsync(r =>
                        r.Id != reserva.Id &&
                        r.HabitacionId == reserva.HabitacionId &&
                        r.Estado == EstadoReservacion.Confirmada);
                    if ((otrasConfirmadas.Data ?? 0) == 0)
                    {
                        reserva.Habitacion.EstadoOperativo = EstadoHabitacion.Disponible;
                        await _uow.THabitacion.ModificarAsync(reserva.Habitacion);
                    }
                }

                await _uow.CompletarTranAsync();
                return await ObtenerPorIdAsync(reserva.Id);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETReservacion>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<ETReservacion>> RegistrarCheckInAsync(CheckInRequestDTO request)
        {
            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                var res = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == request.ReservacionId, ["Habitacion"]);
                if (!res.Success || res.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail("Reservación no encontrada.", 404);
                }

                var reserva = res.Data;
                if (reserva.Estado != EstadoReservacion.Confirmada)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"Solo se permite Check-in para reservaciones 'Confirmada'. Estado actual: '{reserva.Estado}'.", 400);
                }

                DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
                if (hoy < reserva.FechaInicio.AddDays(-1) || hoy > reserva.FechaFin)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"Check-in fuera de la política de llegada ({reserva.FechaInicio:yyyy-MM-dd} al {reserva.FechaFin:yyyy-MM-dd}).", 400);
                }

                if (reserva.Habitacion.EstadoOperativo is EstadoHabitacion.Ocupada or EstadoHabitacion.EnMantenimiento or EstadoHabitacion.Bloqueada)
                {
                    await _uow.RollbackAsync();
                    return Result<ETReservacion>.Fail(
                        $"La habitación {reserva.Habitacion.Numero} se encuentra '{reserva.Habitacion.EstadoOperativo}' y no puede recibir huéspedes.", 409);
                }

                reserva.Estado = EstadoReservacion.EnCurso;
                reserva.FechaCheckInReal = DateTime.UtcNow;
                reserva.LlavesAsignadas = string.IsNullOrWhiteSpace(request.LlavesAsignadas)
                    ? $"LLAVE-{reserva.Habitacion.Numero}"
                    : request.LlavesAsignadas.Trim();

                if (!string.IsNullOrWhiteSpace(request.Acompanantes))
                    reserva.Acompanantes = request.Acompanantes.Trim();
                if (!string.IsNullOrWhiteSpace(request.Observaciones))
                    reserva.Observaciones = request.Observaciones.Trim();

                reserva.Habitacion.EstadoOperativo = EstadoHabitacion.Ocupada;

                await _uow.TReservacion.ModificarAsync(reserva);
                await _uow.THabitacion.ModificarAsync(reserva.Habitacion);
                await _uow.CompletarTranAsync();

                return await ObtenerPorIdAsync(reserva.Id);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETReservacion>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<EstadoCuentaReservacionDTO>> RegistrarCheckOutAsync(CheckOutRequestDTO request)
        {
            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                var res = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == request.ReservacionId, ["Habitacion", "Cliente"]);
                if (!res.Success || res.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<EstadoCuentaReservacionDTO>.Fail("Reservación no encontrada.", 404);
                }

                var reserva = res.Data;
                if (reserva.Estado != EstadoReservacion.EnCurso)
                {
                    await _uow.RollbackAsync();
                    return Result<EstadoCuentaReservacionDTO>.Fail(
                        "No se puede realizar Check-out sin un Check-in previo en estado 'EnCurso'.", 400);
                }

                var pedidosRes = await _uow.TPedidoRestaurante.EjecutarConsultaAsync(q =>
                    q.Where(p => p.ReservacionId == reserva.Id && p.EstadoPedido != EstadoPedidoConst.Cancelado)
                     .Select(p => p.Total));
                decimal totalRestaurante = pedidosRes.Data?.Sum() ?? 0m;

                var pagosRes = await _uow.TPago.EjecutarConsultaAsync(q =>
                    q.Where(p => p.ReservacionId == reserva.Id)
                     .Select(p => p.Monto));
                decimal pagadoActual = pagosRes.Data?.Sum() ?? 0m;

                decimal totalGeneral = reserva.CostoTotal + totalRestaurante + request.AjustesCheckOut;
                decimal saldoPendiente = Math.Round(totalGeneral - pagadoActual, 2);

                if (request.MontoPagoFinal.HasValue && request.MontoPagoFinal.Value > 0)
                {
                    if (request.MontoPagoFinal.Value > saldoPendiente)
                    {
                        await _uow.RollbackAsync();
                        return Result<EstadoCuentaReservacionDTO>.Fail(
                            $"El pago final ({request.MontoPagoFinal.Value:C2}) excede el saldo pendiente ({saldoPendiente:C2}).", 400);
                    }
                    if (string.IsNullOrWhiteSpace(request.MetodoPagoFinal) || !MetodoPagoConst.Todos.Contains(request.MetodoPagoFinal))
                    {
                        await _uow.RollbackAsync();
                        return Result<EstadoCuentaReservacionDTO>.Fail("Método de pago inválido para el cobro de Check-out.", 400);
                    }

                    string tipoComp = TipoComprobanteConst.Todos.Contains(request.TipoComprobante)
                        ? request.TipoComprobante
                        : TipoComprobanteConst.Factura;

                    var pagoFinal = new Pago
                    {
                        ReservacionId = reserva.Id,
                        Monto = request.MontoPagoFinal.Value,
                        MetodoPago = request.MetodoPagoFinal,
                        FechaPago = DateTime.UtcNow,
                        ReferenciaTransaccion = request.ReferenciaPagoFinal?.Trim(),
                        TipoComprobante = tipoComp,
                        NumeroComprobante = $"{(tipoComp == TipoComprobanteConst.Factura ? "FAC" : "REC")}-{reserva.Id:D4}-FIN",
                        Notas = "Liquidación final Check-out"
                    };

                    var insPago = await _uow.TPago.InsertarAsync(pagoFinal);
                    if (!insPago.Success)
                    {
                        await _uow.RollbackAsync();
                        return Result<EstadoCuentaReservacionDTO>.Fail(insPago.Error, insPago.StatusCode);
                    }

                    saldoPendiente = Math.Round(saldoPendiente - request.MontoPagoFinal.Value, 2);
                }

                if (saldoPendiente > 0.01m)
                {
                    await _uow.RollbackAsync();
                    return Result<EstadoCuentaReservacionDTO>.Fail(
                        $"Saldo pendiente sin liquidar: {saldoPendiente:C2}. Registre el pago restante para completar el Check-out.", 400);
                }

                reserva.AjustesCheckOut = request.AjustesCheckOut;
                reserva.FechaCheckOutReal = DateTime.UtcNow;
                reserva.Estado = EstadoReservacion.Completada;
                if (!string.IsNullOrWhiteSpace(request.Observaciones))
                    reserva.Observaciones = string.IsNullOrWhiteSpace(reserva.Observaciones)
                        ? request.Observaciones.Trim()
                        : $"{reserva.Observaciones} | Check-out: {request.Observaciones.Trim()}";

                reserva.Habitacion.EstadoOperativo = EstadoHabitacion.EnLimpieza;

                await _uow.TReservacion.ModificarAsync(reserva);
                await _uow.THabitacion.ModificarAsync(reserva.Habitacion);

                // Promover a cliente frecuente si completa 3 o más estadías
                var estadiasCompletadas = await _uow.TReservacion.ContarAsync(r =>
                    r.ClienteId == reserva.ClienteId && r.Estado == EstadoReservacion.Completada);
                if (estadiasCompletadas.Success && (estadiasCompletadas.Data ?? 0) >= 3 && !reserva.Cliente.EsClienteFrecuente)
                {
                    reserva.Cliente.EsClienteFrecuente = true;
                    await _uow.TCliente.ModificarAsync(reserva.Cliente);
                }

                await _uow.CompletarTranAsync();
                return await ObtenerEstadoCuentaAsync(reserva.Id);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<EstadoCuentaReservacionDTO>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<EstadoCuentaReservacionDTO>> ObtenerEstadoCuentaAsync(int reservacionId)
        {
            var res = await ObtenerPorIdAsync(reservacionId);
            if (!res.Success || res.Data == null)
                return Result<EstadoCuentaReservacionDTO>.Fail(res.Error, res.StatusCode);

            var r = res.Data;

            var pagosRes = await _uow.TPago.EjecutarConsultaAsync(q =>
                q.Where(p => p.ReservacionId == reservacionId)
                 .OrderBy(p => p.FechaPago));

            var pedidosRes = await _uow.TPedidoRestaurante.EjecutarConsultaAsync(q =>
                q.Where(p => p.ReservacionId == reservacionId)
                 .OrderByDescending(p => p.FechaPedido)
                 .Select(p => new ETPedidoRestaurante
                 {
                     Id = p.Id,
                     ReservacionId = p.ReservacionId,
                     CodigoReservacion = r.Codigo,
                     HabitacionNumero = r.HabitacionNumero,
                     ClienteNombre = r.ClienteNombreCompleto,
                     FechaPedido = p.FechaPedido,
                     FechaHoraDeseada = p.FechaHoraDeseada,
                     EstadoPedido = p.EstadoPedido,
                     Subtotal = p.Subtotal,
                     RecargoServicio = p.RecargoServicio,
                     Total = p.Total,
                     EsRoomService = p.EsRoomService,
                     NumeroMesa = p.NumeroMesa,
                     InstruccionesEspeciales = p.InstruccionesEspeciales,
                     Detalles = p.DetallePedidos.Select(d => new ETDetallePedido
                     {
                         Id = d.Id,
                         PedidoId = d.PedidoId,
                         PlatilloId = d.PlatilloId,
                         PlatilloNombre = d.Platillo.Nombre,
                         Cantidad = d.Cantidad,
                         PrecioUnitario = d.PrecioUnitario,
                         Subtotal = d.Subtotal
                     }).ToList()
                 }));

            decimal totalRest = (pedidosRes.Data ?? [])
                .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                .Sum(p => p.Total);
            decimal totalPagado = (pagosRes.Data ?? []).Sum(p => p.Monto);
            decimal totalGeneral = r.CostoTotal + totalRest + r.AjustesCheckOut;

            return Result<EstadoCuentaReservacionDTO>.Ok(new EstadoCuentaReservacionDTO
            {
                ReservacionId = r.Id,
                Codigo = r.Codigo,
                ClienteNombre = r.ClienteNombreCompleto ?? string.Empty,
                HabitacionNumero = r.HabitacionNumero ?? string.Empty,
                Estado = r.Estado,
                CostoHospedaje = r.CostoTotal,
                TotalRestaurante = totalRest,
                AjustesCheckOut = r.AjustesCheckOut,
                TotalGeneral = totalGeneral,
                TotalPagado = totalPagado,
                SaldoPendiente = Math.Round(totalGeneral - totalPagado, 2),
                Pagos = _mapper.Map<List<ETPago>>(pagosRes.Data ?? []),
                Pedidos = pedidosRes.Data ?? []
            });
        }

        public async Task<Result<IEnumerable<MatrizOcupacionHabitacionDTO>>> ObtenerMatrizOcupacionAsync(
            DateOnly fechaInicio, DateOnly fechaFin)
        {
            if (fechaInicio > fechaFin)
                return Result<IEnumerable<MatrizOcupacionHabitacionDTO>>.Fail("La fecha de inicio debe ser menor o igual a la fecha fin.", 400);

            if (fechaFin.DayNumber - fechaInicio.DayNumber > 31)
                return Result<IEnumerable<MatrizOcupacionHabitacionDTO>>.Fail("El rango de la matriz no debe superar los 31 días.", 400);

            var habsRes = await _uow.THabitacion.EjecutarConsultaAsync(q =>
                q.Where(h => h.Activa)
                 .OrderBy(h => h.Piso).ThenBy(h => h.Numero)
                 .Select(h => new
                 {
                     h.Id,
                     h.Numero,
                     h.Piso,
                     Tipo = h.TipoHabitacion.Nombre,
                     h.EstadoOperativo
                 }));

            if (!habsRes.Success)
                return Result<IEnumerable<MatrizOcupacionHabitacionDTO>>.Fail(habsRes.Error, habsRes.StatusCode);

            DateOnly finExclusivo = fechaFin.AddDays(1);
            var reservasRes = await _uow.TReservacion.EjecutarConsultaAsync(q =>
                q.Where(r =>
                    r.Estado != EstadoReservacion.Cancelada &&
                    r.FechaInicio < finExclusivo &&
                    r.FechaFin > fechaInicio)
                 .Select(r => new
                 {
                     r.HabitacionId,
                     r.FechaInicio,
                     r.FechaFin,
                     r.Estado,
                     r.Codigo,
                     Cliente = r.Cliente.Nombres + " " + r.Cliente.Apellidos
                 }));

            if (!reservasRes.Success)
                return Result<IEnumerable<MatrizOcupacionHabitacionDTO>>.Fail(reservasRes.Error, reservasRes.StatusCode);

            var reservas = reservasRes.Data!;
            var matriz = new List<MatrizOcupacionHabitacionDTO>();

            foreach (var h in habsRes.Data!)
            {
                var fila = new MatrizOcupacionHabitacionDTO
                {
                    HabitacionId = h.Id,
                    Numero = h.Numero,
                    Piso = h.Piso,
                    TipoHabitacion = h.Tipo,
                    EstadoOperativoActual = h.EstadoOperativo
                };

                for (var d = fechaInicio; d <= fechaFin; d = d.AddDays(1))
                {
                    var match = reservas.FirstOrDefault(r =>
                        r.HabitacionId == h.Id &&
                        r.FechaInicio <= d &&
                        r.FechaFin > d);

                    string estadoDia;
                    if (h.EstadoOperativo is EstadoHabitacion.EnMantenimiento or EstadoHabitacion.Bloqueada)
                        estadoDia = h.EstadoOperativo;
                    else if (match != null)
                        estadoDia = match.Estado == EstadoReservacion.EnCurso ? EstadoHabitacion.Ocupada : EstadoHabitacion.Reservada;
                    else if (d == DateOnly.FromDateTime(DateTime.Today) && h.EstadoOperativo == EstadoHabitacion.EnLimpieza)
                        estadoDia = EstadoHabitacion.EnLimpieza;
                    else
                        estadoDia = EstadoHabitacion.Disponible;

                    fila.Dias.Add(new MatrizOcupacionDiaDTO
                    {
                        Fecha = d,
                        Estado = estadoDia,
                        CodigoReservacion = match?.Codigo,
                        HuespedNombre = match?.Cliente
                    });
                }

                matriz.Add(fila);
            }

            return Result<IEnumerable<MatrizOcupacionHabitacionDTO>>.Ok(matriz);
        }

        private async Task<string> GenerarCodigoUnicoAsync()
        {
            int anio = DateTime.UtcNow.Year;
            var totalRes = await _uow.TReservacion.ContarAsync(_ => true);
            int seq = (totalRes.Data ?? 0) + 1;

            for (int intento = 0; intento < 25; intento++)
            {
                string candidato = $"RES-{anio}-{(seq + intento):D4}";
                var existe = await _uow.TReservacion.ContarAsync(r => r.Codigo == candidato);
                if (existe.Success && (existe.Data ?? 0) == 0)
                    return candidato;
            }

            return $"RES-{anio}-{Guid.NewGuid().ToString("N")[..6].ToUpperInvariant()}";
        }
    }
}
