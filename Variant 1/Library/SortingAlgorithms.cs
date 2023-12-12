namespace Library
{
    public static class SortingAlgorithms
    {
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                T element = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(element) >= 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = element;
            }
        }
        public static void FisherYatesShuffle<T>(T[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(0, i + 1);
                Swap(ref array[i], ref array[j]);
            }
        }
        private static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
    }
}