using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace tema1
{
    public partial class Window7 : Window
    {
        private List<(string Word, string Content, int Type)> gameWords;
        private int currentIndex = 0;
        private List<string> answers = new List<string>(); 

        public Window7(List<(string Word, string Content, int Type)> gameWords)
        {
            InitializeComponent();
            this.gameWords = gameWords;

            for (int i = 0; i < gameWords.Count; i++)
            {
                answers.Add("");
            }

            ShowWord();
        }

        private void ShowWord()
        {
            if (currentIndex >= 0 && currentIndex < gameWords.Count)
            {
                var currentWord = gameWords[currentIndex];
                WordDescription.Text = currentWord.Content;
                if (currentWord.Type == 1)
                {
                    WordImage.Visibility = Visibility.Collapsed;
                    WordDescription.Visibility = Visibility.Visible;
                }
                else if (currentWord.Type == 2)
                {
                    WordDescription.Visibility = Visibility.Collapsed;
                    WordImage.Visibility = Visibility.Visible;
                    WordImage.Source = new BitmapImage(new Uri(currentWord.Content));
                }
            }

            if (currentIndex == gameWords.Count - 1)
            {
                NextButton.Visibility = Visibility.Collapsed;
                FinishButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Visible;
                FinishButton.Visibility = Visibility.Collapsed;
            }

            PreviousButton.Visibility = (currentIndex == 0) ? Visibility.Collapsed : Visibility.Visible;

            AnswerTextBox.Text = answers[currentIndex];
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentIndex] = AnswerTextBox.Text;

            currentIndex++;

            AnswerTextBox.Text = "";

            ShowWord();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentIndex] = AnswerTextBox.Text;

            int score = CalculateScore();
            MessageBox.Show($"Punctaj final: {score}");
            Close();
        }

        private int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i < gameWords.Count; i++)
            {
                if (answers[i].ToLower() == gameWords[i].Word.ToLower())
                {
                    score++;
                }
            }
            return score;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentIndex] = AnswerTextBox.Text;

            currentIndex--;

            if (currentIndex == gameWords.Count - 1)
            {
                NextButton.Visibility = Visibility.Collapsed;
                FinishButton.Visibility = Visibility.Visible;
            }
            else
            {
                NextButton.Visibility = Visibility.Visible;
                FinishButton.Visibility = Visibility.Collapsed;
            }

            ShowWord();
        }

    }
}

