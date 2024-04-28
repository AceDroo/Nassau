using FluentAssertions;
using NSubstitute;
using Sakura.Units;
using Sakura.Weapons;
using TrenchCats.Random;

namespace Sakura.Tests.Weapons;

[TestFixture]
public class GunShould
{
    [Test]
    public void Deal_Damage_To_Take_When_Shooting()
    {
        var randomService = Substitute.For<IRandomService>();
        var stats = new GunStats("Gun", 5, 10, 10);
        var gun = new Gun(stats, randomService);
        var unit = Substitute.For<IUnit>();

        randomService.Next(5, 10).Returns(10);

        gun.Use(unit);

        unit.Received().TakeDamage(10);
    }

    [Test]
    public void Reduce_Ammo_Amount_When_Shooting()
    {
        var randomService = Substitute.For<IRandomService>();
        var stats = new GunStats("Gun", 5, 10, 10);
        var gun = new Gun(stats, randomService);
        var unit = Substitute.For<IUnit>();

        randomService.Next(5, 10).Returns(10);

        gun.Use(unit);

        gun.Stats["Ammo"].Value.Should().Be(9);
    }

    [Test]
    public void Refill_Ammo_When_Reload()
    {
        var randomService = Substitute.For<IRandomService>();
        var stats = new GunStats("Gun", 5, 10, 10);
        var gun = new Gun(stats, randomService);
        var unit = Substitute.For<IUnit>();

        gun.Use(unit);
        gun.Use(unit);
        gun.Use(unit);

        gun.Reload();

        gun.Stats["Ammo"].Value.Should().Be(10);
    }
}