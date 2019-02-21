namespace CSharp.Test
{
    public class Problems
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public static int Reverse(int x)
        {
            if (x == 0)
                return 0;
            int result = 0;

            while (x != 0)
            {
                if (result > int.MaxValue / 10 || result < int.MinValue / 10)
                    return 0;
                result = result * 10 + x % 10;
                x /= 10;
            }

            return result;
        }
        public static ListNode reverseList(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            ListNode ptmp = head;
            while (ptmp != null)
            {
                ListNode pNex = ptmp.next;//2 3 => 3 null  //先将链表的下一项记录下来
                 ptmp.next = dummy.next;//1 ->2 1 ->3 2 1
                dummy.next = ptmp;//-1 1=>-1 2 1 =>-1 3 2 1
                ptmp = pNex;//1 2 3=> 2 3 => 3 =>null
            }
            return dummy.next;
        }
          public static ListNode reverseList1(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return node;
            }
            else
            {
                ListNode headNode = reverseList1(node.next);//获取下一项链表
                node.next.next = node;//下一项链表的下一个指针位置指向当前链表
                node.next = null;//当前链表的下一项指针位置 设置为空 为终止条件返回当前链表
                return headNode;
            }
        }
         
        public static ListNode CopyList(ListNode l1)
        {
            ListNode dummy = new ListNode(-1);
            ListNode cur = dummy;
            while (l1 != null)
            {
                cur.next = new ListNode(l1.val);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
            }
             cur.next = new ListNode(6);
             cur = cur.next;
            return dummy.next;
        }
        
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode cur = dummy;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int d1 = l1 == null ? 0 : l1.val;
                int d2 = l2 == null ? 0 : l2.val;
                int sum = d1 + d2 + carry;
                carry = sum >= 10 ? 1 : 0;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry == 1) cur.next = new ListNode(1);
            return dummy.next;

        }
        public static int[] TwoSum(int[] nums, int target)
        {
            bool ret=false;
            int[] r = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                while (j < nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        r[0] = i; r[1] = j;
                        ret = true;
                        break;
                    }
                    j++;
                }
                if(ret)break;
            }
            return r;
        }
    }
}