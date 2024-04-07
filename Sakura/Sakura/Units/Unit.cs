using Sakura.Status;

namespace Sakura.Units;

public class Unit(Identity identity, Stats stats, Appearance appearance) : IUnit
{
    public Identity Identity
    {
        get => identity;
        set => identity = value;
    }

    public Stats Stats => stats;
    public Appearance Appearance => appearance;
}