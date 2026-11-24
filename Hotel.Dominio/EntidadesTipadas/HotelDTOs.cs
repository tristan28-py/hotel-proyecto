namespace Hotel.Dominio.EntidadesTipadas
{
    public class CotizacionRequestDTO
    {
        public int HabitacionId { get; set; }
        public int? ClienteId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int CantidadHuespedes { get; set; }
    }

    public class CotizacionResponseDTO
    {
        public int HabitacionId { get; set; }
        public string HabitacionNumero { get; set; } = string.Empty;
        public string TipoHabitacion { get; set; } = string.Empty;
        public bool Disponible { get; set; }
        public string? MensajeDisponibilidad { get; set; }
        public int Noches { get; set; }
        public decimal TarifaBasePorNoche { get; set; }
        public decimal SubtotalHospedaje { get; set; }
        public decimal RecargoTemporada { get; set; }
        public decimal RecargoPersonasExtra { get; set; }
        public decimal DescuentoCliente { get; set; }
        public decimal Impuestos { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal MontoAnticipoRequerido { get; set; }
        public string DetalleTemporada { get; set; } = string.Empty;
    }

    public class CrearReservacionRequestDTO
    {
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public TimeOnly? HoraLlegadaPactada { get; set; }
        public int CantidadHuespedes { get; set; }
        public string? Acompanantes { get; set; }
        public string? Observaciones { get; set; }
        public bool ConfirmarConAnticipo { get; set; }
        public decimal? MontoAnticipoPagado { get; set; }
        public string? MetodoPagoAnticipo { get; set; }
        public string? ReferenciaPagoAnticipo { get; set; }
    }

    public class CheckInRequestDTO
    {
        public int ReservacionId { get; set; }
        public string? Acompanantes { get; set; }
        public string LlavesAsignadas { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
    }

    public class CheckOutRequestDTO
    {
        public int ReservacionId { get; set; }
        public decimal AjustesCheckOut { get; set; }
        public string? Observaciones { get; set; }
        public decimal? MontoPagoFinal { get; set; }
        public string? MetodoPagoFinal { get; set; }
        public string? ReferenciaPagoFinal { get; set; }
        public string TipoComprobante { get; set; } = "Factura";
    }

    public class EstadoCuentaReservacionDTO
    {
        public int ReservacionId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string ClienteNombre { get; set; } = string.Empty;
        public string HabitacionNumero { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public decimal CostoHospedaje { get; set; }
        public decimal TotalRestaurante { get; set; }
        public decimal AjustesCheckOut { get; set; }
        public decimal TotalGeneral { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public List<ETPago> Pagos { get; set; } = new();
        public List<ETPedidoRestaurante> Pedidos { get; set; } = new();
    }

    public class CrearPedidoItemDTO
    {
        public int PlatilloId { get; set; }
        public int Cantidad { get; set; }
    }

    public class CrearPedidoRestauranteRequestDTO
    {
        public int ReservacionId { get; set; }
        public DateTime FechaHoraDeseada { get; set; }
        public bool EsRoomService { get; set; } = true;
        public string? NumeroMesa { get; set; }
        public string? InstruccionesEspeciales { get; set; }
        public List<CrearPedidoItemDTO> Items { get; set; } = new();
    }

    public class DashboardKpiDTO
    {
        public int TotalHabitacionesActivas { get; set; }
        public int HabitacionesDisponibles { get; set; }
        public int HabitacionesOcupadas { get; set; }
        public int HabitacionesReservadas { get; set; }
        public int HabitacionesEnLimpieza { get; set; }
        public int HabitacionesEnMantenimiento { get; set; }
        public decimal PorcentajeOcupacion { get; set; }
        public int LlegadasPendientesHoy { get; set; }
        public int SalidasProgramadasHoy { get; set; }
        public decimal IngresosDelMes { get; set; }
        public int PedidosActivosCocina { get; set; }
    }

    public class MatrizOcupacionDiaDTO
    {
        public DateOnly Fecha { get; set; }
        public string Estado { get; set; } = "Disponible";
        public string? CodigoReservacion { get; set; }
        public string? HuespedNombre { get; set; }
    }

    public class MatrizOcupacionHabitacionDTO
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public int Piso { get; set; }
        public string TipoHabitacion { get; set; } = string.Empty;
        public string EstadoOperativoActual { get; set; } = string.Empty;
        public List<MatrizOcupacionDiaDTO> Dias { get; set; } = new();
    }

    public class ResumenMensualOcupacionDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string MesNombre { get; set; } = string.Empty;
        public int CantidadReservaciones { get; set; }
        public decimal TotalFacturado { get; set; }
    }

    public class ReporteIngresosDTO
    {
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal TotalPagosRecibidos { get; set; }
        public decimal TotalHospedajeProyectado { get; set; }
        public decimal TotalConsumosRestaurante { get; set; }
        public int CantidadTransacciones { get; set; }
        public List<ETPago> DetallePagos { get; set; } = new();
    }

    public class PlatilloMasSolicitadoDTO
    {
        public int PlatilloId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int CantidadTotalSolicitada { get; set; }
        public decimal MontoTotalGenerado { get; set; }
    }

    public class ClienteHistorialDTO
    {
        public ETCliente Cliente { get; set; } = new();
        public int TotalEstadias { get; set; }
        public decimal TotalFacturadoAcumulado { get; set; }
        public List<ETReservacion> Reservaciones { get; set; } = new();
    }
}
