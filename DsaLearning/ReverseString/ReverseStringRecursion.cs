namespace DsaLearning.ReverseString;

public class ReverseStringRecursion
{
    /// <summary>
    /// Problem:
    ///     Reverse the given string using recursion.
    ///
    /// Thought Process:
    ///     - A reverse string is basically the last character
    ///       followed by the reverse of the "rest" of the string.
    ///     - So I can peel off the last character at each recursion process,
    ///       then call the function again on the substring that excludes it.
    ///     - This continues until I hit the empty string (base case). 
    ///
    /// Implementation:
    ///     - Base case: if input is empty or null, return input.
    ///     - Recursive case: return last char + Solve(all except last).
    ///     - Use C# range operator [..^1] to slice the string.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Running Reverse String test...");

        var tests = new List<TestCase<string, string>>
        {
            new("sugi", "igus", Solve),
            new("a", "a", Solve),
            new("", "", Solve),
            new("abba", "abba", Solve),
            new("dsa", "asd", Solve)
        };

        foreach (var test in tests)
        {
            test.RunTest();
        }
    }

    private static string Solve(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return input[^1] + Solve(input[..^1]);
    }
}