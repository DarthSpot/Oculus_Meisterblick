namespace Oculus.Core.Model;

public class Hero
{
    public string Name { get; set; }
    public string Profession { get; set; }
    public string Race { get; set; }
    public string Culture { get; set; }
    public List<Talent> Talents { get; } = new();
    public List<Advantage> Advantages { get; } = new();
    public List<Disadvantage> Disadvantages { get; } = new();
    public List<Ability> Abilities { get; } = new();
    public List<Spell> Spells { get; } = new();

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Profession)}: {Profession}";
    }
}