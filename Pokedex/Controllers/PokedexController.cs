using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokedexController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}