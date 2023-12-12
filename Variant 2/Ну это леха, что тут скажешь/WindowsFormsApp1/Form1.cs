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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int MAX_AMOUNT = 15000;
        const int step = 1000;
        const int Mod = 1000000;


        public long CalcTimeInsert(int[] ints1, int[] ints2)
        {
            HashSet<int> list = new HashSet<int>();
            foreach (int i in ints1)
                list.Add(i);
            foreach (int i in ints2)
                list.Add(i);
            int[] C = list.ToArray();
            Sorter<int> srtr = new Sorter<int>(C);

            Stopwatch s = Stopwatch.StartNew();
            srtr.InsertSort();
            s.Stop();

            GC.Collect();
            return s.ElapsedMilliseconds;
        }
        public long CalcTimeSearch(int[] ints1, int[] ints2)
        {
            HashSet<int> list = new HashSet<int>();
            foreach (int i in ints1)
                list.Add(i);
            foreach (int i in ints2)
                list.Add(i);

            int[] C = list.ToArray();
            FinderInArray<int> sorter = new FinderInArray<int>(C);
            int target = sorter[C.Length / 2];

            Stopwatch s = Stopwatch.StartNew();
            sorter.LinearSearch(target);
            s.Stop();

            GC.Collect();
            return s.ElapsedMilliseconds;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            chart1.Series[1].Points.Clear();
            chart1.Series[1].ChartType = SeriesChartType.FastLine;
            for (int i = 1; i < MAX_AMOUNT + 1; i += step)
            {
                int[] ints1 = Sorter<int>.CreateRandom(-Mod, Mod, i);
                int[] ints2 = Sorter<int>.CreateRandom(-Mod, Mod, i);
                chart1.Series[0].Points.AddXY(i, CalcTimeInsert(ints1, ints2));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            chart1.Series[1].Points.Clear();
            chart1.Series[1].ChartType = SeriesChartType.FastLine;
            for (int i = 1; i < MAX_AMOUNT * 200 + 1; i += step * 200)
            {
                int[] ints1 = Sorter<int>.CreateRandom(-Mod, Mod, i);
                int[] ints2 = Sorter<int>.CreateRandom(-Mod, Mod, i);
                chart1.Series[1].Points.AddXY(i, 
                    CalcTimeSearch(ints1, ints2)
                    );
            }
        }

    }
}
