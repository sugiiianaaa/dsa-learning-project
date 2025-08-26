using DsaLearning.Utils;

namespace DsaLearning.LinkedList;

public static class ReverseLinkedList
{
    public static void Run()
    {
        Console.WriteLine("Running reverse linked list...");

        var tests = new List<TestCase<ListNode?, ListNode?>>
        {
            new(ListNode.CreateLinkedList([1,2,3,4]), ListNode.CreateLinkedList([4,3,2,1]), Solve, AreLinkedListsEqual)
        };

        foreach (var test in tests)
        {
            test.RunTest();
        }
    }

    private static ListNode? Solve(ListNode? head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;

        ListNode? tail = null;

        while (head != null)
        {
            var tmp = head.Next;
            head.Next = tail;
            tail = head;
            head = tmp;
        }

        return tail;
    }
    
    private static bool AreLinkedListsEqual(ListNode? a, ListNode? b)
    {
        while (a != null && b != null)
        {
            if (a.Val != b.Val) return false;
            a = a.Next;
            b = b.Next;
        }
        return a == null && b == null;
    }
}