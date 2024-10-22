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
    public class AuditPrintController : ControllerBase
    {
        private readonly IRepository<AuditPrint, int> _controllerRepository;

        public AuditPrintController(IRepository<AuditPrint, int> AuditPrintRepository)
        {
            _controllerRepository = AuditPrintRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuditPrint>> Get()
        {
            try
            {
                var entities = _controllerRepository.GetList();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AuditPrint> Get(int id)
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
        public async Task<ActionResult<AuditPrint>> Post([FromBody] AuditPrint entity)
        {
            try
            {
                entity = await _controllerRepository.AddAsync(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.AuditPrintId }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<AuditPrint> Put(int id, [FromBody] AuditPrint entity)
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
