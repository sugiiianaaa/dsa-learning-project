using DsaLearning.LinkedList;

namespace DsaLearning.DetectCycleLinkedList;

public class DetectCycleLinkedListFloydsCycle
{
    /// <summary>
    /// Problem:
    ///     Find out if a linked list has cycle
    ///
    /// Thought Process:
    ///     - A Linked list has cycle if there is no null pointer on the next property
    ///     - So I could do loop with 2 pointer one fast and one slow which
    ///       one will move 2 times and another will one 1 times at a time to next node
    ///     - If it's a cycle, then they will both meet at one time on the cycle because
    ///       the difference of moving time.
    ///     - And the base case for the method to stop the loop is when the pointer
    ///       finds null reference.
    ///     - And this method called Floyd's Cycle Detection algorithm
    ///
    /// Implementation:
    ///     - Create loop to move the pointer to each node
    ///     - Create stop condition (either find null pointer or fast and slow meet on one node)
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Running LinkedListCycle test...");

        var tests = new List<TestCase<ListNode?, bool>>
        {
            new(null, false, Solve), // empty list
            new(new ListNode(1), false, Solve), // single node no cycle
            new(ListNode.CreateCycleList(1), true, Solve), // single node cycle
            new(ListNode.CreateLinkedList([1,2,3]), false, Solve), // no cycle
            new(ListNode.CreateCycleList(3), true, Solve), // multiple nodes with cycle
        };

        foreach (var test in tests)
        {
            test.RunTest();
        }
    }
    
    private static bool Solve(ListNode? head)
    {
        if (head == null || head.Next == null)
        {
            return false;
        }
        
        var slow = head;
        var fast = head;

        while (fast?.Next != null)
        {
            fast = fast.Next.Next;
            slow = slow!.Next;

            if (fast == slow)
            {
                return true;
            }
        }
        
        return false;
    }
}