using System;

namespace BillingSystemExc.Classes
{
    abstract class Customer: IComparable
    {
        // static counter
        public static int CustomerCount { get; private set; } = 0;

        //data members
        double _balance;

        //read only Id, can only be initialized
        public int Id { get; }
        public string Name { get; private set; }
        public double Balance
        {
            get { return _balance; }
            protected set { _balance = value; }
        }

        //full constructor with default parameter balance
        public Customer(string name, double balance = 0)
        {
            Name = name;
            Balance = balance;
            Id = ++CustomerCount;
        }
        //an abstract function decleration, will be implemented by the derived class
        //no need for a specific default
        public abstract void AddToBalance(double amount);

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Balance: {Balance}";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Customer otherCustomer = obj as Customer;
            if (otherCustomer != null)
            {
                return Balance.CompareTo(otherCustomer.Balance);
            }

            else
            {
                throw new ArgumentException($"{obj.GetType()} is not of type {GetType()}");
            }
        }
    }
}