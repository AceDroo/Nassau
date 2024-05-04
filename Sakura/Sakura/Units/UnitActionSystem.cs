using Sakura.Combat;

namespace Sakura.Units;

public class UnitActionSystem(UnitManager unitManager, TurnSystem turnSystem)
{
    public event EventHandler<UnitSelectedArgs> UnitSelected;

    private int _selectedIndex;

    public void SelectPreviousUnit()
    {
        if (!turnSystem.IsPlayerTurn()) return;
        _selectedIndex = (_selectedIndex - 1 + unitManager.GetFriendlyUnits().Count) % unitManager.GetFriendlyUnits().Count;
        UnitSelected?.Invoke(this, new UnitSelectedArgs(SelectedUnit));
    }

    public void SelectNextUnit()
    {
        if (!turnSystem.IsPlayerTurn()) return;
        _selectedIndex = (_selectedIndex + 1) % unitManager.GetFriendlyUnits().Count;
        UnitSelected?.Invoke(this, new UnitSelectedArgs(SelectedUnit));
    }

    public IUnit SelectedUnit => unitManager.GetFriendlyUnits()[_selectedIndex];
}