namespace Oculus.Core.Model;

public abstract class HeroPower
{
    public string Name { get; protected set; }
    public int? Value { get; protected set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Value)}: {Value}";
    }
}