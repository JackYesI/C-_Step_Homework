using System;
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

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPEndPoint iPEndPoint;
        private Socket socket;
        private string message;
        private UdpClient udpClient;
        public MainWindow()
        {
            InitializeComponent();
            this.iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            udpClient = new UdpClient();
            message = "";
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        private void SendBottom(object sender, RoutedEventArgs e)
        {
            string message = InputTextBox.Text;
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            udpClient.Send(buffer, buffer.Length, iPEndPoint);
            ReceiveAsync();
        }
        private async void ReceiveAsync()
        {
            UdpReceiveResult res = await udpClient.ReceiveAsync();

            string response = Encoding.Unicode.GetString(res.Buffer);

            string[] catchAnswer = response.Split("!");

            OutputTextBox.Text = "";
            foreach (var item in catchAnswer)
            {
                OutputTextBox.Text += item + "\n";
            }
        }
    }
}