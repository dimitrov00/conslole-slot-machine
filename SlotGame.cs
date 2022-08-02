using static SlotMachineProject.Utils.Validations;

namespace SlotMachineProject;

public class SlotGame
{
    public SlotGame(string name, int rows, int reels, IEnumerable<SlotSymbol> symbols)
    {
        ValidateNotNullOrEmpty(name, "Name should not be empty");
        ValidateNotNullOrEmpty(symbols, "Symbols are required in order to create game");

        this.Name = name;
        this.Symbols = symbols.ToList();
        this.SlotMatrix = new SlotMatrix(rows, reels, symbols);
    }

    public string Name { get; init; }
    public IList<SlotSymbol> Symbols { get; init; }
    public SlotMatrix SlotMatrix { get; init; }
}