using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsExc
{
    class Card
    {
        const int topRange = 13;
        const int bottomRange = 1;

        private int _number;
        public int Number
        {
            get { return _number; }
            private set 
            {
                if (!IsNumberValid(value))
                {
                    throw new IllegalCardException($"{value} is not a valid card number",topRange, bottomRange);
                }
                _number = value; 
            }
        }

        public CardSuit Suit { get; private set; }

        public Card(int number, CardSuit suit)
        {
            Number = number;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Number,2} of {Suit}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
               Card card = obj as Card;
                return card.Number == Number && card.Suit == Suit;
            }
            return false;
        }

        bool IsNumberValid(int number)
        {
            return number >= bottomRange && number <= topRange;
        }
    }
}
