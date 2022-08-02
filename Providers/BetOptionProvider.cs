namespace SlotMachineProject.Providers;

public class BetOptionProvider : ISlotMachineOptionProvider
{
    private readonly ISlotMachineState _slotMachine;

    public BetOptionProvider(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);
        _slotMachine = slotMachine;
    }

    public string OptionName { get; } = "Bet";

    public void Execute()
    {
        Console.Write("Stake amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out var amount))
        {
            Console.WriteLine("Invalid amount");
            return;
        }
        _slotMachine.Bet(amount);
    }
}