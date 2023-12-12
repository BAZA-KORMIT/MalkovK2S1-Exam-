using System.Diagnostics;
using Library;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Stopwatch sw = new Stopwatch();
        const int MIN = -1_000_000;
        const int MAX = 1_000_000;
        int[] lengths = new int[] { 100, 1000, 5000, 10000, 15000 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Console.WriteLine();
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
    }
}