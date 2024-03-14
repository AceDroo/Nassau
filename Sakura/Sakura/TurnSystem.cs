namespace Sakura;

public class TurnSystem
{
    private int _turnNumber = 1;
    private bool _isPlayerTurn = true;

    public event EventHandler TurnChanged;

    public bool IsPlayerTurn() => _isPlayerTurn;

    public int GetTurnNumber() => _turnNumber;

    public void NextTurn()
    {
        _isPlayerTurn = !_isPlayerTurn;
        _turnNumber++;
        TurnChanged?.Invoke(this, EventArgs.Empty); // TODO: Use Event Bus
    }
}