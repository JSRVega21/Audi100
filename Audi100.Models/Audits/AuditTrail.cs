using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class AuditTrail : IRecordLogger
    {
        [Key]
        public int AuditTrailId { get; set; }
        public int? AuditFindingId { get; set; }
        public int? AuditReportId { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la fecha")]
        public DateTime? DateCreate { get; set; }
        public decimal? Line { get; set; }
        public string? DisplayName { get; set; }
        public string? ReportCode { get; set; }
        public string? nomDepto { get; set; }
        public string? nomDivision { get; set; }
        public string? nomSeccion { get; set; }
        public decimal? NumberOfFindings { get; set; }
        public string? DetailFindingAudit { get; set; }
        public string? FindLevel { get; set; }
        public string? WeightingClassification { get; set; }
        public string? FindShortName { get; set; }
        public decimal? PositiveWeighting { get; set; }
        public decimal? NegativeWeighting { get; set; }
        public decimal? PositiveRisk { get; set; }
        public decimal? NegativeRisk { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar la división")]
        public string? AuditTrailDepto { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar la sección")]
        public string? AuditTrailSeccion { get; set; }
        public string? AuditTrailWeighting { get; set; }
        [Required(ErrorMessage = "Se debe ingresar el seguimiento del hallazgo")]
        public string? AuditTrailFollow { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar el estado del seguimiento")]
        public int? AuditTrailStatus { get; set; }
        public RecordLog? RecordLog { get; set; } = new RecordLog();
    }
}
