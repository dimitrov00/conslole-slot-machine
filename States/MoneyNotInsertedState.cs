namespace SlotMachineProject.States;

public class MoneyNotInsertedState : BaseState
{
    public MoneyNotInsertedState(SlotGame? game) : base(game) { }

    public override void Bet(decimal stake) => Console.WriteLine("You cannot place a bet");

    public override decimal GetCurrentBalance() => 0;

    public override void InsertMoney(decimal amount) => Console.WriteLine($"You have inserted {amount}");

    public override void Withdraw(decimal amount) => Console.WriteLine("You do not have money to withdraw");
}