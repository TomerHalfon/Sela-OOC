using VendingMachine.Library.Moduels;

namespace VendingMachine.Library.Beverages
{
    class Tea : Beverage
    {
        //using consts to load the ctor of the base class is ok only because the compiler handles it.
        //it isn't a case of initializing the base class with fields from the derived class.
        //The main reason to load the data like this is readability
        //and making sure this specific beverage can not be initialized with a diffrent name, Image or price

        const string name = "Tea";
        const string image = "Assets/Beverages/Tea.png";
        const decimal price = 12;
        public Tea() : base(name, image, price)
        {
            //load the recipe.
            //it't initialized in the base class.
            Recipe.Add(Enums.IngredientsEnum.TeaLeaves, 20);
            Recipe.Add(Enums.IngredientsEnum.Water, 200);
        }
        protected override string Stir()
        {
            //since the base class holds the recipe there isn't a need to override the add ingredients method.
            //I've asked Michal about this in class the answer was that I can override the stir function to stir the drink in a unique way.
            //the main idea is to show that I can use polymorphism and understand the idea of overriding a function
            return $"Stirring a {Name} in it's unique way...";
        }
    }
}
