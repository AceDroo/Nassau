using TrenchCats.Combat;
using TrenchCats.Status;

namespace Sakura.Units;

public interface IUnit : IDamageable
{
    Flags Flags { get; }
    Stats Stats { get; }
    Identity Identity { get; set; }
    Appearance Appearance { get; }
    IWeapon Weapon { get; }
}