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
    public class AuditPrintService : IService<AuditPrint, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/AuditPrint";
        private string clientName => "Audi100.Server";

        public AuditPrintService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<AuditPrint> AddAsync(AuditPrint entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuditPrint>();
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

        public async Task<AuditPrint> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<AuditPrint>();
        }

        public async Task<IList<AuditPrint>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<AuditPrint>>();
        }

        public async Task<AuditPrint> UpdateAsync(AuditPrint entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.AuditPrintId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuditPrint>();
            return default;
        }
        public async Task<IList<AuditReport>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/AuditReport");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); 
                return JsonSerializer.Deserialize<IList<AuditReport>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }
    }
}
