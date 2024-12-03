using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Audi100.Models
{
    public class ReportPrintHeader
    {
        public string AuditPrintId { get; set; }
        public DateTime? DateI { get; set; }

        // Propiedades calculadas a partir de DateI
        public string DateITime => DateI?.ToString("HH:mm");
        public string DateIYear => DateI?.ToString("yyyy");
        public string DateIDay => DateI?.ToString("dd/MM/yyyy");
        public string DateDayIText => DateI?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        public DateTime? DateE { get; set; }
        // Propiedades calculadas a partir de DateE
        public string DateETime => DateE?.ToString("HH:mm");
        public string DateEYear => DateE?.ToString("yyyy");
        public string DateEDay => DateE?.ToString("dd/MM/yyyy");
        public string DateEDayText => DateE?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        public string ReportCode { get; set; }
        public string CostSeccionPrint { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
        public string Others { get; set; }
        public string AuditorId1_Print { get; set; }
        public string AuditorId2_Print { get; set; }
        public string AuditorId3_Print { get; set; }
        public string EmployeeId1_Print { get; set; }
        public string EmployeeId2_Print { get; set; }
        public string EmployeeId3_Print { get; set; }
        public string OtherEmployee { get; set; }
        public string OtherEmployee2 { get; set; }
        public string OtherEmployee3 { get; set; }
        public string OtherEmployee4 { get; set; }
        public string Line { get; set; }
        public string SubSeccion { get; set; }
        public string AuditReportId { get; set; }
        public string ReportTitle { get; set; }
        public string NomDepto { get; set; }
        public string NomDivision { get; set; }
        public string NomSeccion { get; set; }
        public string NomCompleto { get; set; }
        public DateTime? ReviewdateOf { get; set; }
        public string ReviewdateOfTime => ReviewdateOf?.ToString("HH:mm");
        public string ReviewdateOfYear => ReviewdateOf?.ToString("yyyy");
        public string ReviewdateOfDay => ReviewdateOf?.ToString("dd/MM/yyyy");
        public string ReviewdateOfDayText => ReviewdateOf?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        public DateTime? ReviewdateAt { get; set; }
        public string ReviewdateAtTime => ReviewdateAt?.ToString("HH:mm");
        public string ReviewdateAtYear => ReviewdateAt?.ToString("yyyy");
        public string ReviewdateAtDay => ReviewdateAt?.ToString("dd/MM/yyyy");
        public string ReviewdateAtDayText => ReviewdateAt?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        public string AuditorId1_Report { get; set; }
        public string AuditorId2_Report { get; set; }
        public string AuditorId3_Report { get; set; }
        public string EmployeeId1_Report { get; set; }
        public string EmployeeId2_Report { get; set; }
        public string EmployeeId3_Report { get; set; }

        //Para el acta pequeña

        public string Graduate1  { get; set;}
        public string TextGraduate1 { get; set;}
        public string Graduate2 { get; set;}
        public string TextGraduate2 { get; set;}
        public string Graduate3 { get; set;}
        public string TextGraduate3 { get; set;}
        public string Direct { get; set;}
        public string TextDirect { get; set;}
        public string DateGra { get; set;}
        public string DateGraTime => DateI?.ToString("HH:mm");
        public string DateGraYear => DateI?.ToString("yyyy");
        public string DateGraDay => DateI?.ToString("dd/MM/yyyy");
        public string DateGraDayText => DateI?.ToString("dddd dd 'de' MMMM 'del' yyyy");
        public List<ReportPrintFinding> Findings { get; set; }
    }

    public class ReportPrintFinding
    {
        public string AuditFindingId { get; set; }
        public string FindingTitle { get; set; }
        public string NumberOfFindings { get; set; }
        public DateTime? DateCreate { get; set; }
        public string DateCreateYear => DateCreate?.ToString("dd/MM/yyyy");
        public string DateCreateDay => DateCreate?.ToString("dd/MM/yyyy");
        public string FindLevel { get; set; }
        public string ConditionAudit { get; set; }
        public string CriterionAudit { get; set; }
        public string BasisAudit { get; set; }
        public string CauseAudit { get; set; }
        public string RequirementOfAudit { get; set; }
        public string PlanOfActionAudit { get; set; }
        public string EffectAudit { get; set; }
        public string AddeedDetailFindingAudit { get; set; }
        public string DetailInternalFindingAudit { get; set; }
        public string AuditFindingCostCenter { get; set; }
        public string AuditFindingDepto { get; set; }
        public string AuditFindingSeccion { get; set; }
        public string AuditorFinding { get; set; }
        public string EmployeeFinding { get; set; } 
        public string EmployeeFinding2 { get; set; }

    }


}

