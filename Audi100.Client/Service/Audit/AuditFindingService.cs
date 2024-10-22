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
    public class AuditFindingService : IService<AuditFinding, int>
    {
        
        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/AuditFinding";
        private string clientName => "Audi100.Server";

        public AuditFindingService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<AuditFinding> AddAsync(AuditFinding entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuditFinding>();
            }
            else
            {
                throw new Exception($"Error al agregar el informe: {response.StatusCode}");
            }
        }

        public async Task DeleteAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).DeleteAsync($"{Apiurl}/{key}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar el informe: {response.StatusCode}");
            }
        }

        public async Task<AuditFinding> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<AuditFinding>();
        }

        public async Task<IList<AuditFinding>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<AuditFinding>>();
        }

        public async Task<AuditFinding> UpdateAsync(AuditFinding entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.AuditFindingId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuditFinding>();
            return default;
        }
        public async Task<IList<AuditReport>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/AuditReport");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); // Imprime el contenido para depuración
                return JsonSerializer.Deserialize<IList<AuditReport>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los informes: {response.StatusCode}");
            }
        }
    }
}
