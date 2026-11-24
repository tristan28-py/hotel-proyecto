using Microsoft.AspNetCore.SignalR;

namespace Hotel.Api.Hubs
{
    public static class EventosTiempoReal
    {
        public const string DashboardActualizado = "DashboardActualizado";
        public const string HabitacionesActualizadas = "HabitacionesActualizadas";
        public const string ReservacionesActualizadas = "ReservacionesActualizadas";
        public const string RestauranteActualizado = "RestauranteActualizado";
    }

    public class HotelHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Conectado", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
    }

    public interface INotificadorTiempoReal
    {
        Task NotificarAsync(string evento, object? payload = null);
    }

    public class SignalRNotificador : INotificadorTiempoReal
    {
        private readonly IHubContext<HotelHub> _hubContext;

        public SignalRNotificador(IHubContext<HotelHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotificarAsync(string evento, object? payload = null)
        {
            await _hubContext.Clients.All.SendAsync(evento, payload ?? new { Fecha = DateTime.UtcNow });
        }
    }
}
