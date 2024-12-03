 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class AuditComplete
    {
        public int? AuditFindingId { get; set; }
        public int? AuditReportId { get; set; }
        public string? ReportCode { get; set; }
        public string? nomDepto { get; set; }
        public string? nomDivision { get; set; }
        public string? nomSeccion { get; set; }
        public string? AuditFindingCostCenter { get; set; }
        public string? AuditFindingDepto { get; set; }
        public string? AuditFindingSeccion { get; set; }
        public decimal? NumberOfFindings { get; set; }
        public string? DetailFindingAudit { get; set; }
        public string? FindLevel { get; set; }
        public string? WeightingClassification { get; set; }
        public string? FindShortName { get; set; }
        public decimal? PositiveWeighting { get; set; }
        public decimal? NegativeWeighting { get; set; }
        public decimal? PositiveRisk { get; set; }
        public decimal? NegativeRisk { get; set; }
        public string? AuditorFinding { get; set; }
        public string? EmployeeFinding { get; set; }
        public string? EmployeeFinding2 { get; set; }

        public string DisplayName => $"Código del Informe: {ReportCode},  Centro de costo: {nomDepto}, {nomDivision}, {nomSeccion} " +
            $" Número de hallazgo del Informe: {NumberOfFindings},";
    }

}
