using System.Collections.Generic;
using System.Threading.Tasks;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public interface ISqlReportPrintRepository
    {
        Task<ReportPrintHeader> GetReportPrint(int? AuditPrintId = null);
    }
}
    