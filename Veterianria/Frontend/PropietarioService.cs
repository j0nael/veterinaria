using System.Net.Http.Json;
using Veterianria;
using Veterinaria.Aplication.DTOS;

namespace Veterinaria.Frontend
{
    public class PropietarioService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public PropietarioService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<PropietarioDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<PropietarioDto>>
                ($"{_config.ApiBaseUrl}/api/propietario");

            return result ?? new List<PropietarioDto>();
        }

        public async Task<PropietarioDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<PropietarioDto>
                ($"{_config.ApiBaseUrl}/api/propietario/{id}");
        }

        public async Task<bool> CreateAsync(PropietarioDto dto)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/propietario", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, PropietarioDto dto)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/propietario/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/propietario/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
