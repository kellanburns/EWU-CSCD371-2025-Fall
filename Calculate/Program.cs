using System;
using System.Numerics;

namespace Calculate;

public class Program
{
    public delegate void WriteLineDelegate(string? text);
    public delegate string? ReadLineDelegate();
    public WriteLineDelegate WriteLine { get; init; }
    public ReadLineDelegate ReadLine { get; init; }

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;
    }

    public Program(WriteLineDelegate writeLine, ReadLineDelegate readLine)
    {
        WriteLine = writeLine ?? throw new ArgumentNullException(nameof(writeLine));
        ReadLine = readLine ?? throw new ArgumentNullException(nameof(readLine));
    }
    
    public static int Main()
    {
        return 0;
    }
}