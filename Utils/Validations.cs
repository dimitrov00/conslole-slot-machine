namespace SlotMachineProject.Utils;

public static class Validations
{
    public static void ValidateNotGreaterThan(decimal numberToCheck, decimal number, string message)
    {
        if (numberToCheck > number) throw new ArgumentException(message);
    }

    public static void ValidateGreaterThanZero(decimal number, string message)
    {
        if (number <= 0) throw new ArgumentException(message);
    }

    public static void ValidateNotNullOrEmpty<T>(IEnumerable<T>? collection, string message)
    {
        if (!collection?.Any() ?? true) throw new ArgumentException(message);
    }

    public static void ValidateNotNullOrEmpty(string str, string message)
    {
        if (string.IsNullOrEmpty(str)) throw new ArgumentException(message);
    }
}