using VendingMachine.Library.Moduels;

//allows the creation of custom dirnks.

namespace VendingMachine.Library.Beverages
{
    class CustomBeverage : Beverage
    {
        const string image = "Assets/Beverages/CostomeDrink.png";
        public CustomBeverage(string name, decimal price) : base(name, image, price)
        {
        }
        protected override string Stir()
        {
            return $"Stirring a custom Beverage named {Name} in a custom way...";
        }
    }
}
