using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Window4 : Window
    {
        public string Word { get; set; }
        public string Category { get; set; }
        public Window4()
        {
            InitializeComponent();
        }

        public void SetWordAndCategory(string cuvant, string categorie)
        {
            Word = cuvant;
            Category = categorie;
            DisplayWordDetails();
        }
        private void DisplayWordDetails()
        {
            string filePath = "dictionar.txt";
            bool wordFound = false;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                string wordFromFile = parts[0];
                string description = parts[1];
                string categoryFromFile = parts[2];
                string imagePath = parts[3];
                

                if (wordFromFile.Equals(Word, StringComparison.OrdinalIgnoreCase) && (string.IsNullOrEmpty(Category) || categoryFromFile.Equals(Category, StringComparison.OrdinalIgnoreCase)))
                {
                   
                    wordTextBlock.Text = wordFromFile;
                    descriptionTextBlock.Text = description;
                    categoryTextBlock.Text = categoryFromFile;
                    imgImage.Source = new BitmapImage(new Uri(imagePath));

                    wordFound = true;
                    break;
                }
            }

            if (!wordFound)
            {

                MessageBox.Show("Cuvantul nu exista in dictionar!");
            }
        }
    }


}
