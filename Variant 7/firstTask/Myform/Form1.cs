using System.Diagnostics;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
using ZachetMassivi;
namespace Myform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*// �������� ������� Chart
            Chart chart = new Chart();

            // ������� �������� � ��������� ������� �� �����
            chart.Size = new System.Drawing.Size(400, 300);
            chart.Location = new System.Drawing.Point(50, 50);

            // �������� ������ ������� ChartArea � ���������� ��� � ��������� ChartAreas
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // �������� ������ ������� Series � ���������� ��� � ��������� Series
            Series series = new Series();
            chart.Series.Add(series);

            // ���������� ������ � �����
            series.Points.AddXY("������", 50);
            series.Points.AddXY("�������", 70);
            series.Points.AddXY("����", 90);
            series.Points.AddXY("������", 60);

            // ������� ���������� ����
            chartArea.AxisX.Title = "������";
            chartArea.AxisY.Title = "��������";

            // ���������� ������� �� �����
            Controls.Add(chart);
            Stopwatch st = new Stopwatch();
            Console.WriteLine("����� ��� 100 ���������");
            st.Start();
            Massiv.GetUniqueElements(100);
            st.Stop();
            Console.WriteLine($"����� ���������� ���������� �������� {st.ElapsedMilliseconds} ��");
            st.Reset();
            Console.WriteLine("����� ��� 1000 ���������");
            st.Start();
            Massiv.GetUniqueElements(1000);
            st.Stop();
            Console.WriteLine($"����� ���������� ���������� �������� {st.ElapsedMilliseconds} ��");
            st.Reset();
            Console.WriteLine("����� ��� 5000 ���������");
            st.Start();
            Massiv.GetUniqueElements(5000);
            st.Stop();
            Console.WriteLine($"����� ���������� ���������� �������� {st.ElapsedMilliseconds} ��");
            st.Reset();
            Console.WriteLine("����� ��� 10000 ���������");
            st.Start();
            Massiv.GetUniqueElements(10000);
            st.Stop();
            Console.WriteLine($"����� ���������� ���������� �������� {st.ElapsedMilliseconds} ��");
            st.Reset();
            Console.WriteLine("����� ��� 15000 ���������");
            st.Start();
            Massiv.GetUniqueElements(15000);
            st.Stop();
            Console.WriteLine($"����� ���������� ���������� �������� {st.ElapsedMilliseconds} ��");
            st.Reset();*/

        }
    }
}