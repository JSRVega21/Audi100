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
    public class ShortFController : ControllerBase
    {
        private readonly IRepository<ShortF, int> _controllerRepository;

        public ShortFController(IRepository<ShortF, int> ShortFRepository)
        {
            _controllerRepository = ShortFRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShortF>> Get()
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
        public ActionResult<ShortF> Get(int id)
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
        public ActionResult<ShortF> Post([FromBody] ShortF entity)
        {
            try
            {
                entity = _controllerRepository.Add(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.ShortFId }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ShortF> Put(int id, [FromBody] ShortF entity)
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
