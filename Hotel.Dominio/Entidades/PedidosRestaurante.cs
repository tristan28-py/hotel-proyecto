using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class PedidosRestaurante
{
    public int Id { get; set; }

    public int ReservacionId { get; set; }

    public DateTime FechaPedido { get; set; }

    public DateTime FechaHoraDeseada { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal RecargoServicio { get; set; }

    public decimal Total { get; set; }

    public bool EsRoomService { get; set; }

    public string? NumeroMesa { get; set; }

    public string? InstruccionesEspeciales { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Reservacione Reservacion { get; set; } = null!;
}
