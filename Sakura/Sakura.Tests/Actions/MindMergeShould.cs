using FluentAssertions;
using NSubstitute;
using Sakura.Actions;
using Sakura.Units;
using TrenchCats.Status;

namespace Sakura.Tests.Actions;

[TestFixture]
public class MindMergeShould
{
    [Test]
    public void Increase_Unit_Stats_When_MindMerging()
    {
        var mindMerge = new MindMerge();
        var unit = Substitute.For<IUnit>();
        unit.Stats.Returns([
            new Stat("Health", 5, 7),
            new Stat("Will", 10, 20)
        ]);

        mindMerge.Execute(unit);

        unit.Stats["Health"].Value.Should().Be(7);
        unit.Stats["Will"].Value.Should().Be(20);
    }
}