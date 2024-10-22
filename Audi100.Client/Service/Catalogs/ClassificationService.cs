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
    public class ClassificationService : IService<Classification, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/Classification";
        private string clientName => "Audi100.Server";

        public ClassificationService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<Classification> AddAsync(Classification entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Classification>();
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

        public async Task<Classification> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<Classification>();
        }

        public async Task<IList<Classification>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<Classification>>();
        }

        public async Task<Classification> UpdateAsync(Classification entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.ClassificationId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Classification>();
            return default;
        }
        public async Task<IList<Classification>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/Classification");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); // Imprime el contenido para depuración
                return JsonSerializer.Deserialize<IList<Classification>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }
    }
}
