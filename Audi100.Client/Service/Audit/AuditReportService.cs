using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using Audi100.Models;
using Microsoft.JSInterop;

namespace Audi100.Services
{
    public class AuditReportService : IService<AuditReport, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/AuditReport";
        private string clientName => "Audi100.Server";
        
        public AuditReportService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<AuditReport> AddAsync(AuditReport entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuditReport>();
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

        public async Task<AuditReport> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<AuditReport>();
        }

        public async Task<IList<AuditReport>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<AuditReport>>();
        }

        public async Task<AuditReport> UpdateAsync(AuditReport entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.AuditReportId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuditReport>();
            return default;
        }

    }
}
