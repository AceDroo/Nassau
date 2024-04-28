using FluentAssertions;
using Sakura.Pathfinding;
using TrenchCats.Grid;

namespace Sakura.Tests.Pathfinding;

[TestFixture]
public class PathfinderShould
{
    [Test]
    public void FindPath()
    {
        var pathfinding = Pathfinder.Create(5, 5, 1);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 1), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(2, 1), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(3, 2), false);

        var result = pathfinding.FindPath(new GridPosition(0, 0), new GridPosition(2, 2));

        result.Nodes.Should().ContainInOrder(
            new GridPosition(0, 0),
            new GridPosition(0, 1),
            new GridPosition(1, 2),
            new GridPosition(2, 2)
        );
        result.Length.Should().Be(34);
    }

    [Test]
    public void Not_Find_Path()
    {
        var pathfinding = Pathfinder.Create(5, 5, 1);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 0), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 1), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 2), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 3), false);
        pathfinding.SetIsWalkableGridPosition(new GridPosition(1, 4), false);

        var result = pathfinding.FindPath(new GridPosition(0, 0), new GridPosition(4, 4));

        result.Nodes.Should().BeEmpty();
        result.Length.Should().Be(0);
    }
}