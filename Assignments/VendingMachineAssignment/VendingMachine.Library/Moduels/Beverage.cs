using System.Text;
using VendingMachine.Library.Enums;


namespace VendingMachine.Library.Moduels
{
    public abstract class Beverage
    {
        //beverage data
        public string Name { get; }
        public string Image { get; }
        public decimal Price { get; private set; }
        public IngredientsCollction Recipe { get; }

        StringBuilder _sb;

        protected Beverage(string name, string image, decimal price)
        {
            Name = name;
            Image = image;
            Price = price;
            Recipe = new IngredientsCollction
            {
                { IngredientsEnum.Sugar, 0 }
            };
        }
        //prepare to beverage based on the data known and by overrides in the derived class
        internal string Prepare(IngredientsCollction stock)
        {
            string res = $"Making: {Name}\n{AddIngredients(stock)}\n{Stir()}";
            //reset sugar
            Recipe.ResetAmount(IngredientsEnum.Sugar);
            return res;
        }
        //adding all of the ingredients in the Recipe
        private string AddIngredients(IngredientsCollction stock)
        {
            _sb = new StringBuilder("Adding:\n");
            
            foreach (var ingredient in Recipe)
            {
                if (ingredient.Value != 0)
                {
                    //create the string
                    _sb.AppendLine($"{ingredient.Value} {ingredient.Key}");
                    //use ingredient
                    stock.UseIngredient(ingredient);
                }
            }
            return _sb.ToString();
        }
        //stir the drink
        protected virtual string Stir()
        {
            return $"Stirring {Name}";
        }
        
        //as the assigment demanded
        public override bool Equals(object obj)
        {
            if (!(obj is Beverage beverage))
            {
                return false;
            }
            return beverage.Name.Equals(Name);
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
