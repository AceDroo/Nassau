namespace Sakura.Units;

public class UnitManager
{
    private List<IUnit> _friendlyUnits = [];

    public List<IUnit> GetFriendlyUnits() => _friendlyUnits;

    public void AddFriendlyUnit(IUnit unit)
    {
        _friendlyUnits.Add(unit);
    }
}