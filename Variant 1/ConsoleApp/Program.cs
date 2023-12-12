using ClickableTransparentOverlay;
using ImGuiNET;
using System.Diagnostics;
using Library;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window main = new Window();
            main.Run();
        }
    }

    public class Window : Overlay
    {
        bool _isOpen = true;
        Random rnd = new Random();
        Stopwatch sw = new Stopwatch();
        const int MIN = -1_000_000;
        const int MAX = 1_000_000;

        int M;
        int N;
        long timeA;
        long timeB;
        int[] lengths = new int[] { 100, 1000, 5000, 10000, 15000 };
        float[] searchTime = new float[5];
        float[] sortTime = new float[5];
        public override Task Run()
        {
            ImGui.CreateContext();
            InitTask1();
            return base.Run();
        }
        private void InitTask1()
        {
            M = rnd.Next(0, (int)Math.Pow(2, 14));
            N = rnd.Next(0, (int)Math.Pow(2, 14));

            int[] A = new int[M];
            int[] B = new int[N];

            for (int i = 0; i < M; i++)
            {
                A[i] = rnd.Next(MIN, MAX + 1);
            }

            for (int i = 0; i < N; i++)
            {
                B[i] = rnd.Next(MIN, MAX + 1);
            }

            sw.Start();
            SortingAlgorithms.InsertionSort(A);
            sw.Stop();
            timeA = sw.ElapsedMilliseconds;

            sw.Restart();
            SortingAlgorithms.InsertionSort(B);
            sw.Stop();
            timeB = sw.ElapsedMilliseconds;

            for (int i = 0; i < 5; i++)
            {
                int[] cA = new int[lengths[i]];
                int[] cB = new int[lengths[i]];

                for (int j = 0; j < cA.Length; j++)
                {
                    cA[j] = rnd.Next(MIN, MAX + 1);
                }
                for (int j = 0; j < cB.Length; j++)
                {
                    cB[j] = rnd.Next(MIN, MAX + 1);
                }


                Dictionary<int, int> dict = new Dictionary<int, int>();


                for (int j = 0; j < cA.Length; j++)
                {
                    AddToDictionary(dict, cA[j]);
                    AddToDictionary(dict, cB[j]);
                }

                List<int> c = new List<int>(dict.Keys);

                sw.Restart();
                SearchAlgorithms.LinearSearch(c.ToArray(), c[c.Count - 1]);
                sw.Stop();
                searchTime[i] = sw.ElapsedMilliseconds;


                sw.Restart();
                SortingAlgorithms.InsertionSort(c.ToArray());
                sortTime[i] = sw.ElapsedMilliseconds;


            }
        }
        void AddToDictionary(Dictionary<int, int> dict, int key)
        {
            if (dict.ContainsKey(key))
            {
                dict[key]++;
            }
            else
            {
                dict[key] = 1;
            }
        }
        protected override void Render()
        {
            if (!_isOpen)
            {
                Close();
                return;
            }
            
            ImGui.Begin("Window", ref _isOpen, ImGuiWindowFlags.None);
            ImGui.SetWindowSize(new System.Numerics.Vector2(900, 900));

            ImGui.TextWrapped($"M = {M}");
            ImGui.TextWrapped($"Time = {timeA}");
            ImGui.TextWrapped($"N = {N}");
            ImGui.TextWrapped($"Time = {timeB}");
            ImGui.PlotHistogram("", ref searchTime[0], 5, 0, "Linear search", 0, searchTime[4], new System.Numerics.Vector2(400, 400));
            ImGui.SameLine();
            ImGui.PlotHistogram("", ref sortTime[0], 5, 0, "Insertion sort", 0, sortTime[4], new System.Numerics.Vector2(400, 400));

            ImGui.End();
        }
    }
}