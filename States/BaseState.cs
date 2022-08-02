namespace SlotMachineProject.States;

public abstract class BaseState : ISlotMachineState
{
    protected decimal Balance = 0;
    protected SlotGame? Game;

    protected BaseState(SlotGame? game)
    {
        this.Game = game;
    }

    public virtual void Bet(decimal stake) { }

    public virtual void SelectGame(SlotGame? game)
    {
        ArgumentNullException.ThrowIfNull(game);
        this.Game = game;
    }

    public virtual decimal GetCurrentBalance() => this.Balance;

    public virtual void InsertMoney(decimal amount) { }
    public virtual void Withdraw(decimal amount) { }

    public SlotGame? GetSelectedGame() => this.Game;

    public void DisplayBalance()
    {
        Console.WriteLine($"Current balance is: {this.Balance}");
    }

    public void DisplayMatrix()
    {
        if (this.Game is null)
        {
            Console.WriteLine("Select game first");
            return;
        }

        Console.WriteLine(this.Game.SlotMatrix.ToString());
    }
}