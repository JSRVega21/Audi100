using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi100.Models
{    
    public class AuditFinding : IRecordLogger
    {
        [Key]
        public int AuditFindingId { get; set; }
        public int AuditReportId { get; set; }
        public string? DataReport { get; set; }
        [Required(ErrorMessage = "Se debe ingresar un titulo de hallazgo")]
        public string? FindingTitle { get; set; }
        [Required(ErrorMessage = "Se debe ingresar el número de hallazgo")]
        public decimal? NumberOfFindings { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la fecha")]
        public DateTime? DateCreate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Se debe seleccionar el nivel de hallazgo")]
        public string? FindLevel { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar una ponderación")]
        public int? WeightingClassificationId { get; set; }
        public string? WeightingClassification { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar un hallazgo con nombre corto")]
        public int? FindShortNameId { get; set; }
        public string? FindShortName { get; set; }
        public decimal? PositiveWeighting { get; set; } 
        public decimal? NegativeWeighting { get; set; } 
        public decimal? PositiveRisk { get; set; }
        public decimal? NegativeRisk { get; set; }
        public string? ReviewedBy { get; set; } 
        public string? AuthorizedForReport { get; set; } 
        public string? WorkExecutedBy { get; set; }
        public string? ConditionAudit { get; set; }
        public string? CriterionAudit { get; set; }
        public string? BasisAudit { get; set; }
        public string? CauseAudit { get; set; }
        public string? EffectAudit { get; set; }
        public string? RequirementOfAudit { get; set; }
        public string? PlanOfActionAudit { get; set; }                             
        [Required(ErrorMessage = "Se debe colocar el detalle del hallazgo")]
        public string? DetailFindingAudit { get; set; }
        public int? AuditStatus { get; set; }
        public string? AuditStatusText { get; set; }
        [Required(ErrorMessage = "Se debe colocar el centro de costo")]
        public string? AuditFindingCostCenter { get; set; }
        [Required(ErrorMessage = "Se debe colocar el departamento")]
        public string? AuditFindingDepto { get; set; }
        [Required(ErrorMessage = "Se debe colocar la sección")]
        public string? AuditFindingSeccion { get; set; }
        [Required(ErrorMessage = "Se seleccionar un Auditor")]
        public string? AuditorFinding { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar un Responsable")]
        public string? EmployeeFinding { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar un Responsable")]
        public string? EmployeeFinding2 { get; set; }
        public RecordLog? RecordLog { get; set; } = new RecordLog();

    }
}