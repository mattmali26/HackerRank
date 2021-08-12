using System;
using System.Collections.Generic;

namespace ReverseALinkedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SinglyLinkedList llist = new SinglyLinkedList();
            for (int i = 1; i < 1000; i++)
            {
                llist.InsertNode(i);
            }
            SinglyLinkedListNode llist1 = Result.Reverse(llist.head);

            //int tests = Convert.ToInt32(Console.ReadLine());

            //for (int testsItr = 0; testsItr < tests; testsItr++)
            //{
            //    SinglyLinkedList llist = new SinglyLinkedList();

            //    int llistCount = Convert.ToInt32(Console.ReadLine());

            //    for (int i = 0; i < llistCount; i++)
            //    {
            //        int llistItem = Convert.ToInt32(Console.ReadLine());
            //        llist.InsertNode(llistItem);
            //    }

            //    SinglyLinkedListNode llist1 = Result.Reverse(llist.head);

            //    PrintSinglyLinkedList(llist1, " ");
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
    }

    internal class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    internal class Result
    {
        /*
         * Complete the 'reverse' function below.
         *
         * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
         * The function accepts INTEGER_SINGLY_LINKED_LIST llist as parameter.
         */

        /*
         * For your reference:
         *
         * SinglyLinkedListNode
         * {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */

        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode llist)
        {
            if (llist.next == null)
            {
                return llist;
            }

            var list = new List<int>();
            var listItem = llist;
            while (listItem.next != null)
            {
                list.Add(listItem.data);
                listItem = listItem.next;
            }
            list.Add(listItem.data);

            list.Reverse();

            var reversedList = new SinglyLinkedList();
            for (int i = 0; i < list.Count; i++)
            {
                reversedList.InsertNode(list[i]);
            }

            return reversedList.head;
        }
    }

    internal class SinglyLinkedList
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