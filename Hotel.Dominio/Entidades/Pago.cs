using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class Pago
{
    public int Id { get; set; }

    public int ReservacionId { get; set; }

    public decimal Monto { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime FechaPago { get; set; }

    public string? ReferenciaTransaccion { get; set; }

    public string TipoComprobante { get; set; } = null!;

    public string? NumeroComprobante { get; set; }

    public string? Notas { get; set; }

    public virtual Reservacione Reservacion { get; set; } = null!;
}
