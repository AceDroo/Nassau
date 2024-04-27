using TrenchCats.Combat;

namespace Sakura.Weapons;

public class Claws(int amount) : IWeapon
{
    public void Use(IDamageable target)
    {
        target.TakeDamage(amount);
    }
}