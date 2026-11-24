namespace Hotel.Dominio.Enums
{
    public static class EstadoHabitacion
    {
        public const string Disponible = "Disponible";
        public const string Reservada = "Reservada";
        public const string Ocupada = "Ocupada";
        public const string EnLimpieza = "EnLimpieza";
        public const string EnMantenimiento = "EnMantenimiento";
        public const string Bloqueada = "Bloqueada";

        public static readonly string[] Todos =
        [
            Disponible, Reservada, Ocupada, EnLimpieza, EnMantenimiento, Bloqueada
        ];

        public static bool PermiteReserva(string estado) =>
            estado is Disponible or Reservada or Ocupada or EnLimpieza;
    }

    public static class EstadoReservacion
    {
        public const string PendientePago = "PendientePago";
        public const string Confirmada = "Confirmada";
        public const string EnCurso = "EnCurso";
        public const string Completada = "Completada";
        public const string Cancelada = "Cancelada";

        public static readonly string[] Todos =
        [
            PendientePago, Confirmada, EnCurso, Completada, Cancelada
        ];

        public static readonly string[] ActivosParaTraslape =
        [
            PendientePago, Confirmada, EnCurso
        ];
    }

    public static class MetodoPagoConst
    {
        public const string Efectivo = "Efectivo";
        public const string TarjetaCredito = "TarjetaCredito";
        public const string TarjetaDebito = "TarjetaDebito";
        public const string TransferenciaBancaria = "TransferenciaBancaria";

        public static readonly string[] Todos =
        [
            Efectivo, TarjetaCredito, TarjetaDebito, TransferenciaBancaria
        ];
    }

    public static class EstadoPedidoConst
    {
        public const string Recibido = "Recibido";
        public const string EnCocina = "EnCocina";
        public const string EnCamino = "EnCamino";
        public const string Entregado = "Entregado";
        public const string Cancelado = "Cancelado";

        public static readonly string[] Todos =
        [
            Recibido, EnCocina, EnCamino, Entregado, Cancelado
        ];
    }

    public static class TipoDocumentoConst
    {
        public const string DNI = "DNI";
        public const string Pasaporte = "Pasaporte";
        public const string Cedula = "Cedula";

        public static readonly string[] Todos = [DNI, Pasaporte, Cedula];
    }

    public static class TipoComprobanteConst
    {
        public const string Recibo = "Recibo";
        public const string Factura = "Factura";

        public static readonly string[] Todos = [Recibo, Factura];
    }
}
