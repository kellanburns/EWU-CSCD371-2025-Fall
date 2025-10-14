using Xunit;
using CanHazFunny;
using System;

namespace CanHazFunny.Tests;

public class ConsoleOutputTests
{
    [Fact]
    public void ShowOutput_ShouldThrowArgumentNullException_WhenMessageIsNull()
    { 
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => consoleOutput.ShowOutput(null!));
    }

    [Fact]
    public void ShowOutput_ShouldThrowArgumentException_WhenMessageIsEmpty()
    {
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => consoleOutput.ShowOutput(string.Empty));
    }

    [Fact]
    public void ShowOutput_ShouldThrowArgumentException_WhenMessageIsWhitespace()
    {
        // Arrange
        var consoleOutput = new ConsoleOutput();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => consoleOutput.ShowOutput("   "));
    }
}