using Sakura.Units;

namespace Sakura.Ranking;

public class Promotion(List<RankInfo> ranks)
{
	public void AttemptPromotion(IUnit unit)
	{
		ranks.ForEach(rankInfo =>
		{
			if (!CanPromote(unit, rankInfo)) return;
			unit.Identity = unit.Identity with { Rank = rankInfo.Rank };
		});
	}

	private bool CanPromote(IUnit soldier, RankInfo rank)
	{
		var stat = soldier.Stats["Experience"];
		return stat.Value >= rank.Threshold;
	}
}