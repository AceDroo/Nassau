using Sakura.Grid;

namespace Sakura;

public interface ILevelGrid
{
    void AddUnitAtGridPosition(GridPosition position, IUnit unit);
    void RemoveUnitAtGridPosition(GridPosition position, IUnit unit);
    Option<IUnit> GetUnitAtGridPosition(GridPosition position);
    bool IsValidGridPosition(GridPosition position);
    int Width { get; }
    int Height { get; }
    Option<IInteractable> GetInteractableAtGridPosition(GridPosition position);
    void SetInteractableAtGridPosition(GridPosition position);
    void ClearInteractableAtGridPosition(GridPosition position);
}