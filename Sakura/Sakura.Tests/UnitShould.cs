using FluentAssertions;
using Sakura.Ranking;
using Sakura.Units;
using TrenchCats.Status;

namespace Sakura.Tests;

[TestFixture]
public class UnitShould
{
    [Test]
    public void Reduce_Health_When_Taking_Damage()
    {
        var identity = new Identity("Sakura", "Kinomoto", "Sakura", "Female", "Human", Rank.Rookie);
        Stats stats = [new Stat("Health", 100, 100)];
        var appearance = new Appearance(1, 1, 1, 1, 1);
        var unit = new Unit(identity, stats, appearance, new Flags());

        unit.TakeDamage(10);

        unit.CurrentHealth.Should().Be(90);
    }

    [Test]
    public void Increase_Health_When_Healing()
    {
        var identity = new Identity("Sakura", "Kinomoto", "Sakura", "Female", "Human", Rank.Rookie);
        Stats stats = [new Stat("Health", 90, 100)];
        var appearance = new Appearance(1, 1, 1, 1, 1);
        var unit = new Unit(identity, stats, appearance, new Flags());

        unit.Heal(10);

        unit.CurrentHealth.Should().Be(100);
    }
}