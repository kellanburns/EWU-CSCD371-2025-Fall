using System;

namespace Calculate

public class Calculator {
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiple(int a, int b) => a * b;
    public static int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException();
        return a / b;
    }

    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } =
        new Dictionary<char, Func<int, int, int>>
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiple,
            ['/'] = Divide 
        };
        
    public bool TryCalculate(string calculation, out int result)
    {
        
    }
}