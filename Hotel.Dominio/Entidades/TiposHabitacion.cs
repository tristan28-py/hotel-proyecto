using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class TiposHabitacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CapacidadAdultos { get; set; }

    public int CapacidadNinos { get; set; }

    public decimal PrecioBasePorNoche { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
