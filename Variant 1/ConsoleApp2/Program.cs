using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new int[] { 1, 2, 3, 4, 5, 6, 7};
            int[] a2 = new int[] { 4, 5, 6, 7, 8, 9, 10 };

            MyStack<int> s1 = new MyStack<int>(a1);
            MyStack<int> s2 = new MyStack<int>(a2);

            MyQueue<int> b = new MyQueue<int>();
            MyQueue<int> q = new MyQueue<int>();

            Dictionary<int, int> d1 = new Dictionary<int, int>();
            Dictionary<int, int> d2 = new Dictionary<int, int>();

            while(s1.Count != 0)
            {
                AddToDictionary(d1, s1.Pop());
            }
            while (s2.Count != 0)
            {
                AddToDictionary(d2, s2.Pop());
            }

            foreach(var key in d1.Keys)
            {
                if (d2.ContainsKey(key))
                {
                    b.Enqueue(key);
                    d1.Remove(key);
                    d2.Remove(key);
                }
                else
                {
                    q.Enqueue(key);
                }
            }
            foreach (var key in d2.Keys)
            {
                q.Enqueue(key);
            }


            Console.WriteLine("Пересечение:");
            while(b.Count != 0)
            {
                Console.WriteLine($"{b.Dequeue()} ");
            }
            Console.WriteLine("Оставшиеся элементы:");
            while(q.Count != 0)
            {
                Console.WriteLine($"{q.Dequeue()} ");
            }


        }
        static void AddToDictionary(Dictionary<int, int> dict, int key)
        {
            if (dict.ContainsKey(key))
            {
                dict[key]++;
            }
            else
            {
                dict[key] = 1;
            }
        }
    }
    public class MyList<T> : ICloneable, IEnumerable<MyListNode<T>>
    {
        public int Count { get; private set; }

        public MyListNode<T>? First { get; private set; }
        public MyListNode<T>? Last { get; private set; }

        public MyList()
        {
            First = null;
            Last = First;
            Count = 0;
        }
        public MyList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                InsertInEnd(item);
            }
        }

        private void ValidateNode(MyListNode<T> node)
        {
            if (node.List != this)
            {
                throw new InvalidOperationException("List doesn't contain this node");
            }
        }
        private void DestroyNode(MyListNode<T> node, MyListNode<T>? previousNode)
        {
            if (node == First)
                First = node.Next;
            if (node == Last)
                Last = previousNode;

            if (previousNode is not null)
                previousNode.Next = node.Next;

            node.Dispose();
            Count--;
        }
        private void InsertNode(MyListNode<T> node, MyListNode<T>? previousNode)
        {
            MyListNode<T>? nextNode = previousNode is null ?
                                      First :
                                      previousNode.Next;

            if (previousNode is null && nextNode is null) // Count == 0
            {
                node.Next = null;
                First = node;
                Last = node;
            }
            else if (previousNode is null && nextNode is not null) // Insertion in beginning
            {
                node.Next = First;
                First = node;
            }
            else if (previousNode is not null && nextNode is null) // Insertion in end
            {
                previousNode.Next = node;
                node.Next = null;
                Last = node;
            }
            else
            {
                previousNode!.Next = node;
                node.Next = nextNode;
            }

            Count++;
        }

        public MyListNode<T> GetNode(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index is below zero");
            if (index >= Count)
                throw new ArgumentOutOfRangeException("Index is greater than amount of nodes");

            int counter = 0;
            foreach (var node in this)
            {
                if (counter == index)
                    return node;
                counter++;
            }
            return null;
        }
        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            foreach (MyListNode<T> node in this)
            {
                if (comparer.Equals(node.Value, item))
                    return true;
            }
            return false;
        }

        public void InsertInEnd(T? item) // O(1)
        {
            MyListNode<T> node = new MyListNode<T>(item, this);

            InsertNode(node, Last);
        }
        public void InsertInBeginning(T? item) // O(1)
        {
            MyListNode<T> node = new MyListNode<T>(item, this);

            InsertNode(node, null);
        }

        public void RemoveFirst() // O(1)
        {
            if (First is null)
                throw new InvalidOperationException("List is empty");

            DestroyNode(First, null);
        }
        public void InsertAfter(MyListNode<T> node, T item) // O(1)
        {
            MyListNode<T> newNode = new MyListNode<T>(item, this);
            ValidateNode(node);

            InsertNode(newNode, node);
        }
        public void RemoveAfter(MyListNode<T> node) // O(1)
        {
            ValidateNode(node);

            if (node == Last)
                throw new InvalidOperationException("No nodes after the last one");

            DestroyNode(node.Next!, node);
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public MyList<T> GetRange(int index, int count) // O(n)
        {
            if (index + count > Count)
                throw new ArgumentOutOfRangeException("Elements are outside of the list");
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index is below zero");
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Amount of elements is below or equals zero");

            MyList<T> result = new MyList<T>();
            int i = 0;
            foreach (MyListNode<T> node in this)
            {
                if (i >= index)
                {
                    result.InsertInBeginning(node.Value);
                }
                if (i >= index + count)
                    break;
                i++;
            }

            return result;
        }
        public void AddRange(MyList<T> list) // O(n)
        {
            foreach (var node in list)
            {
                InsertInEnd(node.Value);
            }
        }
        public MyList<T> Concatenate(MyList<T> list) // O(n)
        {
            MyList<T> result = new MyList<T>();

            foreach (var node in this)
            {
                result.InsertInBeginning(node.Value);
            }
            foreach (var node in list)
            {
                result.InsertInBeginning(node.Value);
            }
            return result;
        }
        public object Clone()
        {
            MyList<T> result = new MyList<T>();
            MyListNode<T> currentNode = First!;
            while (currentNode is not null)
            {
                result.InsertInEnd(currentNode.Value);
                currentNode = currentNode.Next!;
            }
            return result;
        }
        public IEnumerator<MyListNode<T>> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }
    }
    internal class MyListEnumerator<T> : IEnumerator<MyListNode<T>>
    {
        private MyList<T>? list;

        private MyListNode<T>? currentNode;

        public MyListEnumerator(MyList<T> List)
        {
            list = (MyList<T>)List.Clone();
            Reset();
        }


        object IEnumerator.Current => Current;
        public MyListNode<T> Current
        {
            get
            {
                return currentNode!;
            }
        }


        public bool MoveNext()
        {
            currentNode = currentNode!.Next;
            return currentNode is not null;
        }

        public void Reset()
        {
            currentNode = new MyListNode<T>(default, list!.First);
        }

        public void Dispose()
        {
            list = null;
            currentNode = null;
        }
    }
    public class MyListNode<T> : IDisposable, ICloneable
    {
        public T? Value;
        public MyListNode<T>? Next;
        public MyList<T>? List;

        public MyListNode(T? value)
        {
            Value = value;
        }
        public MyListNode(T? value, MyListNode<T>? next)
        {
            Value = value;
            Next = next;
        }
        public MyListNode(T? value, MyList<T>? list)
        {
            Value = value;
            List = list;
        }
        public MyListNode(T? value, MyListNode<T>? next, MyList<T>? list)
        {
            Value = value;
            Next = next;
            List = list;
        }
        public void Dispose()
        {
            Next = null;
            List = null;
        }
        public object Clone()
        {
            return new MyListNode<T>(Value, Next, List);
        }
    }
    public class MyQueue<T> : ICloneable
    {
        private MyList<T> _items;
        public int Count { get => _items.Count; }
        public MyQueue()
        {
            _items = new MyList<T>();
        }
        public MyQueue(IEnumerable<T> collection)
        {
            _items = new MyList<T>(collection);
        }
        private MyQueue(MyList<T> items)
        {
            _items = (MyList<T>)items.Clone();
        }
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
        public T? GetItem(int index)
        {
            return _items.GetNode(index).Value;
        }
        public void Enqueue(T item)
        {
            _items.InsertInEnd(item);
        }
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in queue");
            var result = _items.First.Value;
            _items.RemoveFirst();
            return result;
        }
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in queue");
            return _items.First.Value;
        }

        public object Clone()
        {
            return new MyQueue<T>(_items);
        }
    }
    public class MyStack<T> : ICloneable
    {
        private MyList<T> _items;
        public int Count { get => _items.Count; }


        public MyStack()
        {
            _items = new MyList<T>();
        }
        public MyStack(IEnumerable<T> collection)
        {
            _items = new MyList<T>();

            foreach (T item in collection)
            {
                Push(item);
            }
        }

        private MyStack(MyList<T> items)
        {
            _items = (MyList<T>)items.Clone();
        }

        public bool Contains(T? item)
        {
            return _items.Contains(item);
        }

        public T? GetItem(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index is below zero");
            if (index >= Count)
                throw new ArgumentOutOfRangeException("Index is greater than amount of nodes");

            return _items.GetNode(index).Value;
        }

        public T? Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");
            return _items.First!.Value;
        }
        public T? Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            T? value = _items.First!.Value;
            _items.RemoveFirst();
            return value;
        }
        public void Push(T? item)
        {
            _items.InsertInBeginning(item);
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public object Clone()
        {
            return new MyStack<T>(_items);
        }
    }

}