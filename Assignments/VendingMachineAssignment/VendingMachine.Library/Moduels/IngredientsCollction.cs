using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Library.Enums;

namespace VendingMachine.Library.Moduels
{
    //The Collection used to encapsulate the Dictionary
    //used as both stock and as a recipe

    public class IngredientsCollction:IEnumerable<KeyValuePair<IngredientsEnum,int>>
    {
        //inner collection
        Dictionary<IngredientsEnum, int> _inerCollection;

        public IngredientsCollction()
        {
            _inerCollection = new Dictionary<IngredientsEnum, int>();
        }
        //indexer
        public int this[IngredientsEnum ingredient]
        {
            get
            {
                return _inerCollection[ingredient];
            }
            private set
            {
                _inerCollection[ingredient] = value;
            }
        }
        //add an amount to an ingrtedient
        internal void Add(IngredientsEnum ingredient, int amount)
        {
            _inerCollection.Add(ingredient, amount);
        }
        //add an ingredient to the collection
        internal void AddAmountToIngredient(IngredientsEnum ingredient,int amount)
        {
            this[ingredient] = Math.Max(this[ingredient] + amount, 0);
        }
        //reset an ingredient to 0
        internal void ResetAmount (IngredientsEnum ingredient)
        {
            this[ingredient] = 0;
        }
        //check if the collection contains the parameter collection
        internal bool CanMake(IngredientsCollction recipe, out KeyValuePair<IngredientsEnum, int> missingIngredinet)
        {
            foreach (var ingredient in recipe._inerCollection)
            {
                //check if available in stock
                if (ingredient.Value > _inerCollection[ingredient.Key])
                {
                    missingIngredinet = new KeyValuePair<IngredientsEnum, int>
                        (ingredient.Key, ingredient.Value - _inerCollection[ingredient.Key]);
                    return false;
                }
            }
                return true;
        }
        //allow to use an ingredient
        internal void UseIngredient(KeyValuePair<IngredientsEnum,int> ingredient)
        {
            this[ingredient.Key] -= ingredient.Value;
        }
        #region Interface implementation
        //Since I want to expose all of the items in the dictionary, I can simply expose the dictionary's enumerator.
        public IEnumerator<KeyValuePair<IngredientsEnum, int>> GetEnumerator()
        {
            return _inerCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
        #endregion
        //remove an ingredint from the collection
        internal void Remove(IngredientsEnum ingredient)
        {
            _inerCollection.Remove(ingredient);
        }
        //restock all of the items in the collction
        internal void RestockAll(int amount)
        {
            //get an array of the ingredients in the collection
            IngredientsEnum[] ingredients = _inerCollection.Keys.ToArray();
            foreach (IngredientsEnum ingredient in ingredients)
            {
                //restock each ingredient to max 
                Restock(ingredient, amount);
            }
        }
        //restock an ingrdient to an amount
        internal void Restock(IngredientsEnum ingredient,int amount)
        {
            this[ingredient] = amount;
        }
    }
}