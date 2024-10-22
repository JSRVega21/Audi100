using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using Audi100.Models;

namespace Audi100.Services
{
    public class ShortFService : IService<ShortF, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/ShortF";
        private string clientName => "Audi100.Server";

        public ShortFService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<ShortF> AddAsync(ShortF entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ShortF>();
            }
            else
            {
                throw new Exception($"Error al agregar el Informe: {response.StatusCode}");
            }
        }

        public async Task DeleteAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).DeleteAsync($"{Apiurl}/{key}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar el Informe: {response.StatusCode}");
            }
        }

        public async Task<ShortF> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<ShortF>();
        }

        public async Task<IList<ShortF>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<ShortF>>();
        }

        public async Task<ShortF> UpdateAsync(ShortF entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.ShortFId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ShortF>();
            return default;
        }
        public async Task<IList<ShortF>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/ShortF");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); // Imprime el contenido para depuración
                return JsonSerializer.Deserialize<IList<ShortF>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }
    }
}
