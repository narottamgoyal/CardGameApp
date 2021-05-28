using CardGameApp.CustomConsole;
using Moq;
using System;
using Xunit;

namespace CardGameApp.Tests
{
    public class BootstrapAppUnitTest
    {
        private readonly Mock<IConsole> _cmdConsole;
        private readonly BootstrapApp _bootstrapApp;
        public BootstrapAppUnitTest()
        {
            _cmdConsole = new Mock<IConsole>();
            _bootstrapApp = new BootstrapApp(_cmdConsole.Object);
        }

        [Fact]
        public void Run_GivenDefaultValues_ShouldPlayGame()
        {
            // Arrange
            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("deck size"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("number of player"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.ReadKey(It.Is<string>(s => s.Contains("q to exit"))))
                       .Returns(System.ConsoleKey.Q);

            // Act
            _bootstrapApp.Run();

            // Assert
            _cmdConsole.Verify(p => p.WriteLine(It.Is<string>(s => s == Environment.NewLine), It.IsAny<ConsoleColor>()), Times.Never);
        }

        [Fact]
        public void Run_GivenDefaultDeckSizeAnd3Player_ShouldPlayGameWith3Player()
        {
            // Arrange
            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("deck size"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("number of player"))))
                       .Returns("3");

            _cmdConsole.Setup(p => p.ReadKey(It.Is<string>(s => s.Contains("q to exit"))))
                       .Returns(System.ConsoleKey.Q);

            // Act
            _bootstrapApp.Run();

            // Assert
            _cmdConsole.Verify(p => p.WriteLine(It.Is<string>(s => s == Environment.NewLine), It.IsAny<ConsoleColor>()), Times.Never);
        }

        [Fact]
        public void Run_GivenDefaultPlayerAnd52AsDeckSize_ShouldPlayGame()
        {
            // Arrange
            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("deck size"))))
                       .Returns("52");

            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("number of player"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.ReadKey(It.Is<string>(s => s.Contains("q to exit"))))
                       .Returns(System.ConsoleKey.Q);

            // Act
            _bootstrapApp.Run();

            // Assert
            _cmdConsole.Verify(p => p.WriteLine(It.Is<string>(s => s == Environment.NewLine), It.IsAny<ConsoleColor>()), Times.Never);
        }

        [Fact]
        public void Run_GivenDefaultValues_ShouldThrowGameOverException()
        {
            // Arrange
            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("deck size"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("number of player"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.ReadKey(It.Is<string>(s => s.Contains("q to exit"))))
                       .Returns(System.ConsoleKey.Q);

            // Act
            _bootstrapApp.Run();

            // Assert
            _cmdConsole.Verify(p => p.WriteLine(It.Is<string>(s => s.EndsWith("wins the game!")), It.IsAny<ConsoleColor>()), Times.Once);
        }

        [Fact]
        public void Run_GivenDefaultPlayerAndJunkValueAsDeckSize_ShouldThrowException()
        {
            // Arrange
            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("deck size"))))
                       .Returns("junk");

            _cmdConsole.Setup(p => p.AskQuestion(It.Is<string>(s => s.Contains("number of player"))))
                       .Returns(string.Empty);

            _cmdConsole.Setup(p => p.ReadKey(It.Is<string>(s => s.Contains("q to exit"))))
                       .Returns(System.ConsoleKey.Q);

            // Act
            _bootstrapApp.Run();

            // Assert
            _cmdConsole.Verify(p => p.WriteLine(It.Is<string>(s => s == "Input string was not in a correct format."), It.IsAny<ConsoleColor>()), Times.Once);
        }
    }
}
