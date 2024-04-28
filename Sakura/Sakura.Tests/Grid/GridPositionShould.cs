using FluentAssertions;
using TrenchCats.Grid;

namespace Sakura.Tests.Grid;

public class GridPositionShould
{
	[Test]
	public void Add_Two_Positions_Correctly()
	{
		var position1 = new GridPosition(2, 3);
		var position2 = new GridPosition(4, 5);

		var position3 = position1 + position2;

		position3.X.Should().Be(6);
		position3.Z.Should().Be(8);
	}

	[Test]
	public void Subtract_Two_Positions_Correctly()
	{
		var position1 = new GridPosition(6, 8);
		var position2 = new GridPosition(2, 3);

		var position3 = position1 - position2;

		position3.X.Should().Be(4);
		position3.Z.Should().Be(5);
	}

	[Test]
	public void Return_False_If_Two_Positions_Are_Not_Equal_For_Equality()
	{
		var position1 = new GridPosition(6, 8);
		var position2 = new GridPosition(2, 3);

		(position1 == position2).Should().BeFalse();
		position1.Equals(position2).Should().BeFalse();
	}

	[Test]
	public void Return_True_If_Two_Positions_Are_Equal_For_Equality()
	{
		var position1 = new GridPosition(2, 3);
		var position2 = new GridPosition(2, 3);

		(position1 == position2).Should().BeTrue();
		position1.Equals(position2).Should().BeTrue();
	}

	[Test]
	public void Return_True_If_Two_Positions_Are_Not_Equal_For_Inequality()
	{
		var position1 = new GridPosition(6, 8);
		var position2 = new GridPosition(2, 3);

		(position1 != position2).Should().BeTrue();
	}

	[Test]
	public void Return_False_If_Two_Positions_Are_Equal_For_Inequality()
	{
		var position1 = new GridPosition(2, 3);
		var position2 = new GridPosition(2, 3);

		(position1 != position2).Should().BeFalse();
	}
}