using System.Net.Http.Json;
using TiendaOnline.WASM.Models;

namespace TiendaOnline.WASM.Services
{
    public class ClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _http.GetFromJsonAsync<List<Cliente>>("api/Clientes") ?? new List<Cliente>();
        }

        public async Task<Cliente?> ObtenerClientePorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Cliente>($"api/Clientes/{id}");
        }

        public async Task<bool> CrearClienteAsync(Cliente cliente)
        {
            var respuesta = await _http.PostAsJsonAsync("api/Clientes", cliente);
            return respuesta.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            var respuesta = await _http.PutAsJsonAsync($"api/Clientes/{cliente.IdCliente}", cliente);
            return respuesta.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var respuesta = await _http.DeleteAsync($"api/Clientes/{id}");
            return respuesta.IsSuccessStatusCode;
        }
    }
}