using System.Net.Http.Json;
using System.Text.Json;
using Hotel.Utilitario;

namespace Hotel.WindowsForms.Services
{
    public class HotelApiClient
    {
        private readonly HttpClient _http;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public string BaseUrl { get; private set; }

        public HotelApiClient(string baseUrl)
        {
            BaseUrl = baseUrl.TrimEnd('/');
            _http = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl + "/"),
                Timeout = TimeSpan.FromSeconds(25)
            };
        }

        public void ActualizarBaseUrl(string nuevaUrl)
        {
            BaseUrl = nuevaUrl.TrimEnd('/');
            _http.BaseAddress = new Uri(BaseUrl + "/");
        }

        public async Task<bool> VerificarSaludAsync()
        {
            try
            {
                var res = await _http.GetAsync("api/health");
                return res.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Result<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _http.GetAsync(endpoint.TrimStart('/'));
                return await DeserializarRespuestaAsync<T>(response);
            }
            catch (TaskCanceledException)
            {
                return Result<T>.Fail("Tiempo de espera agotado al conectar con el servidor.", 408);
            }
            catch (HttpRequestException ex)
            {
                return Result<T>.Fail($"No se pudo conectar con la API ({BaseUrl}): {ex.Message}", 503);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail($"Error inesperado: {ex.Message}", 500);
            }
        }

        public async Task<Result<T>> PostAsync<T>(string endpoint, object? body = null)
        {
            try
            {
                HttpResponseMessage response = body == null
                    ? await _http.PostAsync(endpoint.TrimStart('/'), null)
                    : await _http.PostAsJsonAsync(endpoint.TrimStart('/'), body, JsonOptions);
                return await DeserializarRespuestaAsync<T>(response);
            }
            catch (TaskCanceledException)
            {
                return Result<T>.Fail("Tiempo de espera agotado al enviar datos al servidor.", 408);
            }
            catch (HttpRequestException ex)
            {
                return Result<T>.Fail($"Error de red con la API ({BaseUrl}): {ex.Message}", 503);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail($"Error inesperado: {ex.Message}", 500);
            }
        }

        public async Task<Result<T>> PutAsync<T>(string endpoint, object body)
        {
            try
            {
                var response = await _http.PutAsJsonAsync(endpoint.TrimStart('/'), body, JsonOptions);
                return await DeserializarRespuestaAsync<T>(response);
            }
            catch (HttpRequestException ex)
            {
                return Result<T>.Fail($"Error de red con la API ({BaseUrl}): {ex.Message}", 503);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail($"Error inesperado: {ex.Message}", 500);
            }
        }

        public async Task<Result<T>> PatchAsync<T>(string endpoint)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Patch, endpoint.TrimStart('/'));
                var response = await _http.SendAsync(request);
                return await DeserializarRespuestaAsync<T>(response);
            }
            catch (HttpRequestException ex)
            {
                return Result<T>.Fail($"Error de red con la API ({BaseUrl}): {ex.Message}", 503);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail($"Error inesperado: {ex.Message}", 500);
            }
        }

        public async Task<Result<T>> DeleteAsync<T>(string endpoint)
        {
            try
            {
                var response = await _http.DeleteAsync(endpoint.TrimStart('/'));
                return await DeserializarRespuestaAsync<T>(response);
            }
            catch (HttpRequestException ex)
            {
                return Result<T>.Fail($"Error de red con la API ({BaseUrl}): {ex.Message}", 503);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail($"Error inesperado: {ex.Message}", 500);
            }
        }

        private static async Task<Result<T>> DeserializarRespuestaAsync<T>(HttpResponseMessage response)
        {
            string raw = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return response.IsSuccessStatusCode
                    ? Result<T>.Ok(default!, (int)response.StatusCode)
                    : Result<T>.Fail($"El servidor respondió con código HTTP {(int)response.StatusCode}.", (int)response.StatusCode);
            }

            try
            {
                var parsed = JsonSerializer.Deserialize<Result<T>>(raw, JsonOptions);
                if (parsed != null)
                    return parsed;
            }
            catch
            {
                // Fallback si la respuesta no tiene el wrapper Result<T>
            }

            return response.IsSuccessStatusCode
                ? Result<T>.Ok(default!, (int)response.StatusCode)
                : Result<T>.Fail($"Error HTTP {(int)response.StatusCode}: {raw}", (int)response.StatusCode);
        }
    }
}
