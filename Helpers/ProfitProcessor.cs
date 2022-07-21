using static SlotMachineProject.Utils.Validations;
namespace SlotMachineProject.Helpers;

public class ProfitProcessor
{
    public decimal Calculate(decimal stake, SlotSymbol[,] matrix)
    {
        ValidateGreaterThanZero(stake, "Stake must be higher than 0");
        var coefficient = 0m;

        for (var rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            var winningSlots = new List<SlotSymbol> { matrix[rowIndex, 0] };
            for (var columnIndex = 1; columnIndex < matrix.GetLength(1); columnIndex++)
            {
                var symbol = matrix[rowIndex, columnIndex];

                if (symbol.IsWildCard || winningSlots.All(s => s.IsWildCard) || winningSlots.Contains(symbol))
                {
                    winningSlots.Add(symbol);
                    continue;
                }
                break;
            }
            if (winningSlots.Count >= 3)
            {
                coefficient += winningSlots.Sum(s => s.Coefficient);
            }
        }

        return stake * coefficient;
    }
}