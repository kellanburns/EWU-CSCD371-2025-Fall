using Xunit;
using CanHazFunny;
using System;

namespace CanHazFunny.Tests;

public class ConsoleOutputTests
{
    [Fact]
    public void ShowOutput_MessageIsNull_ArgumentNullException()
    { 
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => consoleOutput.ShowOutput(null!));
    }

    [Fact]
    public void ShowOutput_MessageIsEmpty_ArgumentException()
    {
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => consoleOutput.ShowOutput(string.Empty));
    }

    [Fact]
    public void ShowOutput_MessageIsWhitespace_ArgumentException()
    {
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => consoleOutput.ShowOutput("   "));
    }
}