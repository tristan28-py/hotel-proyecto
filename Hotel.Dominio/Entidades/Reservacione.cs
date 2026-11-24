using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class Reservacione
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int ClienteId { get; set; }

    public int HabitacionId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public TimeOnly? HoraLlegadaPactada { get; set; }

    public string Estado { get; set; } = null!;

    public int CantidadHuespedes { get; set; }

    public decimal SubtotalHospedaje { get; set; }

    public decimal RecargoTemporada { get; set; }

    public decimal RecargoPersonasExtra { get; set; }

    public decimal DescuentoCliente { get; set; }

    public decimal Impuestos { get; set; }

    public decimal AjustesCheckOut { get; set; }

    public decimal CostoTotal { get; set; }

    public decimal MontoAnticipoRequerido { get; set; }

    public DateTime? FechaCheckInReal { get; set; }

    public DateTime? FechaCheckOutReal { get; set; }

    public string? Acompanantes { get; set; }

    public string? LlavesAsignadas { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Habitacione Habitacion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PedidosRestaurante> PedidosRestaurantes { get; set; } = new List<PedidosRestaurante>();
}
