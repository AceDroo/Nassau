using Sakura.Grid;

namespace Sakura.Pathfinding;

public record PathfindingResult(List<GridPosition> Nodes, int Length)
{
    public List<GridPosition> Nodes = Nodes;
    public int Length = Length;
}