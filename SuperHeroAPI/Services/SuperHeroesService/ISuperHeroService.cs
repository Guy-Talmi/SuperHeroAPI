using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroesService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetSuperHeroes();

    Task<SuperHero> GetSuperHero(int id);

    Task<SuperHero> AddSuperHero(SuperHero superHero);

    Task<SuperHero> UpdateSuperHero(int id, SuperHero superHero);

    Task<SuperHero> DeleteSuperHero(int id);

}
