using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

using Audi100.Server.Data;
using System.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class SqlReportPrintRepository : ISqlReportPrintRepository
    {
        private readonly string _connectionString;

        public SqlReportPrintRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnectionHome");
        }

        #region ReportPrint
        public async Task<ReportPrintHeader> GetReportPrint(int? AuditPrintId = null)
        {
            ReportPrintHeader header = null;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Consulta para el encabezado
                    var headerQuery = @"
                            SELECT AuditPrintId, DateI, DateE, ReportCode, CostSeccionPrint, Part1, Part2, Part3, Others,
                                   AuditorId1_Print, AuditorId2_Print, AuditorId3_Print, EmployeeId1_Print, EmployeeId2_Print, 
                                   EmployeeId3_Print, OtherEmployee, OtherEmployee2, OtherEmployee3, OtherEmployee4, Line, SubSeccion, 
                                   Graduate1, TextGraduate1, Graduate2, TextGraduate2, Graduate3, TextGraduate3, Direct, TextDirect, DateGra,


                                   AuditReportId, ReportTitle, NomDepto, NomDivision, NomSeccion, NomCompleto, ReviewdateOf, ReviewdateAt,
                                   AuditorId1_Report, AuditorId2_Report, AuditorId3_Report, EmployeeId1_Report, EmployeeId2_Report, EmployeeId3_Report
                            FROM [Auditoria].[dbo].[V_AuditReportPrint]
                            WHERE (AuditPrintId = @AuditPrintId)";


                    var headerCommand = new SqlCommand(headerQuery, connection);
                    headerCommand.Parameters.AddWithValue("@AuditPrintId", (object)AuditPrintId ?? DBNull.Value);

                    using (var reader = await headerCommand.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            header = new ReportPrintHeader
                            {
                                AuditPrintId = reader["AuditPrintId"]?.ToString() ?? string.Empty,
                                DateI = reader["DateI"] as DateTime?,
                                DateE = reader["DateE"] as DateTime?,
                                ReportCode = reader["ReportCode"]?.ToString() ?? string.Empty,
                                CostSeccionPrint = reader["CostSeccionPrint"]?.ToString() ?? string.Empty,
                                Part1 = reader["Part1"]?.ToString() ?? string.Empty,
                                Part2 = reader["Part2"]?.ToString() ?? string.Empty,
                                Part3 = reader["Part3"]?.ToString() ?? string.Empty,
                                Others = !string.IsNullOrEmpty(reader["Others"]?.ToString())
                                    ? reader["Others"].ToString()
                                    : string.Empty,
                                AuditorId1_Print = !string.IsNullOrEmpty(reader["AuditorId1_Print"]?.ToString()) 
                                    ? reader["AuditorId1_Print"].ToString() + "," 
                                    : string.Empty,
                                AuditorId2_Print = !string.IsNullOrEmpty(reader["AuditorId2_Print"]?.ToString()) 
                                    ? reader["AuditorId2_Print"].ToString() + "," 
                                    : string.Empty,
                                AuditorId3_Print = reader["AuditorId3_Print"]?.ToString() ?? string.Empty,
                                EmployeeId1_Print = !string.IsNullOrEmpty(reader["EmployeeId1_Print"]?.ToString()) 
                                    ? reader["EmployeeId1_Print"].ToString() + "," 
                                    : string.Empty,
                                EmployeeId2_Print = !string.IsNullOrEmpty(reader["EmployeeId2_Print"]?.ToString()) 
                                    ? reader["EmployeeId2_Print"].ToString() + "," 
                                    : string.Empty,
                                EmployeeId3_Print = !string.IsNullOrEmpty(reader["EmployeeId3_Print"]?.ToString()) 
                                    ? reader["EmployeeId3_Print"].ToString() + "," 
                                    : string.Empty,

                                OtherEmployee = reader["OtherEmployee"]?.ToString() ?? string.Empty,
                                OtherEmployee2 = reader["OtherEmployee2"]?.ToString() ?? string.Empty,
                                OtherEmployee3 = reader["OtherEmployee3"]?.ToString() ?? string.Empty,
                                OtherEmployee4 = reader["OtherEmployee4"]?.ToString() ?? string.Empty,
                                Line = reader["Line"]?.ToString() ?? string.Empty,
                                SubSeccion = reader["SubSeccion"]?.ToString() ?? string.Empty,
                                Graduate1 = reader["Graduate1"]?.ToString() ?? string.Empty,
                                TextGraduate1 = reader["TextGraduate1"]?.ToString() ?? string.Empty,
                                Graduate2 = reader["Graduate2"]?.ToString() ?? string.Empty,
                                TextGraduate2 = reader["TextGraduate2"]?.ToString() ?? string.Empty,
                                Graduate3 = reader["Graduate3"]?.ToString() ?? string.Empty,
                                TextGraduate3 = reader["TextGraduate3"]?.ToString() ?? string.Empty,
                                Direct = reader["Direct"]?.ToString() ?? string.Empty,
                                TextDirect = reader["TextDirect"]?.ToString() ?? string.Empty,
                                DateGra = reader["DateGra"]?.ToString() ?? string.Empty,

                                AuditReportId = reader["AuditReportId"]?.ToString() ?? string.Empty,
                                ReportTitle = reader["ReportTitle"]?.ToString() ?? string.Empty,
                                NomDepto = reader["NomDepto"]?.ToString() ?? string.Empty,
                                NomDivision = reader["NomDivision"]?.ToString() ?? string.Empty,
                                NomSeccion = reader["NomSeccion"]?.ToString() ?? string.Empty,
                                NomCompleto = reader["NomCompleto"]?.ToString() ?? string.Empty,
                                ReviewdateOf = reader["ReviewdateOf"] as DateTime?,
                                ReviewdateAt = reader["ReviewdateAt"] as DateTime?,
                                AuditorId1_Report = reader["AuditorId1_Report"]?.ToString() ?? string.Empty,
                                AuditorId2_Report = reader["AuditorId2_Report"]?.ToString() ?? string.Empty,
                                AuditorId3_Report = reader["AuditorId3_Report"]?.ToString() ?? string.Empty,
                                EmployeeId1_Report = reader["EmployeeId1_Report"]?.ToString() ?? string.Empty,
                                EmployeeId2_Report = reader["EmployeeId2_Report"]?.ToString() ?? string.Empty,
                                EmployeeId3_Report = reader["EmployeeId3_Report"]?.ToString() ?? string.Empty,
                                
                                Findings = new List<ReportPrintFinding>()
                            };
                        }
                    }

                    // Consulta para los detalles
                    var detailsQuery = @"
                        SELECT AuditFindingId, FindingTitle, NumberOfFindings, DateCreate, FindLevel,
                            ConditionAudit, CriterionAudit, RequirementOfAudit, BasisAudit, CauseAudit, EffectAudit,
                            RequirementOfAudit, PlanOfActionAudit, AuditFindingCostCenter, AuditFindingDepto, AuditFindingSeccion,
                            AuditorFinding, EmployeeFinding, EmployeeFinding2
                        FROM [Auditoria].[dbo].[V_AuditReportPrint]
                        WHERE (AuditPrintId = @AuditPrintId)";

                    var detailsCommand = new SqlCommand(detailsQuery, connection);
                    detailsCommand.Parameters.AddWithValue("@AuditPrintId", (object)AuditPrintId ?? DBNull.Value);

                    using (var reader = await detailsCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var finding = new ReportPrintFinding
                            {
                                AuditFindingId = reader["AuditFindingId"]?.ToString() ?? string.Empty,
                                FindingTitle = reader["FindingTitle"]?.ToString() ?? string.Empty,
                                NumberOfFindings = reader["NumberOfFindings"]?.ToString() ?? string.Empty,
                                DateCreate = reader["DateCreate"] as DateTime?,
                                FindLevel = reader["FindLevel"]?.ToString() ?? string.Empty,
                                ConditionAudit = reader["ConditionAudit"]?.ToString() ?? string.Empty,
                                CriterionAudit = reader["CriterionAudit"]?.ToString() ?? string.Empty,
                                RequirementOfAudit = reader["RequirementOfAudit"]?.ToString() ?? string.Empty,
                                BasisAudit = reader["BasisAudit"]?.ToString() ?? string.Empty,
                                CauseAudit = reader["CauseAudit"]?.ToString() ?? string.Empty,
                                PlanOfActionAudit = reader["PlanOfActionAudit"]?.ToString() ?? string.Empty,
                                EffectAudit = reader["EffectAudit"]?.ToString() ?? string.Empty,
                                AuditFindingCostCenter = reader["AuditFindingCostCenter"]?.ToString() ?? string.Empty,
                                AuditFindingDepto = reader["AuditFindingDepto"]?.ToString() ?? string.Empty,
                                AuditFindingSeccion = reader["AuditFindingSeccion"]?.ToString() ?? string.Empty,
                                AuditorFinding = reader["AuditorFinding"]?.ToString() ?? string.Empty,
                                EmployeeFinding = reader["EmployeeFinding"]?.ToString() ?? string.Empty,
                                EmployeeFinding2 = reader["EmployeeFinding2"]?.ToString() ?? string.Empty
                                //AddeedDetailFindingAudit = reader["AddeedDetailFindingAudit"]?.ToString() ?? string.Empty,
                                //DetailInternalFindingAudit = reader["DetailInternalFindingAudit"]?.ToString() ?? string.Empty,
                            };
                            header?.Findings.Add(finding);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                throw;
            }

            return header;
        }
        #endregion

    }
}

