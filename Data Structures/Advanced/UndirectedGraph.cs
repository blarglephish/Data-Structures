using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures
{
    public class Edge<T>
    {
        private Vertex<T> v1;
        private Vertex<T> v2;
    }

    public class Vertex<T>
    {
        public T Data;
        public LinkedList<Edge<T>> Neighbors;
        public Dictionary<string, object> Properties;

        public Vertex(T data)
        {

        }
    }

    class UndirectedGraph<T>
    {
        private const int MAX_SIZE = 128;
        private Vertex<T>[] V;

        public UndirectedGraph(int size = MAX_SIZE)
        {
            V = new Vertex<T>[size];
        }
    }
}
