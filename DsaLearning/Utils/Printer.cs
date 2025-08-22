namespace DsaLearning.Utils;

public static class Printer
{
    public static string FormatArray<T>(IEnumerable<T> array)
    {
        return "[" + string.Join(", ", array) + "]";
    }

    public static string FormatTuple((int[], int) tuple)
    {
        return $"(nums={FormatArray(tuple.Item1)}, target={tuple.Item2})";
    }

    public static bool AreArraysEqual<T>(T[] a, T[] b)
    {
        if (a == null || b == null) return false;
        if (a.Length != b.Length) return false;
        return a.SequenceEqual(b);
    }
}