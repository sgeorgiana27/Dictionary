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
using Microsoft.Win32;
using System.IO;
namespace tema1
{

    public partial class Window3 : Window
    {

        Admin admin = new Admin();
        public Window3()
        {
            InitializeComponent();

        }
        private void NewCategoryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LoadExistingCategories(); // incarca categoriile existente
            existingCategoriesListBox.Visibility = Visibility.Visible;
        }

        private void LoadExistingCategories()
        {
            string filePath = "dictionar.txt";

            existingCategoriesListBox.Items.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3) 
                    {
                        string category = parts[2].Trim(); 
                        if (!string.IsNullOrWhiteSpace(category) && !existingCategoriesListBox.Items.Contains(category))
                        {
                            existingCategoriesListBox.Items.Add(category);
                        }
                    }
                }
            }
        }

        

        private void NewCategoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string enteredText = newCategoryTextBox.Text.ToLower().Trim();

            bool matchFound = false;
            foreach (string category in existingCategoriesListBox.Items)
            {
                if (category.ToLower().Trim() == enteredText)
                {
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
            {
                existingCategoriesListBox.Visibility = Visibility.Collapsed;
            }
        }


        private void ExistingCategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (existingCategoriesListBox.SelectedItem != null)
            {
                newCategoryTextBox.Text = ((ListBoxItem)existingCategoriesListBox.SelectedItem).Content.ToString();

                existingCategoriesListBox.Visibility = Visibility.Collapsed;
            }
        }

        private void AddWordButton_click(object sender, RoutedEventArgs e)
        {
            string resultMessage = admin.AddWord(wordTextBox.Text, descriptionTextBox.Text, newCategoryTextBox.Text);
            MessageBox.Show(resultMessage);
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            string selectedImagePath = admin.SelectImage();
        }
    }
}




