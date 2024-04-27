using Sakura.Status;
using TrenchCats.Combat;

namespace Sakura.Units;

public interface IUnit : IDamageable
{
    Flags Flags { get; }
    Stats Stats { get; }
    Identity Identity { get; set; }
    Appearance Appearance { get; }
    IWeapon Weapon { get; }
}