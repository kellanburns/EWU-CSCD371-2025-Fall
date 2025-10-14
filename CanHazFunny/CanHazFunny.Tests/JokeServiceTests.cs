using Xunit;
using CanHazFunny;
using System;
using Moq;
using System.IO;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReturnsNonEmptyString()
    {
        // Arrange
        JokeService jokeService = new();

        // Act
        string joke = jokeService.GetJoke();

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(joke));
    }
}