using Microsoft.AspNetCore.Mvc;
using System.Net;

using Audi100.Models;
using Audi100.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Audi100.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeighingController : ControllerBase
    {
        private readonly IRepository<Weighing, int> _controllerRepository;

        public WeighingController(IRepository<Weighing, int> WeighingRepository)
        {
            _controllerRepository = WeighingRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Weighing>> Get()
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
        public ActionResult<Weighing> Get(int id)
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
        public ActionResult<Weighing> Post([FromBody] Weighing entity)
        {
            try
            {
                entity = _controllerRepository.Add(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.WeighingId }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Weighing> Put(int id, [FromBody] Weighing entity)
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
