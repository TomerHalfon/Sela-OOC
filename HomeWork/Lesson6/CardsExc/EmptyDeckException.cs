using System;

namespace CardsExc
{
    internal class EmptyDeckException : Exception
    {
        public EmptyDeckException() {}
        public EmptyDeckException(string message) : base(message) { }
        public EmptyDeckException(string message, Exception innerException) : base(message, innerException) { }


        public EmptyDeckException(Deck deck){ Deck = deck; }
        public EmptyDeckException(string message, Deck deck) : base(message) { Deck = deck; }
        public EmptyDeckException(string message, Deck deck, Exception innerException) : base(message, innerException) { Deck = deck; }

        public Deck Deck { get;}
    }
}