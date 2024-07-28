using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LastExamAsynDict
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void ProcessFiles_Click(object sender, RoutedEventArgs e)
        {
            string directoryPath = txtDirectoryPath.Text;
            string targetWord = txtTargetWord.Text;

            try
            {
                Dictionary<string, int> wordCounts = await ProcessFilesAsync(directoryPath, targetWord);
                string statistics = GenerateStatistics(wordCounts, targetWord);
                txtResult.Text = statistics;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SaveResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = txtResult.Text;
                SaveStatisticsToFile(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task<Dictionary<string, int>> ProcessFilesAsync(string directoryPath, string targetWord)
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
                }
            }));

            return wordCounts;
        }

        private int CountOccurrences(string text, string targetWord)
        {
            char[] chars = { ' ', '.', '!', '?', '\n' };
            string[] strings = text.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            int count = strings.Count(word => word == targetWord);
            return count;
        }

        private string GenerateStatistics(Dictionary<string, int> wordCounts, string targetWord)
        {
            string statistics = "";
            foreach (var pair in wordCounts)
            {
                statistics += $"File: {pair.Key}\nCount of target word '{targetWord}': {pair.Value}\n";
            }
            return statistics;
        }

        private void SaveStatisticsToFile(string statistics)
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Result_Statistic.txt");
            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.Write(statistics);
                }

                MessageBox.Show("Statistics saved to file successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}