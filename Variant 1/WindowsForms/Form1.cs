using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private Stopwatch sw = new Stopwatch();
        private const int MINVALUE = -1_000_000;
        private const int MAXVALUE = 1_000_000;
        private int[] lengths = new int[] { 100, 1000, 5000, 10000, 15000 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int M = rnd.Next(0, (int)Math.Pow(2, 14));
            int N = rnd.Next(0, (int)Math.Pow(2, 14));
            int[] A = new int[M];
            int[] B = new int[N];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rnd.Next(MINVALUE, MAXVALUE + 1);
            }
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = rnd.Next(MINVALUE, MAXVALUE + 1);
            }

        }
    }
}
