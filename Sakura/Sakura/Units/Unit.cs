using Sakura.Status;

namespace Sakura.Units;

public class Unit(UnitIdentity identity, Stats stats, UnitAppearance appearance)
{
    public UnitIdentity Identity => identity;
    public Stats Stats => stats;
    public UnitAppearance Appearance => appearance;
}