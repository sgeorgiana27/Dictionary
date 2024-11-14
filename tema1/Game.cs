using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tema1
{
    internal class Game
    {
        private List<(string word, string content, int type)> gameWords;

        public Game()
        {
            gameWords = new List<(string word, string content, int type)>();
        }

        public void LoadDictionary(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            List<(string word, string content)> words = new List<(string word, string content)>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    string word = parts[0].Trim();
                    string content = parts[1].Trim();
                    words.Add((word, content));
                }
            }

            // Alegem aleatoriu 5 cuvinte din lista de cuvinte
            var random = new Random();
            var selectedWords = words.OrderBy(_ => random.Next()).Take(5).ToList();

            foreach (var (word, content) in selectedWords)
            {
                int type = random.Next(1, 3); // 1 pentru descriere, 2 pentru imagine
                gameWords.Add((word, content, type));
            }
        }

        public List<(string word, string content, int type)> GetGameWords()
        {
            return gameWords;
        }
    }
}
