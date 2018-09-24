using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    class ArrayStack<V>
    {
        private V[] Items;
        private int Top;
        private const int MAX_SIZE = 126;

        public ArrayStack(int size = MAX_SIZE)
        {
            this.Items = new V[size];
            this.Top = -1;
        }

        public void Push(V value)
        {
            if (Top == Items.Length -1)
            {
                //overflow, throw error
            }
            else
            {
                Top++;
                Items[Top] = value;
            }
        }

        public V Pop()
        {
            if (IsEmpty())
            {
                // Underflow
                return default(V);
            }
            else
            {
                Top--;
                return Items[Top + 1];
            }
        }

        public V Peek()
        {
            if (!IsEmpty())
            {
                return Items[Top];
            }

            return default(V);
        }

        public bool IsEmpty()
        {
            return (Top == -1);
        }

        public int GetSize()
        {
            return Top+1;
        }

        public int GetMaxSize()
        {
            return Items.Length;
        }
    }
}
