using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Audi100.Models;

namespace Audi100.Client
{
    public class SqlHomeService
    {
        private readonly HttpClient _httpClient;
        public SqlHomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AuditComplete>> GetAuditComplete(int AuditFindingId)
        {
            var query = $"api/SqlDataHome/GetAuditComplete?AuditFindingId={AuditFindingId}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<AuditComplete>>(query);
        }

    }
}

