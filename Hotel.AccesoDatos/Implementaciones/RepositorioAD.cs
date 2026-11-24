using System.Linq.Expressions;
using Hotel.Dominio.InterfazAD;
using Hotel.Utilitario;
using Microsoft.EntityFrameworkCore;

namespace Hotel.AccesoDatos.Implementaciones
{
    public class RepositorioAD<TEntity> : IRepositorioAD<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public RepositorioAD(DbContext context)
        {
            _context = context;
        }

        public async Task<Result<TEntity>> InsertarAsync(TEntity objEntidad)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(objEntidad);
                await _context.SaveChangesAsync();
                return Result<TEntity>.Ok(objEntidad, 201);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result<TEntity>.Fail($"Conflicto de concurrencia al insertar: {ex.Message}", 409);
            }
            catch (DbUpdateException ex)
            {
                return Result<TEntity>.Fail(ex.InnerException?.Message ?? ex.Message, 400);
            }
            catch (Exception ex)
            {
                return Result<TEntity>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<TEntity>> ModificarAsync(TEntity objEntidad)
        {
            try
            {
                _context.Set<TEntity>().Update(objEntidad);
                await _context.SaveChangesAsync();
                return Result<TEntity>.Ok(objEntidad);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result<TEntity>.Fail("El registro fue modificado por otro usuario. Recargue e intente nuevamente.", 409);
            }
            catch (DbUpdateException ex)
            {
                return Result<TEntity>.Fail(ex.InnerException?.Message ?? ex.Message, 400);
            }
            catch (Exception ex)
            {
                return Result<TEntity>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<bool>> EliminarAsync(TEntity objEntidad)
        {
            try
            {
                _context.Entry(objEntidad).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Result<bool>.Ok(true);
            }
            catch (DbUpdateException ex)
            {
                return Result<bool>.Fail(ex.InnerException?.Message ?? ex.Message, 409);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<IEnumerable<TEntity>>> ListarAsync(List<string>? objIncludes = null)
        {
            try
            {
                IQueryable<TEntity> objPreconsulta = _context.Set<TEntity>().AsNoTracking();
                if (objIncludes != null)
                {
                    foreach (var include in objIncludes)
                        objPreconsulta = objPreconsulta.Include(include);
                }
                var lista = await objPreconsulta.ToListAsync();
                return Result<IEnumerable<TEntity>>.Ok(lista);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TEntity>>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<IEnumerable<TEntity>>> BuscarAsync(
            Expression<Func<TEntity, bool>> objPredicado,
            List<string>? objIncludes = null)
        {
            try
            {
                IQueryable<TEntity> objPreconsulta = _context.Set<TEntity>().AsNoTracking();
                if (objIncludes != null)
                {
                    foreach (var include in objIncludes)
                        objPreconsulta = objPreconsulta.Include(include);
                }
                var lista = await objPreconsulta.Where(objPredicado).ToListAsync();
                return Result<IEnumerable<TEntity>>.Ok(lista);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TEntity>>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<TEntity?>> ObtenerEntidadAsync(
            Expression<Func<TEntity, bool>> objPredicado,
            List<string>? objIncludes = null)
        {
            try
            {
                IQueryable<TEntity> objPreconsulta = _context.Set<TEntity>();
                if (objIncludes != null)
                {
                    foreach (var include in objIncludes)
                        objPreconsulta = objPreconsulta.Include(include);
                }
                var entidad = await objPreconsulta.Where(objPredicado).FirstOrDefaultAsync();
                return Result<TEntity?>.Ok(entidad);
            }
            catch (Exception ex)
            {
                return Result<TEntity?>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<int?>> ContarAsync(
            Expression<Func<TEntity, bool>> objPredicado,
            List<string>? objIncludes = null)
        {
            try
            {
                IQueryable<TEntity> objPreconsulta = _context.Set<TEntity>().AsNoTracking();
                if (objIncludes != null)
                {
                    foreach (var include in objIncludes)
                        objPreconsulta = objPreconsulta.Include(include);
                }
                int cantidad = await objPreconsulta.Where(objPredicado).CountAsync();
                return Result<int?>.Ok(cantidad);
            }
            catch (Exception ex)
            {
                return Result<int?>.Fail(ex.Message, 500);
            }
        }

        public IQueryable<TEntity> ObtenerQueryable(bool tracking = false)
        {
            return tracking
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<Result<List<TResult>>> EjecutarConsultaAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> consulta,
            bool tracking = false)
        {
            try
            {
                IQueryable<TEntity> baseQuery = ObtenerQueryable(tracking);
                var lista = await consulta(baseQuery).ToListAsync();
                return Result<List<TResult>>.Ok(lista);
            }
            catch (Exception ex)
            {
                return Result<List<TResult>>.Fail(ex.Message, 500);
            }
        }

        public async Task<Result<TResult?>> EjecutarPrimeroAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> consulta,
            bool tracking = false)
        {
            try
            {
                IQueryable<TEntity> baseQuery = ObtenerQueryable(tracking);
                var item = await consulta(baseQuery).FirstOrDefaultAsync();
                return Result<TResult?>.Ok(item);
            }
            catch (Exception ex)
            {
                return Result<TResult?>.Fail(ex.Message, 500);
            }
        }
    }
}
