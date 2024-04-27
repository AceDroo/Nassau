using Sakura.Functional;
using Sakura.Units;
using TrenchCats.Interactions;

namespace Sakura.Grid;

public interface IGridObject
{
    void AddUnit(IUnit unit);
    void RemoveUnit(IUnit unit);
    Option<IUnit> GetUnit();
    void SetInteractable(IInteractable interactable);
    void ClearInteractable();
    Option<IInteractable> GetInteractable();
}