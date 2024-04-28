using Sakura.Ranking;

namespace Sakura.Units;

[Serializable]
public record Identity(string FirstName, string LastName, string Nickname, string Gender, string Race, Rank Rank);