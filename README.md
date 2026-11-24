# Sistema de Reservaciones y Gestión Hotelera

Proyecto de **Programación III** implementado bajo **Arquitectura Limpia** en **.NET 10**, **Entity Framework Core**, **SQL Server / Azure SQL**, **ASP.NET Core Web API + SignalR** (tiempo real multi-estación) y **Windows Forms**.

## Estructura de la Solución
- `Database/`: Scripts SQL (`01_crear_base_datos_local.sql` y `02_hotel_db_tablas_y_datos.sql`).
- `Hotel.Utilitario`: Clases transversales (`Result<T>`).
- `Hotel.Dominio`: Entidades, DTOs tipados (`ET*`), perfiles AutoMapper, contratos `InterfazAD` e `InterfazLN`, reglas puras de negocio y excepciones/enums.
- `Hotel.AccesoDatos`: `HotelContext` (EF Core Database-First), `RepositorioAD`, `UnidadTrabajoEF` con manejo transaccional y consultas `IQueryable`.
- `Hotel.LogicaNegocio`: Implementación de casos de uso, validaciones de traslape, cálculo de tarifas, transacciones y pagos.
- `Hotel.Api`: API RESTful, Swagger/OpenAPI y `HotelHub` (SignalR) para sincronización en tiempo real entre recepciones y restaurante.
- `Hotel.WindowsForms`: Cliente de escritorio Windows Forms (patrón MVC + `HttpClient` + cliente SignalR).
