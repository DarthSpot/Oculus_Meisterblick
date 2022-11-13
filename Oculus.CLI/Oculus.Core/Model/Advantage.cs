namespace Oculus.Core.Model;

public class Advantage
{
    public Advantage(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Value)}: {Value}";
    }
}