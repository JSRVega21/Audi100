using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class AuditReport : IRecordLogger
    {
        [Key]
        public int AuditReportId { get; set; }
        public string? ReportCode { get; set; }
        [Required(ErrorMessage = "Se debe ingresar el periodo")]
        public string? PeriodString { get; set; }
        public string? nomDepto { get; set; }
        public string? nomDivision { get; set; }
        public string? nomSeccion { get; set; }
        public string? nomCompleto { get; set; }
        public string? ReviewPriority { get; set; }
        public DateTime? ReviewdateOf { get; set; }
        public DateTime? ReviewdateAt { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la fecha de creación")]
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar el origen de la revisión")]
        public string? OriginOfTheReview { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar la clasificación de revisión")]
        public int? ClassificationId { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar el Bsc Indicador")]
        public int? BscId { get; set; }
        public string? Classification { get; set; }
        public string? Bsc { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la Description")]
        public string? ReportDescription { get; set; }
        [Required(ErrorMessage = "Se debe ingresar el titulo del Informe")]
        public string? ReportTitle { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la fecha del Informe")]
        public DateTime? ReportDate { get; set; }
        public decimal? Shortage { get; set; }
        public decimal? CrossShortage { get; set; }
        public decimal? Excess { get; set; }
        public decimal? CrossExcess { get; set; }
        public decimal? MissingInQ {  get; set; }
        public string? AuditorId1 { get; set; }
        public string? AuditorId2 { get; set; }
        public string? AuditorId3 { get; set; }
        public string? EmployeeId1 {  get; set; }
        public string? EmployeeId2 { get; set; }
        public string? EmployeeId3 { get; set; }
        public decimal? Hours { get; set; }
        public decimal? HoursInReviwe { get; set; }
        public decimal? VariationOfHours { get; set; }
        public string? AuditObservations { get; set; }
        public string DisplayName => $"Código del Informe: {ReportCode}, Titulo: {ReportTitle}, " +
            $"Prioridad: {ReviewPriority}, Centro de costo: {nomDepto}, {nomDivision}, {nomSeccion}";
        public string DisplayName2 => $"{ReportCode}, {nomDepto}, {nomDivision}, {nomSeccion}";
        public string DisplayName3 => $"Código del Informe:{ReportCode}, Prioridad:{ReviewPriority}, "+
            $" Centro de costo:{nomDepto}, {nomDivision}, {nomSeccion}";

        public RecordLog? RecordLog { get; set; } = new RecordLog();
        public void GenerateReportCode()
        {
            string currentMonthYear = DateTime.Now.ToString("MMyy");
            ReportCode = $"{currentMonthYear}-{AuditReportId}";
        }

    }
}

