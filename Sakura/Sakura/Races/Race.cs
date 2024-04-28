using TrenchCats.Core;

namespace Sakura.Races;

[Serializable]
public record Race(
    string RaceName,
    string[] FirstNames,
    string[] LastNames, 
    string[] Genders,
    RangedInt Health,
    RangedInt Accuracy,
    RangedInt Defense,
    RangedInt Speed);