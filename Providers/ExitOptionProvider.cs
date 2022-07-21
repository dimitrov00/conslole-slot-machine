namespace SlotMachineProject.Providers;

public class ExitOptionProvider : ISlotMachineOptionProvider
{
    public string OptionName { get; } = "Exit";

    public void Execute() => Environment.Exit(0);
}