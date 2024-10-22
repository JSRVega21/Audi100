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
    public class PhotoService : IPhotoService<Photo, int>
    {

        private readonly IHttpClientFactory _factory;

        private string Apiurl => "/api/Photo";
        private string clientName => "Audi100.Server";

        public PhotoService(IHttpClientFactory httpFactory)
        {
            _factory = httpFactory;
        }

        public async Task<Photo> AddAsync(Photo entity)
        {
            var response = await _factory.CreateClient(clientName).PostAsJsonAsync(Apiurl, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Photo>();
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

        public async Task<Photo> GetByKeyAsync(int key)
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/{key}");
            return await response.Content.ReadFromJsonAsync<Photo>();
        }

        public async Task<IList<Photo>> GetListAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync(Apiurl);
            return await response.Content.ReadFromJsonAsync<IList<Photo>>();
        }

        public async Task<Photo> UpdateAsync(Photo entity)
        {
            var response = await _factory.CreateClient(clientName).PutAsJsonAsync($"{Apiurl}/{entity.PhotoId}", entity);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Photo>();
            return default;
        }
        public async Task<IList<Photo>> GetAllAsync()
        {
            var response = await _factory.CreateClient(clientName).GetAsync("/api/Photo");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return JsonSerializer.Deserialize<IList<Photo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception($"Error al cargar los Informes: {response.StatusCode}");
            }
        }

        public async Task<IList<Photo>> GetAuditId(int auditFindingId)                   
        {
            var response = await _factory.CreateClient(clientName).GetAsync($"{Apiurl}/auditFinding/{auditFindingId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<Photo>>();
            }
            else
            {
                throw new Exception($"Error al cargar las fotos: {response.StatusCode}");
            }
        }
    }
}
