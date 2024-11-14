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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        Admin admin = new Admin();  
        public Window6()
        {
            InitializeComponent();
        }
        private void DeleteWordButton_click(object sender, RoutedEventArgs e)
        {
            string wordToDelete = wordToDeleteTextBox.Text;
            string resultMessage = admin.DeleteWord(wordToDelete);
            MessageBox.Show(resultMessage);
        }

    }
}
