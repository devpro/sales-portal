using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Devpro.Common.AspNetCore.Mvc
{
    public abstract class CrudControllerBase<T> : ControllerBase
        where T : IDto
    {
        private readonly ILogger _logger;

        private readonly ICrudRepository<T> _repository;

        protected CrudControllerBase(ILogger logger, ICrudRepository<T> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            var items = await _repository.FindAllAsync();
            _logger.LogDebug("Number of items found: {0}", items.Count);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<T>> GetById(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var item = await _repository.FindOneAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody] T input)
        {
            var item = await _repository.CreateAsync(input);
            // beware: ASP.NET removes "Async" from method names (see https://stackoverflow.com/a/63834605/12866734)
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(string id, [FromBody] T input)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(input.Id))
            {
                input.Id = id;
            }

            await _repository.UpdateAsync(id, input);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
