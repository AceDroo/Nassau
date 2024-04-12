using NSubstitute;
using Sakura.Actions;
using Sakura.Units;

namespace Sakura.Tests.Actions;

[TestFixture]
public class PsiAttackShould
{
    [Test]
    public void Damage_Enemy_Unit()
    {
        var psiAttack = new PsiAttack();

        var unit = Substitute.For<IUnit>();
        psiAttack.Execute(unit);

        unit.Received().TakeDamage(5);
    }
}