using System;
using System.Diagnostics;

namespace firstTask
{
    class Program
    {

        static void Main()
        {
            int[] m1 = FillingArr(100);
            int[] m2 = FillingArr(1000);
            int[] m3 = FillingArr(5000);
            int[] m4 = FillingArr(10000);
            int[] m5 = FillingArr(15000);
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        sw.Start();
                        BubleSort(m1);
                        JumpSearch(m1);
                        sw.Stop();
                        Console.WriteLine("Время на сортировку и поиск (100 числе): " + sw.ElapsedMilliseconds + " мс");
                        break;
                    case 1:
                        sw.Restart();
                        BubleSort(m2);
                        JumpSearch(m2);
                        sw.Stop();
                        Console.WriteLine("Время на сортировку и поиск (1000 чисел): " + sw.ElapsedMilliseconds + " мс");
                        break;
                    case 2:
                        sw.Restart();
                        BubleSort(m3);
                        JumpSearch(m3);
                        sw.Stop();
                        Console.WriteLine("Время на сортировку и поиск (5000 чисел): " + sw.ElapsedMilliseconds + " мс");
                        break;
                    case 3:
                        sw.Restart();
                        BubleSort(m4);
                        JumpSearch(m4);
                        
                        sw.Stop();
                        Console.WriteLine("Время на сортировку и поиск (10000 чисел): " + sw.ElapsedMilliseconds + " мс");
                        break;
                    case 4:
                        sw.Restart();
                        BubleSort(m5);
                        JumpSearch(m5);
                        sw.Stop();
                        Console.WriteLine("Время на сортировку и поиск (15000 чисел): " + sw.ElapsedMilliseconds + " мс");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        static void PrintArr(int[] m) //work
        {
            foreach (int c in m)
                Console.Write(c+" ");
        }

        // n - кол-во элементов масива
        static int[] FillingArr(int n) //work
        {
            int[] M = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                M[i] = rnd.Next(0, 100);

            return M;
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

        static void JumpSearch(int[] M) //work
        {
            //Console.Write("Введите число для поиска: ");
            //int p = int.Parse(Console.ReadLine());
            int p = M.Max();
            //Console.WriteLine("biG Chislo: " + p);
            //Random r = new Random();
            //int p = r.Next(2, 100);
            int len = M.Length;
            int jump = (int)Math.Pow(len, 1 / 3);
            int left = 0; int right = 0;
            while (left < len && M[left] <= p)
            {
                right = Math.Min(len - 1, left + jump);
                if (M[left] <= p && M[right] >= p)
                    break;
                left += jump;
            }
            if (left >= len || M[left] > p)
                //Console.WriteLine("Числа нет =(");
            right = Math.Min(len - 1, right);
            int i = left;
            while (i <= right && M[i] <= p)
            {
                if (M[i] == p)
                {
                    //Console.WriteLine($"Число найдено по индексу {i}");
                    return;
                }
                i += 1;
            }
            //Console.WriteLine("Числа нет =(");
        }
    }
}