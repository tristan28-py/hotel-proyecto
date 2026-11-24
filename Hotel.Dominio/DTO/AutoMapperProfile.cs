using AutoMapper;
using Hotel.Dominio.Entidades;
using Hotel.Dominio.EntidadesTipadas;

namespace Hotel.Dominio.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TiposHabitacion, ETTipoHabitacion>().ReverseMap();

            CreateMap<Habitacione, ETHabitacion>()
                .ForMember(d => d.TipoHabitacionNombre, o => o.MapFrom(s => s.TipoHabitacion != null ? s.TipoHabitacion.Nombre : null))
                .ForMember(d => d.CapacidadAdultos, o => o.MapFrom(s => s.TipoHabitacion != null ? s.TipoHabitacion.CapacidadAdultos : 0))
                .ForMember(d => d.CapacidadNinos, o => o.MapFrom(s => s.TipoHabitacion != null ? s.TipoHabitacion.CapacidadNinos : 0))
                .ForMember(d => d.PrecioBasePorNoche, o => o.MapFrom(s => s.TipoHabitacion != null ? s.TipoHabitacion.PrecioBasePorNoche : 0m));

            CreateMap<ETHabitacion, Habitacione>()
                .ForMember(d => d.TipoHabitacion, o => o.Ignore())
                .ForMember(d => d.Reservaciones, o => o.Ignore());

            CreateMap<Cliente, ETCliente>().ReverseMap()
                .ForMember(d => d.Reservaciones, o => o.Ignore());

            CreateMap<Reservacione, ETReservacion>()
                .ForMember(d => d.ClienteNombreCompleto, o => o.MapFrom(s => s.Cliente != null ? $"{s.Cliente.Nombres} {s.Cliente.Apellidos}" : null))
                .ForMember(d => d.ClienteDocumento, o => o.MapFrom(s => s.Cliente != null ? $"{s.Cliente.TipoDocumento}: {s.Cliente.NumeroDocumento}" : null))
                .ForMember(d => d.HabitacionNumero, o => o.MapFrom(s => s.Habitacion != null ? s.Habitacion.Numero : null))
                .ForMember(d => d.TipoHabitacionNombre, o => o.MapFrom(s => s.Habitacion != null && s.Habitacion.TipoHabitacion != null ? s.Habitacion.TipoHabitacion.Nombre : null));

            CreateMap<ETReservacion, Reservacione>()
                .ForMember(d => d.Cliente, o => o.Ignore())
                .ForMember(d => d.Habitacion, o => o.Ignore())
                .ForMember(d => d.Pagos, o => o.Ignore())
                .ForMember(d => d.PedidosRestaurantes, o => o.Ignore())
                .ForMember(d => d.RowVersion, o => o.Ignore());

            CreateMap<Pago, ETPago>()
                .ForMember(d => d.CodigoReservacion, o => o.MapFrom(s => s.Reservacion != null ? s.Reservacion.Codigo : null));

            CreateMap<ETPago, Pago>()
                .ForMember(d => d.Reservacion, o => o.Ignore());

            CreateMap<CategoriasPlatillo, ETCategoriaPlatillo>().ReverseMap()
                .ForMember(d => d.Platillos, o => o.Ignore());

            CreateMap<Platillo, ETPlatillo>()
                .ForMember(d => d.CategoriaNombre, o => o.MapFrom(s => s.Categoria != null ? s.Categoria.Nombre : null));

            CreateMap<ETPlatillo, Platillo>()
                .ForMember(d => d.Categoria, o => o.Ignore())
                .ForMember(d => d.DetallePedidos, o => o.Ignore());

            CreateMap<DetallePedido, ETDetallePedido>()
                .ForMember(d => d.PlatilloNombre, o => o.MapFrom(s => s.Platillo != null ? s.Platillo.Nombre : null));

            CreateMap<PedidosRestaurante, ETPedidoRestaurante>()
                .ForMember(d => d.CodigoReservacion, o => o.MapFrom(s => s.Reservacion != null ? s.Reservacion.Codigo : null))
                .ForMember(d => d.HabitacionNumero, o => o.MapFrom(s => s.Reservacion != null && s.Reservacion.Habitacion != null ? s.Reservacion.Habitacion.Numero : null))
                .ForMember(d => d.ClienteNombre, o => o.MapFrom(s => s.Reservacion != null && s.Reservacion.Cliente != null ? $"{s.Reservacion.Cliente.Nombres} {s.Reservacion.Cliente.Apellidos}" : null))
                .ForMember(d => d.Detalles, o => o.MapFrom(s => s.DetallePedidos));
        }
    }
}
