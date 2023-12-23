using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZachetMassivi;

namespace TestMas
{
    class test
    {
        public const int lowvalue = 0;
        public const int highvalue = 10;
        static void Main()
        {
            Stopwatch st = new Stopwatch();
            Console.WriteLine("Поиск для 100 элементов");
            st.Start();
            Massiv.GetUniqueElements(100);
            st.Stop();
            Console.WriteLine($"Время выполнения сортировки выборкой {st.ElapsedMilliseconds} мс");
            st.Reset();
            Console.WriteLine("Поиск для 1000 элементов");
            st.Start();
            Massiv.GetUniqueElements(1000);
            st.Stop();
            Console.WriteLine($"Время выполнения сортировки выборкой {st.ElapsedMilliseconds} мс");
            st.Reset();
            Console.WriteLine("Поиск для 5000 элементов");
            st.Start();
            Massiv.GetUniqueElements(5000);
            st.Stop();
            Console.WriteLine($"Время выполнения сортировки выборкой {st.ElapsedMilliseconds} мс");
            st.Reset();
            Console.WriteLine("Поиск для 10000 элементов");
            st.Start();
            Massiv.GetUniqueElements(10000);
            st.Stop();
            Console.WriteLine($"Время выполнения сортировки выборкой {st.ElapsedMilliseconds} мс");
            st.Reset();
            Console.WriteLine("Поиск для 15000 элементов");
            st.Start();
            Massiv.GetUniqueElements(15000);
            st.Stop();
            Console.WriteLine($"Время выполнения сортировки выборкой {st.ElapsedMilliseconds} мс");
            st.Reset();

        }
    }
}