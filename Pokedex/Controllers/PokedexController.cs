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
        public IActionResult Get(int id)
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
        public IActionResult Create([FromBody]CreatePokemonRequest request) => Json(_service.Create(request));
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdatePokemonRequest request)
        {
            _service.Update(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return Ok();
        }
    }
}