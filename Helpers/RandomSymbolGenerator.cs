using static SlotMachineProject.Utils.Validations;
namespace SlotMachineProject.Helpers;

public class RandomSymbolGenerator
{
    private readonly IReadOnlyList<SlotSymbol> _symbols;

    public RandomSymbolGenerator(IEnumerable<SlotSymbol> symbols)
    {
        ValidateNotNullOrEmpty(symbols, "Symbols are required in order to generate random");
        _symbols = symbols.OrderBy(s => s.Probability).ToList();
    }

    public SlotSymbol Generate()
    {
        var random = new Random().Next(0, 100);
        var cumulative = 0.0;

        for (var i = 0; i < _symbols.Count; i++)
        {
            var symbol = _symbols[i];
            cumulative += symbol.Probability;
            if (random < cumulative)
            {
                return symbol;
            }
        }

        return _symbols[_symbols.Count - 1];
    }
}
