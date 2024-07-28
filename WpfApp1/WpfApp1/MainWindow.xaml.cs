using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// [System.Windows.Localizability(System.Windows.LocalizationCategory.None, Readability=System.Windows.Readability.Unreadable)]
    

    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}
        private Person _person;

        public MainWindow()
        {
            InitializeComponent();
            _person = new Person();
            DataContext = _person; // Встановлення контексту даних
        }

        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            _person.Name = txtName.Text + "Hi";
        }
        //private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
        //    {
        //        lstNames.Items.Add(txtName.Text);
        //        txtName.Clear();
        //        MessageBox.Show("Hello, Windows Presentation Foundation!");
        //    }
        //}
    }
}
