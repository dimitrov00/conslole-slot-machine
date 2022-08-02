namespace SlotMachineProject.Providers;

public class DisplayBalanceOptionProvider : ISlotMachineOptionProvider
{
    private readonly ISlotMachineState _slotMachine;

    public DisplayBalanceOptionProvider(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);
        _slotMachine = slotMachine;
    }

    public string OptionName { get; } = "Display balance";

    public void Execute() => _slotMachine.DisplayBalance();
}