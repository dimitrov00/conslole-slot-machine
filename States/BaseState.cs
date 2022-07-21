using System.ComponentModel.DataAnnotations;

namespace SlotMachineProject.States;

public abstract class BaseState : ISlotMachineState
{
    public BaseState(SlotGame? game)
    {
        _game = game;
    }

    protected decimal _balance = 0;
    public SlotGame? _game;

    public virtual void Bet(decimal stake) { }
    public virtual void SelectGame(SlotGame? game)
    {
        ArgumentNullException.ThrowIfNull(game);
        _game = game;
    }

    public virtual decimal GetCurrentBalance() => _balance;
    public virtual void InsertMoney(decimal amount) { }
    public virtual void Withdraw(decimal amount) { }

    public SlotGame? GetSelectedGame() => _game;
    public void DisplayBalance()
    {
        Console.WriteLine($"Current balance is: {_balance}");
    }

    public void DisplayMatrix()
    {
        if (_game is null)
        {
            Console.WriteLine("Select game first");
            return;
        }

        Console.WriteLine(_game.SlotMatrix.ToString());
    }
}