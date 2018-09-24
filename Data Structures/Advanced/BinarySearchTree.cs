using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class BSTNode<T> where T : IComparable
    {
        public T Key;
        public BSTNode<T> Parent;
        public BSTNode<T> Left;
        public BSTNode<T> Right;

        public BSTNode(T key, 
            BSTNode<T> parent,
            BSTNode<T> left,
            BSTNode<T> right)
        {
            this.Key = key;
            this.Parent = parent;
            this.Left = left;
            this.Right = right;
        }

        public BSTNode(T key) : this(key, null, null, null) { }
        public BSTNode() : this(default(T), null, null, null) { }
    }

    class BinarySearchTree<T> where T : IComparable
    {
        private BSTNode<T> Root;
        private static BSTNode<T> NIL = new BSTNode<T>(default(T), null, null, null);

        public enum TRAVERSAL_ORDER
        {
            IN,
            PRE,
            POST,
            BREADTH
        };

        public BinarySearchTree(BSTNode<T> root)
        {
            this.Root = root;
        }

        public BinarySearchTree(T key)
        {
            BSTNode<T> root = new BSTNode<T>(key);
            this.Root = root;
        }

        public BinarySearchTree() : this(null) { }

        public string GetTreeAsString(TRAVERSAL_ORDER order = TRAVERSAL_ORDER.IN)
        {
            string retVal = "{ ";
            switch(order)
            {
                case TRAVERSAL_ORDER.BREADTH:
                    retVal += _BreadthOrderTreeWalk(Root, string.Empty);
                    break;
                case TRAVERSAL_ORDER.PRE:
                    retVal += _PreorderTreeWalk(Root, string.Empty);
                    break;
                case TRAVERSAL_ORDER.POST:
                    retVal += _PostorderTreeWalk(Root, string.Empty);
                    break;
                case TRAVERSAL_ORDER.IN:
                default:
                    retVal += _InorderTreeWalk(Root, string.Empty);
                    break;
            }

            return retVal += "}";
        }

        public int GetSize()
        {
            return _GetTreeSize(Root, 0);
        }

        public BSTNode<T> Search(T key)
        {
            return _treeSearch(Root, key);
        }

        public BSTNode<T> SearchIterative(T key)
        {
            return _treeSearchIterative(Root, key);
        }

        public BSTNode<T> GetMinimum()
        {
            return _treeMinimum(Root);
        }

        public T GetMinimumValue()
        {
            return GetMinimum().Key;
        }

        public BSTNode<T> GetMaximum()
        {
            return _treeMaximum(Root);
        }

        public T GetMaximumValue()
        {
            return GetMaximum().Key;
        }

        public void Insert(T v)
        {
            BSTNode<T> z = new BSTNode<T>(v);

            BSTNode<T> y = null;
            BSTNode<T> x = Root;
            while (x != null)
            {
                y = x;
                x = (z.Key.CompareTo(x.Key) == -1) ? x.Left : x.Right;
            }

            z.Parent = y;
            if (y == null)
            {
                Root = z; // The tree was empty
            }
            else
            {
                if (z.Key.CompareTo(y.Key) == -1) // z.Key < y.key
                {
                    y.Left = z;
                }
                else
                {
                    y.Right = z;
                }
            }
        }

        public void Insert(T[] values)
        {
            foreach(T item in values)
            {
                Insert(item);
            }
        }

        public BSTNode<T> Delete(T v)
        {
            BSTNode<T> z = SearchIterative(v);  // Get pointer to the node to delete
            if (z == null)
            {
                return z;
            }

            BSTNode<T> x;
            BSTNode<T> y;
            y = (z.Left == null || z.Right == null) ? z : _treeSuccessor(z);
            x = (y.Left != null) ? y.Left : y.Right;
            if (x != null)
            {
                x.Parent = y.Parent;
            }

            if (y.Parent == null)
            {
                Root = x;
            }
            else
            {
                if (y == y.Parent.Left)
                {
                    y.Parent.Left = x;
                }
                else
                {
                    y.Parent.Right = x;
                }
            }

            if (y != z)
            {
                z.Key = y.Key;
                // Copy any additional satellite data into z
            }

            return y;
        }

        public BSTNode<T>[] Delete(T[] values)
        {
            BSTNode<T>[] nodes = new BSTNode<T>[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                nodes[i] = Delete(values[i]);
            }

            return nodes;
        }

        #region Private Methods
        private static string _PostorderTreeWalk(BSTNode<T> x, string retVal)
        {
            string numSequence = string.Empty;
            if (x != null)
            {
                retVal += _PostorderTreeWalk(x.Left, numSequence);
                retVal += _PostorderTreeWalk(x.Right, numSequence);
                retVal += x.Key + " ";
            }

            return retVal;
        }

        private static string _PreorderTreeWalk(BSTNode<T> x, string retVal)
        {
            string numSequence = string.Empty;
            if (x != null)
            {
                retVal += x.Key + " ";
                retVal += _PreorderTreeWalk(x.Left, numSequence);
                retVal += _PreorderTreeWalk(x.Right, numSequence);
            }

            return retVal;
        }

        private static string _InorderTreeWalk(BSTNode<T> x, string retVal)
        {
            string numSequence = string.Empty;
            if (x != null)
            {
                retVal += _InorderTreeWalk(x.Left, numSequence);
                retVal += x.Key + " ";
                retVal += _InorderTreeWalk(x.Right, numSequence);
            }

            return retVal;
        }

        private static string _BreadthOrderTreeWalk(BSTNode<T> x, string retVal)
        {
            ArrayQueue<BSTNode<T>> q = new ArrayQueue<BSTNode<T>>();
            q.Enqueue(x);
            while (!q.IsEmpty())
            {
                BSTNode<T> z = q.Dequeue();
                if (z != null)
                {
                    retVal += z.Key + " ";
                    q.Enqueue(z.Left);
                    q.Enqueue(z.Right);
                }
            }

            return retVal;
        }

        private static int _GetTreeSize(BSTNode<T> x, int count)
        {
            int retVal = 0;
            if (x != null)
            {
                int leftTreeSize = _GetTreeSize(x.Left, count);
                int rightTreeSize = _GetTreeSize(x.Right, count);
                retVal = leftTreeSize + rightTreeSize + 1;
            }

            return retVal;
        }

        private static BSTNode<T> _treeSearch(BSTNode<T> x, T key)
        {
            if (x == null || key.Equals(x.Key))
            {
                return x;
            }
            if (key.CompareTo(x.Key) == -1) // key < x.key
            {
                return _treeSearch(x.Left, key);
            }
            else
            {
                return _treeSearch(x.Right, key);
            }
        }

        private static BSTNode<T> _treeSearchIterative(BSTNode<T> x, T key)
        {
            while (x != null && !key.Equals(x.Key))
            {
                x = (key.CompareTo(x.Key) == -1) ? x.Left : x.Right;
            }

            return x;
        }

        private BSTNode<T> _treeMinimum(BSTNode<T> x)
        {
            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }

        private BSTNode<T> _treeMaximum(BSTNode<T> x)
        {
            while (x.Right != null)
            {
                x = x.Right;
            }

            return x;
        }

        private BSTNode<T> _treeSuccessor(BSTNode<T> x)
        {
            // Case 1: X has a right child
            if (x.Right != null)
            {
                return _treeMinimum(x.Right);
            }
            else
            {
                // Case 2: X DOES NOT have a right child
                BSTNode<T> y = x.Parent;
                while (y != null && x == y.Right)
                {
                    x = y;
                    y = y.Parent;
                }
                return y;
            }
        }

        private BSTNode<T> _treePredecessor(BSTNode<T> x)
        {
            // Case 1: X has a left child
            if (x.Left != null)
            {
                return _treeMaximum(x.Left);
            }
            else
            {
                // Case 2: X DOES NOT have a right child
                BSTNode<T> y = x.Parent;
                while (y != null && x == y.Left)
                {
                    x = y;
                    y = y.Parent;
                }
                return y;
            }
        }
        #endregion
    }
}
