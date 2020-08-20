using System;

namespace VendingMachine.Library.Exceptions
{
    //used to alert the user the his missing an amount of money
    class NotEnoughMoneyException : Exception
    {
        public decimal MoneyMissing { get; }
        public NotEnoughMoneyException() { }
        public NotEnoughMoneyException(string message) : base(message) { }
        public NotEnoughMoneyException(string message, Exception inner) : base(message, inner) { }
        public NotEnoughMoneyException(decimal moneyMissing)
        {
            MoneyMissing = moneyMissing;
        }
    }
}
