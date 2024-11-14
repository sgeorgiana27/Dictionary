using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace tema1
{
    public class Admin
    {
        private string imagePath = "";
        private string defaultImagePath = "C:\\Users\\sirbu\\OneDrive\\Desktop\\sem2\\MAP\\tema1\\tema1\\Images\\noImage.png";

        public Admin()
        {
        }

        public string SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagini (*.jpg, *.png)|*.jpg;*.png|Toate fișierele (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                return imagePath;
            }
            else
            {
                MessageBox.Show("Selectați o imagine!");
                return null;
            }
        }

        public string AddWord(string cuvant, string descriere, string categorie)
        {
            if (string.IsNullOrEmpty(cuvant) || string.IsNullOrEmpty(descriere) || string.IsNullOrEmpty(categorie))
            {
                return "Completați toate câmpurile!";
            }

            if (string.IsNullOrEmpty(imagePath))
            {
                imagePath = defaultImagePath;
            }

           // string relativeImagePath = GetRelativePath(imagePath);

            string line = $"{cuvant},{descriere},{categorie},{imagePath}";

            File.AppendAllLines("dictionar.txt", new[] { line });

            return "Cuvântul a fost adăugat cu succes în dicționar!";
        }

        //private string GetRelativePath(string absolutePath)
        //{
        //    string currentDirectory = Environment.CurrentDirectory;
        //    Uri currentUri = new Uri(currentDirectory + Path.DirectorySeparatorChar);
        //    Uri absoluteUri = new Uri(absolutePath);
        //    Uri relativeUri = currentUri.MakeRelativeUri(absoluteUri);
        //    return Uri.UnescapeDataString(relativeUri.ToString());
        //}
        public string ModifyWord(string wordToModify, string newWord, string newDescription, string newCategory, string newImagePath)
        {
            string filePath = "dictionar.txt";
            bool wordFound = false;
            string[] lines = File.ReadAllLines(filePath);
            string[] modifiedLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                string wordFromFile = parts[0];
                string description = parts[1];
                string categoryFromFile = parts[2];
                string imagePath = parts[3];

                if (wordFromFile.Equals(wordToModify, StringComparison.OrdinalIgnoreCase))
                {
                    wordFound = true;

                    // Actualizăm doar câmpurile care au fost modificate
                    if (!string.IsNullOrEmpty(newWord))
                        wordFromFile = newWord;

                    if (!string.IsNullOrEmpty(newDescription))
                        description = newDescription;

                    if (!string.IsNullOrEmpty(newCategory))
                        categoryFromFile = newCategory;

                    if (!string.IsNullOrEmpty(newImagePath))
                        imagePath = newImagePath;

                    modifiedLines[i] = $"{wordFromFile},{description},{categoryFromFile},{imagePath}";
                }
                else
                {
                    // Dacă nu am găsit cuvântul de modificat, păstrăm linia originală
                    modifiedLines[i] = line;
                }
            }

            if (!wordFound)
            {
                return "Cuvântul nu există în dicționar!";
            }

            File.WriteAllLines(filePath, modifiedLines);
            return "Cuvântul a fost modificat cu succes!";
        }


        public string DeleteWord(string wordToDelete)
        {
            string filePath = "dictionar.txt";
            string[] lines = File.ReadAllLines(filePath);
            bool wordFound = false;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string wordFromFile = parts[0];

                    if (wordFromFile.Equals(wordToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        wordFound = true;
                        continue; // Omitere înregistrare dacă cuvântul trebuie șters
                    }

                    writer.WriteLine(line);
                }
            }

            if (wordFound)
            {
                return "Cuvântul a fost șters din dicționar!";
            }
            else
            {
                return "Cuvântul nu a fost găsit în dicționar!";
            }
        }


    }
}
