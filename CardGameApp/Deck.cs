using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameApp
{
    /// <summary>
    /// Deck of cards
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// List of card in the deck
        /// </summary>
        private readonly List<Card> Cards = new List<Card>();
        public Deck(List<Card> cards)
        {
            if (cards == null || !cards.Any()) throw new Exception(CustomeMessages.DeckWithNoCardError);
            Cards.AddRange(cards);
        }

        /// <summary>
        /// Shuffle all the cards
        /// </summary>
        public void Shuffle()
        {
            Util.ShuffleByFisherYatesAlgo(Cards);
        }

        /// <summary>
        /// Distribute cards from the deck
        /// </summary>
        /// <param name="noOfCards"></param>
        /// <returns></returns>
        public List<Card> GetCards(int noOfCards)
        {
            var cards = Cards.TakeLast(noOfCards).ToList();
            cards.ForEach(x => Cards.Remove(x));
            return cards;
        }
    }
}
