using Sakura.Actions;
using Sakura.Status;
using Sakura.Units;
using TrenchCats.Combat;

namespace Sakura.Enemies;

public class Enemy : IUnit
{
    private IWeapon _weapon;
    private List<ICombatAction> _actions = [];
    private readonly Stats _stats = new();

    public string Name { get; set; }

    public Enemy(EnemyStats enemyStats, IWeapon weapon, Identity identity, Appearance appearance)
    {
        Name = enemyStats.Name;
        _weapon = weapon;
        Identity = identity;
        Appearance = appearance;
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
    public Identity Identity { get; set; }

    public Appearance Appearance { get; }

    public IWeapon Weapon
    {
        get => _weapon;
        set => _weapon = value;
    }

    public void AddCombatAction(ICombatAction combatAction)
    {
        _actions.Add(combatAction);
    }

    public List<ICombatAction> CombatActions => _actions;
}