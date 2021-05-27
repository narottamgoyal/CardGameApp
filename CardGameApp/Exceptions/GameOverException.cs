using System;

namespace CardGameApp.Exceptions
{
    /// <summary>
    /// GameOverException will be thrown to stop the game
    /// </summary>
    public class GameOverException : Exception
    {
        public GameOverException(string message) : base(message) { }
    }
}
