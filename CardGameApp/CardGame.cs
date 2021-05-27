using CardGameApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameApp
{
    /// <summary>
    /// CardGame
    /// </summary>
    public class CardGame
    {
        private int NoOfPlayer;
        /// <summary>
        /// Clubs, Spades, Hearts, Diamonds
        /// </summary>
        private int MaxCardNoOfEachType;
        private int NoOfCardPerPlayer;
        private Deck Deck;
        /// <summary>
        /// PlayedCard will temparaly keep the card in case od draw round
        /// </summary>
        private List<Card> PlayedCard = new List<Card>();
        private List<Player> Players = new List<Player>();
        /// <summary>
        /// Clubs, Spades, Hearts, Diamonds
        /// </summary>
        private const int CardTypeCount = 4;

        /// <summary>
        /// Deck size should be in between 40 to 52, default is 40
        /// Default player count is 2
        /// </summary>
        /// <param name="deckSize"></param>
        public CardGame(int deckSize = 40, int noOfPlayer = 2)
        {
            DefaultSetting(deckSize, noOfPlayer);
            LoadGame();
        }

        /// <summary>
        /// Load the Game
        /// </summary>
        private void LoadGame()
        {
            LoadDeck();
            LoadPlayer();
        }

        /// <summary>
        /// Distribute cards to all the players
        /// </summary>
        private void LoadPlayer()
        {
            for (int i = 1; i <= NoOfPlayer; i++)
            {
                Players.Add(new Player(i, Deck.GetCards(NoOfCardPerPlayer)));
            }
        }

        /// <summary>
        /// Load deck with all the cards
        /// </summary>
        private void LoadDeck()
        {
            var nos = Enumerable.Range(1, MaxCardNoOfEachType).ToList();
            var cards = new List<Card>();
            for (int i = 0; i < CardTypeCount; i++)
            {
                nos.ForEach(x => cards.Add(new Card(x, (CardType)i)));
            }
            Deck = new Deck(cards);
            Deck.Shuffle();
        }

        /// <summary>
        /// Setting default calculation
        /// </summary>
        /// <param name="deckSize"></param>
        /// <param name="noOfPlayer"></param>
        private void DefaultSetting(int deckSize, int noOfPlayer)
        {
            if (noOfPlayer < 2) throw new Exception(ErrorMessages.InvalidPlayerSize);
            if (deckSize > 52 || deckSize < 40) throw new Exception(ErrorMessages.DeckSizeNotInRange);
            NoOfPlayer = noOfPlayer;
            NoOfCardPerPlayer = deckSize / NoOfPlayer;
            var extraTempcardIfAny = CardTypeCount - ((NoOfCardPerPlayer * noOfPlayer) % CardTypeCount);
            // Just to have equal no of cards of all type (Clubs, Spades, Hearts, Diamonds)
            deckSize += extraTempcardIfAny;
            MaxCardNoOfEachType = deckSize / CardTypeCount;
        }

        /// <summary>
        /// Play
        /// </summary>
        /// <returns></returns>
        public void Play()
        {
            try
            {
                var playerDict = new Dictionary<int, Card>();
                foreach (var p in Players.Where(x => x.IsAlive))
                {
                    var card = p.DrawCard();
                    playerDict.Add(p.PlayerNumber, card);
                    Console.WriteLine($"Player {p.PlayerNumber} ({p.DrawPileCount} cards): {card.Number}");
                    //Console.WriteLine($"{p}: {card.Number}");
                }

                CheckRoundResult(playerDict);
                Console.WriteLine();
            }
            catch (EmptyDrawPileException ex)
            {
                CheckForWinner(ex);
            }
        }

        /// <summary>
        /// This method will check, who is the winner of the game.
        /// </summary>
        /// <param name="ex"></param>
        private void CheckForWinner(EmptyDrawPileException ex)
        {
            var deadPlayer = Players.FirstOrDefault(x => x.PlayerNumber == ex.PlayerNumber);
            deadPlayer.IsAlive = false;
            var activePlayerCount = Players.Where(x => x.IsAlive).Count();
            if (activePlayerCount < 2)
            {
                var winner = Players.OrderByDescending(x => x.Score).First();
                throw new GameOverException($"\nPlayer {winner.PlayerNumber} wins the game!");
            }
        }

        /// <summary>
        /// This method will check in round, Who is the winner.
        /// </summary>
        /// <param name="playerDict"></param>
        private void CheckRoundResult(Dictionary<int, Card> playerDict)
        {
            var dict = playerDict.OrderByDescending(x => x.Value.Number);
            var distinctCount = playerDict.Values.Select(x => x.Number).Distinct().Count();
            PlayedCard.AddRange(playerDict.Values);
            if ((dict.First().Value.Number > dict.Last().Value.Number) && distinctCount == Players.Where(x => x.IsAlive).Count())
            {
                Players[dict.First().Key - 1].Score++;
                Players[dict.First().Key - 1].AddToDiscardPile(PlayedCard);
                PlayedCard = new List<Card>();
                Console.WriteLine($"Player {dict.First().Key} wins this round");
            }
            else { Console.WriteLine("No winner in this round"); }
        }
    }
}
