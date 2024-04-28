using TrenchCats.Grid;

namespace Sakura.Grid;

public interface IGridVisual
{
    void Show(List<GridPosition> positions, GridVisualType visualType);
    void Hide();
}