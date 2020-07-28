using System;

namespace CardsExc
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();
            do
            {
                Console.WriteLine(deck);
                Console.WriteLine("taking out a random card...");
                Console.WriteLine($"picked: {deck.Get()}");
                Console.Write("Take another? (Y): ");
            } while (Console.ReadLine() == "Y");


        }
    }
}
