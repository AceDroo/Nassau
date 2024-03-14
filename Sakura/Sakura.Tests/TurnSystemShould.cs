using FluentAssertions;

namespace Sakura.Tests;

[TestFixture]
public class TurnSystemShould
{
    private TurnSystem _turnSystem;

    [SetUp]
    public void Setup()
    {
        _turnSystem = new TurnSystem();
    }

    [Test]
    public void Start_On_Player_Turn()
    {
        _turnSystem.IsPlayerTurn().Should().BeTrue();
    }

    [Test]
    public void Start_On_Turn_One()
    {
        _turnSystem.GetTurnNumber().Should().Be(1);
    }

    [Test]
    public void Increase_Turn_Number_When_NextTurn()
    {
        _turnSystem.NextTurn();

        _turnSystem.GetTurnNumber().Should().Be(2);
    }

    [Test]
    public void Go_To_Enemy_Turn_When_NextTurn()
    {
        _turnSystem.NextTurn();

        _turnSystem.IsPlayerTurn().Should().BeFalse();
    }

    [Test]
    public void Go_Back_To_Player_Turn_When_NextTurn_Twice()
    {
        _turnSystem.NextTurn();
        _turnSystem.NextTurn();

        _turnSystem.IsPlayerTurn().Should().BeTrue();
    }

    [Test]
    public void Invoke_OnTurnChanged_Event_When_NextTurn()
    {
        using var turnSystemMonitor = _turnSystem.Monitor();

        _turnSystem.NextTurn();

        turnSystemMonitor.Should().Raise("TurnChanged")
            .WithSender(_turnSystem);
    }
}