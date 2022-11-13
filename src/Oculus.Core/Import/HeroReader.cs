using System.Xml;
using System.Xml.Linq;
using Oculus.Core.Database;
using Oculus.Core.Model;

namespace Oculus.Core.Import;

public static class HeroReader
{
    public static IEnumerable<Hero> ReadHero(HeroEntry path)
    {
        using var memStream = new MemoryStream(path.HeroData);
        var xml = XDocument.Load(memStream);
        foreach (var heroDoc in xml.Root.Elements("held"))
        {
            var doc = new HeroDocReader(heroDoc);
            var hero = new Hero();
            hero.Name = doc.Name;
                
            foreach (var xelem in doc.GetElements("sf"))
                hero.Abilities.Add(new Ability(xelem.Attribute("name").Value));
                
            foreach (var xelem in doc.GetElements("vt"))
                hero.Advantages.Add(new Advantage(xelem.Attribute("name").Value, xelem.Attribute("value")?.Value));

            foreach (var xelem in doc.GetElements("talentliste"))
                hero.Talents.Add(new Talent(xelem.Attribute("name").Value, xelem.Attribute("value")?.Value));
            yield return hero;
        }
    }
}

public class HeroDocReader
{
    public XElement Hero { get; }
    public string Name => Hero.Attribute("name").Value;

    public HeroDocReader(XElement hero)
    {
        Hero = hero;
    }

    public string GetBaseValue(string name)
    {
        return Hero.Element("basis").Element(name).Attribute("name").Value;
    }

    public IEnumerable<XElement> GetElements(string name)
    {
        return Hero.Element(name).Elements();
    }
}