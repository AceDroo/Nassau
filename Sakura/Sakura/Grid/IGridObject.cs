using Sakura.Core;
using Sakura.Functional;
using Sakura.Interactions;
using Sakura.Units;

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