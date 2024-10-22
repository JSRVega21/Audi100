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
    public class BscService : IService<Bsc, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/Bsc";
        private string clientName => "Audi100.Server";

        public BscService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<Bsc> AddAsync(Bsc entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Bsc>();
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

        public async Task<Bsc> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<Bsc>();
        }

        public async Task<IList<Bsc>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<Bsc>>();
        }

        public async Task<Bsc> UpdateAsync(Bsc entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.BscId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Bsc>();
            return default;
        }
        public async Task<IList<Bsc>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/Bsc");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); // Imprime el contenido para depuración
                return JsonSerializer.Deserialize<IList<Bsc>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }
    }
}
