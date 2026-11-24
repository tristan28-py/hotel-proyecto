using System.Text.RegularExpressions;
using AutoMapper;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.EntidadesTipadas;
using Hotel.Dominio.Enums;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.Utilitario;

namespace Hotel.LogicaNegocio.Implementaciones
{
    public class ClienteLN : IClienteLN
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public ClienteLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ETCliente>>> ListarAsync()
        {
            var res = await _uow.TCliente.EjecutarConsultaAsync(q =>
                q.OrderBy(c => c.Apellidos).ThenBy(c => c.Nombres));
            if (!res.Success) return Result<IEnumerable<ETCliente>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETCliente>>.Ok(_mapper.Map<IEnumerable<ETCliente>>(res.Data));
        }

        public async Task<Result<IEnumerable<ETCliente>>> BuscarAsync(string termino)
        {
            string term = (termino ?? string.Empty).Trim().ToLowerInvariant();
            var res = await _uow.TCliente.EjecutarConsultaAsync(q =>
                string.IsNullOrEmpty(term)
                    ? q.OrderBy(c => c.Apellidos).ThenBy(c => c.Nombres)
                    : q.Where(c =>
                        c.NumeroDocumento.ToLower().Contains(term) ||
                        c.Nombres.ToLower().Contains(term) ||
                        c.Apellidos.ToLower().Contains(term) ||
                        c.Email.ToLower().Contains(term))
                    .OrderBy(c => c.Apellidos));

            if (!res.Success) return Result<IEnumerable<ETCliente>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETCliente>>.Ok(_mapper.Map<IEnumerable<ETCliente>>(res.Data));
        }

        public async Task<Result<ETCliente>> ObtenerPorIdAsync(int id)
        {
            var res = await _uow.TCliente.ObtenerEntidadAsync(c => c.Id == id);
            if (!res.Success) return Result<ETCliente>.Fail(res.Error, res.StatusCode);
            if (res.Data == null) return Result<ETCliente>.Fail("Cliente no encontrado.", 404);
            return Result<ETCliente>.Ok(_mapper.Map<ETCliente>(res.Data));
        }

        public async Task<Result<ClienteHistorialDTO>> ObtenerHistorialAsync(int id)
        {
            var clienteRes = await ObtenerPorIdAsync(id);
            if (!clienteRes.Success) return Result<ClienteHistorialDTO>.Fail(clienteRes.Error, clienteRes.StatusCode);

            var reservasRes = await _uow.TReservacion.EjecutarConsultaAsync(q =>
                q.Where(r => r.ClienteId == id)
                 .OrderByDescending(r => r.FechaInicio)
                 .Select(r => new ETReservacion
                 {
                     Id = r.Id,
                     Codigo = r.Codigo,
                     ClienteId = r.ClienteId,
                     HabitacionId = r.HabitacionId,
                     HabitacionNumero = r.Habitacion.Numero,
                     TipoHabitacionNombre = r.Habitacion.TipoHabitacion.Nombre,
                     FechaInicio = r.FechaInicio,
                     FechaFin = r.FechaFin,
                     Estado = r.Estado,
                     CantidadHuespedes = r.CantidadHuespedes,
                     CostoTotal = r.CostoTotal,
                     TotalPagado = r.Pagos.Sum(p => (decimal?)p.Monto) ?? 0m,
                     TotalConsumosRestaurante = r.PedidosRestaurantes
                         .Where(p => p.EstadoPedido != EstadoPedidoConst.Cancelado)
                         .Sum(p => (decimal?)p.Total) ?? 0m
                 }));

            if (!reservasRes.Success)
                return Result<ClienteHistorialDTO>.Fail(reservasRes.Error, reservasRes.StatusCode);

            var lista = reservasRes.Data!;
            var historial = new ClienteHistorialDTO
            {
                Cliente = clienteRes.Data!,
                TotalEstadias = lista.Count(r => r.Estado == EstadoReservacion.Completada),
                TotalFacturadoAcumulado = lista.Where(r => r.Estado != EstadoReservacion.Cancelada)
                    .Sum(r => r.CostoTotal + r.TotalConsumosRestaurante),
                Reservaciones = lista
            };

            return Result<ClienteHistorialDTO>.Ok(historial);
        }

