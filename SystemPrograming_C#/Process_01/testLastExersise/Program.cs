using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string directoryPath = @"D:\ExemplesFiles";
        string targetWord = "Hello";

        try
        {
            Dictionary<string, int> wordCounts = await ProcessFilesAsync(directoryPath, targetWord);

            // Write to console
            Console.WriteLine("Statistic about files:");
            string statistics = GenerateStatistics(wordCounts, targetWord);
            Console.WriteLine(statistics);

            // Save to file
            SaveStatisticsToFile(statistics);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task<Dictionary<string, int>> ProcessFilesAsync(string directoryPath, string targetWord)
    {
        string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
        int totalFiles = files.Length;
        int processedFiles = 0;

        var wordCounts = new Dictionary<string, int>();

        await Task.WhenAll(files.Select(async file =>
        {
            string fileContent = await File.ReadAllTextAsync(file);
            int count = CountOccurrences(fileContent, targetWord);

            lock (wordCounts)
            {
                wordCounts[file] = count;
                processedFiles++;
                Console.WriteLine($"Progress: {processedFiles}/{totalFiles} files processed");
            }
        }));

        return wordCounts;
    }

    static int CountOccurrences(string text, string targetWord)
    {
        char[] chars = { ' ', '.', '!', '?', '\n' };
        string[] strings = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        int count = strings.Count(word => word == targetWord);
        return count;
    }

    static string GenerateStatistics(Dictionary<string, int> wordCounts, string targetWord)
    {
        string statistics = "";
        foreach (var pair in wordCounts)
        {
            statistics += $"File: {pair.Key}\nFile path: {pair.Key}\nCount of target word '{targetWord}': {pair.Value}\n";
        }
        return statistics;
    }

    static void SaveStatisticsToFile(string statistics)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, "Result_Statistic.txt");
        try
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.Write(statistics);
            }

            Console.WriteLine("Statistics saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
