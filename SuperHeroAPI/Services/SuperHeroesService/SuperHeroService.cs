using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroesService;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _dataContext;

    public SuperHeroService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<SuperHero>> GetSuperHeroes()
    {
        return await _dataContext.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetSuperHero(int id)
    {
        var superHero = await _dataContext.SuperHeroes.FindAsync(id);

        if (superHero == null)
        {
            return null;
        }

        return superHero;
    }

    public async Task<SuperHero> AddSuperHero(SuperHero superHero)
    {
        await _dataContext.SuperHeroes.AddAsync(superHero);

        await _dataContext.SaveChangesAsync();

        return superHero;
    }

    public async Task<SuperHero> UpdateSuperHero(int id, SuperHero superHero)
    {
        var superHeroToUpdate = await _dataContext.SuperHeroes.FindAsync(id);

        if (superHeroToUpdate == null)
        {
            return null;
        }

        superHeroToUpdate.Name = superHero.Name;
        superHeroToUpdate.FirstName = superHero.FirstName;
        superHeroToUpdate.LastName = superHero.LastName;
        superHeroToUpdate.Place = superHero.Place;

        await _dataContext.SaveChangesAsync();

        return superHeroToUpdate;
    }

    public async Task<SuperHero> DeleteSuperHero(int id)
    {
        var superHeroToDelete = await _dataContext.SuperHeroes.FindAsync(id);

        if (superHeroToDelete is null)
        {
            return null;
        }

        _dataContext.SuperHeroes.Remove(superHeroToDelete);

        await _dataContext.SaveChangesAsync();

        return superHeroToDelete;
    }
}
