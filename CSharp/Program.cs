using System;
using CSharp.Test;


namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Problems.ListNode l1 = new Problems.ListNode(2);
            Problems.ListNode l2 = new Problems.ListNode(2);
            Problems.ListNode l3 = new Problems.ListNode(4);
            l1.next = l2; l2.next = l3;
             Problems.ListNode l11 = new Problems.ListNode(1);
            Problems.ListNode l21 = new Problems.ListNode(3);
            Problems.ListNode l31 = new Problems.ListNode(4);
            l11.next = l21; l21.next = l31;
            
           int rl=Problems.RemoveElement(new int[]{3,2,2,3},3);
            //Problems.ListNode rl=Problems.MergeTwoLists(l1,l11);
            // l3=Problems.reverseList1(l1);
            // Console.WriteLine(Problems.Reverse(123));
            // bool ret=Problems.IsValid("(])");
            Console.WriteLine("Hello World!");
        }
    }
}
