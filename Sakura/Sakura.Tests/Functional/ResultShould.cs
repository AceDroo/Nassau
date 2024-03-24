using FluentAssertions;
using Sakura.Functional;

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
}