namespace Hotel.Dominio.EntidadesTipadas
{
    public class ETTipoHabitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int CapacidadAdultos { get; set; }
        public int CapacidadNinos { get; set; }
        public decimal PrecioBasePorNoche { get; set; }
    }

    public class ETHabitacion
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

    public class ETCliente
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
    }

    public class ETReservacion
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
        public string Estado { get; set; } = "PendientePago";
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

    public class ETPago
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

    public class ETCategoriaPlatillo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }

    public class ETPlatillo
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

    public class ETDetallePedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PlatilloId { get; set; }
        public string? PlatilloNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class ETPedidoRestaurante
    {
        public int Id { get; set; }
        public int ReservacionId { get; set; }
        public string? CodigoReservacion { get; set; }
        public string? HabitacionNumero { get; set; }
        public string? ClienteNombre { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaHoraDeseada { get; set; }
        public string EstadoPedido { get; set; } = "Recibido";
        public decimal Subtotal { get; set; }
        public decimal RecargoServicio { get; set; }
        public decimal Total { get; set; }
        public bool EsRoomService { get; set; } = true;
        public string? NumeroMesa { get; set; }
        public string? InstruccionesEspeciales { get; set; }
        public List<ETDetallePedido> Detalles { get; set; } = new();
    }
}
