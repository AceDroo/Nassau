using FluentAssertions;

namespace Sakura.Tests;

[TestFixture]
public class OptionShould
{
    [Test]
    public void Return_False_If_Not_Present()
    {
        var none = Option<int>.None();
        none.IsPresent().Should().BeFalse();
    }

    [Test]
    public void Return_True_If_Present()
    {
        var some = Option<int>.Some(1);
        some.IsPresent().Should().BeTrue();
    }

    [Test]
    public void Return_Value_For_Some()
    {
        var some = Option<int>.Some(1);
        some.Get().Should().Be(1);
    }

    [Test]
    public void Throw_Exception_When_Return_Value_For_None()
    {
        var act = () => Option<int>.None().Get();
        act.Should().Throw<InvalidOperationException>();
    }
}