﻿/*refrence to docs for null-conditional operator:
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and
 */
using System;
using System.Text;


namespace BillingSystemExc.Classes
{
    class BillingSystem
    {
        public Customer this[string name]
        {
            get
            {
                for (int i = 0; i < _customers.Length; i++)
                {
                    if (_customers[i].Name.Equals(name))
                    {
                        return _customers[i];
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < _customers.Length; i++)
                {
                    if (_customers[i].Name.Equals(name))
                    {
                        _customers[i] = value;
                    }
                }
            }
        }
        public Customer this[int id, string name]
        {
            get
            {
                for (int i = 0; i < _customers.Length; i++)
                {
                    if (_customers[i].Id.Equals(id))
                    {
                        if (_customers[i].Name.Equals(name))
                        {
                            return _customers[i];
                        }
                        else
                        {
                            throw new ArgumentException($"The name {name} is not the name of the customer with that ID {id}");
                        }
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < _customers.Length; i++)
                {
                    if (_customers[i].Id.Equals(id))
                    {
                        if (_customers[i].Name.Equals(name))
                        {
                            _customers[i] = value;
                        }
                        else
                        {
                            throw new ArgumentException($"The name {name} is not the name of the customer with that ID {id}");
                        }
                    }
                }
            }
        }
        public Customer this[int position]
        {
            get
            {
                return InRange(position) ? _customers[position] :
                    throw new IndexOutOfRangeException($"{position} is not a valid index in the range, max {_customers.Length - 1} ");
            }
            set
            {
                if (!InRange(position))
                {
                    throw new IndexOutOfRangeException($"{position} is not a valid index in the range, max {_customers.Length - 1} ");
                }
                _customers[position] = value;
            }
        }

        const int defaultSize = 100;
        //An array of customers
        private Customer[] _customers;
        //An index to know where to write to the array
        private int _customersIndex;

        //The default value for the size of the array is 100
        public BillingSystem(int customersAmount = defaultSize)
        {
            _customers = new Customer[customersAmount];
            _customersIndex = 0;
        }

        //Add a customer to the billing system's customersArray(by internal index)
        //if out of range do nothing (Assigment didn't specified)
        public void AddCustomer(Customer customer)
        {
            if (_customersIndex >= _customers.Length)
            {
                throw new IndexOutOfRangeException($"Max number of customers reached: {_customers.Length}");
            }
            _customers[_customersIndex++] = customer;
        }
        //Returns a string of all of the customers
        public override string ToString()
        {
            //using the stringbuilder class (we change the specific string)
            StringBuilder sb = new StringBuilder();
            //looping through the customers array and appending it's ToString to the string builder
            //option 1 (for)
            /* using a for loop insted will allow us to loop up to the index of the customers array
             *  in that way we can skip the null check and save on operating cost
             */
            for (int i = 0; i < _customersIndex; i++)
            {
                //in here we now that we have writen data up to this index, so nothing will be null up to the index
                sb.AppendLine(_customers[i].ToString());
            }
            //option 2 (foreach)
            /*using a foreach is limited, wd have to run through all of the array
             * in this case we can't use the tostring function on a null object.
             */
            //foreach (Customer customer in _customers)
            //{
            //    //we can't operate on a null object, so to filter all of the null operations on the array we can use the null-conditional operator '?.'
            //    //which means that if the object is null it will simply return null, if it isn't null it will execute the operation. a refrence to docs at the top
            //    //this is ok since AppendLine can take null objects.
            //    sb.AppendLine(customer?.ToString());
            //}
            return sb.ToString();
        }

        //will add to every customer an amount.
        //each type will have diffrent logic to calculate the exact amount
        public void UpdateBalance(double amount)
        {
            for (int i = 0; i < _customersIndex; i++)
            {
                //there is no fear of getting a null cell, since we loop up to the index
                _customers[i].AddToBalance(amount);
            }
        }
        private bool InRange(int position)
        {
            return position >= 0 && position < _customers.Length;
        }
    }
}
