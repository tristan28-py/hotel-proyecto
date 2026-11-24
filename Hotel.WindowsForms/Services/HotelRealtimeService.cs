using Microsoft.AspNetCore.SignalR.Client;

namespace Hotel.WindowsForms.Services
{
    public class HotelRealtimeService : IAsyncDisposable
    {
        private HubConnection? _connection;

        public bool EstaConectado => _connection?.State == HubConnectionState.Connected;

        public event Action<bool>? EstadoConexionCambiado;
        public event Action? DashboardActualizado;
        public event Action? HabitacionesActualizadas;
        public event Action? ReservacionesActualizadas;
        public event Action? RestauranteActualizado;

        public async Task ConectarAsync(string apiBaseUrl)
        {
            await DesconectarAsync();

            string hubUrl = apiBaseUrl.TrimEnd('/') + "/hubs/hotel";
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<object>("DashboardActualizado", _ => DashboardActualizado?.Invoke());
            _connection.On<object>("HabitacionesActualizadas", _ => HabitacionesActualizadas?.Invoke());
            _connection.On<object>("ReservacionesActualizadas", _ => ReservacionesActualizadas?.Invoke());
            _connection.On<object>("RestauranteActualizado", _ => RestauranteActualizado?.Invoke());

            _connection.Reconnecting += _ =>
            {
                EstadoConexionCambiado?.Invoke(false);
                return Task.CompletedTask;
            };
            _connection.Reconnected += _ =>
            {
                EstadoConexionCambiado?.Invoke(true);
                return Task.CompletedTask;
            };
            _connection.Closed += _ =>
            {
                EstadoConexionCambiado?.Invoke(false);
                return Task.CompletedTask;
            };

            try
            {
                await _connection.StartAsync();
                EstadoConexionCambiado?.Invoke(true);
            }
            catch
            {
                EstadoConexionCambiado?.Invoke(false);
            }
        }

        public async Task DesconectarAsync()
        {
            if (_connection != null)
            {
                try { await _connection.StopAsync(); } catch { }
                try { await _connection.DisposeAsync(); } catch { }
                _connection = null;
                EstadoConexionCambiado?.Invoke(false);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DesconectarAsync();
        }
    }
}
