using FluentAssertions;
using NSubstitute;
using Sakura.Actions;
using Sakura.Units;
using Sakura.Weapons;

namespace Sakura.Tests.Actions;

[TestFixture]
public class ReloadShould
{
    [Test]
    public void Refill_Gun()
    {
        var stats = new GunStats("Gun", 10, 10, 10);
        var random = Substitute.For<IRandomService>();
        var gun = new Gun(stats, random);
        var unit = Substitute.For<IUnit>();
        unit.Weapon.Returns(gun);

        gun.Use(Substitute.For<IUnit>());

        var reload = new Reload();

        reload.Execute(unit);

        gun.Stats["Ammo"].Value.Should().Be(10);
    }
}