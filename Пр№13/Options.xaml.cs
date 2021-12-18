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
    /// Логика взаимодействия для Options.xaml
    /// </summary>
    public partial class Option : Window
    {
        public Option()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data1.ColumnCount = Convert.ToInt32(NewColumn.Text);
                data1.RowCount = Convert.ToInt32(NewRow.Text);
                Close();
            }
            catch
            {
                MessageBox.Show("Неверное значение");
            }
            NewSize.SaveSize(Convert.ToInt32(NewColumn.Text), Convert.ToInt32(NewRow.Text));
        }

        private void Options_Activated(object sender, EventArgs e)
        {
            NewColumn.Focus();
            NewColumn.Text = data1.ColumnCount.ToString();
            NewRow.Text = data1.RowCount.ToString();
        }
    }
   
}
