
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    class Program
    {
        public static void PrintHeader(string header)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine(header.ToUpper());
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            PrintHeader("RandomizedIntArray");
            RandomizedIntArray a1 = new RandomizedIntArray(10, 0, 50);
            Console.WriteLine("A1 : " + a1.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a1.GetSize());
            Console.WriteLine("IsOrdered : " + a1.IsOrdered());
            Console.WriteLine("Max Value : " + a1.GetMaxValue());
            Console.WriteLine("Min Value : " + a1.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("INSERTION SORTING A1");
            a1.InsertionSort();
            Console.WriteLine("A1 : " + a1.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a1.GetSize());
            Console.WriteLine("IsOrdered : " + a1.IsOrdered());
            Console.WriteLine("Max Value : " + a1.GetMaxValue());
            Console.WriteLine("Min Value : " + a1.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("InsertionSortTest");
            bool passedTest = true;
            for (int i = 0; i < 10; i++)
            {
                RandomizedIntArray someArray = new RandomizedIntArray(25, -100, 100);
                someArray.InsertionSort();
                Console.WriteLine(someArray.GetArrayAsString());
                if (!someArray.IsOrdered())
                {
                    passedTest = false;
                }
            }
            Console.WriteLine("Sorted all 10 arrays? : " + passedTest);
            Console.ReadLine();

            RandomizedIntArray a2 = new RandomizedIntArray(10, 0, 50);
            Console.WriteLine("A2 : " + a2.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a2.GetSize());
            Console.WriteLine("IsOrdered : " + a2.IsOrdered());
            Console.WriteLine("Max Value : " + a2.GetMaxValue());
            Console.WriteLine("Min Value : " + a2.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("MERGE SORTING A2");
            a2.MergeSort();
            Console.WriteLine("A2 : " + a2.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a2.GetSize());
            Console.WriteLine("IsOrdered : " + a2.IsOrdered());
            Console.WriteLine("Max Value : " + a2.GetMaxValue());
            Console.WriteLine("Min Value : " + a2.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("MergeSortTest");
            passedTest = true;
            for (int i = 0; i < 10; i++)
            {
                RandomizedIntArray someArray = new RandomizedIntArray(25, -100, 100);
                someArray.MergeSort();
                Console.WriteLine(someArray.GetArrayAsString());
                if (!someArray.IsOrdered())
                {
                    passedTest = false;
                }
            }
            Console.WriteLine("Sorted all 10 arrays? : " + passedTest);
            Console.ReadLine();

            RandomizedIntArray a3 = new RandomizedIntArray(10, 0, 50);
            Console.WriteLine("A3 : " + a3.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a3.GetSize());
            Console.WriteLine("IsOrdered : " + a3.IsOrdered());
            Console.WriteLine("Max Value : " + a3.GetMaxValue());
            Console.WriteLine("Min Value : " + a3.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("BUBBLE SORTING A3");
            a3.BubbleSort();
            Console.WriteLine("A3 : " + a3.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a3.GetSize());
            Console.WriteLine("IsOrdered : " + a3.IsOrdered());
            Console.WriteLine("Max Value : " + a3.GetMaxValue());
            Console.WriteLine("Min Value : " + a3.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("BubbleSort Tests");
            passedTest = true;
            for (int i = 0; i < 10; i++)
            {
                RandomizedIntArray someArray = new RandomizedIntArray(25, -100, 100);
                someArray.BubbleSort();
                Console.WriteLine(someArray.GetArrayAsString());
                if (!someArray.IsOrdered())
                {
                    passedTest = false;
                }
            }
            Console.WriteLine("Sorted all 10 arrays? : " + passedTest);
            Console.ReadLine();

            PrintHeader("MaxHeap");

            MaxHeap maxHeap = new MaxHeap(10);
            Console.WriteLine("Heap size : " + maxHeap.GetMaxHeapSize());
            Console.WriteLine("Number of elements : " + maxHeap.GetLength());
            Console.WriteLine("Heap values : " + maxHeap.GetArrayAsString());
            Console.WriteLine("IsHeap? : " + maxHeap.IsHeap());
            Console.ReadLine();

            for(int i = 1; i < 6; i++)
            {
                maxHeap.Insert(i);
            }
            Console.WriteLine("Heap size : " + maxHeap.GetMaxHeapSize());
            Console.WriteLine("Number of elements : " + maxHeap.GetLength());
            Console.WriteLine("Heap values : " + maxHeap.GetArrayAsString());
            Console.WriteLine("IsHeap? : " + maxHeap.IsHeap());
            Console.ReadLine();

            RandomizedIntArray a4 = new RandomizedIntArray(10, 0, 50);
            Console.WriteLine("A4 : " + a4.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a4.GetSize());
            Console.WriteLine("IsOrdered : " + a4.IsOrdered());
            Console.WriteLine("Max Value : " + a4.GetMaxValue());
            Console.WriteLine("Min Value : " + a4.GetMinValue());
            Console.WriteLine("IsHeap? : " + MaxHeap.IsHeap(a4.GetArrayItems()));
            Console.ReadLine();

            Console.WriteLine("QUICK SORTING A4");
            a4.QuickSort();
            Console.WriteLine("A4 : " + a4.GetArrayAsString());
            Console.WriteLine("Size (=10): " + a4.GetSize());
            Console.WriteLine("IsOrdered : " + a4.IsOrdered());
            Console.WriteLine("Max Value : " + a4.GetMaxValue());
            Console.WriteLine("Min Value : " + a4.GetMinValue());
            Console.ReadLine();

            Console.WriteLine("QuickSort Tests");
            passedTest = true;
            for (int i = 0; i < 10; i++)
            {
                RandomizedIntArray someArray = new RandomizedIntArray(25, -100, 100);
                someArray.QuickSort();
                Console.WriteLine(someArray.GetArrayAsString());
                if (!someArray.IsOrdered())
                {
                    passedTest = false;
                }
            }
            Console.WriteLine("Sorted all 10 arrays? : " + passedTest);
            Console.ReadLine();

            PrintHeader("Hashtable");

            Hashtable<string, string> hash = new Hashtable<string, string>(20);

            hash.Add("1", "item 1");
            hash.Add("2", "item 2");
            hash.Add("dsfdsdsd", "sadsadsadsad");

            string one = hash.Find("1");
            string two = hash.Find("2");
            string dsfdsdsd = hash.Find("dsfdsdsd");
            Console.WriteLine("Size: " + hash.GetSize());
            hash.Remove("1");
            Console.WriteLine("Size: " + hash.GetSize());
            Console.ReadLine();

            PrintHeader("Singularly Linked List");

            SingularLinkedList<int> list = new SingularLinkedList<int>();
            Console.WriteLine("Size: " + list.GetSize());
            Console.WriteLine("List: " + list.GetListAsString());
            Console.WriteLine("Index 0: " + list.GetAtPosition(0));
            Console.WriteLine("Index 1: " + list.GetAtPosition(1));
            Console.ReadLine();

            list.AddToLast(1);
            list.AddToLast(1);
            list.AddToLast(2);
            list.AddToLast(3);
            list.AddToLast(5);
            list.AddToFirst(100);
            Console.WriteLine("Size: " + list.GetSize());
            Console.WriteLine("List: " + list.GetListAsString());
            Console.WriteLine("Index 0: " + list.GetAtPosition(0));
            Console.WriteLine("Index 3: " + list.GetAtPosition(3));
            Console.WriteLine("Index 5: " + list.GetAtPosition(5));
            Console.WriteLine("Index 6: " + list.GetAtPosition(6));
            Console.WriteLine("Index -3: " + list.GetAtPosition(-3));
            Console.WriteLine("Index 100: " + list.GetAtPosition(100));
            Console.ReadLine();

            list.Reverse();
            Console.WriteLine("Size: " + list.GetSize());
            Console.WriteLine("List: " + list.GetListAsString());
            Console.ReadLine();

            list.RemoveAll(1);
            list.RemoveFirst(100);
            list.RemoveFirst(8);
            list.RemoveAll(99);
            Console.WriteLine("Size: " + list.GetSize());
            Console.WriteLine("List: " + list.GetListAsString());
            Console.WriteLine("Index 0: " + list.GetAtPosition(0));
            Console.ReadLine();

            PrintHeader("Stack");

            ArrayStack<int> stack = new ArrayStack<int>(5);
            Console.WriteLine("IsEmpty :" + stack.IsEmpty());
            Console.WriteLine("Size :" + stack.GetSize());
            Console.ReadLine();

            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            Console.WriteLine("IsEmpty :" + stack.IsEmpty());
            Console.WriteLine("Size :" + stack.GetSize());
            Console.ReadLine();

            stack.Pop();
            int something = stack.Pop();
            Console.WriteLine("IsEmpty :" + stack.IsEmpty());
            Console.WriteLine("Size :" + stack.GetSize());
            Console.WriteLine("Popped Value (should = 3) :" + something);
            Console.ReadLine();

            PrintHeader("Queue");

            ArrayQueue<int> queue = new ArrayQueue<int>(5);
            Console.WriteLine("IsEmpty :" + queue.IsEmpty());
            Console.WriteLine("Size :" + queue.GetSize());
            Console.WriteLine("To String :" + queue.GetQueueAsString());
            Console.ReadLine();

            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(5);
            Console.WriteLine("IsEmpty :" + queue.IsEmpty());
            Console.WriteLine("Size :" + queue.GetSize());
            Console.WriteLine("To String :" + queue.GetQueueAsString());
            Console.ReadLine();

            queue.Dequeue();
            int somethingElse = queue.Dequeue();
            Console.WriteLine("IsEmpty :" + queue.IsEmpty());
            Console.WriteLine("Size :" + queue.GetSize());
            Console.WriteLine("Dequeueped Value (should = 1) :" + somethingElse);
            Console.WriteLine("To String :" + queue.GetQueueAsString());
            Console.ReadLine();

            queue.Dequeue();
            queue.Enqueue(8);
            queue.Enqueue(13);
            Console.WriteLine("IsEmpty :" + queue.IsEmpty());
            Console.WriteLine("Size :" + queue.GetSize());
            Console.WriteLine("To String :" + queue.GetQueueAsString());
            Console.ReadLine();

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("IsEmpty :" + queue.IsEmpty());
            Console.WriteLine("Size :" + queue.GetSize());
            Console.WriteLine("To String :" + queue.GetQueueAsString());
            Console.ReadLine();

            PrintHeader("BinarySearchTree");

            BinarySearchTree<int> tree1 = new BinarySearchTree<int>();
            Console.WriteLine("Size : " + tree1.GetSize());
            Console.WriteLine("To String : " + tree1.GetTreeAsString());
            Console.ReadLine();

            Console.WriteLine("Inserting values into the tree ...");
            tree1.Insert(new int[] { 41, 24, 7, 0, 13, 254, 31, 50});
            Console.WriteLine("Size : " + tree1.GetSize());
            Console.WriteLine("Min Value : " + tree1.GetMinimumValue());
            Console.WriteLine("Max value : " + tree1.GetMaximumValue());
            Console.WriteLine("To String (InOrder): " + tree1.GetTreeAsString());
            Console.WriteLine("To String (PreOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.PRE));
            Console.WriteLine("To String (PostOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.POST));
            Console.WriteLine("To String (BreadthOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.BREADTH));
            Console.ReadLine();

            Console.Write("Deleteing values from the tree ...");
            tree1.Delete(24);
            Console.WriteLine("Size : " + tree1.GetSize());
            Console.WriteLine("Min Value : " + tree1.GetMinimumValue());
            Console.WriteLine("Max value : " + tree1.GetMaximumValue());
            Console.WriteLine("To String (InOrder): " + tree1.GetTreeAsString());
            Console.WriteLine("To String (PreOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.PRE));
            Console.WriteLine("To String (PostOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.POST));
            Console.WriteLine("To String (BreadthOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.BREADTH));
            Console.ReadLine();

            Console.Write("Deleteing MORE values from the tree ...");
            tree1.Delete(new int[] { 0, 8, 254});
            Console.WriteLine("Size : " + tree1.GetSize());
            Console.WriteLine("Min Value : " + tree1.GetMinimumValue());
            Console.WriteLine("Max value : " + tree1.GetMaximumValue());
            Console.WriteLine("To String (InOrder): " + tree1.GetTreeAsString());
            Console.WriteLine("To String (PreOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.PRE));
            Console.WriteLine("To String (PostOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.POST));
            Console.WriteLine("To String (BreadthOrder): " + tree1.GetTreeAsString(BinarySearchTree<int>.TRAVERSAL_ORDER.BREADTH));
            Console.ReadLine();
        }
}
}
