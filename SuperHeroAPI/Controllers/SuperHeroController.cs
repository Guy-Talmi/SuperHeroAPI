using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroesService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private ISuperHeroService _superHeroService;
        private ILogger<SuperHeroController> _logger;

        public SuperHeroController(ISuperHeroService superHeroService, ILogger<SuperHeroController> logger)
        {
            _superHeroService = superHeroService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            _logger.LogError("Getting all superheroes");

            return await _superHeroService.GetSuperHeroes();
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var superHero = await _superHeroService.GetSuperHero(id);

            if (superHero == null)
            {
                return NotFound("Sorry, but this superhero does not exist.");
            }

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddSuperHero([FromBody] SuperHero superHero)
        {
            var addSuperHero = await _superHeroService.AddSuperHero(superHero);

            return Ok(addSuperHero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id, [FromBody] SuperHero superHero)
        {
            var updateSuperHero = await _superHeroService.UpdateSuperHero(id, superHero);

            if (updateSuperHero == null)
            {
                return NotFound("Sorry, but this superhero does not exist.");
            }

            return Ok(updateSuperHero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
        {
            var deleteSuperHero = await _superHeroService.DeleteSuperHero(id);

            if (deleteSuperHero is null)
            {
                return NotFound("Sorry, but this superhero does not exist.");
            }

            return Ok(deleteSuperHero);
        }
    }
}
