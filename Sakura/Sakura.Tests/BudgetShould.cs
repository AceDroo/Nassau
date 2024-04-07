using FluentAssertions;
using Sakura.Economy;

namespace Sakura.Tests;

[TestFixture]
public class BudgetShould
{
    [Test]
    public void Start_With_Initial_Balance()
    {
        var budget = new Budget(100);
        budget.Balance.Should().Be(100);
    }

    [Test]
    public void Return_True_If_Have_Enough_Funds()
    {
        var budget = new Budget(100);
        budget.HasFunds(99).Should().BeTrue();
    }

    [Test]
    public void Return_False_If_Not_Have_Enough_Funds()
    {
        var budget = new Budget(100);
        budget.HasFunds(1000).Should().BeFalse();
    }

    [Test]
    public void Reduce_Balance_When_Taking()
    {
        var budget = new Budget(100);

        budget.Take(50);

        budget.Balance.Should().Be(50);
    }
}