        public async Task<Result<ETCliente>> InsertarAsync(ETCliente dto)
        {
            var err = await ValidarAsync(dto, esEdicion: false);
            if (err != null) return Result<ETCliente>.Fail(err.Value.msg, err.Value.code);

            var entidad = _mapper.Map<Cliente>(dto);
            entidad.NumeroDocumento = dto.NumeroDocumento.Trim();
            entidad.Nombres = dto.Nombres.Trim();
            entidad.Apellidos = dto.Apellidos.Trim();
            entidad.Email = dto.Email.Trim().ToLowerInvariant();
            entidad.Telefono = dto.Telefono.Trim();
            entidad.FechaRegistro = DateTime.UtcNow;

            var res = await _uow.TCliente.InsertarAsync(entidad);
            if (!res.Success) return Result<ETCliente>.Fail(res.Error, res.StatusCode);
            return Result<ETCliente>.Ok(_mapper.Map<ETCliente>(res.Data), 201);
        }

        public async Task<Result<ETCliente>> ModificarAsync(ETCliente dto)
        {
            var existenteRes = await _uow.TCliente.ObtenerEntidadAsync(c => c.Id == dto.Id);
            if (!existenteRes.Success) return Result<ETCliente>.Fail(existenteRes.Error, existenteRes.StatusCode);
            if (existenteRes.Data == null) return Result<ETCliente>.Fail("Cliente no encontrado.", 404);

            var err = await ValidarAsync(dto, esEdicion: true);
            if (err != null) return Result<ETCliente>.Fail(err.Value.msg, err.Value.code);

            var c = existenteRes.Data;
            c.TipoDocumento = dto.TipoDocumento;
            c.NumeroDocumento = dto.NumeroDocumento.Trim();
            c.Nombres = dto.Nombres.Trim();
            c.Apellidos = dto.Apellidos.Trim();
            c.Nacionalidad = string.IsNullOrWhiteSpace(dto.Nacionalidad) ? "Costarricense" : dto.Nacionalidad.Trim();
            c.Email = dto.Email.Trim().ToLowerInvariant();
            c.Telefono = dto.Telefono.Trim();
            c.TelefonoEmergencia = dto.TelefonoEmergencia?.Trim();
            c.Direccion = dto.Direccion?.Trim();
            c.FechaNacimiento = dto.FechaNacimiento;
            c.Preferencias = dto.Preferencias?.Trim();
            c.EsClienteFrecuente = dto.EsClienteFrecuente;

            var res = await _uow.TCliente.ModificarAsync(c);
            if (!res.Success) return Result<ETCliente>.Fail(res.Error, res.StatusCode);
            return Result<ETCliente>.Ok(_mapper.Map<ETCliente>(res.Data));
        }

        private async Task<(string msg, int code)?> ValidarAsync(ETCliente dto, bool esEdicion)
        {
            if (!TipoDocumentoConst.Todos.Contains(dto.TipoDocumento))
                return ("Tipo de documento inválido. Use DNI, Pasaporte o Cedula.", 400);
            if (string.IsNullOrWhiteSpace(dto.NumeroDocumento))
                return ("El número de documento es obligatorio.", 400);
            if (string.IsNullOrWhiteSpace(dto.Nombres) || string.IsNullOrWhiteSpace(dto.Apellidos))
                return ("Nombres y apellidos son obligatorios.", 400);
            if (string.IsNullOrWhiteSpace(dto.Email) || !EmailRegex.IsMatch(dto.Email.Trim()))
                return ("El correo electrónico no tiene un formato válido.", 400);
            if (string.IsNullOrWhiteSpace(dto.Telefono))
                return ("El teléfono principal es obligatorio.", 400);

            string docNorm = dto.NumeroDocumento.Trim().ToLowerInvariant();
            var dupDoc = await _uow.TCliente.ContarAsync(c =>
                c.TipoDocumento == dto.TipoDocumento &&
                c.NumeroDocumento.ToLower() == docNorm &&
                (!esEdicion || c.Id != dto.Id));
            if (dupDoc.Success && dupDoc.Data > 0)
                return ("Ya existe un cliente registrado con ese tipo y número de documento.", 409);

            string emailNorm = dto.Email.Trim().ToLowerInvariant();
            var dupEmail = await _uow.TCliente.ContarAsync(c =>
                c.Email.ToLower() == emailNorm &&
                (!esEdicion || c.Id != dto.Id));
            if (dupEmail.Success && dupEmail.Data > 0)
                return ("Ya existe un cliente registrado con ese correo electrónico.", 409);

            return null;
        }
    }
}
