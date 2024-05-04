namespace Sakura.Units;

public class UnitSelectedArgs(IUnit unit) : EventArgs
{
    public IUnit Unit { get; } = unit;
}