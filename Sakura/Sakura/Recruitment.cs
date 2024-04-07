using Sakura.Economy;
using Sakura.Functional;
using Sakura.Units;

namespace Sakura;

public class Recruitment
{
    private const int UnitRecruitmentCost = 100;
    private readonly Budget _budget;

    public Recruitment(Budget budget)
    {
        _budget = budget;
    }

    public Result<IUnit, string> TryRecruitUnit(IUnit unit)
    {
        if (unit == null)
        {
            return Result<IUnit, string>.Err("No unit selected");
        }

        if (!_budget.HasFunds(UnitRecruitmentCost))
        {
            return Result<IUnit, string>.Err("Not enough funds to recruit");
        }

        _budget.Take(UnitRecruitmentCost);
        return Result<IUnit, string>.Ok(unit);
    }
}