using SlotMachineProject.Helpers;
using System.Text;
using static SlotMachineProject.Utils.Validations;

namespace SlotMachineProject;

public class SlotMatrix
{
    private readonly int _rows;
    private readonly int _reels;
    private readonly IEnumerable<SlotSymbol> _symbols;

    public SlotSymbol[,]? Matrix { get; private set; }
    public SlotMatrix(int rows, int reels, IEnumerable<SlotSymbol> symbols)
    {
        ValidateGreaterThanZero(rows, "Rows must be greater than 0");
        ValidateGreaterThanZero(reels, "Reels must be greater than 0");
        ValidateNotNullOrEmpty(symbols, "Symbols are required in order to create matrix");

        _rows = rows;
        _reels = reels;
        _symbols = symbols;
        Matrix = new SlotSymbol[_rows, _reels];
        Next();
    }

    public SlotMatrix Next()
    {
        var random = new RandomSymbolGenerator(_symbols);
        for (var rowIndex = 0; rowIndex < _rows; rowIndex++)
        {
            for (var reelIndex = 0; reelIndex < _reels; reelIndex++)
            {
                Matrix[rowIndex, reelIndex] = random.Generate();
            }
        }
        return this;
    }

    public static implicit operator SlotSymbol[,](SlotMatrix slotMatrix) => slotMatrix.Matrix;
    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Matrix.GetLength(0); i++)
        {
            for (var j = 0; j < Matrix.GetLength(1); j++)
            {
                sb.Append($"| {Matrix[i, j].Symbol} |".PadRight(5));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}