namespace SlotMachineProject;

public interface ISlotMachineState
{
    void InsertMoney(decimal amount);
    void Withdraw(decimal amount);
    void Bet(decimal stake);
    decimal GetCurrentBalance();
    void SelectGame(SlotGame game);
    SlotGame? GetSelectedGame();
    void DisplayBalance();
    void DisplayMatrix();
}