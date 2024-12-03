using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Audi100.Models;
using DevExpress.XtraPrinting.Native;
using SkiaSharp;

namespace Audi100.Client
{
    public class SqlService
    {
        private readonly HttpClient _httpClient;
        public SqlService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CostCenter>> GetCenterCostList(string nomDepto = null, string nomDivision = null, string nomSeccion = null, string nomCompleto = null)
        {
            var query = $"api/SqlData/GetCostCenter?nomDepto={nomDepto}&nomDivision={nomDivision}&nomSeccion={nomSeccion}&nomCompleto={nomCompleto}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenter>>(query);
        }

        public async Task<IEnumerable<CostCenter>> GetDivisiones(string nomDepto)
        {
            var query = $"api/SqlData/GetDivisiones?nomDepto={nomDepto}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenter>>(query);
        }

        public async Task<IEnumerable<CostCenter>> GetSecciones(string nomDepto, string nomDivision)
        {
            var query = $"api/SqlData/GetSecciones?nomDepto={nomDepto}&nomDivision={nomDivision}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenter>>(query);
        }

        public async Task<IEnumerable<CostCenter>> GetNombresCompleto(string nomDepto, string nomDivision, string nomSeccion)
        {
            var query = $"api/SqlData/GetNombresCompleto?nomDepto={nomDepto}&nomDivision={nomDivision}&nomSeccion={nomSeccion}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenter>>(query);
        }
        public async Task<IEnumerable<Employee>> GetAudit()
        {
            var query = $"api/SqlData/GetAudit";
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>(query);
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var query = $"api/SqlData/GetEmployee";
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>(query);
        }

        public async Task<IEnumerable<CostCenterUnit>> GetCostCenterUnit()
        {
            var query = $"api/SqlData/GetCostCenterUnit";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenterUnit>>(query);
        }

        public async Task<IEnumerable<CostCenterSeccion>> GetCostCenterSeccion()
        {
            var query = $"api/SqlData/GetCostCenterSeccion";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostCenterSeccion>>(query);
        }

        public async Task<IEnumerable<CostSeccion>> GetSeccion()
        {
            var query = $"api/SqlData/GetAudit";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostSeccion>>(query);
        }

        public async Task<IEnumerable<CostDivision>> GetDivision()
        {
            var query = $"api/SqlData/GetEmployee";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CostDivision>>(query);
        }

    }
}

