using System;
using System.Diagnostics;

namespace firstTaskArrays
{
    class Program
    {
        static void Main()
        {
            int[] a = { 0, 0, 1, 1, 2, 3, 3, 4, 5, 6, 6};
            int[] b = {0,2,3,4,5,8,9 };
            Stopwatch sw = new();
            sw.Start();
            int[] c = GetC(a, b);
            sw.Stop();
            Console.Write("Результат: ");
            foreach (int n in c)
                Console.Write(n+" ");
            Console.WriteLine("\nВремя на выполение: " + sw.ElapsedMilliseconds+" мс") ;
        }

        static int[] GetC(int[] a, int[] b)
        {
            List<int> C = new List<int>();

            BubleSort(a); BubleSort(b);
            GetNotUniqueElem(C, a);
            DeleteSameElems(b, C);

            return C.ToArray();
        }

        static void GetNotUniqueElem(List<int> C, int[] arr)
        {
            int elem = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (elem == arr[i])
                {
                    C.Add(elem);
                }
                elem = arr[i];
            }
        }

        static void DeleteSameElems(int[] b, List<int> C)
        {
            for (int i = 0;i<b.Length;i++)
            {
                if (C.Contains(b[i]))
                    C.Remove(b[i]);
            }
        }


        static void BubleSort(int[] M) //work
        {
            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M.Length - 1; j++)
                {
                    if (M[j] > M[j + 1])
                        (M[j], M[j + 1]) = (M[j + 1], M[j]);
                }
            }
        }

        static int[] FillRnd(int n)
        {
            int[] m = new int[n];
            Random rnd = new();
            for (int i = 0; i < m.Length; i++)
                m[i] = rnd.Next(0, 100);
            return m;
        }
    }
}