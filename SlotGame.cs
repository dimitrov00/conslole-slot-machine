using static SlotMachineProject.Utils.Validations;

namespace SlotMachineProject;

public class SlotGame
{
    public SlotGame(string name, int rows, int reels, IEnumerable<SlotSymbol> symbols)
    {
        ValidateNotNullOrEmpty(name, "Name should not be empty");
        ValidateNotNullOrEmpty(symbols, "Symbols are required in order to create game");

        Name = name;
        Symbols = symbols.ToList();
        SlotMatrix = new SlotMatrix(rows, reels, Symbols);
    }

    public string Name { get; }
    public IList<SlotSymbol> Symbols { get; }
    public SlotMatrix SlotMatrix { get; }
}