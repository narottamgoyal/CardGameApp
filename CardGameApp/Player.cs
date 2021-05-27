using CardGameApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameApp
{
    public class Player
    {
        /// <summary>
        /// Default is set to true, This will be useful, in case of more than 2 players
        /// </summary>
        public bool IsAlive { get; set; } = true;
        public int Score { get; set; }
        public int DrawPileCount { get { return DrawPile.Count; } }
        public readonly int PlayerNumber;
        private Stack<Card> DrawPile = new Stack<Card>();
        private List<Card> DiscardPile = new List<Card>();
        public Player(int playerNumber, List<Card> cards)
        {
            PlayerNumber = playerNumber;
            DrawPile = (cards != null && cards.Any()) ? new Stack<Card>(cards) : throw new Exception(ErrorMessages.PlayerWithNoCard);
        }

        /// <summary>
        /// DrawCard will return the top card from draw pile.
        /// If draw pile is empty then it will move all the cards
        /// from discard pile after shuffling. if any.
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            return DrawPile.Any() ? DrawPile.Pop() : GetFromDiscardPile();
        }

        /// <summary>
        /// This method will return the top card after shuffling and moving all the cards
        /// from discard pile to draw pile. if discard pile is empty then it throw
        /// EmptyDrawPileException
        /// </summary>
        /// <returns></returns>
        private Card GetFromDiscardPile()
        {
            if (!DiscardPile.Any())
            {
                var ex = new EmptyDrawPileException();
                ex.PlayerNumber = PlayerNumber;
                throw ex;
            }
            Util.ShuffleByFisherYatesAlgo(DiscardPile);
            DrawPile = new Stack<Card>(DiscardPile);
            DiscardPile = new List<Card>();
            return DrawPile.Pop();
        }

        /// <summary>
        /// This method will add used or played cards to discard pile.
        /// </summary>
        /// <param name="cards"></param>
        public void AddToDiscardPile(List<Card> cards)
        {
            DiscardPile.AddRange(cards);
        }

        public override string ToString()
        {
            return $"Player: {PlayerNumber}, \t Score: {Score},\t Draw Pile: {DrawPile.Count},\t Discard Pile: {DiscardPile.Count}";
        }
    }
}
