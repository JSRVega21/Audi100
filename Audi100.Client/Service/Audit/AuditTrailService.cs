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
    public class AuditTrailService : IService<AuditTrail, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/AuditTrail";
        private string clientName => "Audi100.Server";

        public AuditTrailService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }


        public async Task<AuditTrail> AddAsync(AuditTrail entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuditTrail>();
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

        public async Task<AuditTrail> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<AuditTrail>();
        }

        public async Task<IList<AuditTrail>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<AuditTrail>>();
        }

        public async Task<AuditTrail> UpdateAsync(AuditTrail entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.AuditTrailId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuditTrail>();
            return default;
        }

    }
}
