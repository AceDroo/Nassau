using Sakura.Grid;

namespace Sakura.Pathfinding;

public class PathNode(GridPosition position)
{
    private int _gCost;
    private int _hCost;
    private int _fCost;
    private Option<PathNode> _cameFromPathNode;
    private bool _isWalkable = true;

    public int GetGCost()
    {
        return _gCost;
    }

    public int GetHCost()
    {
        return _hCost;
    }

    public int GetFCost()
    {
        return _fCost;
    }

    public void SetGCost(int gCost)
    {
        _gCost = gCost;
    }

    public void SetHCost(int hCost)
    {
        _hCost = hCost;
    }

    public void CalculateFCost()
    {
        _fCost = _gCost + _hCost;
    }

    public void ResetCameFromPathNode()
    {
        _cameFromPathNode = Option<PathNode>.None();
    }

    public void SetCameFromPathNode(PathNode pathNode)
    {
        _cameFromPathNode = Option<PathNode>.Some(pathNode);
    }

    public Option<PathNode> GetCameFromPathNode()
    {
        return _cameFromPathNode;
    }

    public GridPosition GetGridPosition()
    {
        return position;
    }

    public bool IsWalkable()
    {
        return _isWalkable;
    }

    public void SetIsWalkable(bool isWalkable)
    {
        _isWalkable = isWalkable;
    }
}