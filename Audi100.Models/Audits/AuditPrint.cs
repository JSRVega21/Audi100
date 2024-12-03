using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi100.Models
{
    public class AuditPrint : IRecordLogger
    {
        public int AuditPrintId { get; set; }
        public int AuditReportId { get; set; }
        [Required(ErrorMessage = "Se debe ingresar la subsección")]
        public string? SubSeccion { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar la sección de costo")]
        public string? CostSeccionPrint { get; set; }
        public string? ReportCode { get; set; }
        public string? DisplayName { get; set; }
        public decimal? Line { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar la fecha inicial")]
        public DateTime? DateI { get; set; }
        public string DateTime => DateI?.ToString("HH:mm");
        public string DateYear => DateI?.ToString("yyyy");
        public string DateDay => DateI?.ToString("dd/MM/yyyy");
        public string DateDayText => DateI?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        [Required(ErrorMessage = "Se debe seleccionar la fecha final")]
        public DateTime? DateE { get; set; }
        public string? PersonalPart { get; set; }
        public string? Part1 { get; set; }
        public string? Part2 { get; set; }
        public string? Part3 { get; set; }
        public string? Part4 { get; set; }
        public string? Others { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar el auditor a cargo")]
        public string? AuditorId1 { get; set; }
        public string? AuditorId2 { get; set; }
        public string? AuditorId3 { get; set; }
        [Required(ErrorMessage = "Se debe seleccionar el administrador")]
        public string? EmployeeId1 { get; set; }
        public string? EmployeeId2 { get; set; }
        public string? EmployeeId3 { get; set; }
        public string? OtherEmployee { get; set; }
        public string? OtherEmployee2 { get; set; }
        public string? OtherEmployee3 { get; set; }
        public string? OtherEmployee4 { get; set; }


        //campos para el otro reporte
        public string? Graduate1 { get; set; }
        public string? TextGraduate1 { get; set; }
        public string? Graduate2 { get; set; }
        public string? TextGraduate2 { get; set; }
        public string? Graduate3 { get; set; }
        public string? TextGraduate3 { get; set; }
        public string? Direct { get; set; }
        public string? TextDirect { get; set; }
        public DateTime? DateGra { get; set; }
        public string DateGraTime => DateI?.ToString("HH:mm");
        public string DateGraYear => DateI?.ToString("yyyy");
        public string DateGraDay => DateI?.ToString("dd/MM/yyyy");
        public string DateGraDayText => DateI?.ToString("dddd dd 'de' MMMM 'del' yyyy");

        public RecordLog? RecordLog { get; set; } = new RecordLog();

    }
}
