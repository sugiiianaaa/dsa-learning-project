using DsaLearning.Utils;

namespace DsaLearning.Arrays;

public class TwoSum
{
    public static void Run()
    {
        Console.WriteLine("Running TwoSum tests...");

        var tests = new List<TestCase<(int[], int), int[]>>
        {
            new((new[] { 2, 7, 11, 5 }, 9), new[] { 0, 1 }, Solve),
            new((new[] { 3, 2, 4 }, 6), new[] { 1, 2 }, Solve),
            new((new[] { 3, 3 }, 6), new[] { 0, 1 }, Solve)
        };

        foreach (var test in tests)
        {
            test.RunTest();
        }
    }

    public static int[] Solve((int[], int) input)
    {
        var (nums, target) = input;
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new[] { map[complement], i };
            }
            if (!map.ContainsKey(nums[i])) // avoid duplicates
                map[nums[i]] = i;
        }

        return Array.Empty<int>(); // no solution
    }
}