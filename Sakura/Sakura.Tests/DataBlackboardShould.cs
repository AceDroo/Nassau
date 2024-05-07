using FluentAssertions;
using TrenchCats.Core;

namespace Sakura.Tests;

[TestFixture]
public class DataBlackboardShould
{
    [Test]
    public void Set_KeyValue_Pair_And_Return_Correct_Value()
    {
        var blackboard = new DataBlackboard();

        blackboard.SetData("TEST", 1);

        blackboard.GetData<int>("TEST").Should().Be(1);
    }

    [Test]
    public void Return_Default_If_No_Value_For_Given_Key_Is_Found()
    {
        var blackboard = new DataBlackboard();

        blackboard.GetData<int>("TEST").Should().Be(0);
    }
}