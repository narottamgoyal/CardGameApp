using CardGameApp.Exceptions;
using System;

namespace CardGameApp
{
    /// <summary>
    /// Card Game
    /// </summary>
    public class MainApp
    {
        public static void Main(string[] args)
        {
            try
            {
                var cg = new CardGame();
                while (true)
                {
                    cg.Play();
                }
            }
            catch (GameOverException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
