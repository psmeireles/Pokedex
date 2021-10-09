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

        public class ErrorResponse
        {
            public string Message { get; set; }
            public ErrorResponse(string message) => Message = message;
        }

        private static ErrorResponse PokemonNotFound => new("Pokemon not found");
        private static ErrorResponse InvalidBody => new("Invalid request body");
        private static ErrorResponse InvalidName => new("Invalid name");
        private static ErrorResponse InvalidGeneration => new("Invalid generation");

        [HttpGet("{id}")]
        public IActionResult Get(uint id)
        {
            var result = _service.GetById(id);
            if (result is null)
                return NotFound(PokemonNotFound);
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
                return BadRequest(InvalidBody);
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(InvalidName);
            if (request.Generation == 0)
                return BadRequest(InvalidGeneration);
            return Json(_service.Create(request));
        }

        [HttpPut("{id}")]
        public IActionResult Update(uint id, [FromBody]UpdatePokemonRequest request)
        {
            if (request is null)
                return BadRequest(InvalidBody);
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(InvalidName);
            if (request.Generation == 0)
                return BadRequest(InvalidGeneration);

            var existingPokemon = _service.GetById(id);
            if (existingPokemon is null)
                return NotFound(PokemonNotFound);
            _service.Update(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {
            var existingPokemon = _service.GetById(id);
            if (existingPokemon is null)
                return NotFound(PokemonNotFound);
            _service.DeleteById(id);
            return Ok();
        }
    }
}