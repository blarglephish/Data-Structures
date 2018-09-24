using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public struct KeyValuePair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    class Hashtable<K, V>
    {
        private readonly int size;
        private LinkedList<KeyValuePair<K, V>>[] items;

        public Hashtable(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<K, V>>[size];
        }

        public Hashtable()
        {
            new Hashtable<K, V>(int.MaxValue);
        }

        private int GetHashCodeFromKey(K key)
        {
            // return a hash code
            // possible ideas: 
            //    k mod m
            //    m * (A k mod 1)
            return key.GetHashCode(); 
        }

        private int GetArrayPosition(K key)
        {
            int position = GetHashCodeFromKey(key) % size;
            return Math.Abs(position);
        }

        private LinkedList<KeyValuePair<K, V>> GetLinkedList(int index)
        {
            LinkedList<KeyValuePair<K, V>> list = items[index];
            if (list == null)
            {
                list = new LinkedList<KeyValuePair<K, V>>();
                items[index] = list;
            }

            return list;
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            KeyValuePair<K, V > item = new KeyValuePair<K, V> { Key = key, Value = value };
            list.AddLast(item);
        }

        public V Find(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            foreach (KeyValuePair<K, V> item in list)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }

        public bool Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> list = GetLinkedList(position);
            bool foundItem = false;
            foreach (KeyValuePair<K, V> item in list)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = list.Remove(item);
                    break;
                }
            }

            return foundItem;
        }

        public int GetSize()
        {
            int retVal = 0;
            foreach(LinkedList<KeyValuePair<K, V>> list in items)
            {
                if (list != null)
                {
                    foreach (KeyValuePair<K, V> item in list)
                    {
                        retVal++;
                    }
                }
            }

            return retVal;
        }
    }
}
