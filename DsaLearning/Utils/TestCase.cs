namespace DsaLearning.Utils;

public class TestCase<TInput, TOutput>
{
    public TInput Input { get; }
    public TOutput Expected { get; }
    public Func<TInput, TOutput> Solver { get; }

    public TestCase(TInput input, TOutput expected, Func<TInput, TOutput> solver)
    {
        Input = input;
        Expected = expected;
        Solver = solver;
    }

    public void RunTest()
    {
        var result = Solver(Input);

        bool passed;

        if (result is int[] resultArray && Expected is int[] expectedArray)
        {
            passed = Printer.AreArraysEqual(resultArray, expectedArray);
        }
        else
        {
            passed = result?.Equals(Expected) ?? false;
        }

        string inputStr = Input is ValueTuple<int[], int> tuple
            ? Printer.FormatTuple(tuple)
            : Input?.ToString() ?? "null";

        string resultStr = result is int[] arr ? Printer.FormatArray(arr) : result?.ToString() ?? "null";
        string expectedStr = Expected is int[] expArr ? Printer.FormatArray(expArr) : Expected?.ToString() ?? "null";

        if (passed)
            Console.WriteLine($"✅ Passed | Input: {inputStr} | Output: {resultStr}");
        else
            Console.WriteLine($"❌ Failed | Input: {inputStr} | Expected: {expectedStr}, Got: {resultStr}");
    }
}