namespace DsaLearning.TwoSum;

public class TwoSumDictionary
{
    /// <summary>
    /// Problem:
    ///     Find out which index of number that generates n if index x and y summed
    ///
    /// Though Process:
    ///     - In order to get the expected n value,
    ///       I need to find 2 numbers that if added become n on the list
    ///     - So I think I could like compare each value on list let's called it x
    ///       to reach the target (n) and find how much it needed to get n
    ///       let's say it called y so it's like y = n - x
    ///     - And if on the list later I found y value, then both of x y index will
    ///       be the answer
    ///
    /// Implementation:
    ///     - I could use dictionary to store the y value and the index where y is
    ///       the key and the index is value like
    ///       10 -> 0
    ///     - And use for loop to find x and y that have n value after i do the math
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Running TwoSum tests...");

        var tests = new List<TestCase<(int[], int), int[]>>
        {
            new(([2, 7, 11, 5], 9), [0, 1], Solve),
            new(([3, 2, 4], 6), [1, 2], Solve),
            new(([3, 3], 6), [0, 1], Solve)
        };

        foreach (var test in tests)
        {
            test.RunTest();
        }
    }

    private static int[] Solve((int[], int) input)
    {
        var (nums, target) = input;
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var value))
            {
                return [value, i];
            }
            if (!map.ContainsKey(nums[i])) // only add new data if key not exists
                map[nums[i]] = i;
        }

        return []; // no solution
    }
}