using Sakura.Combat;

namespace Sakura.Units;

public class UnitActionSystem(UnitManager unitManager, TurnSystem turnSystem)
{
    public event Action<IUnit> UnitSelected;

    private int _selectedIndex;

    public void SelectPreviousUnit()
    {
        if (!turnSystem.IsPlayerTurn()) return;
        _selectedIndex = (_selectedIndex - 1 + unitManager.GetFriendlyUnits().Count) % unitManager.GetFriendlyUnits().Count;
        UnitSelected?.Invoke(SelectedUnit);
    }

    public void SelectNextUnit()
    {
        if (!turnSystem.IsPlayerTurn()) return;
        _selectedIndex = (_selectedIndex + 1) % unitManager.GetFriendlyUnits().Count;
        UnitSelected?.Invoke(SelectedUnit);
    }

    public IUnit SelectedUnit => unitManager.GetFriendlyUnits()[_selectedIndex];
}