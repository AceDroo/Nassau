namespace TrenchCats.Grid;

public readonly struct GridPosition(int x, int z) : IEquatable<GridPosition>
{
	public readonly int X = x;
	public readonly int Z = z;

	public bool Equals(GridPosition other)
	{
		return this == other;
	}

	public override bool Equals(object? obj)
	{
		return obj is GridPosition other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Z);
	}

	public static bool operator ==(GridPosition a, GridPosition b)
	{
		return a.X == b.X && a.Z == b.Z;
	}

	public static bool operator !=(GridPosition a, GridPosition b)
	{
		return !(a == b);
	}

	public static GridPosition operator +(GridPosition a, GridPosition b)
	{
		return new GridPosition(a.X + b.X, a.Z + b.Z);
	}

	public static GridPosition operator -(GridPosition a, GridPosition b)
	{
		return new GridPosition(a.X - b.X, a.Z - b.Z);
	}
}