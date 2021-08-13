using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeTwoSortedLinkedLists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SinglyLinkedList llist1 = new SinglyLinkedList();
            for (int i = 0; i < 1000; i++)
            {
                llist1.InsertNode(i);
            }
            SinglyLinkedList llist2 = new SinglyLinkedList();
            for (int i = 0; i < 1; i++)
            {
                llist2.InsertNode(i);
            }
            SinglyLinkedListNode llist3 = MergeLists(llist1.head, llist2.head);

            //int tests = Convert.ToInt32(Console.ReadLine());

            //for (int testsItr = 0; testsItr < tests; testsItr++)
            //{
            //    SinglyLinkedList llist1 = new SinglyLinkedList();

            //    int llist1Count = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < llist1Count; i++)
            //    {
            //        int llist1Item = Convert.ToInt32(Console.ReadLine());
            //        llist1.InsertNode(llist1Item);
            //    }

            //    SinglyLinkedList llist2 = new SinglyLinkedList();

            //    int llist2Count = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < llist2Count; i++)
            //    {
            //        int llist2Item = Convert.ToInt32(Console.ReadLine());
            //        llist2.InsertNode(llist2Item);
            //    }

            //    SinglyLinkedListNode llist3 = MergeLists(llist1.head, llist2.head);

            //    PrintSinglyLinkedList(llist3, " ");
            //    Console.WriteLine();
            //}

            Console.ReadLine();
        }

        private static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }

        // Complete the mergeLists function below.

        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */

        private static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null || head2 == null)
            {
                return head1 == null ? head2 : head1;
            }

            var mergedList = new SinglyLinkedList();

            var list = new List<int>();
            var list1Item = head1;
            var list2Item = head2;
            while (list1Item.next != null && list2Item.next != null)
            {
                list.Add(list1Item.data);
                list.Add(list2Item.data);
                list1Item = list1Item.next;
                list2Item = list2Item.next;
            }
            list.Add(list1Item.data);
            list.Add(list2Item.data);

            if (list1Item.next != null || list2Item.next != null)
            {
                if (list1Item.next != null)
                {
                    list1Item = list1Item.next;
                    while (list1Item.next != null)
                    {
                        list.Add(list1Item.data);
                        list1Item = list1Item.next;
                    }
                    list.Add(list1Item.data);
                }
                else
                {
                    list2Item = list2Item.next;
                    while (list2Item.next != null)
                    {
                        list.Add(list2Item.data);
                        list2Item = list2Item.next;
                    }
                    list.Add(list2Item.data);
                }
            }

            list = list.OrderBy(x => x).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                mergedList.InsertNode(list[i]);
            }

            return mergedList.head;
        }

        private class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        private class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }
    }
}