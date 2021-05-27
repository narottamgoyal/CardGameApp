using Xunit;

namespace CardGameApp.Tests
{
    public class MainAppUnitTest
    {
        [Fact]
        public void PlayCardGame_ShouldPlayGame()
        {
            // Act
            MainApp.Main(null);
        }
    }
}
