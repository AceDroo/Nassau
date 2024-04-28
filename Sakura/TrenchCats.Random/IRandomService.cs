namespace TrenchCats.Random;

public interface IRandomService
{
    int Next(int minValue, int maxValue);
}