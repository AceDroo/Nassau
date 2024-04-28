namespace TrenchCats.Grid;

public class GridSystem<TGridObject>
{
    private readonly int _width;
    private readonly int _height;
    private float _cellSize;
    private static TGridObject[,] _grid;

    private GridSystem(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _grid = new TGridObject[width, height];
    }

    public static GridSystem<TGridObject> Create(int width, int height, float cellSize, Func<GridSystem<TGridObject>, GridPosition, TGridObject> createGridObject)
    {
        var gridSystem = new GridSystem<TGridObject>(width, height, cellSize);
        for (var x = 0; x < width; x++)
        {
            for (var z = 0; z < height; z++)
            {
                _grid[x, z] = createGridObject(gridSystem, new GridPosition(x, z));
            }
        }
        return gridSystem;
    }

    public int Width => _width;

    public int Height => _height;

    public TGridObject GetGridObject(GridPosition position)
    {
        return _grid[position.X, position.Z];
    }

    public bool WithinBounds(GridPosition position)
    {
        return position.X >= 0 && position.Z >= 0 && position.X < _width && position.Z < _height;
    }
}