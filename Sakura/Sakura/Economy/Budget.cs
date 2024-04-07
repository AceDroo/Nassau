namespace Sakura.Economy;

public class Budget
{
    private int _balance;

    public Budget(int balance)
    {
        _balance = balance;
    }

    public int Balance => _balance;

    public void Take(int amount)
    {
        _balance -= amount;
    }

    public bool HasFunds(int amount)
    {
        return _balance >= amount;
    }
}