//// Esto se debe crear como vista en la base de datos!
//USE [Auditoria]
//GO
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER VIEW [dbo].[V_AuditReportPrint] AS
//SELECT 
//    T0.AuditPrintId, 
//    T0.DateI, 
//	T0.DateE,
//    T0.ReportCode, 
//    T0.CostSeccionPrint, 
//    T0.Part1, 
//    T0.Part2,
//    T0.Part3, 
//	T0.Others,
//    T0.AuditorId1 AS AuditorId1_Print, 
//    T0.AuditorId2 AS AuditorId2_Print, 
//    T0.AuditorId3 AS AuditorId3_Print, 
//    T0.EmployeeId1 AS EmployeeId1_Print,
//    T0.EmployeeId2 AS EmployeeId2_Print, 
//    T0.EmployeeId3 AS EmployeeId3_Print, 
//    T0.OtherEmployee, 
//    T0.OtherEmployee2,
//    T0.OtherEmployee3, 
//    T0.OtherEmployee4, 
//    T0.Line, 
//    T0.SubSeccion,
//	T0.Graduate1,
//	T0.TextGraduate1,
//	T0.Graduate2,
//	T0.TextGraduate2,
//	T0.Graduate3,
//	T0.TextGraduate3,
//	T0.Direct,
//	T0.TextDirect,
//	T0.DateGra,


//    T1.AuditReportId, 
//    T1.ReportTitle, 
//    T1.nomDepto, 
//    T1.nomDivision, 
//    T1.nomSeccion, 
//    T1.nomCompleto,
//	T1.ReviewdateOf,
//	T1.ReviewdateAt,
//    T1.AuditorId1 AS AuditorId1_Report, 
//    T1.AuditorId2 AS AuditorId2_Report, 
//    T1.AuditorId3 AS AuditorId3_Report, 
//    T1.EmployeeId1 AS EmployeeId1_Report, 
//    T1.EmployeeId2 AS EmployeeId2_Report, 
//    T1.EmployeeId3 AS EmployeeId3_Report,

//    T2.AuditFindingId, 
//    T2.FindingTitle,
//	T2.NumberOfFindings,
//	T2.DateCreate, 
//	T2.FindLevel,
//    T2.ConditionAudit, 
//    T2.CriterionAudit,
//	T2.BasisAudit, 
//	T2.CauseAudit,
//    T2.RequirementOfAudit,
//	T2.PlanOfActionAudit,
//	T2.EffectAudit,
//	T2.AuditFindingCostCenter,
//	T2.AuditFindingDepto,
//	T2.AuditFindingSeccion,
//	T2.AuditorFinding,
//	T2.EmployeeFinding,
//	T2.EmployeeFinding2
//FROM 

//    dbo.AuditPrint T0
//INNER JOIN 
//    dbo.AuditReport T1 ON T0.AuditReportId = T1.AuditReportId
//INNER JOIN 
//    dbo.AuditFinding T2 ON T0.AuditReportId = T2.AuditReportId;


//Go 