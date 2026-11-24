using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class Cliente
{
    public int Id { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? TelefonoEmergencia { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Preferencias { get; set; }

    public bool EsClienteFrecuente { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
