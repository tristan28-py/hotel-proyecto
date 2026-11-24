using System;
using System.Collections.Generic;

namespace Hotel.Dominio.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public int? ClienteId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
