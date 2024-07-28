using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Course_C_sharp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileSystemItem> FileItems { get; set; }
        public FileSystemItem SelectedFile { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FileItems = new ObservableCollection<FileSystemItem>();
            DataContext = this;
            ResizeMode = ResizeMode.NoResize;
            //Icon = new BitmapImage(new Uri("C:\\Users\\Денис\\Downloads\\download_folder_file_icon_219533.ico", UriKind.RelativeOrAbsolute));
        }



        private void ExploreDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                FileItems.Clear();
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                foreach (string directory in directories)
                {
                    FileItems.Add(new FileSystemItem { Name = Path.GetFileName(directory), IsDirectory = true });
                }

                foreach (string file in files)
                {
                    FileItems.Add(new FileSystemItem { Name = Path.GetFileName(file), IsDirectory = false });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PathTextBox.Text = "D:/";
        }

        private void PathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string path = PathTextBox.Text;
            ExploreDirectory(path);
        }

        private void ResultsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Отримуємо вибраний елемент зі списку
            this.SelectedFile = FileListView.SelectedItem as FileSystemItem;

            if (SelectedFile != null)
            {
                //if (SelectedFile.IsDirectory)
                //{
                //    // Це тека, робимо потрібні дії з текою
                //    MessageBox.Show($"You selected derectory: {SelectedFile.Name}");
                //}
                //else
                //{
                //    // Це файл, робимо потрібні дії з файлом

                //    MessageBox.Show($"You selected file: {SelectedFile.Name}");
                //}
                FileChanger.Text = SelectedFile.Name;
            }
        }
        private void Refresh()
        {
            string aaa = PathTextBox.Text;
            PathTextBox.Text = string.Empty;
            PathTextBox.Text = aaa;
            editBox.Text = string.Empty;
            destination.Text = "Box for destination";
        }
        private void create_button(object sender, RoutedEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text);
                MessageBox.Show($"Directory {FileChanger.Text} create successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            Refresh();
        }

        private void delete_button(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text))
            {
                try
                {
                    Directory.Delete(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text, true);
                    MessageBox.Show($"Directory {FileChanger.Text} deleted successfully.");
                    FileChanger.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                Refresh();
            }
            else
            {
                MessageBox.Show("Directory does not exist !!!");
            }
        }

        private void edit_button(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text))
                {
                    writer.WriteLine(editBox.Text);
                }
                MessageBox.Show("File edited successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void show_button(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text))
                {
                    string line;
                    string result = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        result += line + "\n";
                    }
                    editBox.Text = result;
                }
                MessageBox.Show("File read successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void create_file(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Create(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text);
                MessageBox.Show("File create successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            Refresh();
        }

        private void delete_file(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text))
                {
                    File.Delete(PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text);
                    MessageBox.Show($"File {FileChanger.Text} deleted successfully.");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("File does not exist !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Move_(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text;
            string destinationFilePath = destination.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text;

            try
            {
                File.Move(sourceFilePath, destinationFilePath);
                MessageBox.Show($"File {FileChanger.Text} was moved");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Info_(object sender, RoutedEventArgs e)
        {
            string filePath = PathTextBox.Text.Replace("\\", "\\\\") + "\\" + FileChanger.Text;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                MessageBox.Show($"File name: {fileInfo.Name}\n" +
                    $"Path is {fileInfo.FullName}\n" +
                    $"Size is {fileInfo.Length}\n" +
                    $"Extension is {fileInfo.Extension} \n" +
                    $"Date of create {fileInfo.CreationTime}\n" +
                    $"Date of edit {fileInfo.LastWriteTime} \n" +
                    $"Date of last access time {fileInfo.LastAccessTime}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }

    public class FileSystemItem
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
    }



}
