using FluentAssertions;
using NSubstitute;
using Sakura.Combat;
using Sakura.Units;

namespace Sakura.Tests.Units;

[TestFixture]
public class UnitActionSystemTests
{
    [Test]
    public void SelectPreviousUnit_WhenPlayerTurn_ShouldSelectPreviousUnit()
    {
        var initialUnit = Substitute.For<IUnit>();
        var expectedUnit = Substitute.For<IUnit>();

        var manager = new UnitManager();
        manager.AddFriendlyUnit(initialUnit);
        manager.AddFriendlyUnit(Substitute.For<IUnit>());
        manager.AddFriendlyUnit(expectedUnit);

        var turnSystem = new TurnSystem();
        var unitActionSystem = new UnitActionSystem(manager, turnSystem);

        unitActionSystem.SelectPreviousUnit();

        unitActionSystem.SelectedUnit.Should().Be(expectedUnit);
    }

    [Test]
    public void SelectNextUnit_WhenPlayerTurn_ShouldSelectNextUnit()
    {
        var initialUnit = Substitute.For<IUnit>();
        var expectedUnit = Substitute.For<IUnit>();

        var manager = new UnitManager();
        manager.AddFriendlyUnit(initialUnit);
        manager.AddFriendlyUnit(expectedUnit);
        manager.AddFriendlyUnit(Substitute.For<IUnit>());

        var turnSystem = new TurnSystem();
        var unitActionSystem = new UnitActionSystem(manager, turnSystem);

        unitActionSystem.SelectNextUnit();

        unitActionSystem.SelectedUnit.Should().Be(expectedUnit);
    }

    [Test]
    public void SelectedUnit_ShouldReturnFirstUnitByDefault()
    {
        var expectedUnit = Substitute.For<IUnit>();

        var manager = new UnitManager();
        manager.AddFriendlyUnit(expectedUnit);
        manager.AddFriendlyUnit(Substitute.For<IUnit>());
        manager.AddFriendlyUnit(Substitute.For<IUnit>());

        var turnSystem = new TurnSystem();
        var unitActionSystem = new UnitActionSystem(manager, turnSystem);

        unitActionSystem.SelectedUnit.Should().Be(expectedUnit);
    }
}
