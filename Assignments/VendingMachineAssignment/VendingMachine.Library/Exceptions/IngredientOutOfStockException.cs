using System;
using VendingMachine.Library.Enums;

namespace VendingMachine.Library.Exceptions
{
    //used to show which ingredient is missing and how much is missing
    class IngredientOutOfStockException : Exception
    {
        public IngredientOutOfStockException() { }
        public IngredientOutOfStockException(string message) : base(message) { }
        public IngredientOutOfStockException(string message, Exception inner) : base(message, inner) { }
        public IngredientOutOfStockException(IngredientsEnum ingredient, int amountMissing)
        {
            Ingredient = ingredient;
            AmountMissing = amountMissing;
        }
        public IngredientsEnum Ingredient { get; }
        public int AmountMissing { get; }
    }
}
