namespace CardGameApp
{
    public class ErrorMessages
    {
        public const string GameOver = "GameOver";
        public const string DeckWithNoCardError = "Deck cannot be created with no card";
        public const string PlayerWithNoCard = "Player cannot be created with no card";
        public const string DeckSizeIssue = "Adding more than deck size is not allowed";
        public const string InvalidPlayerSize = "Player size should be greator than 2";
        public const string InvalidDeckSize = "Deck size should be completely divisible by {0}";
        public const string DeckSizeNotInRange = "Deck size should be in range between 40 to 52";
    }
}
