using NSubstitute;
using Sakura.Actions;
using Sakura.Units;

namespace Sakura.Tests.Actions;

[TestFixture]
public class HealShould
{
    [Test]
    public void Increase_Unit_Health()
    {
        var heal = new Heal(3);
        var unit = Substitute.For<IUnit>();

        heal.Execute(unit);

        unit.Received().Heal(3);
    }
}