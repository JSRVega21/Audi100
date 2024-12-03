using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Audi100.Server.Repository;
using Audi100.Models;

namespace Audi100.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqlReportPrintController : ControllerBase
    {
        private readonly ISqlReportPrintRepository _reportPrintRepository;

        public SqlReportPrintController(ISqlReportPrintRepository reportPrintRepository)
        {
            _reportPrintRepository = reportPrintRepository;
        }

        #region GetReportPrint
        [HttpGet("GetReportPrint")]
        public async Task<IActionResult> GetReportPrint([FromQuery] int? AuditPrintId = null)
        {
            try
            {
                var result = await _reportPrintRepository.GetReportPrint(AuditPrintId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el reporte de auditoría: {ex.Message}");
            }
        }
        #endregion
    }
}
