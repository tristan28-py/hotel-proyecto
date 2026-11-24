using System.Linq.Expressions;
using Hotel.Utilitario;

namespace Hotel.Dominio.InterfazAD
{
    public interface IRepositorioAD<TEntity> where TEntity : class
    {
        Task<Result<TEntity>> InsertarAsync(TEntity objEntidad);
        Task<Result<TEntity>> ModificarAsync(TEntity objEntidad);
        Task<Result<bool>> EliminarAsync(TEntity objEntidad);
        Task<Result<IEnumerable<TEntity>>> ListarAsync(List<string>? objIncludes = null);
        Task<Result<IEnumerable<TEntity>>> BuscarAsync(Expression<Func<TEntity, bool>> objPredicado, List<string>? objIncludes = null);
        Task<Result<TEntity?>> ObtenerEntidadAsync(Expression<Func<TEntity, bool>> objPredicado, List<string>? objIncludes = null);
        Task<Result<int?>> ContarAsync(Expression<Func<TEntity, bool>> objPredicado, List<string>? objIncludes = null);

        /// <summary>
        /// Expone IQueryable para ejecutar filtros, proyecciones y agregaciones LINQ directamente en SQL Server.
        /// </summary>
        IQueryable<TEntity> ObtenerQueryable(bool tracking = false);

        Task<Result<List<TResult>>> EjecutarConsultaAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> consulta,
            bool tracking = false);

        Task<Result<TResult?>> EjecutarPrimeroAsync<TResult>(
            Func<IQueryable<TEntity>, IQueryable<TResult>> consulta,
            bool tracking = false);
    }
}
