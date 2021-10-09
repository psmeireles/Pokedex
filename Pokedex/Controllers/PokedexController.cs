using Microsoft.AspNetCore.Mvc;
using Pokedex.Data;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [Route("api/pokedex")]
    public class PokedexController : Controller
    {
        private readonly PokedexService _service;
        
        public PokedexController(PokedexService service) => _service = service;

        [HttpGet("{id}")]
        public IActionResult Get(uint id)
        {
            var result = _service.GetById(id);
            if (result is null)
                return NotFound(new {Message = "Pokemon not found"});
            return Json(result);
        }

        [HttpGet("all")]
        public IActionResult GetPaged(int pageNumber = 0, int pageSize = 10)
        {
            var size = pageSize > 50 ? 50 : pageSize;
            var result = _service.GetPaged(pageNumber, size);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreatePokemonRequest request)
        {
            if (request is null)
                return BadRequest(new {Message = "Invalid request body"});
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new {Message = "Invalid name"});
            if (request.Generation == 0)
                return BadRequest(new {Message = "Invalid generation"});
            return Json(_service.Create(request));
        }

        [HttpPut("{id}")]
        public IActionResult Update(uint id, [FromBody]UpdatePokemonRequest request)
        {
            if (request is null)
                return BadRequest(new {Message = "Invalid request body"});
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new {Message = "Invalid name"});
            if (request.Generation == 0)
                return BadRequest(new {Message = "Invalid generation"});

            var existingPokemon = _service.GetById(id);
            if (existingPokemon is null)
                return NotFound(new {Message = "Pokemon not found"});
            _service.Update(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {
            var existingPokemon = _service.GetById(id);
            if (existingPokemon is null)
                return NotFound(new {Message = "Pokemon not found"});
            _service.DeleteById(id);
            return Ok();
        }
    }
}