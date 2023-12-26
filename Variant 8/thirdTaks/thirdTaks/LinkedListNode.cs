using System;
namespace thirdTaks
{
    public class LinkedListNode<T>
    {
        public T Data;
        public LinkedListNode<T> Next;
        public LinkedListNode<T> Prev;

        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}

