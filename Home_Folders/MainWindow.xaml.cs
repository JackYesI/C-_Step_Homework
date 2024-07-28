using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace File_System
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileSystemItem> FileItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FileItems = new ObservableCollection<FileSystemItem>();
            DataContext = this;
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
            else
            {
                MessageBox.Show("Directory does not exist.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = PathTextBox.Text;
            ExploreDirectory(path);
        }
    }

    public class FileSystemItem
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
    }
}
