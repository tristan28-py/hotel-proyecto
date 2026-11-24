namespace Hotel.WindowsForms.Models
{
    public class TipoHabitacionModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int CapacidadAdultos { get; set; }
        public int CapacidadNinos { get; set; }
        public decimal PrecioBasePorNoche { get; set; }
        public override string ToString() => $"{Nombre} ({PrecioBasePorNoche:C2}/noche)";
    }

    public class HabitacionModel
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public int Piso { get; set; }
        public int TipoHabitacionId { get; set; }
        public string? TipoHabitacionNombre { get; set; }
        public int CapacidadAdultos { get; set; }
        public int CapacidadNinos { get; set; }
        public decimal PrecioBasePorNoche { get; set; }
        public string EstadoOperativo { get; set; } = "Disponible";
        public bool TieneJacuzzi { get; set; }
        public bool TieneVistaMar { get; set; }
        public bool TieneWifi6 { get; set; }
        public bool TieneFrigobar { get; set; }
        public string? AmenidadesAdicionales { get; set; }
        public bool Activa { get; set; } = true;
    }

    public class ClienteModel
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = "Cedula";
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = "Costarricense";
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? TelefonoEmergencia { get; set; }
        public string? Direccion { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Preferencias { get; set; }
        public bool EsClienteFrecuente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();
        public override string ToString() => $"{NombreCompleto} ({TipoDocumento}: {NumeroDocumento})";
    }

    public class ReservacionModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string? ClienteNombreCompleto { get; set; }
        public string? ClienteDocumento { get; set; }
        public int HabitacionId { get; set; }
        public string? HabitacionNumero { get; set; }
        public string? TipoHabitacionNombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public TimeOnly? HoraLlegadaPactada { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int CantidadHuespedes { get; set; }
        public decimal SubtotalHospedaje { get; set; }
        public decimal RecargoTemporada { get; set; }
        public decimal RecargoPersonasExtra { get; set; }
        public decimal DescuentoCliente { get; set; }
        public decimal Impuestos { get; set; }
        public decimal AjustesCheckOut { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal MontoAnticipoRequerido { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal TotalConsumosRestaurante { get; set; }
        public decimal SaldoPendiente { get; set; }
        public DateTime? FechaCheckInReal { get; set; }
        public DateTime? FechaCheckOutReal { get; set; }
        public string? Acompanantes { get; set; }
        public string? LlavesAsignadas { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class PagoModel
    {
        public int Id { get; set; }
        public int ReservacionId { get; set; }
        public string? CodigoReservacion { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = "Efectivo";
        public DateTime FechaPago { get; set; }
        public string? ReferenciaTransaccion { get; set; }
        public string TipoComprobante { get; set; } = "Recibo";
        public string? NumeroComprobante { get; set; }
        public string? Notas { get; set; }
    }

    public class CategoriaPlatilloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public override string ToString() => Nombre;
    }

    public class PlatilloModel
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int TiempoPreparacionMinutos { get; set; }
        public bool Disponible { get; set; } = true;
        public bool Activo { get; set; } = true;
        public string? ImagenUrl { get; set; }
    }

    public class DetallePedidoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PlatilloId { get; set; }
        public string? PlatilloNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class PedidoRestauranteModel
    {
        public int Id { get; set; }
        public int ReservacionId { get; set; }
        public string? CodigoReservacion { get; set; }
        public string? HabitacionNumero { get; set; }
        public string? ClienteNombre { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaHoraDeseada { get; set; }
        public string EstadoPedido { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal RecargoServicio { get; set; }
        public decimal Total { get; set; }
        public bool EsRoomService { get; set; }
        public string? NumeroMesa { get; set; }
        public string? InstruccionesEspeciales { get; set; }
        public List<DetallePedidoModel> Detalles { get; set; } = new();
    }

    public class CotizacionRequestModel
    {
        public int HabitacionId { get; set; }
        public int? ClienteId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int CantidadHuespedes { get; set; }
    }

    public class CotizacionResponseModel
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

    public class CrearReservacionRequestModel
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

    public class CheckInRequestModel
    {
        public int ReservacionId { get; set; }
        public string? Acompanantes { get; set; }
        public string LlavesAsignadas { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
    }

    public class CheckOutRequestModel
    {
        public int ReservacionId { get; set; }
        public decimal AjustesCheckOut { get; set; }
        public string? Observaciones { get; set; }
        public decimal? MontoPagoFinal { get; set; }
        public string? MetodoPagoFinal { get; set; }
        public string? ReferenciaPagoFinal { get; set; }
        public string TipoComprobante { get; set; } = "Factura";
    }

    public class EstadoCuentaModel
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
        public List<PagoModel> Pagos { get; set; } = new();
        public List<PedidoRestauranteModel> Pedidos { get; set; } = new();
    }

    public class CrearPedidoItemModel
    {
        public int PlatilloId { get; set; }
        public int Cantidad { get; set; }
    }

    public class CrearPedidoRequestModel
    {
        public int ReservacionId { get; set; }
        public DateTime FechaHoraDeseada { get; set; }
        public bool EsRoomService { get; set; } = true;
        public string? NumeroMesa { get; set; }
        public string? InstruccionesEspeciales { get; set; }
        public List<CrearPedidoItemModel> Items { get; set; } = new();
    }

    public class DashboardKpiModel
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

    public class MatrizOcupacionDiaModel
    {
        public DateOnly Fecha { get; set; }
        public string Estado { get; set; } = "Disponible";
        public string? CodigoReservacion { get; set; }
        public string? HuespedNombre { get; set; }
    }

    public class MatrizOcupacionHabitacionModel
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public int Piso { get; set; }
        public string TipoHabitacion { get; set; } = string.Empty;
        public string EstadoOperativoActual { get; set; } = string.Empty;
        public List<MatrizOcupacionDiaModel> Dias { get; set; } = new();
    }

    public class ResumenMensualOcupacionModel
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string MesNombre { get; set; } = string.Empty;
        public int CantidadReservaciones { get; set; }
        public decimal TotalFacturado { get; set; }
    }

    public class ReporteIngresosModel
    {
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal TotalPagosRecibidos { get; set; }
        public decimal TotalHospedajeProyectado { get; set; }
        public decimal TotalConsumosRestaurante { get; set; }
        public int CantidadTransacciones { get; set; }
        public List<PagoModel> DetallePagos { get; set; } = new();
    }

    public class PlatilloMasSolicitadoModel
    {
        public int PlatilloId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int CantidadTotalSolicitada { get; set; }
        public decimal MontoTotalGenerado { get; set; }
    }

    public class ClienteHistorialModel
    {
        public ClienteModel Cliente { get; set; } = new();
        public int TotalEstadias { get; set; }
        public decimal TotalFacturadoAcumulado { get; set; }
        public List<ReservacionModel> Reservaciones { get; set; } = new();
    }

    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int? ClienteId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class LoginRequestModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseModel
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int? ClienteId { get; set; }
    }

    public class RegistroHuespedRequestModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = "Cedula";
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = "Costarricense";
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }

    public class CrearUsuarioRequestModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Rol { get; set; } = "Recepcionista";
        public int? ClienteId { get; set; }
    }
}
