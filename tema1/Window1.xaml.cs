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

namespace tema1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void BackButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow fereastra = new MainWindow();
                fereastra.Show();
                
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userTextBox.Text;
            string password = passwordTextBox.Password;

            if (User.Authenticate(username, password))
            {
               // MessageBox.Show("Conectare reușită!");
                Window2 w=new Window2();
                w.Show();
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă incorectă!");
            }
        }

    }

}
