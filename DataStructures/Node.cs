using System;
using System.Collections;

namespace DataStructures
{
    public class Node<T>
    {
        public T data;
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T input, Node<T> previous = null, Node<T> next = null)
        {
            data = input;
            Next = next;
            Previous = previous;
        }
    }
}
