using FluentAssertions;
using TrenchCats.Functional;

namespace Sakura.Tests.Functional;

[TestFixture]
public class ResultShould
{
    [Test]
    public void Return_Success_And_Is_Not_Error_When_Ok()
    {
        var result = Result<int, string>.Ok(1);
        result.Success.Should().Be(1);
        result.IsError.Should().BeFalse();
    }

    [Test]
    public void Return_Error_And_Is_Error_When_Err()
    {
        var result = Result<int, string>.Err("An error has occured!");
        result.Error.Should().Be("An error has occured!");
        result.IsError.Should().BeTrue();
    }

    [Test]
    public void Match_Should_Invoke_SuccessHandler_When_Result_Is_Success()
    {
        var result = Result<int, string>.Ok(42);
        var actual = result.Match(
            onSuccess: success => success.ToString(),
            onError: error => throw new Exception("Should not be called")
        );

        actual.Should().Be("42");
    }

    [Test]
    public void Match_Should_Invoke_ErrorHandler_When_Result_Is_Error()
    {
        var result = Result<int, string>.Err("Error");
        var actual = result.Match(
            onSuccess: success => throw new Exception("Should not be called"),
            onError: error => error.ToUpper()
        );

        actual.Should().Be("ERROR");
    }

    [Test]
    public void Map_Should_Transform_Success_Value_When_Result_Is_Success()
    {
        var result = Result<int, string>.Ok(42);
        var mappedResult = result.Map(success => success * 2);

        mappedResult.Should().BeEquivalentTo(Result<int, string>.Ok(84));
    }

    [Test]
    public void Map_Should_Not_Transform_Error_Value_When_Result_Is_Error()
    {
        var result = Result<int, string>.Err("Error");
        var map = result.Map<int>(_ => throw new Exception("Should not be called"));

        map.Should().BeEquivalentTo(Result<int, string>.Err("Error"));
    }

    [Test]
    public void Reduce_Should_Return_Success_Value_When_Result_Is_Success()
    {
        var result = Result<int, string>.Ok(42);
        var reducedValue = result.Reduce(
            onSuccess: success => success * 2,
            onError: error => throw new Exception("Should not be called")
        );

        reducedValue.Should().Be(84);
    }

    [Test]
    public void Reduce_Should_Return_Error_Value_When_Result_Is_Error()
    {
        var result = Result<int, string>.Err("Error");
        var reducedValue = result.Reduce(
            onSuccess: success => throw new Exception("Should not be called"),
            onError: error => error.ToUpper()
        );

        reducedValue.Should().Be("ERROR");
    }
}