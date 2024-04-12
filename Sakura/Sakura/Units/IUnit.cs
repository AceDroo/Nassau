using Sakura.Core;
using Sakura.Status;
using Sakura.Weapons;

namespace Sakura.Units;

public interface IUnit : IDamageable
{
    Stats Stats { get; }
    Identity Identity { get; set; }
    Appearance Appearance { get; }
    IWeapon Weapon { get; set; }
}