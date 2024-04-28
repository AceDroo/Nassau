using TrenchCats.Grid;

namespace TrenchCats.Pathfinding;

public class Pathfinder
{
    private const int MoveStraightCost = 10;
    private const int MoveDiagonalCost = 14;

    private readonly GridSystem<PathNode> _gridSystem;

    private Pathfinder(int width, int height, float cellSize)
    {
        _gridSystem = GridSystem<PathNode>.Create(width, height, cellSize, (_, position) => new PathNode(position));
    }

    public static Pathfinder Create(int width, int height, float cellSize)
    {
        return new Pathfinder(width, height, cellSize);
    }

    public void SetIsWalkableGridPosition(GridPosition gridPosition, bool isWalkable)
    {
        _gridSystem.GetGridObject(gridPosition).SetIsWalkable(isWalkable);
    }

    
    public PathfindingResult FindPath(GridPosition startPosition, GridPosition endPosition)
    {
        var openList = new List<PathNode>();
        var closedList = new List<PathNode>();

        var startNode = _gridSystem.GetGridObject(startPosition);
        var endNode = _gridSystem.GetGridObject(endPosition);

        openList.Add(startNode);
        for (int x = 0; x < _gridSystem.Width; x++)
        {
            for (int z = 0; z < _gridSystem.Height; z++)
            {
                var pathNode = _gridSystem.GetGridObject(new GridPosition(x, z));
                pathNode.SetGCost(int.MaxValue);
                pathNode.SetHCost(0);
                pathNode.CalculateFCost();
                pathNode.ResetCameFromPathNode();
            }
        }

        startNode.SetGCost(0);
        startNode.SetHCost(CalculateDistance(startPosition, endPosition));
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            var currentNode = GetLowestFCostPathNode(openList);

            if (currentNode == endNode)
            {
                var path = CalculatePath(endNode);
                return new PathfindingResult(path, endNode.GetFCost());
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (var neighbourNode in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode))
                {
                    continue;
                }

                if (!neighbourNode.IsWalkable())
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                var distance = CalculateDistance(currentNode.GetGridPosition(), neighbourNode.GetGridPosition());
                var tentativeGCost = currentNode.GetGCost() + distance;
                if (tentativeGCost >= neighbourNode.GetGCost())
                {
                    continue;
                }

                neighbourNode.SetCameFromPathNode(currentNode);
                neighbourNode.SetGCost(tentativeGCost);
                neighbourNode.SetHCost(CalculateDistance(neighbourNode.GetGridPosition(), endPosition));
                neighbourNode.CalculateFCost();

                if (!openList.Contains(neighbourNode))
                {
                    openList.Add(neighbourNode);
                }
            }
        }

        return new PathfindingResult([], 0);
    }

    private IEnumerable<PathNode> GetNeighbourList(PathNode pathNode)
    {
        var neighbourList = new List<PathNode>();
        var gridPosition = pathNode.GetGridPosition();

        if (gridPosition.X - 1 >= 0)
        {
            // Left
            neighbourList.Add(GetNode(gridPosition.X - 1, gridPosition.Z + 0));
            if (gridPosition.Z - 1 >= 0)
            {
                // Left Down
                neighbourList.Add(GetNode(gridPosition.X - 1, gridPosition.Z - 1));
            }

            if (gridPosition.Z + 1 < _gridSystem.Height - 1)
            {
                // Left Up
                neighbourList.Add(GetNode(gridPosition.X - 1, gridPosition.Z + 1));
            }
        }

        if (gridPosition.X + 1 < _gridSystem.Width - 1)
        {
            // Right
            neighbourList.Add(GetNode(gridPosition.X + 1, gridPosition.Z + 0));
            if (gridPosition.Z - 1 >= 0)
            {
                // Right Down
                neighbourList.Add(GetNode(gridPosition.X + 1, gridPosition.Z - 1));
            }
            if (gridPosition.X + 1 < _gridSystem.Height - 1)
            {
                // Right Up
                neighbourList.Add(GetNode(gridPosition.X + 1, gridPosition.Z + 1));
            }
        }

        if (gridPosition.Z - 1 >= 0)
        {
            // Down
            neighbourList.Add(GetNode(gridPosition.X + 0, gridPosition.Z - 1));
        }
        if (gridPosition.Z + 1 < _gridSystem.Height - 1)
        {
            // Up
            neighbourList.Add(GetNode(gridPosition.X + 0, gridPosition.Z + 1));
        }

        return neighbourList;
    }

    private PathNode GetNode(int x, int z)
    {
        return _gridSystem.GetGridObject(new GridPosition(x, z));
    }

    private List<GridPosition> CalculatePath(PathNode endNode)
    {
        List<PathNode> pathNodeList = [ endNode ];
        var currentNode = endNode;
        while (currentNode.GetCameFromPathNode().IsPresent())
        {
            var pathNode = currentNode.GetCameFromPathNode().Get();
            pathNodeList.Add(pathNode);
            currentNode = pathNode;
        }

        pathNodeList.Reverse();

        return pathNodeList.Select(pathNode => pathNode.GetGridPosition()).ToList();
    }

    private PathNode GetLowestFCostPathNode(List<PathNode> openList)
    {
        var lowestFCostPathNode = openList[0];
        foreach (var pathNode in openList)
        {
            if (pathNode.GetFCost() < lowestFCostPathNode.GetFCost())
            {
                lowestFCostPathNode = pathNode;
            }
        }
        return lowestFCostPathNode;
    }

    private int CalculateDistance(GridPosition startPosition, GridPosition endPosition)
    {
        var gridPositionDistance = startPosition - endPosition;
        var xDistance = Math.Abs(gridPositionDistance.X);
        var zDistance = Math.Abs(gridPositionDistance.Z);
        var remaining = Math.Abs(xDistance - zDistance);
        return MoveDiagonalCost * Math.Min(xDistance, zDistance) + MoveStraightCost * remaining;
    }
}