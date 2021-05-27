namespace CardGameApp
{
    public enum CardType { Clubs, Spades, Hearts, Diamonds }
    /// <summary>
    /// Playing card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Card number
        /// </summary>
        public int Number { get; private set; }
        /// <summary>
        /// Clubs, Spades, Hearts, Diamonds
        /// </summary>
        public CardType Type { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        ///// <param name="maxCardNumber"></param>
        /// <param name="number"></param>
        /// <param name="type"></param>
        public Card(int number, CardType type)
        {
            Number = number;
            Type = type;
        }
    }
}
