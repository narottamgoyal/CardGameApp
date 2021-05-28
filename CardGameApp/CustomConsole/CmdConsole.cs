using System;

namespace CardGameApp.CustomConsole
{
    public class CmdConsole : IConsole
    {
        public ConsoleKey ReadKey(string message)
        {
            WriteLine(message);
            return Console.ReadKey().Key;
        }

        public string AskQuestion(string message)
        {
            WriteLine(message);
            return Console.ReadLine();
        }

        public void WriteLine(string message, ConsoleColor color = ConsoleColor.Blue)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
