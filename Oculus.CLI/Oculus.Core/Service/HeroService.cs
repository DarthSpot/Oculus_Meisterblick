using Oculus.Core.Database;
using Oculus.Core.Import;
using Oculus.Core.Model;

namespace Oculus.Core.Service;

public class HeroService
{
    public HeroDb HeroDb { get; }
    public List<Hero> Heroes { get; } = new(); 
    
    public HeroService(HeroDb heroDb)
    {
        HeroDb = heroDb;
    }

    public async Task Initialize()
    {
        foreach (var entry in await HeroDb.GetHeroes())
        {
            foreach (var hero in HeroReader.ReadHero(entry))
                Heroes.Add(hero);
        }
    }

    public async Task AddHero(string path, string name)
    {
        var heroEntry = await HeroDb.AddHero(path, name);
        foreach (var hero in HeroReader.ReadHero(heroEntry))
            Heroes.Add(hero);
    }
    
}