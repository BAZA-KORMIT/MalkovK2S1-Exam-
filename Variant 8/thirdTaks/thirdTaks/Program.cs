﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using thirdTaks;

namespace thirdTask
{
    class Program
    {
        //закинуть элементы из стека которых нет в листе в очередь
        static void Main()
        {
            //MyLinkedList<int> linkedList = new MyLinkedList<int>();
            MyLinkList<int> list= new MyLinkList<int>(); 
            MyStack<int> stack = new MyStack<int>();
            MyQuery<int> query = new MyQuery<int>();

            StackFilling(stack);
            LinkedListFilling(list) ;
            GetQuery(list, stack, query);
            Console.Write("Итоговая очередь: ");
            foreach (int c in query)
                Console.Write(c+" ");
        }

        static void GetQuery(MyLinkList<int> list, MyStack<int> stack, MyQuery<int> query)
        {
            for (int i = 0; i < 10; i++)
            {
                if (list.Contains(stack.Peek()))
                {
                    stack.Remove();
                }
                else
                {
                    query.Add(stack.Peek());
                    stack.Remove();
                }
            }
        }

        static void LinkedListFilling(MyLinkList<int> linkedList)
        {
            for (int i = 1; i <= 7; i++)
            {
                if (i % 2 == 0)
                    linkedList.AddFirst(i);
                else
                    linkedList.Add(i);
            }
        }

        static void StackFilling(MyStack<int> stack)
        {
            for (int i = 1; i <= 10; i++)
                stack.Add(i);
        }
    }

    // Есть добавление в начало и конец и удаление тоже
    // имеет 2 поля указателя - на следующий и предыдущий элемент
    // используется линкед лист нода. У нее есть ссылка не только на следующий элемент (как в обычной ноде), но и на предыдущий
    public class MyLinkList<T>
    {
        private thirdTaks.LinkedListNode<T> head;
        private thirdTaks.LinkedListNode<T> tail;
        int count;

        public MyLinkList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddFirst(T data)
        {
            thirdTaks.LinkedListNode<T> newLinkedListNode = new(data);

            if (head == null)
            {
                head = newLinkedListNode;
                tail = newLinkedListNode;
            }
            else
            {
                newLinkedListNode.Next = head;
                head.Prev = newLinkedListNode;
                head = newLinkedListNode;
            }
            count++;
        }

        public void Add(T data)
        {
            thirdTaks.LinkedListNode<T> node = new(data);

            if (head == null)
                head = node;
            else
                tail!.Next = node;
            tail = node;

            count++;
        }

        public void Remove(T data)
        {
            thirdTaks.LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == head)
                        head = current.Next;

                    if (current == tail)
                        tail = current.Prev;

                    if (current.Prev != null)
                        current.Prev.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;

                    break;
                }

                current = current.Next;
            }
            count--;
        }

        public bool Contains(T data)
        {
            thirdTaks.LinkedListNode<T> current = head;
            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        public T Remove()
        {
            thirdTaks.LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current == head)
                    head = current.Next;

                if (current == tail)
                    tail = current.Prev;

                if (current.Prev != null)
                    current.Prev.Next = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;

                break;
            }
            count--;
            return current.Data;
        }
        public int Count() => count;

        public bool IsEmpty() => count == 0;
    }
    /*public class MyLinkedList<T> : IEnumerable<T>
    {
        Node<T>? head; 
        Node<T>? tail; 
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail!.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента

        public bool Remove(T data)
        {
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head?.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count => count;
        public bool IsEmpty() { return count == 0; }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T>? current = head;
            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }*/

    public class MyStack<T> : IMove<T>
    {
        private Node<T> top;
        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item)
            {
                Data = item,
                Next = top
            };
            top = newNode;
        }

        public T Remove()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            T item = top.Data;
            top = top.Next;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            return top.Data;
        }

        public bool isEmpty() => top == null;
        public bool IsEmpty => top == null;
    }

    public class MyQuery<T> : IEnumerable<T>, IMove<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }

        public bool isEmpty() => count == 0;

        public T Remove()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        public int Count => count;
        public bool IsEmpty => count == 0;

        public void Clear()
        {
            head = tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}