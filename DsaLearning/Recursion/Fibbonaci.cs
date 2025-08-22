using DsaLearning.Utils;

namespace DsaLearning.Recursion;

public class Fibbonaci
{
    /// <summary>
    /// Problem: Compute the n-th Fibonacci number.
    ///
    /// Approach:
    /// - Base case: F(0) = 0, F(1)=1.
    /// - Recursive: F(n) = F(n-1) + F(n-2)
    ///
    /// Implementation:
    /// - Used a helper (SolveRecursive) with parameters (limit, index, initialValue, lastValue).
    /// - This avoids recalculating values repeatedly (like naive recursion would).
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Running Fibonacci tests...");

        var tests = new List<TestCase<int, int>>
        {
            new(0, 0, Solve),
            new(1, 1, Solve),
            new(5, 5, Solve),
            new(10, 55, Solve)
        };

        foreach (var test in tests) test.RunTest();
    }

    public static int Solve(int n)
    {
        // Basic case for first and second index just return static value
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        // Recursively sum the number until index > limit
        var result = SolveRecursive(n, 2, 0, 1);
        return result;
    }

    private static int SolveRecursive(int limit, int index, int prev, int curr)
    {
        // Base case where index > limit 
        if(index > limit) return curr;
        
        return SolveRecursive(limit, index + 1, curr, prev + curr);
    }
}