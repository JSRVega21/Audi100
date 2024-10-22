using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audi100.Server.Repository
{
    public interface ISqlHomeRepository
    {
        Task<IEnumerable<AuditComplete>> GetAuditComplete(int? AuditFindingId = null);
    }
}
