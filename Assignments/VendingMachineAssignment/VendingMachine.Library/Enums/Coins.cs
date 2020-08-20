
namespace VendingMachine.Library.Enums
{
    //the payment method in the machine.
    //since an enum can't have a decimal value, i've multiplied it by a 100
    public enum Coins
    {
        Half = 50,
        One = 100,
        Two = 200,
        Five = 500,
        Ten = 1000
    }
}
