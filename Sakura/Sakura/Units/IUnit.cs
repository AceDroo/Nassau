using Sakura.Core;
using Sakura.Status;

namespace Sakura.Units;

public interface IUnit : IDamageable
{
    Stats Stats { get; }
    Identity Identity { get; set; }
    Appearance Appearance { get; }
}