using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZadachaStecki
{
    public class Zadachi
    {
        public static void Peresecheniye<T>(ClassicQueue<T> firsts, ClassicQueue<T> seconds )
        {
            /*Mylist<T> Listfirst = new Mylist<T>();
            Mylist<T> Listsecond = new Mylist<T>();
            while (firsts. != null)
            {
                Listfirst.Add(firsts.element.Data);
                firsts.element = firsts.element.Next;
            }
            while (seconds.element != null)
            {
                Listsecond.Add(seconds.element.Data);
                seconds.element = seconds.element.Next;
            }*/

        }
    }
    /// <summary>
    /// Класс связный списко необходимый для реализации класса стек
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// текущее значение в списке
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Связный список для стека
        /// </summary>
        public LinkedList<T> Next { get; set; }
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="data">текущий элемент списка</param>
        public LinkedList(T data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// Класс стек
    /// </summary>
    public class MyStack<T>
    {
        /// <summary>
        /// Связный список необходимы для стека
        /// </summary>
        public LinkedList<T> element;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MyStack()
        {
            element = null;
        }
        /// <summary>
        /// Проверка стека на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() { return element == null; }
        /// <summary>
        /// Метод заполнения стэка из листа
        /// </summary>
        /// <param name="list"></param>
        public void EnqList(Mylist<T> list)
        {
            while (!list.IsEmpty())
            {
                LinkedList<T> newNode = new LinkedList<T>(list.Removefirst());
                if (IsEmpty())
                    element = newNode;
                else
                {
                    newNode.Next = element;
                    element = newNode;
                }
            }
        }
        /// <summary>
        /// Метод добавления элемента в стек
        /// </summary>
        /// <param name="data">элемент</param>
        public void Push(T data)
        {
            LinkedList<T> newNode = new LinkedList<T>(data);
            if (IsEmpty())
                element = newNode;
            else
            {
                newNode.Next = element;
                element = newNode;
            }
        }
        /// <summary>
        /// Метод, позволяет извлечь верхний элемент стека
        /// </summary>
        /// <returns>Значение верхнего элемента</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");
            T data = element.Data;
            element = element.Next;
            return data;
        }
        /// <summary>
        /// Метод, позволяет получить значение верхнего элемента стека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");
            return element.Data;
        }
        /// <summary>
        /// Метод, который очищает стек
        /// </summary>
        public void Clear()
        {
            element = null;
        }
        /// <summary>
        /// Проверяет есть ли в стеке элемент
        /// </summary>
        /// <param name="value">элемент для проверки на наличие</param>
        /// <returns></returns>
        public bool Contatins(T value)
        {
            LinkedList<T> current = element;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return true;
                else
                    current = current.Next;
            }
            return false;
        }
    }


    /// <summary>
    /// Класс создающий очередь на основе двух стеков
    /// </summary>
    public class StackQueue<T>
    {
        /// <summary>
        /// голова очереди
        /// </summary>
        private LinList head;
        /// <summary>
        /// последний элемент(хвост) очереди
        /// </summary>
        private LinList tail;
        /// <summary>
        /// класс связного списка
        /// </summary>
        private class LinList
        {
            public T Data { get; set; }
            public LinList Next { get; set; }
        }
        /// <summary>
        /// конструктор создающий очередь из двух стеков
        /// </summary>
        /// <param name="first">первый стек</param>
        /// <param name="second">второй стек</param>
        public StackQueue()
        {
            head = null;
            tail = null;
        }
        /// <summary>
        /// Метод добавления элемента в конец очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public void Enqueue(T item)
        {
            LinList newNode = new LinList { Data = item, Next = null };
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {

                tail.Next = newNode;
                tail = newNode;
            }
        }
        /// <summary>
        /// Метод извлечения элемента с начала очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста");
            T item = head.Data;
            head = head.Next;
            if (IsEmpty())
                tail = null;
            return item;
        }
        /// <summary>
        /// проверка на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (head == null && tail == null);
        }
    }


    /// <summary>
    /// Класс классическая очередь
    /// </summary>
    /// <typeparam name="T">тип данных</typeparam>
    public class ClassicQueue<T>
    {
        /// <summary>
        /// класс связного списка
        /// </summary>
        private class LinList
        {
            public T Data { get; set; }
            public LinList Next { get; set; }
        }
        /// <summary>
        /// голова очереди
        /// </summary>
        private LinList head;
        /// <summary>
        /// последний элемент(хвост) очереди
        /// </summary>
        private LinList tail;
        public Mylist<T> Peresech(ClassicQueue<T> second)
        {
            Mylist<T> Listfirst = new Mylist<T>();
            Mylist<T> Listsecond = new Mylist<T>();
            while (head != null)
            {
                Listfirst.Add(head.Data);
                head = head.Next;
            }
            while (second.head != null)
            {
                Listsecond.Add(second.head.Data);
                second.head = second.head.Next;
            }
            Mylist<T> uni = Listfirst.GetUnique(Listsecond);
            return uni;
        }
        /// <summary>
        /// Метод добавления элемента в конец очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public void Enqueue(T item)
        {
            LinList newNode = new LinList { Data = item, Next = null };
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }
        /// <summary>
        /// Метод извлечения элемента с начала очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста");
            T item = head.Data;
            head = head.Next;
            if (IsEmpty())
                tail = null;
            return item;
        }
        /// <summary>
        /// проверка на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }
    }
    /// <summary>
    /// Класс кольцевая очередь
    /// </summary>
    /// <typeparam name="T">Тип элементов</typeparam>
    public class RingQueue<T>
    {
        /// <summary>
        /// класс связного списка
        /// </summary>
        private class LinList
        {
            public T Data { get; set; }
            public LinList Next { get; set; }
        }
        /// <summary>
        /// голова очереди
        /// </summary>
        private LinList head;
        /// <summary>
        /// последний элемент(хвост) очереди
        /// </summary>
        private LinList tail;
        /// <summary>
        /// Метод добавления элемента в конец очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public void Enqueue(T item)
        {
            LinList newNode = new LinList { Data = item, Next = head };
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }
        /// <summary>
        /// Метод извлечения элемента с начала очереди
        /// </summary>
        /// <param name="item">Элемент</param>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста");
            T item = head.Data;
            head = head.Next;
            tail.Next = head;
            if (IsEmpty())
                tail = null;
            return item;
        }
        /// <summary>
        /// проверка на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }
    }


    /// <summary>
    /// Класс очередь с приоритетом
    /// </summary>
    /// <typeparam name="T">Тип элементов</typeparam>
    public class MyPriorityQueue<T>
    {
        /// <summary>
        /// Класс связного списка с приоритетом
        /// </summary>
        /// <typeparam name="T">Тип элементов</typeparam>
        private class Node<T>
        {
            /// <summary>
            /// Текущее значение
            /// </summary>
            public T data;
            /// <summary>
            /// Приоритет
            /// </summary>
            public int priority;
            /// <summary>
            /// список значений
            /// </summary>
            public Node<T> next;
            /// <summary>
            /// конструктор класса
            /// </summary>
            /// <param name="data">значение</param>
            /// <param name="priority">приоритет</param>
            public Node(T data, int priority)
            {
                this.data = data;
                this.priority = priority;
                this.next = null;
            }
        }
        /// <summary>
        /// Поле связного списка
        /// </summary>
        private Node<T> head;
        /// <summary>
        /// Кол-во элементов в списке
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MyPriorityQueue()
        {
            head = null;
            Count = 0;
        }
        /// <summary>
        /// Метод добавления элемента в очередь
        /// </summary>
        /// <param name="data">значение</param>
        /// <param name="priority">приоритет</param>
        public void Enqueue(T data, int priority)
        {
            Node<T> newNode = new Node<T>(data, priority);

            if (head == null || priority < head.priority)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.next != null && priority >= current.next.priority)
                {
                    current = current.next;
                }
                newNode.next = current.next;
                current.next = newNode;
            }
            Count++;
        }
        /// <summary>
        /// Метод удаления значения с наименьшим приоритетом из очереди
        /// </summary>
        /// <returns>значения с наименьшим приоритетом</returns>
        /// <exception cref="InvalidOperationException">Ошибка при пустой очереди </exception>
        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            T data = head.data;
            head = head.next;
            Count--;

            return data;
        }
        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }
    }
    /// <summary>
    /// Класс двухсторонней очереди
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Deq<T>
    {
        /// <summary>
        /// Вспомогательный класс связный список для двухсторонней очереди
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Node<T>
        {
            /// <summary>
            /// Текущее значение
            /// </summary>
            public T data;
            /// <summary>
            /// список предыдущих значений
            /// </summary>
            public Node<T> prev;
            /// <summary>
            /// список следующиъ значений
            /// </summary>
            public Node<T> next;
            /// <summary>
            /// конструктор класса
            /// </summary>
            /// <param name="data">значение</param>
            /// <param name="priority">приоритет</param>
            public Node(T data)
            {
                this.data = data;
                this.prev = null;
                this.next = null;
            }
        }
        /// <summary>
        /// Следующий список элементов
        /// </summary>
        private Node<T> front;
        /// <summary>
        /// Пердыдущий список элементов
        /// </summary>
        private Node<T> back;
        /// <summary>
        /// Кол-во элементов в очереди
        /// </summary>
        private int Count;
        /// <summary>
        /// конструктор класса Дек
        /// </summary>
        public Deq()
        {
            this.Count = 0;
            this.front = null;
            this.back = null;
        }
        /// <summary>
        /// Метод добавления элемента в начало дека
        /// </summary>
        /// <param name="data"></param>
        public void AddFront(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (front == null)
            {
                front = newNode;
                back = newNode;
            }
            else
            {
                newNode.next = front;
                front.prev = newNode;
                front = newNode;
            }

            Count++;
        }
        /// <summary>
        /// Метод добавления элемента в конец дека
        /// </summary>
        /// <param name="data"></param>
        public void AddBack(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (back == null)
            {
                front = newNode;
                back = newNode;
            }
            else
            {
                newNode.prev = back;
                back.next = newNode;
                back = newNode;
            }

            Count++;
        }
        /// <summary>
        /// Метод удаления элемента с начала дека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T RemoveFront()
        {
            if (front == null)
                throw new InvalidOperationException("Дек пуст");
            T data = front.data;
            if (front == back)
            {
                front = null;
                back = null;
            }
            else
            {
                front = front.next;
                front.prev = null;
            }
            Count--;
            return data;
        }
        /// <summary>
        /// Метод удаления элемента с конца дека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T RemoveBack()
        {
            if (back == null)
                throw new InvalidOperationException("Дек пуст");
            T data = back.data;
            if (front == back)
            {
                front = null;
                back = null;
            }
            else
            {
                back = back.prev;
                back.next = null;
            }
            Count--;
            return data;
        }
        /// <summary>
        /// Проверка дека на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front == null;
        }
    }
    /// <summary>
    /// Класс список, содержит методы удаления, добавления,
    /// проверки на пустоту, слияние двух списков и копирования части списка
    /// </summary>
    public class Mylist<T>
    {
        /// <summary>
        /// массив элементов
        /// </summary>
        private T[] items;
        /// <summary>
        /// кол-во элементов в списке
        /// </summary>
        private int count;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Mylist()
        {
            items = new T[1];
            count = 0;
        }
        /// <summary>
        /// Метод добавления элемента в список
        /// </summary>
        /// <param name="item">элемент</param>
        public void Add(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, count + 1);
            items[count] = item;
            count++;
        }
        /// <summary>
        /// Метод удаления первого элемента из списка равного 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public T Removefirst()
        {
            T result = items[0];
            for (int i = 0; i < count - 1; i++)
                items[i] = items[i + 1];
            Array.Resize(ref items, items.Length - 1);
            count--; 
            return result;
        }
        /// <summary>
        /// Метод удаления первого элемента из списка равного item
        /// </summary>
        /// <param name="item">элемент который нужно удалить</param>
        /// <exception cref="ArgumentException"></exception>
        public void Remove(T item)
        {
            int itemIndex = -1;

            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    itemIndex = i;
                    break;
                }
            }

            if (itemIndex != -1)
            {
                for (int i = itemIndex; i < count - 1; i++)
                    items[i] = items[i + 1];
                Array.Resize(ref items, items.Length - 1);
                count--;
            }
            else
                throw new ArgumentException("Такого элемента нет в списке");
        }
        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }
        /// <summary>
        ///  Метод слияния двух списков с созданием нового списка
        /// </summary>
        /// <param name="secondlist">Второй списко</param>
        /// <returns>возвращает слияние двух списков</returns>
        public Mylist<T> MergeWithNewList(Mylist<T> secondlist)
        {
            Mylist<T> mergedList = new Mylist<T>();
            foreach (T item in items)
                mergedList.Add(item);
            foreach (T item in secondlist.items)
                mergedList.Add(item);
            return mergedList;
        }
        /// <summary>
        ///  Метод добавляющий к второму листу элементы текущего листа
        /// </summary>
        /// <param name="secondlist">второй список</param>
        /// <returns>возвращает слияние двух списков</returns>
        public Mylist<T> MergeWithoutNewList(Mylist<T> secondlist)
        {
            for (int i = 0; i < count; i++)
                secondlist.Add(items[i]);
            return secondlist;
        }
        /// <summary>
        /// Метод копирующий список с конкретного индекс
        /// </summary>
        /// <param name="startIndex">индекс с которого начнется копирование</param>
        /// <param name="count">кол-во скопированных элементов</param>
        /// <returns></returns>
        public Mylist<T> Copy(int startIndex, int count)
        {
            Mylist<T> copiedList = new Mylist<T>();
            for (int i = startIndex; i < startIndex + count; i++)
                copiedList.Add(items[i]);
            return copiedList;
        }
        /// <summary>
        /// Метод возвращающий лист одинаковых элементов из двух листов
        /// </summary>
        /// <param name="second">второй лист</param>
        /// <returns></returns>
        public Mylist<T> GetEqual(Mylist<T> second)
        {
            Mylist<T> res = new Mylist<T>();
            for (int i = 0; i < count; i++)
            {
                bool haveelem = false;
                for(int j = 0; j < second.count; j++)
                    if (this.items[i].Equals(second.items[j]))
                        haveelem = true;
                if (haveelem)
                    res.Add(items[i]);
            }
            return res; 
        }
        /// <summary>
        /// Метод возвращающий лист различных элементов из двух листов
        /// </summary>
        /// <param name="second">второй лист</param>
        /// <returns></returns>
        public Mylist<T> GetUnique(Mylist<T> second)
        {
            T[] uniquearay1 = items.Except(second.items).ToArray();
            T[] uniquearay2 = second.items.Except(items).ToArray();
            Mylist<T> res = new Mylist<T>();
            for (int i = 0; i < uniquearay1.Length; i++)
                res.Add(uniquearay1[i]);
            for (int i = 0; i < uniquearay2.Length; i++)
                res.Add(uniquearay2[i]);
            return res;
        }
    }
}
