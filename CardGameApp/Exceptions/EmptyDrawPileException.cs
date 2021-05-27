using System;

namespace CardGameApp.Exceptions
{
    /// <summary>
    /// EmptyDrawPileException will be thrown, when player tries to draw a card from an empty draw pile
    /// </summary>
    public class EmptyDrawPileException : Exception
    {
        public int PlayerNumber { get; set; }
        public EmptyDrawPileException() { }
    }
}
