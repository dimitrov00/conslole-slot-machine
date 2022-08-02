namespace SlotMachineProject.Providers;

public class WithdrawMoneyOptionProvider : ISlotMachineOptionProvider
{
    private readonly ISlotMachineState _slotMachine;

    public WithdrawMoneyOptionProvider(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);
        _slotMachine = slotMachine;
    }

    public string OptionName { get; } = "Withdraw money";

    public void Execute()
    {
        Console.Write("Amount to withdraw: ");
        if (!decimal.TryParse(Console.ReadLine(), out var amount))
        {
            Console.WriteLine("Invalid amount");
            return;
        }

        _slotMachine.Withdraw(amount);
    }
}