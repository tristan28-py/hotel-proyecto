using System.Data;
using Hotel.AccesoDatos.Contexto;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.InterfazAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Hotel.AccesoDatos.Implementaciones
{
    public class UnidadTrabajoEF : IUnidadTrabajoEF
    {
        private readonly HotelContext _contexto;
        private IDbContextTransaction? _transaction;

        public IRepositorioAD<TiposHabitacion> TTipoHabitacion { get; }
        public IRepositorioAD<Habitacione> THabitacion { get; }
        public IRepositorioAD<Cliente> TCliente { get; }
        public IRepositorioAD<Reservacione> TReservacion { get; }
        public IRepositorioAD<Pago> TPago { get; }
        public IRepositorioAD<CategoriasPlatillo> TCategoriaPlatillo { get; }
        public IRepositorioAD<Platillo> TPlatillo { get; }
        public IRepositorioAD<PedidosRestaurante> TPedidoRestaurante { get; }
        public IRepositorioAD<DetallePedido> TDetallePedido { get; }
        public IRepositorioAD<Usuario> TUsuario { get; }

        public UnidadTrabajoEF(HotelContext contexto)
        {
            _contexto = contexto;
            TTipoHabitacion = new RepositorioAD<TiposHabitacion>(_contexto);
            THabitacion = new RepositorioAD<Habitacione>(_contexto);
            TCliente = new RepositorioAD<Cliente>(_contexto);
            TReservacion = new RepositorioAD<Reservacione>(_contexto);
            TPago = new RepositorioAD<Pago>(_contexto);
            TCategoriaPlatillo = new RepositorioAD<CategoriasPlatillo>(_contexto);
            TPlatillo = new RepositorioAD<Platillo>(_contexto);
            TPedidoRestaurante = new RepositorioAD<PedidosRestaurante>(_contexto);
            TDetallePedido = new RepositorioAD<DetallePedido>(_contexto);
            TUsuario = new RepositorioAD<Usuario>(_contexto);
        }

        public int Completar() => _contexto.SaveChanges();

        public Task<int> CompletarAsync() => _contexto.SaveChangesAsync();

        public void EmpezarTransaccion(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = _contexto.Database.BeginTransaction(isolationLevel);
        }

        public async Task EmpezarTransaccionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = await _contexto.Database.BeginTransactionAsync(isolationLevel);
        }

        public void CompletarTran()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public async Task CompletarTranAsync()
        {
            try
            {
                if (_transaction != null)
                    await _transaction.CommitAsync();
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            try
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync();
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void DiscardChanges()
        {
            foreach (var entry in _contexto.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public void CerrarConexion()
        {
            _contexto.Database.CloseConnection();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
                await _transaction.DisposeAsync();
            await _contexto.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
