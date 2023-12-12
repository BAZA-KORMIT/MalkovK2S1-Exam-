using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6to8
{
    public abstract class MyQueue<T>
    {
        public abstract T Dequeue();
        public abstract bool IsEmpty();

        public abstract T GetCurrent();

        public abstract void Enqueue(T elem);
    }
    public class MyCyclingQueue<T> : MyQueue<T>
    {
        /// <summary>
        /// Индекс первого элемента в очереди
        /// </summary>
        private int first;
        /// <summary>
        /// Индекс последнего элемента в очереди
        /// </summary>
        private int last;
        /// <summary>
        /// Размер буффера
        /// </summary>
        private int size;
        /// <summary>
        /// Массив-буффер для очереди
        /// </summary>
        private T[] buffer;
        /// <summary>
        /// Создает кольцевую очередь с буффером указанного размера
        /// </summary>
        /// <param name="size">Размер буффера</param>
        public MyCyclingQueue(int size)
        {
            this.size = size;
            buffer = new T[size];
            first = -1;
            last = -1;
        }
        /// <summary>
        /// Возвращает первый элемент очереди
        /// </summary>
        /// <returns>Первый элемент очереди</returns>
        public override T GetCurrent()
        {
            return buffer[first];
        }
        /// <summary>
        /// Возвращает первый элемент очереди, удаляя его
        /// </summary>
        /// <returns>Первый элемент очереди</returns>
        public override T Dequeue()
        {
            T elem = buffer[first];
            if (first == last)
            {
                first = -1;
                last = -1;
            }
            else
            {
                first = (first + 1) % size;
            }
            return elem;
        }
        /// <summary>
        /// Вставляет элемент в конец очереди
        /// </summary>
        /// <param name="elem">Вставляемый элемент</param>
        public override void Enqueue(T elem)
        {
            last = (last + 1) % size;
            if (IsEmpty())
                first = 0;
            buffer[last] = elem;
        }
        /// <summary>
        /// Проверяет очередь на пустоту
        /// </summary>
        /// <returns>
        /// True: очередь пуста и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public override bool IsEmpty()
        {
            return first == -1;
        }
    }

    public class MyQueueOnArray<T> : MyQueue<T>
    {
        private T[] _buffer;
        private int _head;
        private int _tail;

        public MyQueueOnArray(int capacity)
        {
            _buffer = new T[capacity];
            _head = 0;
            _tail = -1;
        }

        public override void Enqueue(T item)
        {
            _buffer[++_tail] = item;
        }

        public override T Dequeue()
        {
            return _buffer[_head++];
        }

        public override T GetCurrent()
        {
            return _buffer[_head];
        }

        public override bool IsEmpty()
        {
            return _head > _tail;
        }

    }
    /// <summary>
    /// Реализует структуру данных стэк
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимый в экземпляре стека</typeparam>
    public class MyStack<T>
    {
        private T[] _buffer;
        private int _top;

        public MyStack(int capacity)
        {
            _buffer = new T[capacity];
            _top = -1;
        }

        /// <summary>
        /// Вставляет элемент на верхушку стека
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
        public void Push(T item)
        {
            if (_top == _buffer.Length - 1)
            {
                throw new Exception("Буффер кончился!");
            }
            _buffer[++_top] = item;
        }

        /// <summary>
        /// Возвращает верхний элемент стека, удаляя его
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public T Pop()
        {
            T res = this.Peek();
            _top--;
            return res;
        }

        /// <summary>
        /// Возвращает верхний элемент стека
        /// </summary>
        /// <returns>Верхний элемент стека</returns>
        public T Peek()
        {
            if (_top == -1)
            {
                throw new Exception("Стэк пуст");
            }
            return _buffer[_top];
        }

        /// <summary>
        /// Проверяет стек на пустоту
        /// </summary>
        /// <returns>
        /// True: стек пуст и не содержит элементов
        /// False: все остальные случаи
        /// </returns>
        public bool IsEmpty()
        {
            return _top == -1;
        }

        public int Count
        {
            get => _top+ 1;
        }
        
    }

}
