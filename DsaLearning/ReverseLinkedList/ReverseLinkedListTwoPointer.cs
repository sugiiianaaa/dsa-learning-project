using DsaLearning.LinkedList;

namespace DsaLearning.ReverseLinkedList;

public class ReverseLinkedListTwoPointer
{
    /// <summary>
    /// Problem:
    ///     Return reversed linked list
    /// 
    /// Though Process:
    ///     - Linked List are a node that has value and pointer to the next node
    ///     - So to reverse it, I think I only need to revert the pointer
    ///     - Like a --/ b to a \-- b
    ///
    /// Implementation:
    ///     - Create for loop to iterate each node on linked list
    ///     - For each iteration, revert the pointer of the next node
    ///       without losing the data of linked list which I could use
    ///       temporary pointer to mark the node 
    /// </summary>
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