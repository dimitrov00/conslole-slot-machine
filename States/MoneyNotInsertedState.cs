namespace SlotMachineProject.States
{
    public class MoneyNotInsertedState : BaseState, ISlotMachineState
    {
        public MoneyNotInsertedState(SlotGame? game) : base(game)
        {
        }

        public void Bet(decimal stake)
        {
            Console.WriteLine($"You cannot place a bet");
        }

        public decimal GetCurrentBalance() => 0;
        public void InsertMoney(decimal amount)
        {
            Console.WriteLine($"You have inserted {amount}");
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"You do not have money to withdraw");
        }
    }
}