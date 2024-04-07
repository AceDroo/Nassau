using Sakura.Functional;
using Sakura.Units;

namespace Sakura;

public class Recruitment
{
    private const int UnitRecruitmentCost = 100;
    private int _balance;

    public Recruitment(int balance)
    {
        _balance = balance;
    }

    public int Balance => _balance;

    public Result<IUnit, string> TryRecruitUnit(IUnit unit)
    {
        if (unit == null)
        {
            return Result<IUnit, string>.Err("No unit selected");
        }

        if (_balance < UnitRecruitmentCost)
        {
            return Result<IUnit, string>.Err("Not enough funds to recruit");
        }

        _balance -= UnitRecruitmentCost;
        return Result<IUnit, string>.Ok(unit);
    }
}