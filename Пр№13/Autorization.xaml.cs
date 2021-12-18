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
using System.Windows.Shapes;

namespace Пр_13
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (txtPas.Password == "123") Close();
            else
            {
                MessageBox.Show("Пароль невереню Повторите ввод", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPas.Focus();
                txtPas.Clear();
            }
        }

        private void Esc_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtPas.Focus();
        }
    }
}
