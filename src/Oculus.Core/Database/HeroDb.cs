using SQLite;

namespace Oculus.Core.Database;

public class HeroDb
{
    private string DbPath = Path.Combine(Settings.AppFolder, "heroes.db");
    
    private SQLiteAsyncConnection Database { get; }
    
    public HeroDb()
    {
        Settings.EnsureAppFolderExists();
        Database = new SQLiteAsyncConnection(DbPath);
        if (Database.TableMappings.All(x => x.MappedType != typeof(HeroEntry)))
            Database.CreateTableAsync<HeroEntry>().Wait();
        
    }

    public async Task<List<HeroEntry>> GetHeroes()
    {
        return await Database.Table<HeroEntry>().ToListAsync();
    }

    public async Task<HeroEntry> AddHero(string filePath, string name)
    {
        var data = File.ReadAllBytes(filePath);
        var entry = new HeroEntry()
        {
            Name = name,
            Active = true,
            Created = DateTime.Now,
            HeroData = data
        };
        await Database.InsertAsync(entry);
        return entry;
    }
}

public class HeroEntry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime Created { get; set; }
    
    public bool Active { get; set; }
    
    public byte[] HeroData { get; set; }
}