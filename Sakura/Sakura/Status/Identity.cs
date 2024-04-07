using Sakura.Ranking;

namespace Sakura.Status;

[Serializable]
public record Identity(string FirstName, string LastName, string Nickname, string Gender, string Race, Rank Rank);