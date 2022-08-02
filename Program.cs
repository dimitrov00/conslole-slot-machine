using SlotMachineProject;
using SlotMachineProject.Providers;

var symbols = new List<SlotSymbol>
{
    new('A', 0.4m, 45, false), new('B', 0.6m, 35, false), new('P', 0.8m, 15, false), new('*', 0m, 5, true)
};

var slotMachine = new SlotMachine();
var slotGame = new SlotGame("Fancy game name", 4, 3, symbols);
slotMachine.SelectGame(slotGame);

var optionProviderFactory = new SlotMachineOptionProviderFactory(slotMachine);
var options = optionProviderFactory.AvailableOptions;

while (true)
{
    Console.WriteLine(string.Join(Environment.NewLine, options.Select((option, index) => $"{index}: {option}")));
    Console.Write("Choose an option: ");
    try
    {
        if (!int.TryParse(Console.ReadLine(), out var chosenOption)) throw new ArgumentException("Invalid option");
        if (chosenOption < 0 || chosenOption > options.Count - 1) throw new ArgumentException("Invalid option");

        var provider = optionProviderFactory.GetOptionProvider(options[chosenOption]);
        provider.Execute();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}