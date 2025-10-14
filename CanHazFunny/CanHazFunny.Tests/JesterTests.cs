using Xunit;
using CanHazFunny;
using System;
using Moq;
using System.IO;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Jester_ShouldThrowArgumentNullException_WhenOutputIsNull()
    {
        // Arrange
        JokeService jokeService = new JokeService();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeService));
    }

    [Fact]
    public void Jester_ShouldThrowArgumentNullException_WhenJokeServiceIsNull()
    {
        // Arrange
        ConsoleOutput consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(consoleOutput, null!));
    }

    [Fact]
    public void TellJoke_CallsShowOutput_WithNonChuckNorrisJoke()
    {
        // Arrange
        string testJoke = "test output";
        var mockOutput = new Mock<IOutput>();
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.SetupSequence(js => js.GetJoke())
            .Returns(testJoke);
        StringWriter sw = new StringWriter();
        TextWriter original = Console.Out;

        // Act
        try
        {
            Console.SetOut(sw);
            Jester jester = new Jester(new ConsoleOutput(), mockJokeService.Object);
            jester.TellJoke();
        }
        finally
        {
            Console.SetOut(original);
        }

        // Assert
        Assert.Contains(testJoke, sw.ToString());
    }

    [Fact]
    public void TellJoke_ChuckNorrisJoke_GeneratesNewJoke()
    {
        // Arrange
        var mockOutput = new Mock<IOutput>();
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.SetupSequence(js => js.GetJoke())
            .Returns("Norris counted to infinity. Twice.")
            .Returns("Chuck Norris can divide by zero.")
            .Returns("A test joke.");
        StringWriter sw = new StringWriter();
        TextWriter original = Console.Out;

        // Act
        try
        {
            Console.SetOut(sw);
            Jester jester = new Jester(new ConsoleOutput(), mockJokeService.Object);
            jester.TellJoke();
        }
        finally
        {
            Console.SetOut(original);
        }

        // Assert
        string output = sw.ToString();
        Assert.DoesNotContain("Chuck", output);
        Assert.DoesNotContain("Norris", output);
        Assert.Contains("A test joke.", output);
    }
}
