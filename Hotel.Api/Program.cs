using System.Text.Json;
using Hotel.AccesoDatos.Contexto;
using Hotel.AccesoDatos.Implementaciones;
using Hotel.Api.Hubs;
using Hotel.Dominio.DTO;
using Hotel.Dominio.InterfazAD;
using Hotel.Dominio.InterfazLN;
using Hotel.LogicaNegocio.Implementaciones;
using Hotel.Utilitario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión externa (appsettings.json / Azure App Service Connection Strings / appsettings.Development.json)
string connectionString = builder.Configuration.GetConnectionString("HotelConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'HotelConnection'.");

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

// Inyección de dependencias (Arquitectura Limpia)
builder.Services.AddScoped<IUnidadTrabajoEF, UnidadTrabajoEF>();
builder.Services.AddScoped<ITipoHabitacionLN, TipoHabitacionLN>();
builder.Services.AddScoped<IHabitacionLN, HabitacionLN>();
builder.Services.AddScoped<IClienteLN, ClienteLN>();
builder.Services.AddScoped<IReservacionLN, ReservacionLN>();
builder.Services.AddScoped<IPagoLN, PagoLN>();
builder.Services.AddScoped<IRestauranteLN, RestauranteLN>();
builder.Services.AddScoped<IReporteLN, ReporteLN>();

builder.Services.AddSignalR();
builder.Services.AddSingleton<INotificadorTiempoReal, SignalRNotificador>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Hotel Management API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Manejador global de excepciones para respuestas claras en JSON
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var res = Result<object>.Fail("Ocurrió un error interno inesperado en el servidor.", 500);
        await context.Response.WriteAsync(JsonSerializer.Serialize(res));
    });
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Management API v1");
    c.RoutePrefix = "swagger";
});

app.UseCors("PermitirTodo");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<HotelHub>("/hubs/hotel");

app.Run();
