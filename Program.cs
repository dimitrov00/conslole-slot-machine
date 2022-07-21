using SlotMachineProject;
using SlotMachineProject.Providers;

var symbols = new List<SlotSymbol>
{
    new SlotSymbol('A', 0.4m, 45, false),
    new SlotSymbol('B', 0.6m, 35, false),
    new SlotSymbol('P', 0.8m, 15, false),
    new SlotSymbol('*', 0m, 5, true)
};

var slotMachine = new SlotMachine();
var slotGame = new SlotGame("Fancy game name", 4, 3, symbols);
slotMachine.SelectGame(slotGame);
var optionProviderFactory = new SlotMachineOptionProviderFactory(slotMachine);
var options = optionProviderFactory.AvailableOptions;

while (true)
{
    Console.WriteLine(string.Join(Environment.NewLine, options.Select((o, i) => $"{i}: {o}")));
    Console.Write("Choose an option: ");
    if (!int.TryParse(Console.ReadLine(), out var option))
    {
        Console.WriteLine("Invalid option");
        continue;
    }
    if (option < 0 || option > options.Count - 1)
    {
        Console.WriteLine("Invalid option");
        continue;
    }
    try
    {
        var provider = optionProviderFactory.GetOptionProvider(options[option]);
        provider.Execute();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
