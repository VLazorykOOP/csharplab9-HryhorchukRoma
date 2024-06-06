using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Lab9T2
{
    private string _filePath;

    public Lab9T2(string filePath)
    {
        _filePath = filePath;
    }

    public async Task Run()
    {
        try
        {
            List<string> vowelWords = new List<string>();
            List<string> consonantWords = new List<string>();
            string vowels = "AEIOUaeiou";

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string reversedLine = ReverseLine(line);
                    Console.WriteLine(reversedLine);

                    string[] words = reversedLine.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (!string.IsNullOrEmpty(word) && vowels.IndexOf(word[0]) >= 0)
                        {
                            vowelWords.Add(word);
                        }
                        else
                        {
                            consonantWords.Add(word);
                        }
                    }
                }
            }

            foreach (string word in vowelWords)
            {
                Console.WriteLine(word);
            }

            foreach (string word in consonantWords)
            {
                Console.WriteLine(word);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private string ReverseLine(string line)
    {
        char[] charArray = line.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

// Використання класу Lab9T2:
class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "example.txt"; // Вкажіть шлях до вашого файлу
        Lab9T2 lab9task2 = new Lab9T2(filePath);
        await lab9task2.Run();
    }
}
