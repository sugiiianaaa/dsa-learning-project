using DsaLearning.Utils;

namespace DsaLearning.Recursion;

public class IsPalindrome
{
    /// <summary>
    /// Problem:
    ///     Find if a string is palindrome
    ///
    /// Tough Process:
    ///     - A palindrome reads the same forward and backward.
    ///     - This means the first and last characters must match,
    ///       then the second and second-to-last, and so on.
    ///     - I realized I could use recursion to compare first and last index
    ///       and move the index toward the center index
    ///
    /// Implementation:
    ///     - Base case: when head index >= tail index, return true (this means all characters are same for each character already checked)
    ///     - Recursive case: if characters differ, return false.
    ///     - Otherwise, call the function again with head+1 and tail-1 
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Running IsPalindrome Tests... ");

        var tests = new List<TestCase<string, bool>>
        {
            new("madam", true, Solve),
            new("hello", false, Solve),
            new("abba", true, Solve),
            new("", true, Solve),
            new("a", true, Solve),
            new("aa", true,Solve),
            new("aba", true, Solve),
            new("Madam", false, Solve) // Case sensitivity
        };
        
        foreach(var test in tests) test.RunTest();
    }
    
    private static bool Solve(string input)
    {
        return PalindromeCheck(input, 0, input.Length - 1);
    }

    private static bool PalindromeCheck(string input, int headIndex, int tailIndex)
    {
        if (headIndex >= tailIndex) return true;
        if (input[headIndex] != input[tailIndex]) return false;

        return PalindromeCheck(input, headIndex + 1, tailIndex - 1);
    }
}

