using BillingSystemExc.Interfaces;

namespace BillingSystemExc.Classes
{
    class MarketingPerson : IAdressable
    {
        public string Name { get; private set; }
        public string Adress { get; private set; }

        public string GetAdress()
        {
            return $"Adress: {Adress}";
        }
    }
}
