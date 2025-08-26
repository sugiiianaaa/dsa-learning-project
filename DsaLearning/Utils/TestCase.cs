public class TestCase<TInput, TOutput>
{
    public TInput Input { get; }
    public TOutput Expected { get; }
    public Func<TInput, TOutput> Solver { get; }
    public Func<TOutput?, TOutput?, bool> Comparer { get; }

    public TestCase(TInput input, TOutput expected, Func<TInput, TOutput> solver, Func<TOutput?, TOutput?, bool>? comparer = null)
    {
        Input = input;
        Expected = expected;
        Solver = solver;
        Comparer = comparer ?? ((a, b) => a?.Equals(b) ?? false);
    }

    public void RunTest()
    {
        var result = Solver(Input);

        bool passed = Comparer(result, Expected);

        string inputStr = Input?.ToString() ?? "null";
        string resultStr = result?.ToString() ?? "null";
        string expectedStr = Expected?.ToString() ?? "null";

        if (passed)
            Console.WriteLine($"✅ Passed | Input: {inputStr} | Output: {resultStr}");
        else
            Console.WriteLine($"❌ Failed | Input: {inputStr} | Expected: {expectedStr}, Got: {resultStr}");
    }
}