using System;
using System.Collections.Generic;
using Hotel.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Hotel.AccesoDatos.Contexto;

public partial class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasPlatillo> CategoriasPlatillos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PedidosRestaurante> PedidosRestaurantes { get; set; }

    public virtual DbSet<Platillo> Platillos { get; set; }

    public virtual DbSet<Reservacione> Reservaciones { get; set; }

    public virtual DbSet<TiposHabitacion> TiposHabitacions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasPlatillo>(entity =>
        {
            entity.ToTable("CategoriasPlatillo");

            entity.HasIndex(e => e.Nombre, "UQ_CategoriasPlatillo_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true, "DF_CategoriasPlatillo_Activo");
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasIndex(e => new { e.TipoDocumento, e.NumeroDocumento }, "UQ_Clientes_Documento").IsUnique();

            entity.HasIndex(e => e.Email, "UQ_Clientes_Email").IsUnique();

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysutcdatetime())", "DF_Clientes_FechaRegistro");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(60)
                .HasDefaultValue("Costarricense", "DF_Clientes_Nacionalidad");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(30);
            entity.Property(e => e.Preferencias).HasMaxLength(250);
            entity.Property(e => e.Telefono).HasMaxLength(30);
            entity.Property(e => e.TelefonoEmergencia).HasMaxLength(30);
            entity.Property(e => e.TipoDocumento).HasMaxLength(20);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Pedidos");

            entity.HasOne(d => d.Platillo).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PlatilloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Platillos");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasIndex(e => e.Numero, "UQ_Habitaciones_Numero").IsUnique();

            entity.Property(e => e.Activa).HasDefaultValue(true, "DF_Habitaciones_Activa");
            entity.Property(e => e.AmenidadesAdicionales).HasMaxLength(250);
            entity.Property(e => e.EstadoOperativo)
                .HasMaxLength(30)
                .HasDefaultValue("Disponible", "DF_Habitaciones_Estado");
            entity.Property(e => e.Numero).HasMaxLength(10);
            entity.Property(e => e.TieneWifi6).HasDefaultValue(true, "DF_Habitaciones_Wifi6");

            entity.HasOne(d => d.TipoHabitacion).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.TipoHabitacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitaciones_TiposHabitacion");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.Property(e => e.FechaPago).HasDefaultValueSql("(sysutcdatetime())", "DF_Pagos_FechaPago");
            entity.Property(e => e.MetodoPago).HasMaxLength(40);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Notas).HasMaxLength(250);
            entity.Property(e => e.NumeroComprobante).HasMaxLength(40);
            entity.Property(e => e.ReferenciaTransaccion).HasMaxLength(100);
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .HasDefaultValue("Recibo", "DF_Pagos_TipoComp");

            entity.HasOne(d => d.Reservacion).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Reservaciones");
        });

        modelBuilder.Entity<PedidosRestaurante>(entity =>
        {
            entity.ToTable("PedidosRestaurante");

            entity.Property(e => e.EsRoomService).HasDefaultValue(true, "DF_PedidosRestaurante_RoomService");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(30)
                .HasDefaultValue("Recibido", "DF_PedidosRestaurante_Estado");
            entity.Property(e => e.FechaHoraDeseada).HasDefaultValueSql("(sysutcdatetime())", "DF_PedidosRestaurante_FechaDeseada");
            entity.Property(e => e.FechaPedido).HasDefaultValueSql("(sysutcdatetime())", "DF_PedidosRestaurante_Fecha");
            entity.Property(e => e.InstruccionesEspeciales).HasMaxLength(500);
            entity.Property(e => e.NumeroMesa).HasMaxLength(20);
            entity.Property(e => e.RecargoServicio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Reservacion).WithMany(p => p.PedidosRestaurantes)
                .HasForeignKey(d => d.ReservacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidosRestaurante_Reservaciones");
        });

        modelBuilder.Entity<Platillo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true, "DF_Platillos_Activo");
            entity.Property(e => e.Descripcion).HasMaxLength(350);
            entity.Property(e => e.Disponible).HasDefaultValue(true, "DF_Platillos_Disponible");
            entity.Property(e => e.ImagenUrl).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Platillos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Platillos_CategoriasPlatillo");
        });

        modelBuilder.Entity<Reservacione>(entity =>
        {
            entity.HasIndex(e => new { e.HabitacionId, e.Estado, e.FechaInicio, e.FechaFin }, "IX_Reservaciones_Habitacion_Fechas");

            entity.HasIndex(e => e.Codigo, "UQ_Reservaciones_Codigo").IsUnique();

            entity.Property(e => e.Acompanantes).HasMaxLength(500);
            entity.Property(e => e.AjustesCheckOut).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Codigo).HasMaxLength(30);
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoCliente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValue("PendientePago", "DF_Reservaciones_Estado");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())", "DF_Reservaciones_FechaCreacion");
            entity.Property(e => e.Impuestos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LlavesAsignadas).HasMaxLength(100);
            entity.Property(e => e.MontoAnticipoRequerido).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.RecargoPersonasExtra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RecargoTemporada).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SubtotalHospedaje).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservaciones_Clientes");

            entity.HasOne(d => d.Habitacion).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.HabitacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservaciones_Habitaciones");
        });

        modelBuilder.Entity<TiposHabitacion>(entity =>
        {
            entity.ToTable("TiposHabitacion");

            entity.HasIndex(e => e.Nombre, "UQ_TiposHabitacion_Nombre").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.PrecioBasePorNoche).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
