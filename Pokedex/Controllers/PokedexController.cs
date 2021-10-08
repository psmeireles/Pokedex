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
        public IActionResult Get(int id) => Json(_service.GetById(id));
        
        [HttpPost]
        public IActionResult Create([FromBody]CreatePokemonRequest request) => Json(_service.Create(request));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return Ok();
        }
    }
}