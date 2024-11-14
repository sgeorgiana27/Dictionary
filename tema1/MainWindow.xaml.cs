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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> categories = new List<string>();
        private List<string> allWords = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();
            LoadWordsFromFile();
        }

        private void OpenDivertismentButton_click(Object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> filteredWords = FilterAndSortWordsByCategory(categoryComboBox.SelectedItem?.ToString());

                if (filteredWords.Count >= 5)
                {
                    // Selectăm 5 cuvinte aleatorii
                    Random random = new Random();
                    List<string> selectedWords = new List<string>();
                    while (selectedWords.Count < 5)
                    {
                        int index = random.Next(filteredWords.Count);
                        string word = filteredWords[index];
                        if (!selectedWords.Contains(word))
                        {
                            selectedWords.Add(word);
                        }
                    }

                    // Creăm o listă de tupluri pentru a reține cuvântul, conținutul și tipul (1 pentru descriere, 2 pentru imagine)
                    List<(string, string, int)> gameWords = new List<(string, string, int)>();

                    foreach (string word in selectedWords)
                    {
                        string[] lines = File.ReadAllLines("dictionar.txt");
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length >= 4 && parts[0].Trim().ToLower() == word.ToLower())
                            {
                                string description = parts[1];
                                string imagePath = parts[3];
                                int type = (imagePath == "C:\\Users\\sirbu\\OneDrive\\Desktop\\sem2\\MAP\\tema1\\tema1\\Images\\noImage.png") ? 1 : 2; // 1 pentru descriere, 2 pentru imagine
                                gameWords.Add((word, (type == 1) ? description : imagePath, type));
                                break;
                            }
                        }
                    }

                    Window7 w = new Window7(gameWords);
                    w.Show();
                }
                else
                {
                    MessageBox.Show("Nu există suficiente cuvinte pentru a juca jocul. Selectați mai multe cuvinte și încercați din nou.");
                }
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void OpenAdminLogInButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window1 w = new Window1();
                w.Show();
            }
            catch (Exception exe) { MessageBox.Show("nu merge"); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private List<string> FilterAndSortWordsByCategory(string category)
        {
            // Filtrare cuvinte în funcție de categoria selectată
            var filteredWords = allWords;
            if (!string.IsNullOrEmpty(category))
            {
                filteredWords = filteredWords.Where(word => categories.Contains(category)).ToList();
            }

            // Sortare alfabetică ???
            filteredWords = filteredWords.OrderBy(word => word).ToList();

            return filteredWords;
        }//de revazut

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string cuvant = wordTextBox.Text; 

            string categorie = (categoryComboBox.SelectedItem != null) ? categoryComboBox.SelectedItem.ToString() : null; // Ia categoria din ComboBox sau null dacă nu este selectată nicio categorie

            Window4 window4 = new Window4();
            window4.SetWordAndCategory(cuvant, categorie);
            window4.Show();
        }
        private void LoadCategories()
        {
            string filePath = "dictionar.txt"; 
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3) 
                    {
                        string categorie = parts[2]; 
                        if (!string.IsNullOrWhiteSpace(categorie) && !categories.Contains(categorie))
                        {
                            categories.Add(categorie);
                        }
                    }
                }

                foreach (string categorie in categories)
                {
                    categoryComboBox.Items.Add(categorie);
                }
            }
            else
            {
                MessageBox.Show("Fișierul cu dictionarul nu există.");
            }
        }
        private void LoadWordsFromFile()
        {
            string filePath = "dictionar.txt";
            allWords = File.ReadAllLines(filePath).Select(line => line.Split(',')[0]).ToList();
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wordTextBox.Text.Length >= 2) 
            {
                
                string searchText = wordTextBox.Text.ToLower();
                var filteredWords = allWords.Where(word => word.ToLower().StartsWith(searchText)).ToList();

                suggestionsListBox.ItemsSource = filteredWords;
                suggestionsListBox.Visibility = Visibility.Visible; 
            }
            else
            {
                suggestionsListBox.Visibility = Visibility.Collapsed; 
            }
        }


        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                int selectedIndex = suggestionsListBox.SelectedIndex;
                if (selectedIndex < suggestionsListBox.Items.Count - 1)
                {
                    suggestionsListBox.SelectedIndex = selectedIndex + 1;
                    suggestionsListBox.ScrollIntoView(suggestionsListBox.SelectedItem);
                }
            }

            else if (e.Key == Key.Enter) 
            {
                if (suggestionsListBox.Items.Count > 0)
                {
                    string selectedWord = suggestionsListBox.SelectedItem as string;
                    if (!string.IsNullOrEmpty(selectedWord))
                    {
                        wordTextBox.Text = selectedWord;
                        wordTextBox.CaretIndex = wordTextBox.Text.Length; // Plaseaza cursorul la sfarsitul cuvantului
                    }
                }
                suggestionsListBox.Visibility = Visibility.Collapsed; 
            }
        }

    }
}
