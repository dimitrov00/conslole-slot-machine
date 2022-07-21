using SlotMachineProject.Helpers;
using static SlotMachineProject.Utils.Validations;
namespace SlotMachineProject.States;

public class MoneyInsertedState : BaseState, ISlotMachineState
{
    public MoneyInsertedState(decimal amount, SlotGame? game) : base(game)
    {
        ValidateGreaterThanZero(amount, "You cannot enter 0 or negative amount");
        _balance = amount;
    }

    public override void Bet(decimal stake)
    {
        ValidateGreaterThanZero(stake, "You cannot have 0 or negative stake");
        ValidateNotGreaterThan(stake, _balance, "You cannot have higher stake than your balance");

        var slotMatrix = _game!.SlotMatrix.Next();
        var profitProcessor = new ProfitProcessor();
        var winAmount = profitProcessor.Calculate(stake, slotMatrix);
        _balance = _balance - stake + winAmount;
        DisplayMatrix();
        Console.WriteLine($"You have won: {winAmount}");
        DisplayBalance();
    }

    public override decimal GetCurrentBalance() => _balance;

    public override void InsertMoney(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only insert positive amount of money");
        _balance += amount;
        Console.WriteLine($"{amount} inserted");
    }

    public override void Withdraw(decimal amount)
    {
        ValidateGreaterThanZero(amount, "You can only withdraw positive amount of money");
        ValidateNotGreaterThan(amount, _balance, "You cannot withdraw more than your balance");

        _balance -= amount;
        Console.WriteLine($"{amount} withdrawn");
    }
}