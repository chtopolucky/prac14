using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;
using LibMas;

namespace Пр_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Autorization pas = new Autorization();
            pas.ShowDialog();
        }
        int[,] matrix;
        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
            if(File.Exists("config.ini"))
            {
                Column.Text = File.ReadLines("config.ini").First();
                Row.Text = File.ReadLines("config.ini").Last();
                if (Int32.TryParse(Column.Text, out int numberColumn) == true && Int32.TryParse(Row.Text, out int numberRow) == true)
                {
                    ActionsArrays.CreateArray(out matrix, numberRow, numberColumn);
                    DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                }
                else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            data.Text = d.ToString("dd.MM.yyyy");
        }
        private void CreateArray_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Column.Text, out int numberColumn) == true && Int32.TryParse(Row.Text, out int numberRow) == true)
            {
                size.Text = $"Size: {numberRow}*{numberColumn}";
                ActionsArrays.CreateArray(out matrix, numberRow, numberColumn );
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Start.Text, out int startRange) == true && Int32.TryParse(End.Text, out int endRange) == true && Int32.TryParse(Row.Text, out int numberRow) == true && Int32.TryParse(Column.Text, out int numberColumn) == true)
            {
                ActionsArrays.FillArray(out matrix, startRange, endRange, numberColumn, numberRow );
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                Result.Clear();
                for (int j = 1; j < matrix.GetLength(1); j = j + 2)
                {
                    int sum = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        sum += matrix[i, j];
                    }
                    Result.Text += $"сумма элементов {j + 1} столбца = {sum}\n";
                }
            }
            else MessageBox.Show("Таблица пуста", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Column.Clear();
            Row.Clear();
            Start.Clear();
            End.Clear();
            Result.Clear();
            if (matrix != null)
            {
                ActionsArrays.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            ActionsArrays.SaveArray(matrix);
        }

        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            ActionsArrays.OpenArray(out matrix);
            DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №13 Вариант 11\nВыполнил студент группы ИСП-31 Обухов С\nЗадание: Дана матрица размера M * N. Для каждого столбца матрицы с четным номером (2, 4, …) найти сумму его элементов. Условный оператор не использовать.", "Доп.Информация", MessageBoxButton.OK, MessageBoxImage.Question) ;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Здесь необходимо ввести размер матрицы и указать диапозон значений. При нажатии на кнопки 'Заполнить' и 'Создать' вы увидите таблицу с заданными вами параметрами", "Сведения о входных данных", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void InfoResult_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("При нажатии на кнопку 'Рассчитать' вы увидите результат сложения значений четных столбцов", "Сведения о результате", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Row_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.Clear();
            if (matrix != null)
            {
                ActionsArrays.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void Column_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.Clear();
            if (matrix != null)
            {
                ActionsArrays.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void Start_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.Clear();
            if (matrix != null)
            {
                ActionsArrays.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void End_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.Clear();
            if (matrix != null)
            {
                ActionsArrays.ClearArray(ref matrix);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int indexColumn = e.Column.DisplayIndex;
                int indexRow = e.Row.GetIndex();
                matrix[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            int currentColumnIndex = DataGrid.CurrentColumn.DisplayIndex;
            int currentRowIndex = DataGrid.Items.IndexOf(DataGrid.CurrentItem);
            indexElement.Text = $"IndexElement: [{(currentRowIndex + 1)}, {currentColumnIndex + 1}]";
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Option opt = new Option();
            opt.ShowDialog();
            Column.Text = data1.ColumnCount.ToString();
            Row.Text = data1.RowCount.ToString();
        }
    }
}
