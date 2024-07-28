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
using WpfApp1.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LibraryContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();
            //LoadAuthors();
            LoadAuthorsAsync();

        }

        //private void LoadAuthors()
        //{
        //    comboBoxAuthors.ItemsSource = _context.Authors.ToList();
        //}

        //private void comboBoxAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (comboBoxAuthors.SelectedItem != null)
        //    {
        //        var selectedAuthor = (Author)comboBoxAuthors.SelectedItem;
        //        var books = _context.Books.Where(b => b.AuthorId == selectedAuthor.Id).ToList();
        //        listBoxBooks.ItemsSource = books;
        //    }
        //}

        private async Task LoadAuthorsAsync()
        {
            List<Author> authors = await Task.Run(() => _context.Authors.ToList());
            comboBoxAuthors.ItemsSource = authors;
        }

        private async void comboBoxAuthors_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (comboBoxAuthors.SelectedItem != null)
            {
                var selectedAuthor = (Author)comboBoxAuthors.SelectedItem;
                List<Book> books = await Task.Run(() => _context.Books.Where(b => b.AuthorId == selectedAuthor.Id).ToList());
                listBoxBooks.ItemsSource = books;
            }
        }
    }
}