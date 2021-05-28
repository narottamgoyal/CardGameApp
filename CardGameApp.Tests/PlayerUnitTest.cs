using CardGameApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CardGameApp.Tests
{
    public class PlayerUnitTest
    {
        [Fact]
        public void DrawCard_WhenPlayerHasSomeCardInDrawPile_ShouldReturnTopCard()
        {
            // Arrange
            var cardList = new List<Card>
            {
                new Card(4, CardType.Clubs),
                new Card(1, CardType.Clubs),
                new Card(5, CardType.Clubs)
            };
            var player = new Player(1, cardList);

            // Act
            var result = player.DrawCard();

            // Assert
            Assert.Equal(cardList.LastOrDefault().Number, result.Number);
        }

        [Fact]
        public void DrawCard_WhenPlayerHasSomeCardInDisCardPileAndNoCardInDrawPile_ShouldShuffleDiscardPileAndMoveToDrawPileThenShouldReturnTopCard()
        {
            // Arrange
            var cardList1 = new List<Card> { new Card(3, CardType.Clubs) };
            var cardList2 = new List<Card> { new Card(4, CardType.Clubs) };
            var player = new Player(1, cardList1);
            player.AddToDiscardPile(cardList2);
            player.DrawCard();

            // Act
            var result = player.DrawCard();

            // Assert
            Assert.Equal(cardList2.LastOrDefault().Number, result.Number);
        }

        [Fact]
        public void DrawCard_WhenDrawAndDiscardPileAreEmpty_ShouldEmptyDrawPileException()
        {
            // Arrange
            var cardList = new List<Card>
            {
                new Card(4, CardType.Clubs),
                new Card(1, CardType.Clubs),
                new Card(5, CardType.Clubs)
            };
            var player = new Player(1, cardList);
            player.DrawCard(); player.DrawCard(); player.DrawCard();

            // Act
            var caughtException = Assert.Throws<EmptyDrawPileException>(() => player.DrawCard());

            // Assert
            Assert.Equal(1, caughtException.PlayerNumber);
        }

        [Fact]
        public void ToString_ShouldReturnPlayerStatus()
        {
            // Arrange
            var cardList = new List<Card> { new Card(5, CardType.Clubs) };
            var player = new Player(1, cardList);

            // Act
            var result = player.ToString();

            // Assert
            Assert.StartsWith("Player: 1", result);
        }

        [Fact]
        public void CreatePlayer_GivenEmptyCardList_ShouldThrowException()
        {
            // Arrange
            var list = new List<Card>();

            // Act
            void action() => new Player(1, list);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.PlayerWithNoCard, caughtException.Message);
        }

        [Fact]
        public void CreatePlayer_GivenNullCardList_ShouldThrowException()
        {
            // Arrange
            List<Card> list = null;

            // Act
            void action() => new Player(1, list);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.PlayerWithNoCard, caughtException.Message);
        }
    }
}
