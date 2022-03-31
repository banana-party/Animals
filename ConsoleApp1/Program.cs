
ListNode l = new ListNode(1, new ListNode(0, new ListNode(1 )));



Console.WriteLine(Solution.IsPalindrome(l));






public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static bool IsPalindrome(ListNode head)
    {
        int i = 0, j = Count(head);


        while (i < j)
        {
            var h1 = head;
            var h2 = head;
            var t1 = 0;
            //while (t1 < i)
            //{
            //    h1 = h1.next;
            //    t1++;
            //}
            var t2 = 0;
            if (i != j - 1)
                while (t2 < j - 1)
                {
                    if (t1 == i)
                    {
                        h1 = h2;
                    }

                    t1++;

                    h2 = h2.next;
                    t2++;
                }
            if (h1.val != h2.val)
                return false;
            i++;
            j--;
        }
        return true;
    }

    public static int Count(ListNode head)
    {
        int i = 0;
        var h = head;
        while (h != null)
        {
            i++;
            h = h.next;
        }
        return i;
    }
}


