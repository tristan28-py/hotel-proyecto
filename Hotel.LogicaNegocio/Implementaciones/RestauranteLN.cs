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
    public class RestauranteLN : IRestauranteLN
    {
        private const decimal PorcentajeRecargoRoomService = 0.10m;
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public RestauranteLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETCategoriaPlatillo>>> ListarCategoriasAsync(bool soloActivas = false)
        {
            var res = await _uow.TCategoriaPlatillo.EjecutarConsultaAsync(q =>
            {
                if (soloActivas) q = q.Where(c => c.Activo);
                return q.OrderBy(c => c.Nombre);
            });
            if (!res.Success) return Result<IEnumerable<ETCategoriaPlatillo>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETCategoriaPlatillo>>.Ok(_mapper.Map<IEnumerable<ETCategoriaPlatillo>>(res.Data));
        }

        public async Task<Result<ETCategoriaPlatillo>> GuardarCategoriaAsync(ETCategoriaPlatillo dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return Result<ETCategoriaPlatillo>.Fail("El nombre de la categoría es obligatorio.", 400);

            if (dto.Id == 0)
            {
                var dup = await _uow.TCategoriaPlatillo.ContarAsync(c => c.Nombre.ToLower() == dto.Nombre.Trim().ToLower());
                if (dup.Success && dup.Data > 0)
                    return Result<ETCategoriaPlatillo>.Fail("Ya existe una categoría con ese nombre.", 409);

                var entidad = _mapper.Map<CategoriasPlatillo>(dto);
                entidad.Nombre = dto.Nombre.Trim();
                var ins = await _uow.TCategoriaPlatillo.InsertarAsync(entidad);
                return ins.Success
                    ? Result<ETCategoriaPlatillo>.Ok(_mapper.Map<ETCategoriaPlatillo>(ins.Data), 201)
                    : Result<ETCategoriaPlatillo>.Fail(ins.Error, ins.StatusCode);
            }
            else
            {
                var exist = await _uow.TCategoriaPlatillo.ObtenerEntidadAsync(c => c.Id == dto.Id);
                if (!exist.Success || exist.Data == null)
                    return Result<ETCategoriaPlatillo>.Fail("Categoría no encontrada.", 404);

                exist.Data.Nombre = dto.Nombre.Trim();
                exist.Data.Descripcion = dto.Descripcion?.Trim();
                exist.Data.Activo = dto.Activo;
                var upd = await _uow.TCategoriaPlatillo.ModificarAsync(exist.Data);
                return upd.Success
                    ? Result<ETCategoriaPlatillo>.Ok(_mapper.Map<ETCategoriaPlatillo>(upd.Data))
                    : Result<ETCategoriaPlatillo>.Fail(upd.Error, upd.StatusCode);
            }
        }

        public async Task<Result<IEnumerable<ETPlatillo>>> ListarPlatillosAsync(int? categoriaId = null, bool soloDisponibles = false)
        {
            var res = await _uow.TPlatillo.EjecutarConsultaAsync(q =>
            {
                q = q.Where(p => p.Activo);
                if (categoriaId.HasValue) q = q.Where(p => p.CategoriaId == categoriaId.Value);
                if (soloDisponibles) q = q.Where(p => p.Disponible && p.Categoria.Activo);

                return q.OrderBy(p => p.Categoria.Nombre)
                        .ThenBy(p => p.Nombre)
                        .Select(p => new ETPlatillo
                        {
                            Id = p.Id,
                            CategoriaId = p.CategoriaId,
                            CategoriaNombre = p.Categoria.Nombre,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Precio = p.Precio,
                            TiempoPreparacionMinutos = p.TiempoPreparacionMinutos,
                            Disponible = p.Disponible,
                            Activo = p.Activo,
                            ImagenUrl = p.ImagenUrl
                        });
            });

            if (!res.Success) return Result<IEnumerable<ETPlatillo>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETPlatillo>>.Ok(res.Data!);
        }

        public async Task<Result<ETPlatillo>> GuardarPlatilloAsync(ETPlatillo dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return Result<ETPlatillo>.Fail("El nombre del platillo es obligatorio.", 400);
            if (dto.Precio <= 0)
                return Result<ETPlatillo>.Fail("El precio del platillo debe ser mayor que cero.", 400);
            if (dto.TiempoPreparacionMinutos <= 0)
                return Result<ETPlatillo>.Fail("El tiempo de preparación debe ser mayor que cero.", 400);

            var cat = await _uow.TCategoriaPlatillo.ContarAsync(c => c.Id == dto.CategoriaId);
            if (!cat.Success || (cat.Data ?? 0) == 0)
                return Result<ETPlatillo>.Fail("La categoría seleccionada no existe.", 400);

            if (dto.Id == 0)
            {
                var entidad = _mapper.Map<Platillo>(dto);
                entidad.Nombre = dto.Nombre.Trim();
                entidad.Activo = true;
                var ins = await _uow.TPlatillo.InsertarAsync(entidad);
                if (!ins.Success) return Result<ETPlatillo>.Fail(ins.Error, ins.StatusCode);
                var cargado = await _uow.TPlatillo.ObtenerEntidadAsync(p => p.Id == ins.Data!.Id, ["Categoria"]);
                return Result<ETPlatillo>.Ok(_mapper.Map<ETPlatillo>(cargado.Data), 201);
            }
            else
            {
                var exist = await _uow.TPlatillo.ObtenerEntidadAsync(p => p.Id == dto.Id);
                if (!exist.Success || exist.Data == null)
                    return Result<ETPlatillo>.Fail("Platillo no encontrado.", 404);

                exist.Data.CategoriaId = dto.CategoriaId;
                exist.Data.Nombre = dto.Nombre.Trim();
                exist.Data.Descripcion = dto.Descripcion?.Trim();
                exist.Data.Precio = dto.Precio;
                exist.Data.TiempoPreparacionMinutos = dto.TiempoPreparacionMinutos;
                exist.Data.Disponible = dto.Disponible;
                exist.Data.Activo = dto.Activo;
                exist.Data.ImagenUrl = dto.ImagenUrl?.Trim();

                var upd = await _uow.TPlatillo.ModificarAsync(exist.Data);
                if (!upd.Success) return Result<ETPlatillo>.Fail(upd.Error, upd.StatusCode);
                var cargado = await _uow.TPlatillo.ObtenerEntidadAsync(p => p.Id == upd.Data!.Id, ["Categoria"]);
                return Result<ETPlatillo>.Ok(_mapper.Map<ETPlatillo>(cargado.Data));
            }
        }

        public async Task<Result<bool>> DesactivarPlatilloAsync(int id)
        {
            var exist = await _uow.TPlatillo.ObtenerEntidadAsync(p => p.Id == id);
            if (!exist.Success || exist.Data == null)
                return Result<bool>.Fail("Platillo no encontrado.", 404);

            exist.Data.Activo = false;
            exist.Data.Disponible = false;
            var upd = await _uow.TPlatillo.ModificarAsync(exist.Data);
            return upd.Success ? Result<bool>.Ok(true) : Result<bool>.Fail(upd.Error, upd.StatusCode);
        }

        public async Task<Result<IEnumerable<ETPedidoRestaurante>>> ListarPedidosAsync(
            int? reservacionId = null,
            string? estado = null,
            DateOnly? fecha = null)
        {
            var res = await _uow.TPedidoRestaurante.EjecutarConsultaAsync(q =>
            {
                if (reservacionId.HasValue) q = q.Where(p => p.ReservacionId == reservacionId.Value);
                if (!string.IsNullOrWhiteSpace(estado)) q = q.Where(p => p.EstadoPedido == estado);
                if (fecha.HasValue)
                {
                    DateTime inicio = fecha.Value.ToDateTime(TimeOnly.MinValue);
                    DateTime fin = inicio.AddDays(1);
                    q = q.Where(p => p.FechaPedido >= inicio && p.FechaPedido < fin);
                }

                return q.OrderByDescending(p => p.FechaPedido)
                        .Select(p => new ETPedidoRestaurante
                        {
                            Id = p.Id,
                            ReservacionId = p.ReservacionId,
                            CodigoReservacion = p.Reservacion.Codigo,
                            HabitacionNumero = p.Reservacion.Habitacion.Numero,
                            ClienteNombre = p.Reservacion.Cliente.Nombres + " " + p.Reservacion.Cliente.Apellidos,
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
                        });
            });

            if (!res.Success) return Result<IEnumerable<ETPedidoRestaurante>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETPedidoRestaurante>>.Ok(res.Data!);
        }

        public async Task<Result<ETPedidoRestaurante>> CrearPedidoAsync(CrearPedidoRestauranteRequestDTO request)
        {
            if (request.Items == null || request.Items.Count == 0)
                return Result<ETPedidoRestaurante>.Fail("Debe seleccionar al menos un platillo para realizar el pedido.", 400);

            if (request.Items.Any(i => i.Cantidad <= 0))
                return Result<ETPedidoRestaurante>.Fail("Las cantidades de los platillos deben ser mayores que cero.", 400);

            if (!request.EsRoomService && string.IsNullOrWhiteSpace(request.NumeroMesa))
                return Result<ETPedidoRestaurante>.Fail("Debe indicar el número de mesa para pedidos en salón.", 400);

            await _uow.EmpezarTransaccionAsync(IsolationLevel.ReadCommitted);
            try
            {
                // Regla del folio: validar que la reservación esté activa en estado 'EnCurso'
                var resReserva = await _uow.TReservacion.ObtenerEntidadAsync(r => r.Id == request.ReservacionId);
                if (!resReserva.Success || resReserva.Data == null)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPedidoRestaurante>.Fail("La reservación indicada no existe.", 404);
                }

                if (resReserva.Data.Estado != EstadoReservacion.EnCurso)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPedidoRestaurante>.Fail(
                        $"Solo huéspedes con estadía activa ('EnCurso') pueden cargar pedidos a la habitación. Estado actual: {resReserva.Data.Estado}.", 400);
                }

                var idsPlatillos = request.Items.Select(i => i.PlatilloId).Distinct().ToList();
                var platillosRes = await _uow.TPlatillo.BuscarAsync(p => idsPlatillos.Contains(p.Id));
                if (!platillosRes.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPedidoRestaurante>.Fail(platillosRes.Error, platillosRes.StatusCode);
                }

                var mapaPlatillos = platillosRes.Data!.ToDictionary(p => p.Id);
                var detalles = new List<DetallePedido>();
                decimal subtotal = 0m;

                foreach (var item in request.Items)
                {
                    if (!mapaPlatillos.TryGetValue(item.PlatilloId, out var platillo))
                    {
                        await _uow.RollbackAsync();
                        return Result<ETPedidoRestaurante>.Fail($"El platillo ID {item.PlatilloId} no existe.", 404);
                    }
                    if (!platillo.Activo || !platillo.Disponible)
                    {
                        await _uow.RollbackAsync();
                        return Result<ETPedidoRestaurante>.Fail($"El platillo '{platillo.Nombre}' no está disponible en este momento.", 400);
                    }

                    decimal subItem = Math.Round(platillo.Precio * item.Cantidad, 2);
                    subtotal += subItem;
                    detalles.Add(new DetallePedido
                    {
                        PlatilloId = platillo.Id,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = platillo.Precio,
                        Subtotal = subItem
                    });
                }

                decimal recargo = request.EsRoomService ? Math.Round(subtotal * PorcentajeRecargoRoomService, 2) : 0m;
                decimal total = Math.Round(subtotal + recargo, 2);

                var pedido = new PedidosRestaurante
                {
                    ReservacionId = request.ReservacionId,
                    FechaPedido = DateTime.UtcNow,
                    FechaHoraDeseada = request.FechaHoraDeseada == default ? DateTime.UtcNow : request.FechaHoraDeseada,
                    EstadoPedido = EstadoPedidoConst.Recibido,
                    Subtotal = subtotal,
                    RecargoServicio = recargo,
                    Total = total,
                    EsRoomService = request.EsRoomService,
                    NumeroMesa = request.EsRoomService ? null : request.NumeroMesa?.Trim(),
                    InstruccionesEspeciales = request.InstruccionesEspeciales?.Trim(),
                    DetallePedidos = detalles
                };

                var ins = await _uow.TPedidoRestaurante.InsertarAsync(pedido);
                if (!ins.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<ETPedidoRestaurante>.Fail(ins.Error, ins.StatusCode);
                }

                await _uow.CompletarTranAsync();

                var lista = await ListarPedidosAsync(reservacionId: pedido.ReservacionId);
                var creado = lista.Data?.FirstOrDefault(p => p.Id == pedido.Id);
                return Result<ETPedidoRestaurante>.Ok(creado!, 201);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<ETPedidoRestaurante>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<ETPedidoRestaurante>> CambiarEstadoPedidoAsync(int pedidoId, string nuevoEstado)
        {
            if (!EstadoPedidoConst.Todos.Contains(nuevoEstado))
                return Result<ETPedidoRestaurante>.Fail($"Estado de pedido inválido: '{nuevoEstado}'.", 400);

            var res = await _uow.TPedidoRestaurante.ObtenerEntidadAsync(p => p.Id == pedidoId);
            if (!res.Success || res.Data == null)
                return Result<ETPedidoRestaurante>.Fail("Pedido no encontrado.", 404);

            var pedido = res.Data;
            if (pedido.EstadoPedido is EstadoPedidoConst.Entregado or EstadoPedidoConst.Cancelado)
                return Result<ETPedidoRestaurante>.Fail($"El pedido ya está '{pedido.EstadoPedido}' y no admite más cambios.", 400);

            if (nuevoEstado == EstadoPedidoConst.Cancelado)
                return await CancelarPedidoAsync(pedidoId);

            bool transicionValida = (pedido.EstadoPedido, nuevoEstado) switch
            {
                (EstadoPedidoConst.Recibido, EstadoPedidoConst.EnCocina) => true,
                (EstadoPedidoConst.EnCocina, EstadoPedidoConst.EnCamino) => true,
                (EstadoPedidoConst.EnCocina, EstadoPedidoConst.Entregado) => true,
                (EstadoPedidoConst.EnCamino, EstadoPedidoConst.Entregado) => true,
                _ => false
            };

            if (!transicionValida)
                return Result<ETPedidoRestaurante>.Fail(
                    $"Transición incompatible de '{pedido.EstadoPedido}' a '{nuevoEstado}'. Flujo: Recibido -> EnCocina -> EnCamino -> Entregado.", 400);

            pedido.EstadoPedido = nuevoEstado;
            var upd = await _uow.TPedidoRestaurante.ModificarAsync(pedido);
            if (!upd.Success) return Result<ETPedidoRestaurante>.Fail(upd.Error, upd.StatusCode);

            var lista = await ListarPedidosAsync(reservacionId: pedido.ReservacionId);
            return Result<ETPedidoRestaurante>.Ok(lista.Data!.First(p => p.Id == pedido.Id));
        }

        public async Task<Result<ETPedidoRestaurante>> CancelarPedidoAsync(int pedidoId)
        {
            var res = await _uow.TPedidoRestaurante.ObtenerEntidadAsync(p => p.Id == pedidoId);
            if (!res.Success || res.Data == null)
                return Result<ETPedidoRestaurante>.Fail("Pedido no encontrado.", 404);

            var pedido = res.Data;
            if (pedido.EstadoPedido != EstadoPedidoConst.Recibido)
                return Result<ETPedidoRestaurante>.Fail(
                    $"Solo se puede cancelar un pedido en estado 'Recibido'. Estado actual: '{pedido.EstadoPedido}'.", 400);

            pedido.EstadoPedido = EstadoPedidoConst.Cancelado;
            var upd = await _uow.TPedidoRestaurante.ModificarAsync(pedido);
            if (!upd.Success) return Result<ETPedidoRestaurante>.Fail(upd.Error, upd.StatusCode);

            var lista = await ListarPedidosAsync(reservacionId: pedido.ReservacionId);
            return Result<ETPedidoRestaurante>.Ok(lista.Data!.First(p => p.Id == pedido.Id));
        }
    }
}
