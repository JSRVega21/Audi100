using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Audi100.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Audi100.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqlDataController : ControllerBase
    {
        private readonly ISqlRepository _sqlRepository;

        public SqlDataController(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        #region GetCostCenter

        [HttpGet("GetCostCenter")]
        public async Task<IActionResult> GetCenterCostList([FromQuery] string nomDepto = null, [FromQuery] string nomDivision = null,  [FromQuery] string nomSeccion = null, [FromQuery] string nomCompleto = null)
        {
            try
            {
                var result = await _sqlRepository.GetCenterCostList(nomDepto, nomDivision, nomSeccion, nomCompleto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la lista de costos: {ex.Message}");
            }
        }

        #endregion

        #region GetDivision
        [HttpGet("GetDivision")]
        public async Task<IActionResult> GetDivision()
        {
            try
            {
                var result = await _sqlRepository.GetDivision();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la lista: {ex.Message}");
            }
        }
        #endregion

        #region GetSeccion
        [HttpGet("GetSeccion")]
        public async Task<IActionResult> GetSeccion()
        {
            try
            {
                var result = await _sqlRepository.GetSeccion();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la lista: {ex.Message}");
            }
        }
        #endregion

        #region GetAudit
        [HttpGet("GetAudit")]
        public async Task<IActionResult> GetAuditor()
        {
            try
            {
                var result = await _sqlRepository.GetAuditors();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la lista de auditores: {ex.Message}");
            }
        }
        #endregion

        #region GetEmployee
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result = await _sqlRepository.GetEmployee();
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
