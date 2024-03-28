namespace Sakura.Units;

public class Unit(UnitIdentity identity, UnitStats stats, UnitAppearance appearance)
{
    public UnitIdentity Identity => identity;
    public UnitStats Stats => stats;
    public UnitAppearance Appearance => appearance;
}