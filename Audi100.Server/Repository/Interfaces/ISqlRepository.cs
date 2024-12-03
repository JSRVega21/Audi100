using Audi100.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audi100.Server.Repository
{
    public interface ISqlRepository
    {
        Task<IEnumerable<CostCenter>> GetCenterCostList(string nomDepto = null, string nomDivision = null, string nomSeccion = null, string nomCompleto = null);
        Task<IEnumerable<CostCenterUnit>> GetCostCenterUnit();
        Task<IEnumerable<CostCenterSeccion>> GetCostCenterSeccion();
        Task<IEnumerable<CostDivision>> GetDivision();
        Task<IEnumerable<CostSeccion>> GetSeccion();
        Task<IEnumerable<Employee>> GetAuditors();
        Task<IEnumerable<Employee>> GetEmployee();
    }
}
 