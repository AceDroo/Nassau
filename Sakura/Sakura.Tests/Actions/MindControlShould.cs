using FluentAssertions;
using NSubstitute;
using Sakura.Actions;
using Sakura.Units;
using TrenchCats.Random;
using TrenchCats.Status;

namespace Sakura.Tests.Actions;

[TestFixture]
[TestOf(typeof(MindControl))]
public class MindControlShould
{
    [Test]
    public void MindControl_Opponent_When_Successful()
    {
        var randomService = Substitute.For<IRandomService>();
        randomService.Next(0, 10).Returns(1);
        var enemy = Substitute.For<IUnit>();
        Stats stats = new Stats();
        stats.Add("Will", 5, 5);
        enemy.Stats.Returns(stats);
        var intimidate = new MindControl(enemy, randomService);
        
        var target = Substitute.For<IUnit>();
        target.Flags.Returns(new Flags());
        intimidate.Execute(target);

        target.Flags["Controlled"].Should().BeTrue();
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
        var intimidate = new MindControl(enemy, randomService);
        
        var target = Substitute.For<IUnit>();
        target.Flags.Returns(new Flags());
        intimidate.Execute(target);

        target.Flags["Controlled"].Should().BeFalse();
    }
}