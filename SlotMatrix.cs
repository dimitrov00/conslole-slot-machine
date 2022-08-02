using SlotMachineProject.Helpers;
using System.Text;
using static SlotMachineProject.Utils.Validations;

namespace SlotMachineProject;

public class SlotMatrix
{
    private readonly RandomSymbolGenerator _randomSymbolGenerator;
    private readonly int _reels;
    private readonly int _rows;

    public SlotMatrix(int rows, int reels, IEnumerable<SlotSymbol> symbols)
    {
        ValidateGreaterThanZero(rows, "Rows must be greater than 0");
        ValidateGreaterThanZero(reels, "Reels must be greater than 0");
        ValidateNotNullOrEmpty(symbols, "Symbols are required in order to create matrix");

        _rows = rows;
        _reels = reels;
        _randomSymbolGenerator = new RandomSymbolGenerator(symbols);

        Matrix = new SlotSymbol[_rows, _reels];
        Next();
    }

    public SlotSymbol[,] Matrix { get; }

    public SlotMatrix Next()
    {
        for (var row = 0; row < _rows; row++)
            for (var reel = 0; reel < _reels; reel++)
                Matrix[row, reel] = _randomSymbolGenerator.Generate();
        return this;
    }

    public static implicit operator SlotSymbol[,](SlotMatrix slotMatrix) => slotMatrix.Matrix;

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var row = 0; row < Matrix.GetLength(0); row++)
        {
            for (var reel = 0; reel < Matrix.GetLength(1); reel++)
                sb.Append($"| {Matrix[row, reel].Symbol} |".PadRight(5));
            sb.AppendLine();
        }

        return sb.ToString();
    }
}