using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Library.Enums;
using VendingMachine.Library.Exceptions;

namespace VendingMachine.Library.Moduels
{
    public class VendingMachine
    {
        //the size of the containers in the machine
        const int MaxAmountInStock = 5000;

        //a list that implements the INotifyCollectionChanged Interface (for binding)
        public ObservableCollection<Beverage> Menu { get; }
        public IngredientsCollction Stock { get; }
        public decimal Money { get; private set; }

        //the assigment required me to allow to ask the vending machine how many items are in the menu.
        //since I use a collection with dynamic size, and not an array in which i hold a static counter to limit it's size.
        //I simply exposed the Count property in the collection
        public int MenuItemsCount { get { return Menu.Count; } }

        public VendingMachine(Beverage[] menu)
        {
            Menu = new ObservableCollection<Beverage>(menu);
            Stock = new IngredientsCollction();
            Money = default;
            //load the stock with empty ingredients
            LoadAllStockItems();
        }
        internal string PrepareBeverage(Beverage beverage)
        {
            //check selection
            if (beverage == null)
            {
                throw new ArgumentNullException("No Beverage Were Selected");
            }
            //check money
            if (beverage.Price > Money)
            {
                throw new NotEnoughMoneyException(beverage.Price - Money);
            }
            //check stock
            if (!Stock.CanMake(beverage.Recipe, out KeyValuePair<IngredientsEnum, int> missingIngridient))
            {
                throw new IngredientOutOfStockException(missingIngridient.Key, missingIngridient.Value);
            }
            //lower money
            Money -= beverage.Price;

            //make the beverage
            return beverage.Prepare(Stock);
        }
        
        #region Money controls
        //add money
        internal void AddMoney(Coins coin) => Money += (int)coin / 100M;
        //reset money
        internal void ResetMoney() => Money = default;
        #endregion
        #region Menu controls
        //add a beverage to the menu
        internal void AddBeverage(Beverage beverage) => Menu.Add(beverage);
        //remove a beverage from the menu
        internal void RemoveBeverage(Beverage beverage) => Menu.Remove(beverage);
        //if the beverage is in the menu
        internal bool IsInMenu(Beverage beverage) => Menu.Contains(beverage);

        #endregion
        #region Stock control
        //fill all ingredients to max
        internal void Restock()
        {
            Stock.RestockAll(MaxAmountInStock);
        }
        internal void Restock(int amount)
        {
            Stock.RestockAll(amount);
        }
        //fill a spesific ingredient to an amount
        internal void Restock(IngredientsEnum ingredient, int amount) =>
            Stock.Restock(ingredient, Math.Min(Stock[ingredient] + amount, MaxAmountInStock));
        //restock an ingredient to max
        internal void Restock(IngredientsEnum ingredient) =>
            Stock.Restock(ingredient, MaxAmountInStock);

        //simply load the stock with all of the ingredients in the enum (set to 0)
        void LoadAllStockItems()
        {
            foreach (string ingredient in Enum.GetNames(typeof(IngredientsEnum)))
            {
                Stock.Add((IngredientsEnum)Enum.Parse(typeof(IngredientsEnum), ingredient), 0);
            }
        }

        #endregion

    }
}