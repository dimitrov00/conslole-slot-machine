namespace SlotMachineProject.Providers;

public class DisplayMatrixOptionProvider : ISlotMachineOptionProvider
{
    private readonly ISlotMachineState _slotMachine;

    public DisplayMatrixOptionProvider(ISlotMachineState slotMachine)
    {
        ArgumentNullException.ThrowIfNull(slotMachine);
        _slotMachine = slotMachine;
    }

    public string OptionName { get; } = "Display matrix";

    public void Execute() => _slotMachine.DisplayMatrix();
}