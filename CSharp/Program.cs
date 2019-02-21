using System;
using CSharp.Test;


namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Problems.ListNode l1 = new Problems.ListNode(1);
            Problems.ListNode l2 = new Problems.ListNode(2);
            Problems.ListNode l3 = new Problems.ListNode(3);
            l1.next = l2; l2.next = l3;
            l3=Problems.reverseList1(l1);
            //Console.WriteLine();
            Console.WriteLine("Hello World!");
        }
    }
}
