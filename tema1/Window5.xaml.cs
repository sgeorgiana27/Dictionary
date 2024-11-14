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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        Admin admin=new Admin();
        public Window5()
        {
            InitializeComponent();
        }
        private string imagePath;

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            string selectedImagePath = admin.SelectImage();
            if (selectedImagePath != null)
            {
                imagePath = selectedImagePath;
            }
            else
            {
                imagePath = "C:\\Users\\sirbu\\OneDrive\\Desktop\\sem2\\MAP\\tema1\\tema1\\Images\\noImage.png"; 
            }
        }

        private void ModifyWordButton_Click(object sender, RoutedEventArgs e)
        {
            string wordToModify = wordToModifyTextBox.Text;
            string newWord = newWordTextBox.Text;
            string newDescription = newDescriptionTextBox.Text;
            string newCategory = newCategoryTextBox.Text;

            string resultMessage = admin.ModifyWord(wordToModify, newWord, newDescription, newCategory, imagePath);
            MessageBox.Show(resultMessage);
        }
    }
}
