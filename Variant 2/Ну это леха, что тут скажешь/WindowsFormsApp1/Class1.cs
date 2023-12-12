using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс-обертка для массива, добавляющий 
    /// методы сортировки для
    /// массивов произвольного типа Т, 
    /// реализующего интерфейс IComparable
    /// </summary>
    /// <typeparam name="T">Тип данных в сортируемых массивах</typeparam>
    public class Sorter<T> : ICloneable, IList<T>, 
        ICollection<T>, IEnumerable<T>, IStructuralEquatable, IStructuralComparable
        where T : IComparable<T> 
    {
        /// <summary>
        /// Поле, отображающее массив
        /// </summary>
        protected T[] arr;
        /// <summary>
        /// Длина массива
        /// </summary>
        protected int len;

        public int Count => ((ICollection<T>)arr).Count;

        public bool IsReadOnly => ((ICollection<T>)arr).IsReadOnly;

        /// <summary>
        /// Конструктор, создающий объект на основе массива
        /// </summary>
        /// <param name="arr">Массив</param>
        public Sorter(T[] arr)
        {
            this.arr = arr;
            this.len = arr.Length;
        }
        /// <summary>
        /// Конструктор, создающий объект на основе IList
        /// </summary>
        /// <param name="arr">IList</param>
        public Sorter(IList<T> arr)
        {
            this.arr = arr.ToArray();
            this.len = arr.Count;
        }
        /// <summary>
        /// Индексатор, позволяющий работать с элементами массива по индексу
        /// </summary>
        /// <param name="i">Индекс элемента в обернутом массиве</param>
        /// <returns>Элемент массива по данному индексу</returns>
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value;  }
        }
        /// <summary>
        /// Позволяет поменять местами элементы по ссылке
        /// </summary>
        /// <param name="elem1">Первый элемент</param>
        /// <param name="elem2">Второй элемент</param>
        private void Swap(ref T elem1, ref T elem2)
        {
            T temp = elem1;
            elem1 = elem2;
            elem2 = temp;
        }
        /// <summary>
        /// Позволяет поменять элементы местами по индексу
        /// </summary>
        /// <param name="index1">Первый индекс</param>
        /// <param name="index2">Второй индекс</param>

        private void Swap(int index1, int index2)
        {
            T temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
        /// <summary>
        /// Осуществляет сортировку выбором
        /// </summary>
        public void SelectSort()
        {
            for (int i = 0; i < len; i++)
            {
                int min = i;
                for (int j = i; j < len; j++)
                {
                    if (arr[min].CompareTo(arr[j]) > 0)
                        min = j;
                }
                Swap(i, min);
            }
        }
        /// <summary>
        /// Осуществляет сортировку пузырьком
        /// </summary>
        public void BubbleSort()
        {
            for (int i = 0; i < len; i++)
                for (int j = i; j < len; j++)
                    if (arr[j].CompareTo(arr[i]) < 0)
                        Swap(ref arr[j], ref arr[i]);

        }
        /// <summary>
        /// Осуществляет сортировку Шелла
        /// </summary>
        public void ShellSort()
        {
            int d = len / 2;
            while (d >= 1)
            {
                for (int i = 0; i < len; i+=d)
                {
                    int j = i;
                    while (j > 0 && arr[j].CompareTo(arr[j - 1]) <= 0)
                    {
                        Swap(j - 1, j);
                        j-=d;
                    }
                }
                d /= 2;
            }
        }
        /// <summary>
        /// Осуществляет сортировку вставками
        /// </summary>
        public void InsertSort()
        {
            for (int i = 0; i < len; i++)
            {
                int j = i;
                while (j > 0 && arr[j].CompareTo(arr[j - 1]) <= 0)
                {
                    Swap(j - 1, j);
                    j--;
                }
            }
        }
        /// <summary>
        /// Осуществляет быструю сортировку Хоара
        /// </summary>
        public void FastSort()
        {
            FastSortRec(0, len - 1);
        }
        /// <summary>
        /// Вспомогательная рекурсивная функция 
        /// для быстрой сортировки Хоара
        /// </summary>
        /// <param name="start">Начало сортируемого отрезка</param>
        /// <param name="end">Конец сортируемого отрезка</param>
        private void FastSortRec(int start, int end)
        {
            int i = start, j = end;
            T pivot = arr[(start + end) / 2];
            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                FastSortRec(start, j);
            }
            if (i < end)
            {
                FastSortRec(i, end);
            }

        }
        /// <summary>
        /// Осуществляет пирамидальную сортировку
        /// </summary>
        public void HeapSort()
        {
            HeapSort(len);
        }
        /// <summary>
        /// Вспомогательная функция для пирамидальной сортировки
        /// </summary>
        private void HeapSort(int N)
        {
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, N, i);
            }

            for (int i = N - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0);
            }
            return;
        }
        /// <summary>
        /// Вспомогательная функция для пирамидальной сортировки,
        /// приводящая массив на отрезке к виду бинарной кучи
        /// </summary>

        private void Heapify(T[] M, int N, int i)
        {
            int iM = i;
            int L = 2 * i + 1, R = 2 * i + 2;
            if (L < N && (M[L].CompareTo(M[iM]) > 0))
            {
                iM = L;
            }
            if (R < N && (M[R].CompareTo(M[iM]) > 0))
            {
                iM = R;
            }
            if (i != iM)
            {
                Swap(ref M[i], ref M[iM]);
                Heapify(M, N, iM);
            }
            return;
        }
        /// <summary>
        /// Статический метод, создающий случаный целочисленный массив
        /// </summary>
        /// <param name="start">Начало отрезка случайных чисел</param>
        /// <param name="end">Конец отрезка случайных чисел</param>
        /// <param name="N">Длина массива</param>
        /// <returns>Целочисленный случайный массив</returns>
        public static int[] CreateRandom(int start, int end, int N)
        {
            Random R = new Random();
            int[] res = new int[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = R.Next(start, end);
            }
            return res;
        }
        /// <summary>
        /// Осуществляет перемешку текущего массива
        /// </summary>
        public void Shuffle()
        {
            Random R = new Random();
            for (int i = 0; i < len; i++)
            {
                this.Swap(i, R.Next(0, len));
            }
        }
        /// <summary>
        /// Проверяет, отсортирован ли данный массив по возрастанию
        /// </summary>
        /// <param name="arr">Проверяемый массив</param>
        /// <returns>True: массив отсортирован по возрастанию
        /// False: все иные случаи</returns>
        public static bool CheckIfSorted<P>(P[] arr) where P : IComparable<P>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                    return false;
            }
            return true;
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)arr).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)arr).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)arr).RemoveAt(index);
        }

        public void Add(T item)
        {
            ((ICollection<T>)arr).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)arr).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)arr).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)arr).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)arr).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public bool Equals(object other, IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)arr).Equals(other, comparer);
        }

        public int GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)arr).GetHashCode(comparer);
        }

        public int CompareTo(object other, IComparer comparer)
        {
            return ((IStructuralComparable)arr).CompareTo(other, comparer);
        }

        public object Clone()
        {
            return arr.Clone();
        }
    }
    /// <summary>
    /// Класс, добавляющий в функционал класса Sorter
    /// возможность различных видов поиска элемента
    /// </summary>
    /// <typeparam name="T">Тип данных в массива</typeparam>
    public class FinderInArray<T> : Sorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Создает экземпляр класса на основе
        /// данного массива
        /// </summary>
        /// <param name="arr">Данный массив</param>
        public FinderInArray(T[] arr) : base(arr) { }
        /// <summary>
        /// Осуществляет линейный поиск в данном массиве
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        public int LinearSearch(T elem)
        {
            for (int i = 0; i < len; i++)
                if (arr[i].Equals(elem))
                    return i;
            return -1;
        }
        /// <summary>
        /// Осуществляет бинарный поиск в отсортированном 
        /// по возрастанию массиве
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        public int BinarySearch(T elem)
        {
            
            int left = 0, right = len, center;
            while (right > left)
            {
                center = (left + right) / 2;
                if (arr[center].Equals(elem))
                    return center;
                if (arr[center].CompareTo(elem) > 0)
                    right = center;
                else
                    left = center + 1;
            }
            return -1;
        }
        /// <summary>
        /// Осуществляет бинарный рекурсивный 
        /// поиск в отсортированном 
        /// по возрастанию массиве
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        public int BinaryRecursiveSearch(T elem)
        {
            return BinRecS(elem, this.arr, 0, len);
        }
        /// <summary>
        /// Осуществляет бинарный рекурсивный 
        /// поиск в отсортированном 
        /// по возрастанию массиве
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="arr">Массив, в котором осуществляется поиск</param>
        /// <param name="start">Начало проверяемого отрезка</param>
        /// <param name="end">Конец проверяемого отрезка</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        private static int BinRecS(T elem, T[] arr, int start, int end)
        {
            int center = (start + end) / 2;
            if (start == end)
                return -1;
            if (arr[center].Equals(elem))
                return center;
            if (arr[center].CompareTo(elem) < 0)
                return BinRecS(elem, arr, center + 1, end);
            else
                return BinRecS(elem, arr, start, center);
        }
        /// <summary>
        /// Осуществляет интерполяционный поиск в задаваемом массиве, 
        /// интерполяция линейная
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="array">Массив, в котором происходит поиск</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        public static int InterpolateSearch(int elem, int[] array)
        {
            int left = 0, right = array.Length - 1, center;
            while (right > left)
            {
                center = left + ((elem - array[left]) * (right - left)) / ((array[right] - array[left]));

                if (array[center].Equals(elem))
                    return center;
                if (array[center].CompareTo(elem) > 0)
                    right = center;
                else
                    left = center + 1;
            }
            return -1;
        }
        /// <summary>
        /// Осуществляет экстраполяционный поиск в задаваемом массиве
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="array">Массив, в котором происходит поиск</param>
        /// <returns>
        /// Индекс элемента если такой присутствует, 
        /// иначе -1
        /// </returns>
        public static int ExponentialSearch(int elem, int[] array)
        {
            if (array[0] == elem)
                return 0;

            int k = 1;

            while (k < array.Length && array[k] < elem)
                k *= 2;

            int end = k < array.Length - 1 ? k : array.Length - 1;
            end++;
            return FinderInArray<int>.BinRecS(elem, array, k / 2, end);
        }
    }
}
