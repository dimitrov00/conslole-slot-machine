namespace SlotMachineProject.States;

public abstract class BaseState : ISlotMachineState
{
    protected decimal Balance = 0;
    protected SlotGame? Game;

    protected BaseState(SlotGame? game)
    {
        Game = game;
    }

    public virtual void Bet(decimal stake) { }

    public virtual void SelectGame(SlotGame? game)
    {
        ArgumentNullException.ThrowIfNull(game);
        Game = game;
    }

    public virtual decimal GetCurrentBalance() => Balance;

    public virtual void InsertMoney(decimal amount) { }
    public virtual void Withdraw(decimal amount) { }

    public SlotGame? GetSelectedGame() => Game;

    public void DisplayBalance() => Console.WriteLine($"Current balance is: {Balance}");

    public void DisplayMatrix()
    {
        if (Game is null)
        {
            Console.WriteLine("Select game first");
            return;
        }

        Console.WriteLine(Game.SlotMatrix.ToString());
    }
}