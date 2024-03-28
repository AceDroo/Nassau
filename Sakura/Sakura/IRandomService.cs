namespace Sakura;

public interface IRandomService
{
    int Next(int max);
    int Next(int min, int max);
    T Choose<T>(T[] array);
}