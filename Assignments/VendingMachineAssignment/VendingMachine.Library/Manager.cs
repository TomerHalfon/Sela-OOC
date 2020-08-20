using System;
using VendingMachine.Library.Beverages;
using VendingMachine.Library.Enums;
using VendingMachine.Library.Exceptions;
using VendingMachine.Library.Moduels;

namespace VendingMachine.Library
{
    public class Manager
    {
        public Moduels.VendingMachine VendingMachine { get; }

        //all the default beverages
        public Beverage[] DefaultBeverages = new Beverage[]
        {
            //beverages go here
            new Espresso(),
            new Americano(),
            new Cappuccino(),
            new ChocolateMilk(),
            new Tea()
        };

        public Manager()
        {
            VendingMachine = new Moduels.VendingMachine(DefaultBeverages);
        }

        #region Money controls
        public string GetMoney() => string.Format("{0:C}", VendingMachine.Money);
        public string AddMoney(Coins coin)
        {
            VendingMachine.AddMoney(coin);
            return $"Payed {((int)coin / 100M):C}";
        }
        public string ReturnMoney()
        {
            VendingMachine.ResetMoney();
            return $"Returned all coins";
        }
        #endregion
        #region Menu controls
        public string AddBeverageToMenu(Beverage beverage)
        {
            if (beverage == null)
            {
                return $"No beverage was selected";
            }
            if (VendingMachine.IsInMenu(beverage))
            {
                return $"{beverage} is allready in the menu";
            }
            VendingMachine.AddBeverage(beverage);
            return $"Add {beverage} to the menu";
        }
        public string RemoveFromMenu(Beverage beverage)
        {
            VendingMachine.RemoveBeverage(beverage);
            return $"Removed {beverage} from the menu";
        }
        public string CreateBeverage(string name, decimal price)
        {
            VendingMachine.AddBeverage(new CustomBeverage(name, price));
            return $"Created {name}";
        }
        #endregion
        #region Stock controls
        public string RestockMachine()
        {
            VendingMachine.Restock();
            return $"Restocked all to max";
        }
        public string RestockMachineToAmount(int amount)
        {
            VendingMachine.Restock(amount);
            return $"Restocked all to {amount}";
        }
        public string RestockIngredient(IngredientsEnum ingredient, int amount)
        {
            VendingMachine.Restock(ingredient, amount);
            return $"Restocked {ingredient},added {amount}";
        }
        public string RestockIngredient(IngredientsEnum ingredient)
        {
            VendingMachine.Restock(ingredient);
            return $"Restocked {ingredient} to max";
        }

        #endregion
        #region Recipe controls
        public string UpdateIngredientAmountInRecipe(Beverage beverage, IngredientsEnum ingredient, int amount)
        {
            try
            {
                beverage.Recipe.AddAmountToIngredient(ingredient, amount);
            }
            catch (Exception)
            {
                return $"Select an ingredient first";
            }
            return $"Added {amount} {ingredient} to {beverage}";
        }
        public string RemoveIngredientFromRecipe(Beverage beverage, IngredientsEnum ingredient)
        {
            //dont allow the user to delete the sugar from the recipe.
            if (ingredient.Equals(IngredientsEnum.Sugar))
            {
                return $"All Beverages must have sugar in the recipe!";
            }
            try
            {
                beverage.Recipe.Remove(ingredient);
            }
            catch (Exception)
            {
                //if an ingreidnet wasn't selected.
                //or for some reason the ingredient isn't in the dictionery
                //(Shouldn't happen but catching the base class Exception will catch all excaptions)
                return $"Select an ingredient first";
            }
            return $"Removed {ingredient} from {beverage}'s recipe";
        }
        public string AddIngredientToRecipe(Beverage beverage, IngredientsEnum ingredient)
        {
            try
            {
                beverage.Recipe.Add(ingredient, 0);
            }
            catch (NullReferenceException)
            {
                return $"Select an ingredient first";
            }
            catch (Exception)
            {
                return $"{ingredient} is allready in {beverage}'s recipe";

            }
            return $"Added {ingredient} to {beverage}'s recipe";
        }
        #endregion

        //make the beverage(handle the exceptions)
        public string Prepare(Beverage beverage, int sugarAmount)
        {
            try
            {
                //set the sugar in the recipe to user's choice
                beverage.Recipe.AddAmountToIngredient(IngredientsEnum.Sugar, sugarAmount);
                //prepare
                return VendingMachine.PrepareBeverage(beverage);
            }
            catch (NotEnoughMoneyException e)
            {
                return $"Not enough money, missing {e.MoneyMissing:C}";
            }
            catch (IngredientOutOfStockException e)
            {
                return $"Can't prepare {beverage.Name}, missing {e.AmountMissing} {e.Ingredient}";
            }
            catch (NullReferenceException)
            {
                return $"Select a drink first";
            }
        }
    }
}