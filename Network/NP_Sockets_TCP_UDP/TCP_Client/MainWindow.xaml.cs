using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
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

namespace TCP_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPEndPoint serverPoint;
        TcpClient client;
        NetworkStream stream = null;
        StreamReader sr = null;
        StreamWriter sw = null;
        ObservableCollection<MessageInfo> messages;
        public MainWindow()
        {
            InitializeComponent();
            string serverAdress = "127.0.0.1";
            int serverPort = 4040;
            serverPoint = new IPEndPoint(IPAddress.Parse(serverAdress), serverPort);
            client = new TcpClient();
            messages = new ObservableCollection<MessageInfo>();
        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            //if (msgTextBox.Text == string.Empty)
            //{
            //    MessageBox.Show("Message is empty !!!");
            //}


            try
            {
                client.Connect(serverPoint);
                stream  = client.GetStream   ();
                sr = new StreamReader(stream);
                sw = new StreamWriter(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

            //StreamReader sr = new StreamReader(nt);

        }

        private async void Disconnect_Buttom(object sender, RoutedEventArgs e)
        {
            await sw.WriteLineAsync("close");

            stream.Close();
            client.Close();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = msgTextBox.Text;
            msgTextBox.Text = "";


            await sw.WriteLineAsync(message);
            sw.Flush();

            Listener();
        }
        private async void Listener()
        {
            while (true)
            {
                string? message = await sr.ReadLineAsync();
                MessageBox.Show(message);
            }
        }
    }
    public class MessageInfo
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public MessageInfo(string message)
        {
            Message = message;
            Time = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Message,-20} {Time.ToShortTimeString()}";
        }
    }
}