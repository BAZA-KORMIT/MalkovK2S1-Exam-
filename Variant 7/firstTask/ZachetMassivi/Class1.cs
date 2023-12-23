
namespace ZachetMassivi
{

    public class Massiv
    {
        public const int lowvalue = 0;
        public const int highvalue = 1000;

        public static void GetUniqueElements(int countelem)
        {
            int[] A = CreateRandomArray(countelem, lowvalue, highvalue);
            int[] B = CreateRandomArray(countelem, lowvalue, highvalue);
            List<int> C = new List<int>();
            SortVS(A);
            SortVS(B);
            for (int i = 0; i < A.Length; i++)
            {
                bool haveelem = Massiv.LinearSerach(B, A[i]);
                if (!haveelem)
                    C.Add(A[i]);
            }
        }
        public static int[] CreateRandomArray(int countelem, int lowvalue, int highvalue)
        {
            int[] array = new int[countelem];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(lowvalue, highvalue + 1);
            return array;
        }
        /// <summary>
        /// Сортировка вставками
        /// </summary>
        public static void SortVS(int[] m)
        {
            for (int i = 0; i <= m.Length - 1; i++)
                for (int j = 0; j < m.Length - 1; j++)
                    if (m[j] > m[j + 1])
                    {
                        int t = m[j];
                        m[j] = m[j + 1];
                        m[j + 1] = t;
                    }
        }
        /// <summary>
        /// Алгоритм линейного поиска элементов в массиве
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="p">искомый элемент</param>
        public static bool LinearSerach(int[] arr, int p)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] == p)
                        flag = true;
                return flag;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка");
            }
        }
    }
}