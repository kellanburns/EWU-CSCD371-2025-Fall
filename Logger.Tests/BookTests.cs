using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests
{
    public class BookTests
    {
        [Fact]
        public void Name_AuthorIsProvided_ReturnsTitleByAuthor()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string title = "Dungeon Crawler Carl";
            string author = "Matt Dinniman";
            Book book = new Book(id, title, author);

            // Act
            string name = book.Name;

            // Assert
            Assert.Equal("Dungeon Crawler Carl by Matt Dinniman", name);
        }

        [Fact]
        public void Name_AuthorIsNull_ReturnsTitleOnly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string title = "The Assassins Apprentice";
            Book book = new Book(id, title, null);

            // Act
            string name = book.Name;

            // Assert
            Assert.Equal("The Assassins Apprentice", name);
        }

        [Fact]
        public void Name_AuthorIsWhitespace_ReturnsTitleOnly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string title = "The Assassins Apprentice";
            string author = "   ";
            Book book = new Book(id, title, author);

            // Act
            string name = book.Name;

            // Assert
            Assert.Equal("The Assassins Apprentice", name);
        }

        [Fact]
        public void Equals_TwoBooksWithSameIdTitleAndAuthor_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string title = "Dungeon Crawler Carl";
            string author = "Matt Dinniman";
            Book book1 = new Book(id, title, author);
            Book book2 = new Book(id, title, author);

            // Act
            bool areEqual = book1.Equals(book2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Equals_TwoBooksWithDifferentIds_ReturnsFalse()
        {
            // Arrange
            string title = "Dungeon Crawler Carl";
            string author = "Matt Dinniman";
            Book book1 = new Book(Guid.NewGuid(), title, author);
            Book book2 = new Book(Guid.NewGuid(), title, author);

            // Act
            bool areEqual = book1.Equals(book2);

            // Assert
            Assert.False(areEqual);
        }
    }
}
