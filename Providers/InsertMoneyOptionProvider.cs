namespace SlotMachineProject.Providers;

public class InsertMoneyOptionProvider : ISlotMachineOptionProvider
{
    private readonly ISlotMachineState _slotMachine;

    public InsertMoneyOptionProvider(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);
        _slotMachine = slotMachine;
    }

    public string OptionName { get; } = "Insert money";

    public void Execute()
    {
        Console.Write("Insert amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out var amount))
        {
            Console.WriteLine("Invalid amount");
            return;
        }

        _slotMachine.InsertMoney(amount);
    }
}