using TrenchCats.Grid;

namespace TrenchCats.Pathfinding;

public record PathfindingResult(List<GridPosition> Nodes, int Length)
{
    public readonly List<GridPosition> Nodes = Nodes;
    public readonly int Length = Length;
}