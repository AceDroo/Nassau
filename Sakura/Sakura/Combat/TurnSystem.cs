namespace Sakura.Combat;

public class TurnSystem
{
    private int _turnNumber = 1;
    private Turn _currentTurn;

    public event EventHandler TurnChanged;

    public bool IsPlayerTurn() => _currentTurn == Turn.Player;

    public int GetTurnNumber() => _turnNumber;

    public void NextTurn()
    {
        _currentTurn = _currentTurn == Turn.Player ? Turn.Enemy : Turn.Player;
        _turnNumber++;
        TurnChanged?.Invoke(this, EventArgs.Empty); // TODO: Use Event Bus
    }

    public void SetCurrenTurn(Turn turn)
    {
        _currentTurn = turn;
        TurnChanged?.Invoke(this, EventArgs.Empty); // TODO: Use Event Bus
    }
}