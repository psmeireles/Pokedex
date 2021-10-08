using Microsoft.AspNetCore.Mvc;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("api/pokedex")]
    public class PokedexController : ControllerBase
    {
        private readonly PokedexService _service;
        
        public PokedexController(PokedexService service) => _service = service;

        [HttpGet("{id}")]
        public IActionResult Get(int id) => new JsonResult(_service.GetById(id));
    }
}