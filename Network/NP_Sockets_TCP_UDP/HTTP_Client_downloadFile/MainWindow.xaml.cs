using Microsoft.Win32;
using System.ComponentModel;
using System.Net;
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


namespace HTTP_Client_downloadFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebClient client = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CancelDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.CancelAsync();
                AddToDownloadsListBox($"Download {client.BaseAddress} canceled.");
            }
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string fileName = System.IO.Path.GetFileName(UrlTextBox.Text);
                string adress = dialog.FileName;
                int lastIndex = adress.LastIndexOf('\\');
                if (lastIndex != -1)
                {
                    adress = adress.Substring(0, lastIndex);
                }
                else
                {
                    adress = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                SavePathTextBox.Text = System.IO.Path.Combine(adress, fileName);
            }
        }

        private async void StartDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            client = new WebClient();

            client.DownloadFileCompleted += ClientDownloadFileCompleted;
            client.DownloadProgressChanged += ClientDownloadProgressChanged;

            string fileName = System.IO.Path.GetFileName(UrlTextBox.Text);

            await client.DownloadFileTaskAsync(UrlTextBox.Text, SavePathTextBox.Text);
        }

        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = SavePathTextBox.Text;
            ViewFileOrImage(filePath);
        }
        private void ClientDownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            string message = e.Cancelled ? "Loading was canceled !!!" : "File download successfully !!!";
            AddToDownloadsListBox(message);
        }
        private void ClientDownloadProgressChanged(object? sender, DownloadProgressChangedEventArgs e)
        {
            string progressMessage = $"Downloads.... {Math.Round((float)e.BytesReceived / 1024 / 1024, 2)} Mb of {Math.Round((float)e.TotalBytesToReceive / 1024 / 1024, 2)} MB {e.ProgressPercentage}";
            AddToDownloadsListBox(progressMessage);
        }
        private void AddToDownloadsListBox(string message)
        {
            DownloadsListBox.Items.Add(message);
        }
        private void ViewFileOrImage(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    
                    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                    if (fileExtension == ".txt" || fileExtension == ".xml" || fileExtension == ".csv")
                    {
                
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        MessageBox.Show($"File content:\n{fileContent}", "File Content", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".gif")
                    {
              
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        DisplayImage.Source = bitmap;
                    }
                    else
                    {
                        MessageBox.Show("Unsupported file format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("File not found or path is invalid.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}