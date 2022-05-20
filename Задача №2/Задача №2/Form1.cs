using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text); //переменная,предназначенная для считывания количества судей
            if (n < 3 || n > 10) //условие,предназначенное для выполнения условия задачи с количеством судей
            {
                MessageBox.Show("Вы ввели неверное значение. Повторите попытку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); //при выполнении условия будет появляться окно с ошибкой
                n = 0; //обнуляем кол-во судей
            }
            int m = Convert.ToInt32(textBox2.Text); //переменная,предназначенная для считывания количества фигуристов
            double sum = 0; //переменная,предназначенная для накопления суммы
            double sr = 0; //переменная,предназначенная для вычисления среднего значения оценки
            double[,] mas = new double[m, n]; //создаём массив
            Random rnd = new Random(); //объявляем переменную для рандома чисел
            dataGridView1.RowCount = m; //присваиваем строкам таблицы фигуристов
            dataGridView1.ColumnCount = n; //присваиваем столбцам таблицы судей
            for (int i = 0; i < m; i++) //запускаем цикл для заполнения массива
            {
                for (int j = 0; j < n; j++) //запускаем цикл для заполнения массива
                {
                    mas[i, j] = Convert.ToDouble(rnd.Next(0, 100) / 10.0); //задаём массиву рандомные дробные значения
                    dataGridView1.Rows[i].Cells[j].Value = mas[i, j]; //выводим наши значения в таблицу
                }
            }
            for (int i = 0; i < n; i++) //запускаем цикл по количеству столбцов
            {
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1) + " судья"; //добавляем название каждого столбца таблицы
            }
            for (int i = 0; (i <= (dataGridView1.Rows.Count - 1)); i++) //запускаем цикл по количеству строк таблицы
            {
                dataGridView1.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0"); //записываем в каждой строке номер фигуриста
            }
            for (int i = 0; i < m; i++) //запускаем цикл для вычисления средней оценки
            {
                double max = 0; //переменная,предназначенная для выявления максимальной оценки
                double min = mas[0, 0]; //переменная,предназначенная для выявления минимальной оценки
                for (int j = 0; j < n; j++) //запускаем цикл для вычисления средней оценки
                {
                    sum += mas[i, j]; //суммируем элементы массива
                    if (max < mas[i, j]) //если начальное значение переменной меньше элемента массива,то…
                    {
                        max = mas[i, j]; //переменной присваивается этот элемент массива
                    }
                    if (min > mas[i, j]) //если начальное значение переменной больше элемента массива,то…
                    {
                        min = mas[i, j]; //переменной присваивается этот элемент массива
                    }
                }
                sr = (sum - min - max) / (n - 2); //высчитываем среднее значение,при условии,что откидывается одна максимальная и одна минимальная оценка судей у каждого фигуриста
                listBox1.Items.Add("Итоговая оценка " + (i + 1) + " фигуриста: " + Math.Round(sr, 1)); //выводим итоговую оценку каждого фигуриста на экран
                sum = 0; //обнуляем сумму для дальнейших вычислений
            }
        } 
    }
}
