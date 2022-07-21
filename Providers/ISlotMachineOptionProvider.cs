namespace SlotMachineProject.Providers;

public interface ISlotMachineOptionProvider
{
    string OptionName { get; }
    void Execute();
}