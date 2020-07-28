using System;
using System.Collections.Generic;
using System.Text;

namespace CardsExc
{
    class Deck
    {
        const int defaultSize = 52;

        Card[] _cards;
        List<Card> _removedCards;

        public Deck()
        {
            _cards = CreateFullDeck();
            _removedCards = new List<Card>();
        }
        public Card Get()
        {
            Random rng = new Random();
            Card card;
            int index;
            int maxSuit = Enum.GetNames(typeof(CardSuit)).Length;

            do
            {
                int value = rng.Next(1, 14);
                CardSuit suit = (CardSuit)rng.Next(1, maxSuit);
                card = new Card(value, suit);
            } while (_removedCards.Contains(card));

            try
            {
               index = Array.IndexOf(_cards, card);
            }
            catch (ArgumentNullException e)
            {
                throw new EmptyDeckException("The Deck Was Empty!", this, e);
            }
            _removedCards.Add(card);
            _cards[index] = null;
            return card;
        }
        
        public bool IsEmpty()
        {
            foreach (Card card in _cards)
            {
                if (card != null)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"--------------------\n{_cards.Length - _removedCards.Count} cards in the Deck\n--------------------\n");
            foreach (Card card in _cards)
            {
                if (card == null)
                {
                    continue;
                }
                sb.AppendLine(card?.ToString());
            }
            return sb.ToString();
        }
        Card[] CreateFullDeck()
        {
            string[] suits = Enum.GetNames(typeof(CardSuit));
            Card[] results = new Card[defaultSize];

            int cardValueCounter = 1;
            int cardSuitCounter = 0;

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = new Card(cardValueCounter, (CardSuit)cardSuitCounter);

                if (cardSuitCounter < suits.Length - 1)
                {
                    cardSuitCounter++;
                }
                else
                {
                    cardSuitCounter = 0;
                }
                if (cardValueCounter < 13)
                {
                    cardValueCounter++;
                }
                else
                {
                    cardValueCounter = 1;
                }
            }
            return results;
        }

    }
}
