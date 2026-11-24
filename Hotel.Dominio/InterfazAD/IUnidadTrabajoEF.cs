using System.Data;
using Hotel.Dominio.Entidades;

namespace Hotel.Dominio.InterfazAD
{
    public interface IUnidadTrabajoEF : IDisposable, IAsyncDisposable
    {
        IRepositorioAD<TiposHabitacion> TTipoHabitacion { get; }
        IRepositorioAD<Habitacione> THabitacion { get; }
        IRepositorioAD<Cliente> TCliente { get; }
        IRepositorioAD<Reservacione> TReservacion { get; }
        IRepositorioAD<Pago> TPago { get; }
        IRepositorioAD<CategoriasPlatillo> TCategoriaPlatillo { get; }
        IRepositorioAD<Platillo> TPlatillo { get; }
        IRepositorioAD<PedidosRestaurante> TPedidoRestaurante { get; }
        IRepositorioAD<DetallePedido> TDetallePedido { get; }

        int Completar();
        Task<int> CompletarAsync();
        void EmpezarTransaccion(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task EmpezarTransaccionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CompletarTran();
        Task CompletarTranAsync();
        void Rollback();
        Task RollbackAsync();
        void DiscardChanges();
        void CerrarConexion();
    }
}
