namespace DsaLearning.Factorial;

// TODO SUGI: add documentation later
public class FactorialRecursion
{
    /// <summary>
    /// 
    /// </summary>
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
        return Recursion(n, 1);
    }

    private static int Recursion(int n, int acc)
    {
        return n <= 1 ? acc : Recursion(n - 1, acc * n);
    }
}