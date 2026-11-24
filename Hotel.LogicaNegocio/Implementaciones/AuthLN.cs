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
    public class AuthLN : IAuthLN
    {
        private readonly IUnidadTrabajoEF _uow;
        private readonly IMapper _mapper;

        public AuthLN(IUnidadTrabajoEF uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<LoginResponseDTO>> LoginAsync(LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return Result<LoginResponseDTO>.Fail("Debe ingresar usuario y contrasena.", 400);

            string userNorm = request.Username.Trim().ToLowerInvariant();
            string hash = SeguridadHelper.HashPassword(request.Password);

            var res = await _uow.TUsuario.ObtenerEntidadAsync(u => u.Username.ToLower() == userNorm);
            if (!res.Success) return Result<LoginResponseDTO>.Fail(res.Error, res.StatusCode);

            var usuario = res.Data;
            if (usuario == null || usuario.PasswordHash != hash)
                return Result<LoginResponseDTO>.Fail("Usuario o contrasena incorrectos.", 401);

            if (!usuario.Activo)
                return Result<LoginResponseDTO>.Fail("Este usuario se encuentra desactivado.", 403);

            return Result<LoginResponseDTO>.Ok(new LoginResponseDTO
            {
                UsuarioId = usuario.Id,
                Username = usuario.Username,
                NombreCompleto = usuario.NombreCompleto,
                Rol = usuario.Rol,
                ClienteId = usuario.ClienteId
            });
        }

        public async Task<Result<LoginResponseDTO>> RegistrarHuespedAsync(RegistroHuespedRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || request.Password.Length < 4)
                return Result<LoginResponseDTO>.Fail("Usuario obligatorio y contrasena de al menos 4 caracteres.", 400);
            if (string.IsNullOrWhiteSpace(request.Nombres) || string.IsNullOrWhiteSpace(request.Apellidos))
                return Result<LoginResponseDTO>.Fail("Nombres y apellidos son obligatorios.", 400);
            if (string.IsNullOrWhiteSpace(request.NumeroDocumento) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Telefono))
                return Result<LoginResponseDTO>.Fail("Documento, correo y telefono son obligatorios.", 400);
            if (!TipoDocumentoConst.Todos.Contains(request.TipoDocumento))
                return Result<LoginResponseDTO>.Fail("Tipo de documento invalido.", 400);

            await _uow.EmpezarTransaccionAsync(IsolationLevel.Serializable);
            try
            {
                string userNorm = request.Username.Trim().ToLowerInvariant();
                var dupUser = await _uow.TUsuario.ContarAsync(u => u.Username.ToLower() == userNorm);
                if (dupUser.Success && (dupUser.Data ?? 0) > 0)
                {
                    await _uow.RollbackAsync();
                    return Result<LoginResponseDTO>.Fail("El nombre de usuario ya esta en uso.", 409);
                }

                string docNorm = request.NumeroDocumento.Trim().ToLowerInvariant();
                var dupDoc = await _uow.TCliente.ContarAsync(c =>
                    c.TipoDocumento == request.TipoDocumento && c.NumeroDocumento.ToLower() == docNorm);
                if (dupDoc.Success && (dupDoc.Data ?? 0) > 0)
                {
                    await _uow.RollbackAsync();
                    return Result<LoginResponseDTO>.Fail("Ya existe un cliente con ese numero de documento.", 409);
                }

                string emailNorm = request.Email.Trim().ToLowerInvariant();
                var dupEmail = await _uow.TCliente.ContarAsync(c => c.Email.ToLower() == emailNorm);
                if (dupEmail.Success && (dupEmail.Data ?? 0) > 0)
                {
                    await _uow.RollbackAsync();
                    return Result<LoginResponseDTO>.Fail("Ya existe un cliente registrado con ese correo.", 409);
                }

                var cliente = new Cliente
                {
                    TipoDocumento = request.TipoDocumento,
                    NumeroDocumento = request.NumeroDocumento.Trim(),
                    Nombres = request.Nombres.Trim(),
                    Apellidos = request.Apellidos.Trim(),
                    Nacionalidad = string.IsNullOrWhiteSpace(request.Nacionalidad) ? "Costarricense" : request.Nacionalidad.Trim(),
                    Email = emailNorm,
                    Telefono = request.Telefono.Trim(),
                    FechaRegistro = DateTime.UtcNow
                };

                var insCli = await _uow.TCliente.InsertarAsync(cliente);
                if (!insCli.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<LoginResponseDTO>.Fail(insCli.Error, insCli.StatusCode);
                }

                var usuario = new Usuario
                {
                    Username = userNorm,
                    PasswordHash = SeguridadHelper.HashPassword(request.Password),
                    NombreCompleto = $"{cliente.Nombres} {cliente.Apellidos}",
                    Rol = RolUsuarioConst.Cliente,
                    ClienteId = cliente.Id,
                    Activo = true,
                    FechaCreacion = DateTime.UtcNow
                };

                var insUsr = await _uow.TUsuario.InsertarAsync(usuario);
                if (!insUsr.Success)
                {
                    await _uow.RollbackAsync();
                    return Result<LoginResponseDTO>.Fail(insUsr.Error, insUsr.StatusCode);
                }

                await _uow.CompletarTranAsync();

                return Result<LoginResponseDTO>.Ok(new LoginResponseDTO
                {
                    UsuarioId = usuario.Id,
                    Username = usuario.Username,
                    NombreCompleto = usuario.NombreCompleto,
                    Rol = usuario.Rol,
                    ClienteId = usuario.ClienteId
                }, 201);
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync();
                return Result<LoginResponseDTO>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<IEnumerable<ETUsuario>>> ListarUsuariosAsync()
        {
            var res = await _uow.TUsuario.EjecutarConsultaAsync(q =>
                q.OrderBy(u => u.Rol).ThenBy(u => u.Username));

            if (!res.Success) return Result<IEnumerable<ETUsuario>>.Fail(res.Error, res.StatusCode);
            return Result<IEnumerable<ETUsuario>>.Ok(_mapper.Map<IEnumerable<ETUsuario>>(res.Data));
        }

        public async Task<Result<ETUsuario>> CrearUsuarioAsync(CrearUsuarioRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || request.Password.Length < 4)
                return Result<ETUsuario>.Fail("Usuario obligatorio y contrasena de al menos 4 caracteres.", 400);
            if (string.IsNullOrWhiteSpace(request.NombreCompleto))
                return Result<ETUsuario>.Fail("El nombre completo es obligatorio.", 400);
            if (!RolUsuarioConst.Todos.Contains(request.Rol))
                return Result<ETUsuario>.Fail("Rol invalido. Use Administrador, Recepcionista o Cliente.", 400);

            string userNorm = request.Username.Trim().ToLowerInvariant();
            var dup = await _uow.TUsuario.ContarAsync(u => u.Username.ToLower() == userNorm);
            if (dup.Success && (dup.Data ?? 0) > 0)
                return Result<ETUsuario>.Fail("Ese nombre de usuario ya existe.", 409);

            var usuario = new Usuario
            {
                Username = userNorm,
                PasswordHash = SeguridadHelper.HashPassword(request.Password),
                NombreCompleto = request.NombreCompleto.Trim(),
                Rol = request.Rol,
                ClienteId = request.ClienteId,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            var ins = await _uow.TUsuario.InsertarAsync(usuario);
            if (!ins.Success) return Result<ETUsuario>.Fail(ins.Error, ins.StatusCode);
            return Result<ETUsuario>.Ok(_mapper.Map<ETUsuario>(ins.Data), 201);
        }

        public async Task<Result<ETUsuario>> CambiarEstadoAsync(int usuarioId, bool activo)
        {
            var res = await _uow.TUsuario.ObtenerEntidadAsync(u => u.Id == usuarioId);
            if (!res.Success || res.Data == null)
                return Result<ETUsuario>.Fail("Usuario no encontrado.", 404);

            res.Data.Activo = activo;
            var upd = await _uow.TUsuario.ModificarAsync(res.Data);
            if (!upd.Success) return Result<ETUsuario>.Fail(upd.Error, upd.StatusCode);

            return Result<ETUsuario>.Ok(_mapper.Map<ETUsuario>(upd.Data));
        }
    }
}
