using Sakura.Actions;
using TrenchCats.Combat;
using TrenchCats.Status;

namespace Sakura.Enemies;

public class Enemy : IDamageable
{
    private readonly string _name;
    private IWeapon _weapon;
    private List<ICombatAction> _actions = [];
    private readonly Stats _stats = [];

    public Enemy(EnemyStats enemyStats, IWeapon weapon)
    {
        _name = enemyStats.Name;
        _weapon = weapon;
        _stats.Add("Health", enemyStats.Health);
        _stats.Add("Will", enemyStats.Will);
        _stats.Add("Aim", enemyStats.Aim);
        _stats.Add("Defense", enemyStats.Defense);
    }

    public int CurrentHealth => _stats["Health"].Value;

    public void TakeDamage(int amount)
    {
        _stats["Health"].Decrease(amount);
    }

    public void Heal(int amount)
    {
        _stats["Health"].Increase(amount);
    }

    public Stats Stats => _stats;

    public IWeapon Weapon => _weapon;

    public void AddCombatAction(ICombatAction combatAction)
    {
        _actions.Add(combatAction);
    }

    public IEnumerable<ICombatAction> CombatActions => _actions;
}