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
using SecondLibraryCodeFirstFluentAPI;
using SecondLibraryCodeFirstFluentAPI.Classes;

namespace HomeWork_Ex_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Result
    {
        public string ShopName { get; set; }
        public List<Workers> workers { get; set; }
        public List<Products> products { get; set; }
    }
    public partial class MainWindow : Window
    {
        private GroceryDb dbGrocery;
        public MainWindow()
        {
            InitializeComponent();
            dbGrocery = new GroceryDb();
            List<Result> results = GetSampleResults();

            dataGrid.ItemsSource = results;
        }

        private List<Result> GetSampleResults()
        {
            return dbGrocery.Shops.Select(shop => new Result
            {
                ShopName = shop.Name,
                workers = shop.Workers.ToList(),
                products = shop.Products.ToList()
            }).ToList();
        }
    }
}