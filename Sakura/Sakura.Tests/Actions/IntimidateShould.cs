using FluentAssertions;
using NSubstitute;
using Sakura.Actions;
using Sakura.Status;
using Sakura.Units;

namespace Sakura.Tests.Actions;

[TestFixture]
public class IntimidateShould
{
    [Test]
    public void Intimidate_Opponent_When_Successful()
    {
        var randomService = Substitute.For<IRandomService>();
        randomService.Next(0, 10).Returns(1);
        var enemy = Substitute.For<IUnit>();
        Stats stats = new Stats();
        stats.Add("Will", 5, 5);
        enemy.Stats.Returns(stats);
        var intimidate = new Intimidate(enemy, randomService);
        
        var target = Substitute.For<IUnit>();
        target.Flags.Returns(new Flags());
        intimidate.Execute(target);

        target.Flags["Panic"].Should().BeTrue();
    }

    [Test]
    public void Do_Nothing_When_Unsuccessful()
    {
        var randomService = Substitute.For<IRandomService>();
        randomService.Next(0, 10).Returns(9);
        var enemy = Substitute.For<IUnit>();
        Stats stats = new Stats();
        stats.Add("Will", 5, 5);
        enemy.Stats.Returns(stats);
        var intimidate = new Intimidate(enemy, randomService);
        
        var target = Substitute.For<IUnit>();
        target.Flags.Returns(new Flags());
        intimidate.Execute(target);

        target.Flags["Panic"].Should().BeFalse();
    }
}