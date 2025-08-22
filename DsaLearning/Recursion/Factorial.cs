using DsaLearning.Arrays;
using DsaLearning.Utils;

namespace DsaLearning.Recursion;

public class Factorial
{
    public static void Run()
    {
        Console.WriteLine("Running Factorial tests...");

        var tests = new List<TestCase<int, int>>
        {
            new(0, 1, Solve),
            new(1, 1, Solve),
            new(5, 120, Solve),
            new(7, 5040, Solve)
        };

        foreach (var test in tests) test.RunTest();
    }

    private static int Solve(int n)
    {
        return FactorialRecursion(n, 1);
    }

    private static int FactorialRecursion(int n, int acc)
    {
        if (n <= 1) return acc;
        return FactorialRecursion(n - 1, acc * n);
    }
}