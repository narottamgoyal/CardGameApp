namespace CardGameApp
{
    public class CustomeMessages
    {
        public const string GameOver = "GameOver";
        public const string NoWinner = "No winner in this round";
        public const string PlayerWinInRound = "Player {0} wins this round";
        public const string PlayerWonTheGame = "\nPlayer {0} wins the game!";
        public const string DeckWithNoCardError = "Deck cannot be created with no card";
        public const string PlayerWithNoCard = "Player cannot be created with no card";
        public const string DeckSizeIssue = "Adding more than deck size is not allowed";
        public const string InvalidPlayerSize = "Player size should be greator than 2";
        public const string InvalidDeckSize = "Deck size should be completely divisible by {0}";
        public const string DeckSizeNotInRange = "Deck size should be in range between 40 to 52";
        public const string PlayerStatus = "Player {0} ({1} cards): {2}";
        public const string PlayerDetailedStatus = "{0}: {1}";
        public const string PlayerIsDead = "Player {0} is dead\n";
    }
}
