using AutoMapper;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.Utilitario;

namespace Hotel.LogicaNegocio.Implementaciones
{
    public class TipoHabitacionLN : ITipoHabitacionLN
    {
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public TipoHabitacionLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETTipoHabitacion>>> ListarAsync()
        {
            var res = await _uow.TTipoHabitacion.EjecutarConsultaAsync(q =>
                q.OrderBy(t => t.PrecioBasePorNoche));

            if (!res.Success) return Result<IEnumerable<ETTipoHabitacion>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETTipoHabitacion>>.Ok(_mapper.Map<IEnumerable<ETTipoHabitacion>>(res.Data));
        }

        public async Task<Result<ETTipoHabitacion>> ObtenerPorIdAsync(int id)
        {
            var res = await _uow.TTipoHabitacion.ObtenerEntidadAsync(t => t.Id == id);
            if (!res.Success) return Result<ETTipoHabitacion>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<ETTipoHabitacion>.Fail("Tipo de habitación no encontrado.", 404);
            return Result<ETTipoHabitacion>.Ok(_mapper.Map<ETTipoHabitacion>(res.Data));
        }

        public async Task<Result<ETTipoHabitacion>> InsertarAsync(ETTipoHabitacion dto)
        {
            var validacion = Validar(dto);
            if (validacion != null) return Result<ETTipoHabitacion>.Fail(validacion, 400);

            var duplicado = await _uow.TTipoHabitacion.ContarAsync(t => t.Nombre.ToLower() == dto.Nombre.Trim().ToLower());
            if (duplicado.Success && duplicado.Data > 0)
                return Result<ETTipoHabitacion>.Fail("Ya existe un tipo de habitación con ese nombre.", 409);

            var entidad = _mapper.Map<TiposHabitacion>(dto);
            entidad.Nombre = entidad.Nombre.Trim();
            var res = await _uow.TTipoHabitacion.InsertarAsync(entidad);
            if (!res.Success) return Result<ETTipoHabitacion>.Fail(res.Error, res.StatusCode);

            return Result<ETTipoHabitacion>.Ok(_mapper.Map<ETTipoHabitacion>(res.Data), 201);
        }

        public async Task<Result<ETTipoHabitacion>> ModificarAsync(ETTipoHabitacion dto)
        {
            var validacion = Validar(dto);
            if (validacion != null) return Result<ETTipoHabitacion>.Fail(validacion, 400);

            var existenteRes = await _uow.TTipoHabitacion.ObtenerEntidadAsync(t => t.Id == dto.Id);
            if (!existenteRes.Success) return Result<ETTipoHabitacion>.Fail(existenteRes.Error, existenteRes.StatusCode);
            if (existenteRes.Data == null) return Result<ETTipoHabitacion>.Fail("Tipo de habitación no encontrado.", 404);

            var duplicado = await _uow.TTipoHabitacion.ContarAsync(t =>
                t.Id != dto.Id && t.Nombre.ToLower() == dto.Nombre.Trim().ToLower());
            if (duplicado.Success && duplicado.Data > 0)
                return Result<ETTipoHabitacion>.Fail("Ya existe otro tipo de habitación con ese nombre.", 409);

            var entidad = existenteRes.Data;
            entidad.Nombre = dto.Nombre.Trim();
            entidad.Descripcion = dto.Descripcion?.Trim();
            entidad.CapacidadAdultos = dto.CapacidadAdultos;
            entidad.CapacidadNinos = dto.CapacidadNinos;
            entidad.PrecioBasePorNoche = dto.PrecioBasePorNoche;

            var res = await _uow.TTipoHabitacion.ModificarAsync(entidad);
            if (!res.Success) return Result<ETTipoHabitacion>.Fail(res.Error, res.StatusCode);

            return Result<ETTipoHabitacion>.Ok(_mapper.Map<ETTipoHabitacion>(res.Data));
        }

        public async Task<Result<bool>> EliminarAsync(int id)
        {
            var existenteRes = await _uow.TTipoHabitacion.ObtenerEntidadAsync(t => t.Id == id);
            if (!existenteRes.Success) return Result<bool>.Fail(existenteRes.Error, existenteRes.StatusCode);
            if (existenteRes.Data == null) return Result<bool>.Fail("Tipo de habitación no encontrado.", 404);

            var habitacionesAsociadas = await _uow.THabitacion.ContarAsync(h => h.TipoHabitacionId == id);
            if (habitacionesAsociadas.Success && habitacionesAsociadas.Data > 0)
                return Result<bool>.Fail("No se puede eliminar el tipo porque tiene habitaciones asociadas.", 409);

            return await _uow.TTipoHabitacion.EliminarAsync(existenteRes.Data);
        }

        private static string? Validar(ETTipoHabitacion dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return "El nombre del tipo de habitación es obligatorio.";
            if (dto.CapacidadAdultos <= 0)
                return "La capacidad de adultos debe ser mayor que cero.";
            if (dto.CapacidadNinos < 0)
                return "La capacidad de niños no puede ser negativa.";
            if (dto.PrecioBasePorNoche <= 0)
                return "El precio base por noche debe ser mayor que cero.";
            return null;
        }
    }
}
