using FluentAssertions;
using NSubstitute;
using Sakura.Combat;
using Sakura.Units;

namespace Sakura.Tests.Units;

[TestFixture]
public class UnitActionSystemShould
{
    [Test]
    public void Do_Nothing_When_SelectPreviousUnit_And_Not_Player_Turn()
    {
        var unit1 = Substitute.For<IUnit>();
        var unit2 = Substitute.For<IUnit>();
        
        var turnSystem = new TurnSystem();

        var unitManager = new UnitManager();
        unitManager.AddFriendlyUnit(unit1);
        unitManager.AddFriendlyUnit(unit2);
        var manager = new UnitActionSystem(unitManager, turnSystem);

        turnSystem.SetCurrenTurn(Turn.Enemy);

        manager.SelectPreviousUnit();

        manager.SelectedUnit.Should().Be(unit1);
    }

    [Test]
    public void Do_Nothing_When_SelectNextUnit_And_Not_Player_Turn()
    {
        var unit1 = Substitute.For<IUnit>();
        var unit2 = Substitute.For<IUnit>();
        
        var turnSystem = new TurnSystem();

        var unitManager = new UnitManager();
        unitManager.AddFriendlyUnit(unit1);
        unitManager.AddFriendlyUnit(unit2);
        var manager = new UnitActionSystem(unitManager, turnSystem);

        turnSystem.SetCurrenTurn(Turn.Enemy);

        manager.SelectNextUnit();

        manager.SelectedUnit.Should().Be(unit1);
    }

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
        var monitor = unitActionSystem.Monitor();

        unitActionSystem.SelectPreviousUnit();

        unitActionSystem.SelectedUnit.Should().Be(expectedUnit);
        monitor
            .Should().Raise(nameof(unitActionSystem.UnitSelected))
            .WithSender(unitActionSystem)
            .WithArgs<UnitSelectedArgs>(args => args.Unit == expectedUnit);
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

        var monitor = unitActionSystem.Monitor();
        
        unitActionSystem.SelectNextUnit();

        unitActionSystem.SelectedUnit.Should().Be(expectedUnit);
        monitor
            .Should().Raise(nameof(unitActionSystem.UnitSelected))
            .WithSender(unitActionSystem)
            .WithArgs<UnitSelectedArgs>(args => args.Unit == expectedUnit);
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
