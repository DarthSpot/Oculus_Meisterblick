using System.Xml.Linq;

namespace Oculus.Core.Model;

public class Ability
{
    public Ability(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}";
    }
}