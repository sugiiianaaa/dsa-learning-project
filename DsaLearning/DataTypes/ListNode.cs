namespace DsaLearning.LinkedList;

/// <summary>
/// ListNode Data Type Model
/// </summary>
public class ListNode
{
    public int Val;
    public ListNode? Next;

    public ListNode(
        int val = 0, 
        ListNode? next = null)
    {
        this.Val = val;
        this.Next = next;
    }
    
    public static ListNode CreateLinkedList(int[] values)
    {
        if (values.Length == 0) return null!;
        var head = new ListNode(values[0]);
        var current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new ListNode(values[i]);
            current = current.Next;
        }
        return head;
    }

    public static ListNode CreateCycleList(int n)
    {
        var head = new ListNode(1);
        var current = head;
        for (int i = 2; i <= n; i++)
        {
            current.Next = new ListNode(i);
            current = current.Next;
        }
        current.Next = head; // cycle
        return head;
    } 
}