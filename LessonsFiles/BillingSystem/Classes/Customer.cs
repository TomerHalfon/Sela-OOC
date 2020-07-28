using System;

namespace BillingSystemExc.Classes
{
    abstract class Customer: IComparable, IComparable<Customer>
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
                return -1;
            }
            if (obj is Customer otherCustomer)
            {
                return Name.CompareTo(otherCustomer.Name);
            }
            throw new ArgumentException($"{obj.GetType()} is not of type {GetType()}");
        }

        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                return -1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}