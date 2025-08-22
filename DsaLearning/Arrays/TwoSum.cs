using DsaLearning.Utils;

namespace DsaLearning.Arrays;

public class TwoSum
{
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
            if (!map.ContainsKey(nums[i])) // avoid duplicates
                map[nums[i]] = i;
        }

        return []; // no solution
    }
}