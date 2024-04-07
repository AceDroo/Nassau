using Sakura.Status;

namespace Sakura.Units;

public interface IUnit
{
    Stats Stats { get; }
    Identity Identity { get; set; }
    Appearance Appearance { get; }
}