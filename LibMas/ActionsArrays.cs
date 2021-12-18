using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Forms;

namespace LibMas
{
    public class ActionsArrays
    {
        public static void CreateArray(out int[,] matrix, int numberRow, int numberColumn)
        {
            matrix = new int[numberRow, numberColumn];
        }
        public static void FillArray(out int[,] matrix, int startRange, int endRange, int numberColumn, int numberRow)
        {
            matrix = new int [numberRow, numberColumn];
            Random Rand = new Random();
            for (int i = 0; i < numberRow; i++)
            {
                for (int j = 0; j < numberColumn; j++)
                    matrix[i, j] = Rand.Next(startRange, endRange);
            }
        }
        public static void ClearArray(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = 0;
        }
        public static void SaveArray(int[,] matrix)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (matrix != null)
            {
                if (save.ShowDialog() > 0)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(matrix.GetLength(0));
                    file.WriteLine(matrix.GetLength(1));
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            file.WriteLine(matrix[i, j]);
                        }
                    }
                    file.Close();
                }
            }
            else MessageBox.Show("Таблица пуста", "Ошибка");
        }
        public static void OpenArray(out int[,] matrix)
        {
            matrix = new int[0, 0];
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() > 0)
            {
                StreamReader file = new StreamReader(open.FileName);
                int numberRow = Convert.ToInt32(file.ReadLine());
                int numberColumn = Convert.ToInt32(file.ReadLine());
                matrix = new Int32[numberRow, numberColumn];
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        matrix[i, j] = Convert.ToInt32(file.ReadLine());
                file.Close();
            }
        }
    }
}
