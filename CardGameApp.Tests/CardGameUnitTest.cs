using CardGameApp.CustomConsole;
using CardGameApp.Exceptions;
using Moq;
using System;
using Xunit;

namespace CardGameApp.Tests
{
    public class CardGameUnitTest
    {
        private readonly Mock<IConsole> _cmdConsole = new Mock<IConsole>();

        [Fact]
        public void PlayCardGame_GivenWrongPlayerCount_ShouldThrowException()
        {
            // Arrange
            int noOfPlayer = 1;

            // Act
            void action() => new CardGame(console: _cmdConsole.Object, noOfPlayer: noOfPlayer);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.InvalidPlayerSize, caughtException.Message);
        }

        [Fact]
        public void PlayCardGame_GivenWrongDeckSize_ShouldThrowException()
        {
            // Arrange
            int deckSize = 100;

            // Act
            void action() => new CardGame(console: _cmdConsole.Object, deckSize: deckSize);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.DeckSizeNotInRange, caughtException.Message);
        }

        [Fact]
        public void PlayCardGame_GivenDefaultDeckSizeAndPlayerCount_ShouldPlayRound1()
        {
            // Arrange
            var cardGame = new CardGame(console: _cmdConsole.Object);

            // Act
            var exception = Record.Exception(() => cardGame.Play());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PlayCardGame_Given3PlayerCount_ShouldPlayGame()
        {
            // Arrange
            var cardGame = new CardGame(console: _cmdConsole.Object, noOfPlayer: 3);

            // Act
            Action action = () =>
            {
                while (true)
                {
                    cardGame.Play();
                }
            };

            // Assert
            var caughtException = Assert.Throws<GameOverException>(action);
            Assert.EndsWith("wins the game!", caughtException.Message);
        }
    }
}