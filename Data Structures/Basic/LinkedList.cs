using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class Node<V>
    {
        public V Value { get; set; }
        public Node<V> Next { get; set; }

        public Node(V value, Node<V> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public Node(V value)
        {
            this.Value = value;
            this.Next = null;
        }
    }

    public class SingularLinkedList<V>
    {
        private Node<V> Head;

        public SingularLinkedList(V value)
        {
            this.Head = new Node<V>(value);
        }

        public SingularLinkedList(Node<V> head)
        {
            this.Head = head;
        }

        public SingularLinkedList()
        {
            this.Head = null;
        }

        public int GetSize()
        {
            int size = 0;
            Node<V> current = this.Head;
            while (current != null)
            {
                size++;
                current = current.Next;
            }

            return size;
        }

        public void AddToLast(V value)
        {
            if (this.Head == null)
            {
                Head = new Node<V>(value);
            }
            else
            {
                Node<V> current = this.Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<V>(value);
            }
        }

        public void AddToFirst(V value)
        {
            Node<V> temp = Head;
            this.Head = new Node<V>(value, temp);
        }

        public V GetAtPosition(int index)
        {
            if (Head == null || index < 0 || index >= GetSize())
            {
                return default(V);
            }

            Node<V> current = this.Head;
            V retVal = current.Value;
            for(int i = 0; i <= index; i++)
            {
                retVal = current.Value;
                current = current.Next;
            }
            return retVal;
        }

        public string GetListAsString()
        {
            string retVal = "{ ";
            Node<V> current = this.Head;
            while (current != null)
            {
                retVal += current.Value.ToString() + " ";
                current = current.Next;
            }
            return retVal += "}";
        }

        public void RemoveAll(V value)
        {
            if (Head == null)
            {
                return;
            }
            else if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                return;
            }
            else
            {
                Node<V> current = Head;
                while (current.Next != null)
                {
                    while (current.Next.Value.Equals(value))
                    {
                        Node<V> after = current.Next.Next;
                        current.Next = after;
                    }

                    current = current.Next;
                }
            }
        }

        public void RemoveFirst(V value)
        {
            if (Head == null)
            {
                return;
            }
            else if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                return;
            }
            else
            {
                Node<V> current = Head;
                while (current.Next != null)
                {
                    if (current.Next.Value.Equals(value))
                    {
                        Node<V> after = current.Next.Next;
                        current.Next = after;
                        return;
                    }

                    current = current.Next;
                }
            }
        }

        public void Reverse()
        {
            Node<V> prev = null;
            Node<V> next = null;
            Node<V> current = Head;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }
    }

    public class DNode<V>
    {
        public V Value { get; set; }
        public DNode<V> Next { get; set; }
        public DNode<V> Prev { get; set; }

        public DNode(V value, DNode<V> next, DNode<V> prev)
        {
            this.Value = value;
            this.Next = next;
            this.Prev = prev;
        }

        public DNode(V value)
        {
            this.Value = value;
            this.Next = null;
            this.Prev = null;
        }
    }

    public class DoubleLinkedList<V>
    {
        private DNode<V> Head;

        public DoubleLinkedList(V value)
        {
            Head = new DNode<V>(value);
        }

        public DoubleLinkedList(DNode<V> node)
        {
            Head = node;
        }

        public DoubleLinkedList()
        {
            Head = null;
        }

        public int GetSize()
        {
            int size = 0;
            DNode<V> current = this.Head;
            while (current != null)
            {
                size++;
                current = current.Next;
            }

            return size;
        }

        public string GetListAsString()
        {
            string retVal = "{ ";
            DNode<V> current = this.Head;
            while (current != null)
            {
                retVal += current.Value.ToString() + " ";
                current = current.Next;
            }
            return retVal += "}";
        }

        public void AddToLast(V valToAdd)
        {

        }
    }
}
