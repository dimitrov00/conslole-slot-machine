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
        this.SlotMatrix = new SlotMatrix(rows, reels, this.Symbols);
    }

    public string Name { get; }
    public IList<SlotSymbol> Symbols { get; }
    public SlotMatrix SlotMatrix { get; }
}