using FluentAssertions;
using TrenchCats.Functional;

namespace Sakura.Tests.Functional;

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

    [Test]
    public void Match_Some_ReturnsSomeResult()
    {
        var option = Option<int>.Some(10);

        var result = option.Match(
            val => val * 2,
            () => -1
        );

        result.Should().Be(20);
    }

    [Test]
    public void Match_None_ReturnsNoneResult()
    {
        var option = Option<int>.None();

        var result = option.Match(
            val => val * 2,
            () => -1
        );

        result.Should().Be(-1);
    }

    [Test]
    public void IfNone_Some_ReturnsOptionWithValue()
    {
        var option = Option<int>.Some(10);

        var result = option.IfNone(() => 5);

        result.IsPresent().Should().BeTrue();
        result.Get().Should().Be(10);
    }

    [Test]
    public void IfNone_None_ReturnsOptionWithDefaultValue()
    {
        var option = Option<int>.None();

        var result = option.IfNone(() => 5);

        result.IsPresent().Should().BeTrue();
        result.Get().Should().Be(5);
    }

    [Test]
    public void Then_Some_ReturnsMappedOption()
    {
        var option = Option<int>.Some(10);

        var result = option.Then(val => val * 2);

        result.IsPresent().Should().BeTrue();
        result.Get().Should().Be(20);
    }

    [Test]
    public void Then_None_ReturnsNone()
    {
        var option = Option<int>.None();

        var result = option.Then(val => val * 2);

        result.IsPresent().Should().BeFalse();
    }

    [Test]
    public void Map_Some_ReturnsMappedOption()
    {
        var option = Option<string>.Some("hello");

        var result = option.Map(str => str.ToUpper());

        result.IsPresent().Should().BeTrue();
        result.Get().Should().Be("HELLO");
    }

    [Test]
    public void Map_None_ReturnsNone()
    {
        var option = Option<string>.None();

        var result = option.Map(str => str.ToUpper());

        result.IsPresent().Should().BeFalse();
    }

    [Test]
    public void Reduce_Some_ReturnsValue()
    {
        var option = Option<int>.Some(10);

        var result = option.Reduce(5);

        result.Should().Be(10);
    }

    [Test]
    public void Reduce_None_ReturnsOrElseValue()
    {
        var option = Option<int>.None();

        var result = option.Reduce(5);

        result.Should().Be(5);
    }
}