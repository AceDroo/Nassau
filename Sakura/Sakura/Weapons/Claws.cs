using Sakura.Units;

namespace Sakura.Weapons;

public class Claws : IWeapon
{
    private readonly int _amount;

    public Claws(int amount)
    {
        _amount = amount;
    }

    public void Use(IUnit unit)
    {
        unit.TakeDamage(_amount);
    }
}