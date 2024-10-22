using Microsoft.AspNetCore.Mvc;
using System.Net;

using Audi100.Models;
using Audi100.Server.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Audi100.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditReportController : ControllerBase
    {
        private readonly IRepository<AuditReport, int> _controllerRepository;

        public AuditReportController(IRepository<AuditReport, int> AuditReportRepository)
        {
            _controllerRepository = AuditReportRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuditReport>> Get()
        {
            try
            {
                var entities = _controllerRepository.GetList();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }


        }

        [HttpGet("{id}")]
        public ActionResult<AuditReport> Get(int id)
        {
            try
            {
                var entity = _controllerRepository.GetByKey(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuditReport>> Post([FromBody] AuditReport entity)
        {
            try
            {
                entity = await _controllerRepository.AddAsync(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.AuditReportId }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AuditReport> Put(int id, [FromBody] AuditReport entity)
        {
            try
            {
                var existingEntity = _controllerRepository.GetByKey(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }

                entity = _controllerRepository.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = _controllerRepository.GetByKey(id);
                if (entity == null)
                {
                    return NotFound();
                }

                _controllerRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
