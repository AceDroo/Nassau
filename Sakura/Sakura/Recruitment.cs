using Sakura.Economy;
using Sakura.Units;
using TrenchCats.Functional;

namespace Sakura;

public class Recruitment
{
    private const int UnitRecruitmentCost = 100;
    private readonly Budget _budget;

    public Recruitment(Budget budget)
    {
        _budget = budget;
    }

    public Result<IUnit, string> TryRecruitUnit(Option<IUnit> unit)
    {
        if (!unit.IsPresent())
        {
            return Result<IUnit, string>.Err("No unit selected");
        }

        if (!_budget.HasFunds(UnitRecruitmentCost))
        {
            return Result<IUnit, string>.Err("Not enough funds to recruit");
        }

        _budget.Take(UnitRecruitmentCost);
        return Result<IUnit, string>.Ok(unit.Get());
    }
}