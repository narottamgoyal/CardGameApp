using System;
using System.Collections.Generic;
using Xunit;

namespace CardGameApp.Tests
{
    public class DeckUnitTest
    {
        [Fact]
        public void GetCards_GivenOneCardInDeck_ShouldReturnSingleCard()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(1, CardType.Clubs)
            };
            var deck = new Deck(cards);

            // Act
            var result = deck.GetCards(1);

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public void CreateDeck_GivenEmptyCardListInDeck_ShouldThrowException()
        {
            // Arrange
            var list = new List<Card>();

            // Act
            void action() => new Deck(list);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.DeckWithNoCardError, caughtException.Message);
        }

        [Fact]
        public void CreateDeck_GivenNullInDeck_ShouldThrowException()
        {
            // Arrange
            List<Card> list = null;

            // Act
            void action() => new Deck(list);

            // Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Contains(CustomeMessages.DeckWithNoCardError, caughtException.Message);
        }


        [Fact]
        public void Shuffle_GivenListOfCardsInDeck_ShouldShuffleCards()
        {
            // Arrange
            var cardList = new List<Card>
            {
                new Card(1, CardType.Clubs),
                new Card(2, CardType.Clubs),
                new Card(3, CardType.Clubs),
                new Card(4, CardType.Clubs),
                new Card(5, CardType.Clubs)
            };
            var deck = new Deck(cardList);

            // Act
            deck.Shuffle();
            var result = deck.GetCards(1);

            // Assert
            Assert.NotEqual(5, result[0].Number);
        }
    }
}
