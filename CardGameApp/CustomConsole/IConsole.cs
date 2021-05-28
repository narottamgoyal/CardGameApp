using System;

namespace CardGameApp.CustomConsole
{
    public interface IConsole
    {
        void WriteLine(string message, ConsoleColor color = ConsoleColor.Blue);
        string AskQuestion(string message);
        ConsoleKey ReadKey(string message);
    }
}
