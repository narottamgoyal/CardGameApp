using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CardGameApp.Tests
{
    public class UtilUnitTest
    {
        [Fact]
        public void ShuffleByFisherYatesAlgo_GivenIntegerList_ShouldReturnShuffledList()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5, 6 };
            var topItem = items.First();
            var lastItem = items.LastOrDefault();

            // Act
            Util.ShuffleByFisherYatesAlgo(items);

            // Assert
            Assert.NotEqual(topItem, items.First());
            Assert.NotEqual(lastItem, items.LastOrDefault());
        }
    }
}
