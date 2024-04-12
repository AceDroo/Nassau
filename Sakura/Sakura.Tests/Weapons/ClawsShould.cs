using NSubstitute;
using Sakura.Units;
using Sakura.Weapons;

namespace Sakura.Tests.Weapons;

[TestFixture]
public class ClawsShould
{
    [Test]
    public void Deal_Damage_To_Target_When_Used()
    {
        var claws = new Claws(10);

        var unit = Substitute.For<IUnit>();
        claws.Use(unit);

        unit.Received().TakeDamage(10);
    }
}