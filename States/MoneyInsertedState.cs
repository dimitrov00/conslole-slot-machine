using SlotMachineProject.Helpers;
using static SlotMachineProject.Utils.Validations;
namespace SlotMachineProject.States;

public class MoneyInsertedState : BaseState
{
    public MoneyInsertedState(decimal amount, SlotGame? game) : base(game)
    {
        ValidateGreaterThanZero(amount, "You cannot enter 0 or negative amount");
        this.Balance = amount;
    }

    public override void Bet(decimal stake)
    {
        ValidateGreaterThanZero(stake, "You cannot have 0 or negative stake");
        ValidateNotGreaterThan(stake, this.Balance, "You cannot have higher stake than your balance");

        var slotMatrix = this.Game!.SlotMatrix.Next();
        var winAmount = ProfitProcessor.Calculate(stake, slotMatrix);
        this.Balance = this.Balance - stake + winAmount;
        DisplayMatrix();
        Console.WriteLine($"You have won: {winAmount}");
        DisplayBalance();
    }

    public override decimal GetCurrentBalance() => this.Balance;

    public override void InsertMoney(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only insert positive amount of money");
        this.Balance += amount;
        Console.WriteLine($"{amount} inserted");
    }

    public override void Withdraw(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only withdraw positive amount of money");
        ValidateNotGreaterThan(amount, this.Balance, "You cannot withdraw more than your balance");

        this.Balance -= amount;
        Console.WriteLine($"{amount} withdrawn");
    }
}