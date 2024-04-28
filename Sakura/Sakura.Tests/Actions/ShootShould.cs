using NSubstitute;
using Sakura.Actions;
using Sakura.Units;
using TrenchCats.Combat;
using TrenchCats.Random;
using TrenchCats.Status;

namespace Sakura.Tests.Actions;

[TestFixture]
public class ShootShould
{
    [Test]
    public void Fire_Gun_At_Enemy_When_Hit()
    {
        var randomService = Substitute.For<IRandomService>();
        randomService.Next(0, 100).Returns(10);

        var weapon = Substitute.For<IWeapon>();

        var unit = Substitute.For<IUnit>();
        Stats stats =
        [
            new Stat("Aim", 6, 6)
        ];
        unit.Stats.Returns(stats);
        unit.Weapon.Returns(weapon);
        var shoot = new Shoot(unit, randomService);

        var target = Substitute.For<IUnit>();
        shoot.Execute(target);

        weapon.Received().Use(target);
    }

    [Test]
    public void Do_Nothing_If_Miss()
    {
        var randomService = Substitute.For<IRandomService>();
        randomService.Next(0, 100).Returns(90);

        var weapon = Substitute.For<IWeapon>();

        var unit = Substitute.For<IUnit>();
        Stats stats =
        [
            new Stat("Aim", 6, 6)
        ];
        unit.Stats.Returns(stats);
        unit.Weapon.Returns(weapon);
        var shoot = new Shoot(unit, randomService);

        var target = Substitute.For<IUnit>();
        shoot.Execute(target);

        weapon.DidNotReceive().Use(target);
    }
}