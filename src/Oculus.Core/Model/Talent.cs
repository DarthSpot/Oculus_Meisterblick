namespace Oculus.Core.Model;

public class Talent : HeroPower
{
    public Talent(string name, string value)
    {
        Name = name;
        if (!string.IsNullOrEmpty(value))
            Value = int.Parse(value);
    }

    public override string ToString()
    {
        return $"{base.ToString()}";
    }
}