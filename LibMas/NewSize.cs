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
    public static class NewSize
    {
        public static void SaveSize(int Column, int Row)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".ini";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.ini";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            save.FileName = "config.ini";
            StreamWriter file = new StreamWriter(save.FileName);
            file.WriteLine(Column);
            file.WriteLine(Row);
            file.Close();
        }
    }
}
