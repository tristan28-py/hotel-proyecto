using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class Habitacione
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public int Piso { get; set; }

    public int TipoHabitacionId { get; set; }

    public string EstadoOperativo { get; set; } = null!;

    public bool TieneJacuzzi { get; set; }

    public bool TieneVistaMar { get; set; }

    public bool TieneWifi6 { get; set; }

    public bool TieneFrigobar { get; set; }

    public string? AmenidadesAdicionales { get; set; }

    public bool Activa { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();

    public virtual TiposHabitacion TipoHabitacion { get; set; } = null!;
}
