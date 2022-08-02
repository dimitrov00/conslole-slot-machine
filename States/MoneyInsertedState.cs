using SlotMachineProject.Helpers;
using static SlotMachineProject.Utils.Validations;

namespace SlotMachineProject.States;

public class MoneyInsertedState : BaseState
{
    public MoneyInsertedState(decimal amount, SlotGame? game) : base(game)
    {
        ValidateGreaterThanZero(amount, "You cannot enter 0 or negative amount");
        Balance = amount;
    }

    public override void Bet(decimal stake)
    {
        ValidateGreaterThanZero(stake, "You cannot have 0 or negative stake");
        ValidateNotGreaterThan(stake, Balance, "You cannot have higher stake than your balance");

        var slotMatrix = Game!.SlotMatrix.Next();
        var winAmount = ProfitProcessor.Calculate(stake, slotMatrix);
        Balance = Balance - stake + winAmount;
        DisplayMatrix();
        Console.WriteLine($"You have won: {winAmount}");
        DisplayBalance();
    }

    public override decimal GetCurrentBalance() => Balance;

    public override void InsertMoney(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only insert positive amount of money");
        Balance += amount;
        Console.WriteLine($"{amount} inserted");
    }

    public override void Withdraw(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only withdraw positive amount of money");
        ValidateNotGreaterThan(amount, Balance, "You cannot withdraw more than your balance");

        Balance -= amount;
        Console.WriteLine($"{amount} withdrawn");
    }
}