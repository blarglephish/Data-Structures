using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    class ArrayQueue<V>
    {
        private const int MAX_SIZE = 126;

        private V[] Items;
        private int Head;
        private int Tail;

        public ArrayQueue(int size = MAX_SIZE)
        {
            Items = new V[size];
            Head = Tail = -1;
        }

        public void Enqueue(V value)
        {
            // Case 1: Overflow
            if ((Head == 0 && Tail == Items.Length-1) || (Head == Tail + 1))
            {
                // Overflow
            }
            else
            {
                if (IsEmpty())
                {
                    Head = Tail = 0;
                }
                else
                {
                    Tail = (Tail == Items.Length - 1) ? 0 : Tail + 1;
                }
                Items[Tail] = value;
            }
        }

        public V Dequeue()
        {
            // Case 1: Empty
            if (IsEmpty())
            {
                // Underflow
                return default(V);
            }
            else
            {
                // Case 2: General
                V retVal = Items[Head];

                if (Head == Tail)
                {
                    Head = Tail = -1;
                }
                else
                {
                    Head = (Head == Items.Length - 1) ? 0 : Head + 1;
                }

                return retVal;
            }
        }

        public bool IsEmpty()
        {
            return (Head == -1 && Tail == -1);
        }

        public bool IsFull()
        {
            return ((Tail + 1) == Head);
        }

        public string GetQueueAsString()
        {
            string retVal = "{ ";
            int front = Head;
            int rear = Tail;

            if (IsEmpty())
            {
                // Do nothing
            }
            else
            {
                if (front <= rear)
                {
                    while (front <= rear)
                    {
                        retVal += Items[front].ToString() + " ";
                        front++;
                    }
                }
                else
                {
                    while (front <= Items.Length-1)
                    {
                        retVal += Items[front].ToString() + " ";
                        front++;
                    }
                    front = 0;
                    while (front <= rear)
                    {
                        retVal += Items[front].ToString() + " ";
                        front++;
                    }
                }
            }

            return retVal += "}";
        }

        public int GetSize()
        {
            int size = 0;
            int front = Head;
            int rear = Tail;

            if (IsEmpty())
            {
                // Do nothing
            }
            else
            {
                if (front <= rear)
                {
                    while (front <= rear)
                    {
                        size++;
                        front++;
                    }
                }
                else
                {
                    while (front <= Items.Length-1)
                    {
                        size++;
                        front++;
                    }
                    front = 0;
                    while (front <= rear)
                    {
                        size++;
                        front++;
                    }
                }
            }

            return size;
        }
    }
}
