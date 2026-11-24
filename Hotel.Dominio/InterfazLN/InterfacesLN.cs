using Hotel.Dominio.EntidadesTipadas;
using Hotel.Utilitario;

namespace Hotel.Dominio.InterfazLN
{
    public interface ITipoHabitacionLN
    {
        Task<Result<IEnumerable<ETTipoHabitacion>>> ListarAsync();
        Task<Result<ETTipoHabitacion>> ObtenerPorIdAsync(int id);
        Task<Result<ETTipoHabitacion>> InsertarAsync(ETTipoHabitacion dto);
        Task<Result<ETTipoHabitacion>> ModificarAsync(ETTipoHabitacion dto);
        Task<Result<bool>> EliminarAsync(int id);
    }

    public interface IHabitacionLN
    {
        Task<Result<IEnumerable<ETHabitacion>>> ListarAsync(bool soloActivas = false);
        Task<Result<ETHabitacion>> ObtenerPorIdAsync(int id);
        Task<Result<ETHabitacion>> InsertarAsync(ETHabitacion dto);
        Task<Result<ETHabitacion>> ModificarAsync(ETHabitacion dto);
        Task<Result<ETHabitacion>> CambiarEstadoOperativoAsync(int id, string nuevoEstado);
        Task<Result<bool>> DesactivarAsync(int id);
        Task<Result<IEnumerable<ETHabitacion>>> BuscarDisponiblesAsync(
            DateOnly fechaInicio,
            DateOnly fechaFin,
            int cantidadHuespedes,
            int? tipoHabitacionId = null);
    }

    public interface IClienteLN
    {
        Task<Result<IEnumerable<ETCliente>>> ListarAsync();
        Task<Result<IEnumerable<ETCliente>>> BuscarAsync(string termino);
        Task<Result<ETCliente>> ObtenerPorIdAsync(int id);
        Task<Result<ClienteHistorialDTO>> ObtenerHistorialAsync(int id);
        Task<Result<ETCliente>> InsertarAsync(ETCliente dto);
        Task<Result<ETCliente>> ModificarAsync(ETCliente dto);
    }

    public interface IReservacionLN
    {
        Task<Result<IEnumerable<ETReservacion>>> BuscarAsync(
            string? codigoODocumento = null,
            int? clienteId = null,
            int? habitacionId = null,
            string? estado = null,
            DateOnly? desde = null,
            DateOnly? hasta = null);
        Task<Result<ETReservacion>> ObtenerPorIdAsync(int id);
        Task<Result<ETReservacion>> ObtenerPorCodigoAsync(string codigo);
        Task<Result<CotizacionResponseDTO>> CotizarAsync(CotizacionRequestDTO request);
        Task<Result<ETReservacion>> CrearReservacionAsync(CrearReservacionRequestDTO request);
        Task<Result<ETReservacion>> ConfirmarReservacionAsync(int reservacionId);
        Task<Result<ETReservacion>> CancelarReservacionAsync(int reservacionId, string? motivo = null);
        Task<Result<ETReservacion>> RegistrarCheckInAsync(CheckInRequestDTO request);
        Task<Result<EstadoCuentaReservacionDTO>> RegistrarCheckOutAsync(CheckOutRequestDTO request);
        Task<Result<EstadoCuentaReservacionDTO>> ObtenerEstadoCuentaAsync(int reservacionId);
        Task<Result<IEnumerable<MatrizOcupacionHabitacionDTO>>> ObtenerMatrizOcupacionAsync(DateOnly fechaInicio, DateOnly fechaFin);
    }

    public interface IPagoLN
    {
        Task<Result<IEnumerable<ETPago>>> ListarPorReservacionAsync(int reservacionId);
        Task<Result<ETPago>> RegistrarPagoAsync(ETPago dto);
    }

    public interface IRestauranteLN
    {
        Task<Result<IEnumerable<ETCategoriaPlatillo>>> ListarCategoriasAsync(bool soloActivas = false);
        Task<Result<ETCategoriaPlatillo>> GuardarCategoriaAsync(ETCategoriaPlatillo dto);

        Task<Result<IEnumerable<ETPlatillo>>> ListarPlatillosAsync(int? categoriaId = null, bool soloDisponibles = false);
        Task<Result<ETPlatillo>> GuardarPlatilloAsync(ETPlatillo dto);
        Task<Result<bool>> DesactivarPlatilloAsync(int id);

        Task<Result<IEnumerable<ETPedidoRestaurante>>> ListarPedidosAsync(
            int? reservacionId = null,
            string? estado = null,
            DateOnly? fecha = null);
        Task<Result<ETPedidoRestaurante>> CrearPedidoAsync(CrearPedidoRestauranteRequestDTO request);
        Task<Result<ETPedidoRestaurante>> CambiarEstadoPedidoAsync(int pedidoId, string nuevoEstado);
        Task<Result<ETPedidoRestaurante>> CancelarPedidoAsync(int pedidoId);
    }

    public interface IReporteLN
    {
        Task<Result<DashboardKpiDTO>> ObtenerDashboardKpisAsync();
        Task<Result<IEnumerable<ResumenMensualOcupacionDTO>>> ObtenerResumenMensualAsync(int anio);
        Task<Result<ReporteIngresosDTO>> ObtenerReporteIngresosAsync(DateOnly fechaInicio, DateOnly fechaFin);
        Task<Result<IEnumerable<PlatilloMasSolicitadoDTO>>> ObtenerPlatillosMasSolicitadosAsync(int top = 10);
    }
}
