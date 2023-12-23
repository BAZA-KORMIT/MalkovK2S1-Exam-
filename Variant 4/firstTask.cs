using System.Diagnostics;

class prog_1{
    static int[] RandomMas(int size){
        int[] mas = new int[size];
        Random rnd = new Random();
        for(int i = 0; i < mas.Length; i++){
            mas[i] = rnd.Next(0, 10000);
        }
        return mas;
    }
    static int[] copyMas(int[] mas){
        int[] newMas = new int[mas.Length];
        Array.Copy(mas, newMas, mas.Length);
        return newMas;

    }
    static void Sort(int[] mas){
        int n = mas.Length;
        for (int i = 1; i < n; i++){
            int elem = mas[i];
            int j = i - 1;

            while (j >= 0 && mas[j] > elem){
                mas[j + 1] = mas[j];
                j = j - 1;
            }
            mas[j + 1] = elem;
        }
    }
    static void quick(int[] mas, int start, int end){
        if(start < end){
            int mid = partition(mas, start, end);
            quick( mas, start, mid-1);
            quick(mas, mid+1, end);
        }
    }
    static int partition(int[] mas, int start, int end){
        int mid = mas[start];
        int i = start+1;
        int j = end;
        while(i <= j){
            while(i <= end && mas[i] < mid){
                i++;
            }
            while(j > start && mas[j] > mid){
                j--;
            }
            if(i >= j){
                break;
            }
            int x = mas[i];
            mas[i] = mas[j];
            mas[j] = x;
            i++;
            j--;
        }
        int X = mas[start];
        mas[start] = mas[j];
        mas[j] = X;
        return j;

    }
    static void ThreadQuickSort(int[] mas){
    
        int mid = partition(mas, 0, mas.Length-1);
        
        int mid1 = partition(mas, 0, mid-1);
        
        int mid2 = partition(mas, mid+1, mas.Length-1);
        
        Thread[] thread1 = new Thread[4];
        thread1[0] = new Thread(() => quick(mas, 0, mid1-1));
        thread1[1] = new Thread(() => quick(mas, mid1+1, mid-1));
        thread1[2] = new Thread(() => quick(mas, mid+1, mid2-1));
        thread1[3] = new Thread(() => quick(mas, mid2+1, mas.Length-1));
        for(int i = 0; i < 4; i++){
            thread1[i].Start();
        }
        foreach(var t in thread1){
            t.Join();
        }
        /*for(int i = 0; i < mas.Length; i++){
            Console.Write(mas[i] + " ");
        }
        Console.WriteLine();*/
    }

    static int easy(int[] mas, int elem){
        if(mas.Length == 0){
            //Console.WriteLine("\n элемент не найден");
            return -1;
        }
        int end = mas.Length-1;
        //Console.WriteLine("список посещенных элементов");
        for(int i = 0; i < end; i++){
            //Console.Write(" "+ mas[i]);
            if(mas[i] == elem){
                //Console.WriteLine("\nура, нужный элемент находится на позиции "+i);
                return i;
            }
        }
        //Console.WriteLine("\n элемент не найден");
        return -1;

    }
    static void helpFunc(HashSet<int> result, int[] mas_1){
        int elem = mas_1[0];
        for(int i = 1; i < mas_1.Length; i++){
            if(elem == mas_1[i]){
                result.Add(elem);
            }
            elem = mas_1[i];
        }
    }

    static HashSet<int> algoritm(int[] mas_1, int[] mas_2){
        Sort(mas_1);
        Sort(mas_2);
        HashSet<int> result = new HashSet<int>();
        helpFunc(result, mas_1);
        helpFunc(result, mas_2);
        return result;
    }
    static void Main(){
        Random rnd = new Random();
        int[] time = {5, 10, 100, 1000, 5000, 10000, 15000};
        
        foreach(int x in time){
            Console.WriteLine("\nдля массива "  + x);
        Stopwatch stopwatch1 = new Stopwatch();
        Stopwatch stopwatch3 = new Stopwatch();
        Stopwatch stopwatch2 = new Stopwatch();
        int[] mas_1 = RandomMas(x);
        int[] mas_help = copyMas(mas_1);
        
        int[] mas_2 = RandomMas(x);
        stopwatch1.Start();
        Sort(mas_1);
        /*for(int i = 0; i < mas_1.Length; i++){
            Console.Write(mas_1[i] + " ");
        }*/
        Console.WriteLine();
        stopwatch1.Stop();
        Console.WriteLine("сортировка шелла, время: " + stopwatch1.Elapsed.TotalMilliseconds+ " милсек");

        stopwatch2.Start();
        int elem = rnd.Next(0, mas_2.Length);
        easy(mas_2, elem);
        stopwatch2.Stop();
        Console.WriteLine("поиск, время: " + stopwatch2.Elapsed.TotalMilliseconds+ " милсек");

        stopwatch3.Start();
        algoritm(mas_help, mas_2);
        stopwatch3.Stop();
        Console.WriteLine("алгоритм, время: " + stopwatch3.Elapsed.TotalMilliseconds+ " милсек");
        }
    }




}
