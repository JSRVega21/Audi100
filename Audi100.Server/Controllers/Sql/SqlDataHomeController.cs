using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Audi100.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Audi100.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqlDataHomeController : ControllerBase
    {
        private readonly ISqlHomeRepository _sqlRepository;

        public SqlDataHomeController(ISqlHomeRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        #region GetAuditComplete
        [HttpGet("GetAuditComplete")]
        public async Task<IActionResult> GetAuditComplete([FromQuery] int? AuditFindingId = null)
        {
            try
            {
                var result = await _sqlRepository.GetAuditComplete(AuditFindingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la lista de auditores: {ex.Message}");
            }
        }
        #endregion
    }
}
