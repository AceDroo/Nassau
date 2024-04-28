using FluentAssertions;
using TrenchCats.Grid;

namespace Sakura.Tests.Grid;

[TestFixture]
public class GridSystemShould
{
    private GridSystem<int> _gridSystem = null!;

    [SetUp]
    public void Setup()
    {
        _gridSystem = GridSystem<int>.Create(5, 10, 1.0f, 
            (_, position) => CreateGridObject(position)
        );
    }

    [Test]
    public void Return_Width()
    {
        _gridSystem.Width.Should().Be(5);
    }

    [Test]
    public void Return_Height()
    {
        _gridSystem.Height.Should().Be(10);
    }

    [Test]
    public void Return_GridObject_At_Position()
    {
        _gridSystem.GetGridObject(new GridPosition(2, 2)).Should().Be(1);
    }

    [Test]
    public void Return_True_If_GridPosition_Is_Within_Bounds()
    {
        _gridSystem.WithinBounds(new GridPosition(1, 1)).Should().BeTrue();
    }

    [Test]
    [TestCase(-1, 0)]
    [TestCase(100, 0)]
    [TestCase(0, -1)]
    [TestCase(0, 100)]
    public void Return_False_If_GridPosition_Is_Not_Within_Bounds(int x, int z)
    {
        _gridSystem.WithinBounds(new GridPosition(x, z)).Should().BeFalse();
    }

    private static int CreateGridObject(GridPosition position)
    {
        if (position.X % 2 == 0 || position.Z % 2 == 0)
        {
            return 1;
        }
        return 0;
    }
}