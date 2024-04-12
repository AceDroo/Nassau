using Sakura.Units;

namespace Sakura.Weapons;

public interface IWeapon
{
    void Use(IUnit unit);
}