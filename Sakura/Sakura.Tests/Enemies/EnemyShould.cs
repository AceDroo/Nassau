using FluentAssertions;
using NSubstitute;
using Sakura.Actions;
using Sakura.Enemies;
using TrenchCats.Combat;

namespace Sakura.Tests.Enemies;

[TestFixture]
[TestOf(typeof(Enemy))]
public class EnemyShould
{

    [Test]
    public void Reduce_Health_When_Taking_Damage()
    {
        var weapon = Substitute.For<IWeapon>();
        var stats = new EnemyStats("Enemy", 100, 10, 10, 10);
        var enemy = new Enemy(stats, weapon);

        enemy.TakeDamage(10);

        enemy.CurrentHealth.Should().Be(90);
    }

    [Test]
    public void Increase_Health_When_Healing()
    {
        var weapon = Substitute.For<IWeapon>();
        var stats = new EnemyStats("Enemy", 100, 10, 10, 10);
        var enemy = new Enemy(stats, weapon);

        enemy.Stats["Health"].Value = 90;

        enemy.Heal(10);

        enemy.CurrentHealth.Should().Be(100);
    }

    [Test]
    public void Return_Current_Weapon()
    {
        var weapon = Substitute.For<IWeapon>();
        var stats = new EnemyStats("Enemy", 100, 10, 10, 10);
        var enemy = new Enemy(stats, weapon);

        enemy.Weapon.Should().Be(weapon);
    }

    [Test]
    public void Successfully_Add_Combat_Action()
    {
        var weapon = Substitute.For<IWeapon>();
        var stats = new EnemyStats("Enemy", 100, 10, 10, 10);
        var enemy = new Enemy(stats, weapon);

        var action = Substitute.For<ICombatAction>();

        enemy.AddCombatAction(action);

        enemy.CombatActions.Should().Contain(action);
    }
}