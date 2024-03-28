using Sakura.Ranking;
using Sakura.Status;

namespace Sakura.Core;

public interface IUnit
{
    Stats Stats { get; }
    Rank Rank { get; set; }
}