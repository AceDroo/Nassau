using Sakura.Status;
using TrenchCats.Combat;

namespace Sakura.Units;

public class Unit(Identity identity, Stats stats, Appearance appearance, Flags flags) : IUnit
{
    public Identity Identity
    {
        get => identity;
        set => identity = value;
    }

    public Flags Flags => flags;
    public Stats Stats => stats;
    public Appearance Appearance => appearance;
    public IWeapon Weapon { get; set; }

    public void TakeDamage(int damage)
    {
        stats["Health"].Decrease(damage);
    }

    public void Heal(int amount)
    {
        stats["Health"].Increase(amount);
    }

    public int CurrentHealth => stats["Health"].Value;
}