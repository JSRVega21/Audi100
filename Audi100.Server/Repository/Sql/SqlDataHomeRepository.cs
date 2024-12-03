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
    public class SqlDataHomeRepository : ISqlHomeRepository
    {
        private readonly string _connectionString;

        public SqlDataHomeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnectionHome");
        }

        #region AuditComplete
        public async Task<IEnumerable<AuditComplete>> GetAuditComplete(int? AuditFindingId = null)
        {
            var seccions = new List<AuditComplete>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        SELECT 
                            T0.AUDITFINDINGID, T1.[AUDITREPORTID], T1.[REPORTCODE], T1.[NOMDEPTO], T1.[NOMDIVISION],
                            T1.[NOMSECCION], T0.[NUMBEROFFINDINGS], T0.[DETAILFINDINGAUDIT], 
                            T0.[FINDLEVEL], T2.[DESCRIPTION] AS WEIGHTINGCLASSIFICATION , T3.[DESCRIPTION] AS [FINDSHORTNAME],
                            T0.[POSITIVEWEIGHTING], T0.[NEGATIVEWEIGHTING], T0.[POSITIVERISK], T0.[NEGATIVERISK],
                            T0.[AUDITFINDINGCOSTCENTER], T0.[AUDITFINDINGDEPTO], T0.[AUDITFINDINGSECCION],
                            T0.[AUDITORFINDING], T0.[EMPLOYEEFINDING], T0.[EMPLOYEEFINDING2],
                            T0.[AUDITFINDINGCOSTCENTER], T0.[AUDITFINDINGDEPTO], T0.[AUDITFINDINGSECCION]
                                FROM [AUDITORIA].[DBO].[AUDITREPORT] T1
                                    INNER JOIN [AUDITORIA].[DBO].[AUDITFINDING] T0 ON T1.[AUDITREPORTID] = T0.[AUDITREPORTID]
                                    INNER JOIN [AUDITORIA].[DBO].[WEIGHTINGCLASSIFICATION] T2 ON T2.[WEIGHINGID] = T0.[WEIGHTINGCLASSIFICATIONID]
                                    INNER JOIN [AUDITORIA].[DBO].[SHORTF] T3 ON T3.[SHORTFID] = T0.[FINDSHORTNAMEID]
                        WHERE (@AuditFindingId IS NULL OR T0.AUDITFINDINGID = @AuditFindingId)";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AuditFindingId", (object)AuditFindingId ?? DBNull.Value);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var seccion = new AuditComplete
                            {
                                AuditFindingId = reader.IsDBNull(reader.GetOrdinal("AUDITFINDINGID")) ? 0 : reader.GetInt32(reader.GetOrdinal("AUDITFINDINGID")),
                                AuditReportId = reader.IsDBNull(reader.GetOrdinal("AUDITREPORTID")) ? 0 : reader.GetInt32(reader.GetOrdinal("AUDITREPORTID")),
                                ReportCode = reader.IsDBNull(reader.GetOrdinal("REPORTCODE")) ? string.Empty : reader.GetString(reader.GetOrdinal("REPORTCODE")),
                                nomDepto = reader.IsDBNull(reader.GetOrdinal("NOMDEPTO")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOMDEPTO")),
                                nomDivision = reader.IsDBNull(reader.GetOrdinal("NOMDIVISION")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOMDIVISION")),
                                nomSeccion = reader.IsDBNull(reader.GetOrdinal("NOMSECCION")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOMSECCION")),
                                AuditFindingCostCenter = reader.IsDBNull(reader.GetOrdinal("AUDITFINDINGCOSTCENTER")) ? string.Empty : reader.GetString(reader.GetOrdinal("AUDITFINDINGCOSTCENTER")),
                                AuditFindingDepto = reader.IsDBNull(reader.GetOrdinal("AUDITFINDINGDEPTO")) ? string.Empty : reader.GetString(reader.GetOrdinal("AUDITFINDINGDEPTO")),
                                AuditFindingSeccion = reader.IsDBNull(reader.GetOrdinal("AUDITFINDINGSECCION")) ? string.Empty : reader.GetString(reader.GetOrdinal("AUDITFINDINGSECCION")),
                                NumberOfFindings = reader.IsDBNull(reader.GetOrdinal("NUMBEROFFINDINGS")) ? 0 : reader.GetDecimal(reader.GetOrdinal("NUMBEROFFINDINGS")),
                                DetailFindingAudit = reader.IsDBNull(reader.GetOrdinal("DETAILFINDINGAUDIT")) ? string.Empty : reader.GetString(reader.GetOrdinal("DETAILFINDINGAUDIT")),
                                FindLevel = reader.IsDBNull(reader.GetOrdinal("FINDLEVEL")) ? string.Empty : reader.GetString(reader.GetOrdinal("FINDLEVEL")),
                                WeightingClassification = reader.IsDBNull(reader.GetOrdinal("WEIGHTINGCLASSIFICATION")) ? string.Empty : reader.GetString(reader.GetOrdinal("WEIGHTINGCLASSIFICATION")),
                                FindShortName = reader.IsDBNull(reader.GetOrdinal("FINDSHORTNAME")) ? string.Empty : reader.GetString(reader.GetOrdinal("FINDSHORTNAME")),
                                PositiveWeighting = reader.IsDBNull(reader.GetOrdinal("POSITIVEWEIGHTING")) ? 0 : reader.GetDecimal(reader.GetOrdinal("POSITIVEWEIGHTING")),
                                NegativeWeighting = reader.IsDBNull(reader.GetOrdinal("NEGATIVEWEIGHTING")) ? 0 : reader.GetDecimal(reader.GetOrdinal("NEGATIVEWEIGHTING")),
                                PositiveRisk = reader.IsDBNull(reader.GetOrdinal("POSITIVERISK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("POSITIVERISK")),
                                NegativeRisk = reader.IsDBNull(reader.GetOrdinal("NEGATIVERISK")) ? 0 : reader.GetDecimal(reader.GetOrdinal("NEGATIVERISK")),
                                AuditorFinding = reader.IsDBNull(reader.GetOrdinal("AUDITORFINDING")) ? string.Empty : reader.GetString(reader.GetOrdinal("AUDITORFINDING")),
                                EmployeeFinding = reader.IsDBNull(reader.GetOrdinal("EMPLOYEEFINDING")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMPLOYEEFINDING")),
                                EmployeeFinding2 = reader.IsDBNull(reader.GetOrdinal("EMPLOYEEFINDING2")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMPLOYEEFINDING2")),
                            };
                            seccions.Add(seccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                throw;
            }

            return seccions;
        }

        #endregion

    }
}

