using Microsoft.Win32;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window3 w = new Window3();
                w.Show();
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }

        }
        private void ModifyWordButton_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                Window5 w = new Window5();
                w.Show();
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }
        }
        private void DeleteWordButton_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                Window6 w = new Window6();
                w.Show();
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }
        }
    }
}
