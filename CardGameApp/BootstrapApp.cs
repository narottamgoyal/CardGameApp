using CardGameApp.CustomConsole;
using CardGameApp.Exceptions;
using System;

namespace CardGameApp
{
    /// <summary>
    /// BootstrapApp
    /// </summary>
    public class BootstrapApp
    {
        private readonly IConsole _console;
        public BootstrapApp(IConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run()
        {
            do
            {
                try
                {
                    // Welcome
                    _console.WriteLine("--------------------------Welcome to Card Game--------------------------");

                    // ask deck size
                    var ds = _console.AskQuestion("Enter deck size or press enter for default deck size 40:\n");
                    var deckSize = string.IsNullOrWhiteSpace(ds) ? 40 : Convert.ToInt32(ds);

                    // no of player
                    var np = _console.AskQuestion("Enter number of player or press enter for default 2 player:\n");
                    var noOfPlayer = string.IsNullOrWhiteSpace(np) ? 2 : Convert.ToInt32(np);

                    var cg = new CardGame(_console, deckSize: deckSize, noOfPlayer: noOfPlayer);
                    while (true)
                    {
                        cg.Play();
                    }
                }
                catch (GameOverException ex)
                {
                    _console.WriteLine(ex.Message, ConsoleColor.Green);
                }
                catch (Exception ex)
                {
                    _console.WriteLine(ex.Message, ConsoleColor.Red);
                }

                // ask to exit game
                var key = _console.ReadKey("Press q to exit the game or press any key to play again:\n");
                if (key == ConsoleKey.Q) break;

                _console.WriteLine(Environment.NewLine, ConsoleColor.Black);
            } while (true);
        }
    }
}
