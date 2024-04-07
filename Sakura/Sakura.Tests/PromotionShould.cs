using FluentAssertions;
using NSubstitute;
using Sakura.Core;
using Sakura.Ranking;
using Sakura.Status;
using Sakura.Units;

namespace Sakura.Tests;

[TestFixture]
public class PromotionShould
{
	private Promotion _promotion;
	private IUnit _unit;

	[SetUp]
	public void Setup()
	{
		_unit = Substitute.For<IUnit>();
		_promotion = new Promotion([
			new RankInfo(Rank.Squaddie, 100),
			new RankInfo(Rank.Corporal, 200)
		]);
	}

	[Test]
	public void Promote_Soldier_To_Next_Rank_When_Experience_Threshold_Reached()
	{
		_unit.Identity.Returns(new Identity("Stacey", "Fakename", "Flight", "Female", "Emotion", Rank.Rookie));
		_unit.Stats.Returns([new Stat("Experience", 100, 1000)]);

		_promotion.AttemptPromotion(_unit);

		_unit.Identity.Rank.Should().Be(Rank.Squaddie);
	}

	[Test]
	public void Not_Promote_Soldier_When_Experience_Threshold_Not_Reached()
	{
		_unit.Identity.Returns(new Identity("Stacey", "Fakename", "Flight", "Female", "Emotion", Rank.Rookie));
		_unit.Stats.Returns([new Stat("Experience", 99, 1000)]);

		_promotion.AttemptPromotion(_unit);

		_unit.Identity.Rank.Should().Be(Rank.Rookie);
	}

	[Test]
	public void Not_Overpromote_Soldier()
	{
		_unit.Identity.Returns(new Identity("Stacey", "Fakename", "Flight", "Female", "Emotion", Rank.Rookie));
		_unit.Stats.Returns([new Stat("Experience", 120, 1000)]);

		_promotion.AttemptPromotion(_unit);

		_unit.Identity.Rank.Should().Be(Rank.Squaddie);
	}
}