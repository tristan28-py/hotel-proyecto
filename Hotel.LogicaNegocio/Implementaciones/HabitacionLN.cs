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
    public class HabitacionLN : IHabitacionLN
    {
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public HabitacionLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETHabitacion>>> ListarAsync(bool soloActivas = false)
        {
            var res = await _uow.THabitacion.EjecutarConsultaAsync(q =>
            {
                if (soloActivas) q = q.Where(h => h.Activa);
                return q.OrderBy(h => h.Piso)
                        .ThenBy(h => h.Numero)
                        .Select(h => new ETHabitacion
                        {
                            Id = h.Id,
                            Numero = h.Numero,
                            Piso = h.Piso,
                            TipoHabitacionId = h.TipoHabitacionId,
                            TipoHabitacionNombre = h.TipoHabitacion.Nombre,
                            CapacidadAdultos = h.TipoHabitacion.CapacidadAdultos,
                            CapacidadNinos = h.TipoHabitacion.CapacidadNinos,
                            PrecioBasePorNoche = h.TipoHabitacion.PrecioBasePorNoche,
                            EstadoOperativo = h.EstadoOperativo,
                            TieneJacuzzi = h.TieneJacuzzi,
                            TieneVistaMar = h.TieneVistaMar,
                            TieneWifi6 = h.TieneWifi6,
                            TieneFrigobar = h.TieneFrigobar,
                            AmenidadesAdicionales = h.AmenidadesAdicionales,
                            Activa = h.Activa
                        });
            });

            if (!res.Success) return Result<IEnumerable<ETHabitacion>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETHabitacion>>.Ok(res.Data!);
        }

        public async Task<Result<ETHabitacion>> ObtenerPorIdAsync(int id)
        {
            var res = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == id, ["TipoHabitacion"]);
            if (!res.Success) return Result<ETHabitacion>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<ETHabitacion>.Fail("Habitación no encontrada.", 404);
            return Result<ETHabitacion>.Ok(_mapper.Map<ETHabitacion>(res.Data));
        }

        public async Task<Result<ETHabitacion>> InsertarAsync(ETHabitacion dto)
        {
            var error = await ValidarAsync(dto, esEdicion: false);
            if (error != null) return Result<ETHabitacion>.Fail(error.Value.msg, error.Value.code);

            var entidad = _mapper.Map<Habitacione>(dto);
            entidad.Numero = dto.Numero.Trim().ToUpperInvariant();
            entidad.EstadoOperativo = string.IsNullOrWhiteSpace(dto.EstadoOperativo)
                ? EstadoHabitacion.Disponible
                : dto.EstadoOperativo;

            var res = await _uow.THabitacion.InsertarAsync(entidad);
            if (!res.Success) return Result<ETHabitacion>.Fail(res.Error, res.StatusCode);

            return await ObtenerPorIdAsync(res.Data!.Id);
        }

        public async Task<Result<ETHabitacion>> ModificarAsync(ETHabitacion dto)
        {
            var existenteRes = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == dto.Id);
            if (!existenteRes.Success) return Result<ETHabitacion>.Fail(existenteRes.Error, existenteRes.StatusCode);
            if (existenteRes.Data == null) return Result<ETHabitacion>.Fail("Habitación no encontrada.", 404);

            var error = await ValidarAsync(dto, esEdicion: true);
            if (error != null) return Result<ETHabitacion>.Fail(error.Value.msg, error.Value.code);

            var entidad = existenteRes.Data;
            entidad.Numero = dto.Numero.Trim().ToUpperInvariant();
            entidad.Piso = dto.Piso;
            entidad.TipoHabitacionId = dto.TipoHabitacionId;
            entidad.EstadoOperativo = dto.EstadoOperativo;
            entidad.TieneJacuzzi = dto.TieneJacuzzi;
            entidad.TieneVistaMar = dto.TieneVistaMar;
            entidad.TieneWifi6 = dto.TieneWifi6;
            entidad.TieneFrigobar = dto.TieneFrigobar;
            entidad.AmenidadesAdicionales = dto.AmenidadesAdicionales?.Trim();
            entidad.Activa = dto.Activa;

            var res = await _uow.THabitacion.ModificarAsync(entidad);
            if (!res.Success) return Result<ETHabitacion>.Fail(res.Error, res.StatusCode);

            return await ObtenerPorIdAsync(entidad.Id);
        }

        public async Task<Result<ETHabitacion>> CambiarEstadoOperativoAsync(int id, string nuevoEstado)
        {
            if (!EstadoHabitacion.Todos.Contains(nuevoEstado))
                return Result<ETHabitacion>.Fail($"Estado operativo inválido: '{nuevoEstado}'.", 400);

            var res = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == id);
            if (!res.Success) return Result<ETHabitacion>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<ETHabitacion>.Fail("Habitación no encontrada.", 404);

            res.Data.EstadoOperativo = nuevoEstado;
            var upd = await _uow.THabitacion.ModificarAsync(res.Data);
            if (!upd.Success) return Result<ETHabitacion>.Fail(upd.Error, upd.StatusCode);

            return await ObtenerPorIdAsync(id);
        }

        public async Task<Result<bool>> DesactivarAsync(int id)
        {
            var res = await _uow.THabitacion.ObtenerEntidadAsync(h => h.Id == id);
            if (!res.Success) return Result<bool>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<bool>.Fail("Habitación no encontrada.", 404);

            var activas = await _uow.TReservacion.ContarAsync(r =>
                r.HabitacionId == id &&
                (r.Estado == EstadoReservacion.Confirmada || r.Estado == EstadoReservacion.EnCurso));
            if (activas.Success && activas.Data > 0)
                return Result<bool>.Fail("No se puede desactivar la habitación porque tiene reservaciones confirmadas o estadías en curso.", 409);

            res.Data.Activa = false;
            res.Data.EstadoOperativo = EstadoHabitacion.Bloqueada;
            var upd = await _uow.THabitacion.ModificarAsync(res.Data);
            return upd.Success ? Result<bool>.Ok(true) : Result<bool>.Fail(upd.Error, upd.StatusCode);
        }

        public async Task<Result<IEnumerable<ETHabitacion>>> BuscarDisponiblesAsync(
            DateOnly fechaInicio,
            DateOnly fechaFin,
            int cantidadHuespedes,
            int? tipoHabitacionId = null)
        {
            try
            {
                _ = new RangoFechas(fechaInicio, fechaFin);
            }
            catch (ArgumentException ex)
            {
                return Result<IEnumerable<ETHabitacion>>.Fail(ex.Message, 400);
            }

            if (cantidadHuespedes <= 0)
                return Result<IEnumerable<ETHabitacion>>.Fail("La cantidad de huéspedes debe ser mayor que cero.", 400);

            var res = await _uow.THabitacion.EjecutarConsultaAsync(q =>
            {
                var query = q.Where(h =>
                    h.Activa &&
                    h.EstadoOperativo != EstadoHabitacion.EnMantenimiento &&
                    h.EstadoOperativo != EstadoHabitacion.Bloqueada &&
                    (h.TipoHabitacion.CapacidadAdultos + h.TipoHabitacion.CapacidadNinos) >= cantidadHuespedes &&
                    !h.Reservaciones.Any(r =>
                        r.Estado != EstadoReservacion.Cancelada &&
                        r.Estado != EstadoReservacion.Completada &&
                        r.FechaInicio < fechaFin &&
                        r.FechaFin > fechaInicio));

                if (tipoHabitacionId.HasValue)
                    query = query.Where(h => h.TipoHabitacionId == tipoHabitacionId.Value);

                return query
                    .OrderBy(h => h.TipoHabitacion.PrecioBasePorNoche)
                    .ThenBy(h => h.TipoHabitacion.CapacidadAdultos + h.TipoHabitacion.CapacidadNinos)
                    .Select(h => new ETHabitacion
                    {
                        Id = h.Id,
                        Numero = h.Numero,
                        Piso = h.Piso,
                        TipoHabitacionId = h.TipoHabitacionId,
                        TipoHabitacionNombre = h.TipoHabitacion.Nombre,
                        CapacidadAdultos = h.TipoHabitacion.CapacidadAdultos,
                        CapacidadNinos = h.TipoHabitacion.CapacidadNinos,
                        PrecioBasePorNoche = h.TipoHabitacion.PrecioBasePorNoche,
                        EstadoOperativo = h.EstadoOperativo,
                        TieneJacuzzi = h.TieneJacuzzi,
                        TieneVistaMar = h.TieneVistaMar,
                        TieneWifi6 = h.TieneWifi6,
                        TieneFrigobar = h.TieneFrigobar,
                        AmenidadesAdicionales = h.AmenidadesAdicionales,
                        Activa = h.Activa
                    });
            });

            if (!res.Success) return Result<IEnumerable<ETHabitacion>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETHabitacion>>.Ok(res.Data!);
        }

        private async Task<(string msg, int code)?> ValidarAsync(ETHabitacion dto, bool esEdicion)
        {
            if (string.IsNullOrWhiteSpace(dto.Numero))
                return ("El número de habitación es obligatorio.", 400);
            if (dto.Piso < 1)
                return ("El piso debe ser mayor o igual a 1.", 400);
            if (!EstadoHabitacion.Todos.Contains(dto.EstadoOperativo))
                return ($"Estado operativo inválido: '{dto.EstadoOperativo}'.", 400);

            var tipo = await _uow.TTipoHabitacion.ContarAsync(t => t.Id == dto.TipoHabitacionId);
            if (!tipo.Success || (tipo.Data ?? 0) == 0)
                return ("El tipo de habitación seleccionado no existe.", 400);

            string numeroNorm = dto.Numero.Trim().ToUpperInvariant();
            var dup = await _uow.THabitacion.ContarAsync(h =>
                h.Numero.ToUpper() == numeroNorm && (!esEdicion || h.Id != dto.Id));
            if (dup.Success && dup.Data > 0)
                return ($"Ya existe una habitación registrada con el número '{numeroNorm}'.", 409);

            return null;
        }
    }
}
