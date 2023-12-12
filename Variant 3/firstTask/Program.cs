using Microsoft.VisualBasic;
using System.Diagnostics;

namespace exam
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] mas = new int[] { 100, 1000, 5000, 10000, 15000};
            for (int j = 0; j < 5; j++)
            {
               Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int[] array1 = Sorts.InsertionSort(Sorts.RndArr(mas[j]));
                int[] array2 = Sorts.InsertionSort(Sorts.RndArr(mas[j]));
                int[] array3 = Array.Empty<int>();
                int size = 0;

                for (int i = 0; i < array1.Length; i++)
                {
                    if (Sorts.LineSearch(array2, array1[i]) == -1 && Sorts.LineSearch(array3, array1[i]) == -1)
                    {
                        Array.Resize(ref array3, array3.Length + 1);
                        array3[size] = array1[i];
                        size++;
                    }
                }
                stopWatch.Stop();
                //Sorts.Print(array1);
                //Sorts.Print(array2);
                //Sorts.Print(array3);
                Console.WriteLine("Для "+ mas[j].ToString() +": "+stopWatch.ElapsedMilliseconds+" мс");
            }
        }

    }
    public static class Sorts
    {
        public static int[] RndArr(int lenth)
        {
            Random rnd = new Random();
            int[] arr = new int[lenth];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, (int)Math.Pow(2, 14));
            }
            return arr;
        }
        public static int[] InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var key = arr[i];
                var j = i;
                while ((j > 1) && (arr[j - 1] > key))
                {
                    (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                    j--;
                }
                arr[j] = key;
            }
            return arr;
        }
        public static int LineSearch(int[] arr, int elem)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == elem)
                    return i;
            return -1;
        }
        public static void Print(int[] arr)
        {
            for(int i = 0;i < arr.Length;i++)
                Console.Write(arr[i]+" ");
            Console.WriteLine();
        }
    }
}