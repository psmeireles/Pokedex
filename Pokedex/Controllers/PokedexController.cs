using Microsoft.AspNetCore.Mvc;
using Pokedex.Data;
using Pokedex.Repositories;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("api/pokedex")]
    public class PokedexController : ControllerBase
    {
        private readonly IRepository<Pokemon> _Repository;
        
        public PokedexController(IRepository<Pokemon> repository) => _Repository = repository;

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}