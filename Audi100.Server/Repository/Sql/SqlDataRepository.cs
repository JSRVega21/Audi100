using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class SqlDataRepository : ISqlRepository
    {
        private readonly string _connectionString;

        public SqlDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }

        #region GetCenterCostList
        public async Task<IEnumerable<CostCenter>> GetCenterCostList(string nomDepto = null, string nomDivision = null, string nomSeccion = null, string nomCompleto = null)
        {
            var costCenters = new List<CostCenter>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = @"
                    SELECT [NOM_DEPTO],
                           [NOM_DIVISION],
                           [NOM_SECCION],
                           [NOM_COMPLETO],
                           [DESC_PUESTO]
                    FROM [SBO_FFACSA_APPS].[dbo].[Costo_Personal_Auditoria]
                    WHERE (@nomDepto IS NULL OR NOM_DEPTO = @nomDepto)
                    AND (@nomDivision IS NULL OR NOM_DIVISION = @nomDivision)
                    AND (@nomSeccion IS NULL OR NOM_SECCION = @nomSeccion)
                    AND (@nomCompleto IS NULL OR NOM_COMPLETO = @nomCompleto)
                    ORDER BY NOM_DEPTO ASC";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nomDepto", string.IsNullOrEmpty(nomDepto) ? (object)DBNull.Value : nomDepto);
                    command.Parameters.AddWithValue("@nomDivision", string.IsNullOrEmpty(nomDivision) ? (object)DBNull.Value : nomDivision);
                    command.Parameters.AddWithValue("@nomSeccion", string.IsNullOrEmpty(nomSeccion) ? (object)DBNull.Value : nomSeccion);
                    command.Parameters.AddWithValue("@nomCompleto", string.IsNullOrEmpty(nomCompleto) ? (object)DBNull.Value : nomCompleto);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var costCenter = new CostCenter
                            {
                                NomDepto = reader.GetString(reader.GetOrdinal("NOM_DEPTO")),
                                NomDivision = reader.GetString(reader.GetOrdinal("NOM_DIVISION")),
                                NomSeccion = reader.GetString(reader.GetOrdinal("NOM_SECCION")),
                                NomCompleto = reader.GetString(reader.GetOrdinal("NOM_COMPLETO")),
                                DescPuesto = reader.GetString(reader.GetOrdinal("DESC_PUESTO"))
                            };
                            costCenters.Add(costCenter);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                throw;
            }

            return costCenters;
        }

        #endregion

        #region GetDivision
        public async Task<IEnumerable<CostDivision>> GetDivision()
        {
            var seccions = new List<CostDivision>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        SELECT DISTINCT [NOM_DIVISION]
                        FROM [SBO_FFACSA_APPS].[dbo].[Costo_Personal_Auditoria]
                        ORDER BY [NOM_DIVISION] ASC;
                        ";

                    var command = new SqlCommand(query, connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var seccion = new CostDivision
                            {
                                NomDivision = reader.GetString(reader.GetOrdinal("NOM_DIVISION")),
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

        #region GetSeccion
        public async Task<IEnumerable<CostSeccion>> GetSeccion()
        {
            var seccions = new List<CostSeccion>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        SELECT DISTINCT [NOM_SECCION]
                        FROM [SBO_FFACSA_APPS].[dbo].[Costo_Personal_Auditoria]
                        ORDER BY [NOM_SECCION] ASC;
                        ";

                    var command = new SqlCommand(query, connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var seccion = new CostSeccion
                            {
                                NomSeccion = reader.GetString(reader.GetOrdinal("NOM_SECCION")),
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

        #region GetAuditor
        public async Task<IEnumerable<Employee>> GetAuditors()
        {
            var auditors = new List<Employee>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        SELECT 
                        COD_EMPLEADO,
                        NOM_COMPLETO,
                        COD_PUESTO,
                        DESC_PUESTO
                        FROM [SBO_FFACSA_APPS].[dbo].[Costo_Personal_Auditoria]
                        WHERE DESC_PUESTO LIKE '%AUDITORIA%'
                        OR DESC_PUESTO LIKE '%AUDITOR%'";

                    var command = new SqlCommand(query, connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var auditor = new Employee
                            {
                                Cod_Employee = reader.GetString(reader.GetOrdinal("COD_EMPLEADO")),
                                Name_Employee = reader.GetString(reader.GetOrdinal("NOM_COMPLETO")),
                                Cod_Position = reader.GetString(reader.GetOrdinal("COD_PUESTO")),
                                Name_Position = reader.GetString(reader.GetOrdinal("DESC_PUESTO"))
                            };
                            auditors.Add(auditor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                throw;
            }

            return auditors;
        }
        #endregion

        #region GetEmployee
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var auditors = new List<Employee>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        SELECT 
                        COD_EMPLEADO,
                        NOM_COMPLETO,
                        COD_PUESTO,
                        DESC_PUESTO
                        FROM [SBO_FFACSA_APPS].[dbo].[Costo_Personal_Auditoria]";

                    var command = new SqlCommand(query, connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var auditor = new Employee
                            {
                                Cod_Employee = reader.GetString(reader.GetOrdinal("COD_EMPLEADO")),
                                Name_Employee = reader.GetString(reader.GetOrdinal("NOM_COMPLETO")),
                                Cod_Position = reader.GetString(reader.GetOrdinal("COD_PUESTO")),
                                Name_Position = reader.GetString(reader.GetOrdinal("DESC_PUESTO"))
                            };
                            auditors.Add(auditor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                throw;
            }

            return auditors;
        }
        #endregion

    }
}

