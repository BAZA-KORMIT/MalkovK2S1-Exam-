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
            /*// Создание объекта Chart
            Chart chart = new Chart();

            // Задание размеров и положения графика на форме
            chart.Size = new System.Drawing.Size(400, 300);
            chart.Location = new System.Drawing.Point(50, 50);

            // Создание нового объекта ChartArea и добавление его в коллекцию ChartAreas
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Создание нового объекта Series и добавление его в коллекцию Series
            Series series = new Series();
            chart.Series.Add(series);

            // Добавление данных в серию
            series.Points.AddXY("Январь", 50);
            series.Points.AddXY("Февраль", 70);
            series.Points.AddXY("Март", 90);
            series.Points.AddXY("Апрель", 60);

            // Задание заголовков осей
            chartArea.AxisX.Title = "Месяцы";
            chartArea.AxisY.Title = "Значение";

            // Добавление графика на форму
            Controls.Add(chart);
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
            st.Reset();*/

        }
    }
}