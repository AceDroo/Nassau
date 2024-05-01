using FluentAssertions;
using NSubstitute;
using Sakura.Economy;
using Sakura.Units;

namespace Sakura.Tests.Units;

[TestFixture]
public class RecruitmentShould
{
    [Test]
    public void Return_Error_When_Attempting_To_Recruit_But_No_Unit_Selected()
    {
        var recruitment = new Recruitment(new Budget(100));

        var result = recruitment.TryRecruitUnit(null);

        result.IsError.Should().BeTrue();
        result.Error.Should().Be("No unit selected");
    }

    [Test]
    public void Return_Error_When_Attempting_To_Recruit_But_Lack_Funds()
    {
        var recruitment = new Recruitment(new Budget(99));

        var unit = Substitute.For<IUnit>();
        var result = recruitment.TryRecruitUnit(unit);

        result.IsError.Should().BeTrue();
        result.Error.Should().Be("Not enough funds to recruit");
    }

    [Test]
    public void Return_Success_When_Unit_Successfully_Recruited()
    {
        var recruitment = new Recruitment(new Budget(100));

        var unit = Substitute.For<IUnit>();
        var result = recruitment.TryRecruitUnit(unit);

        result.IsError.Should().BeFalse();
        result.Success.Should().Be(unit); 
    }

    [Test]
    public void Subtract_Recruitment_Cost_From_Balance_When_Unit_Successfully_Recruited()
    {
        var budget = new Budget(100);
        var recruitment = new Recruitment(budget);

        var unit = Substitute.For<IUnit>();
        recruitment.TryRecruitUnit(unit);

        budget.Balance.Should().Be(0);
    }
}