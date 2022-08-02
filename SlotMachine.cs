using SlotMachineProject.States;

namespace SlotMachineProject;

public class SlotMachine : ISlotMachineState
{
    private ISlotMachineState _state;

    public SlotMachine()
    {
        _state = new MoneyNotInsertedState(null);
    }

    public SlotGame? GetSelectedGame() => _state.GetSelectedGame();

    public void Bet(decimal stake)
    {
        if (_state.GetSelectedGame() is null)
            throw new InvalidOperationException("You have to choose game before you can bet");
        _state.Bet(stake);
        if (_state is MoneyInsertedState && _state.GetCurrentBalance() <= 0)
        {
            Console.WriteLine("Game over");
            _state = new MoneyNotInsertedState(_state.GetSelectedGame());
        }
    }

    public void SelectGame(SlotGame game)
    {
        _state.SelectGame(game);
        Console.WriteLine($"Now you are playing \"{game.Name}\"");
    }

    public decimal GetCurrentBalance() => _state.GetCurrentBalance();
    public void DisplayBalance() => _state.DisplayBalance();

    public void InsertMoney(decimal amount)
    {
        _state.InsertMoney(amount);

        if (_state is MoneyNotInsertedState)
            _state = new MoneyInsertedState(amount, _state.GetSelectedGame());
    }

    public void Withdraw(decimal amount)
    {
        _state.Withdraw(amount);
        if (_state is MoneyInsertedState && _state.GetCurrentBalance() <= 0)
            _state = new MoneyNotInsertedState(_state.GetSelectedGame());
    }

    public void DisplayMatrix() => _state.DisplayMatrix();
}