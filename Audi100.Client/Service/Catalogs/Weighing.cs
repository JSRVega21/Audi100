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
    public class WeighingService : IService<Weighing, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/Weighing";
        private string clientName => "Audi100.Server";

        public WeighingService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<Weighing> AddAsync(Weighing entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Weighing>();
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

        public async Task<Weighing> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<Weighing>();
        }

        public async Task<IList<Weighing>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<Weighing>>();
        }

        public async Task<Weighing> UpdateAsync(Weighing entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.WeighingId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Weighing>();
            return default;
        }
        public async Task<IList<Weighing>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/Weighing");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); // Imprime el contenido para depuración
                return JsonSerializer.Deserialize<IList<Weighing>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }
    }
}
