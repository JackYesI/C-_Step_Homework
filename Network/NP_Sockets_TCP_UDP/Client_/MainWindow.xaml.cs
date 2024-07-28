using System.Collections.ObjectModel;
using System.Net.Sockets;
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

namespace Client_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*const string serverAddress = "127.0.0.1";
        const short serverPort = 4040;*/
        string name;
        IPEndPoint serverPoint;
        UdpClient client;
        ObservableCollection<MessageInfo> messages;
        private static readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            string serverAddress = "127.0.0.1";
            short serverPort = 8080;
            serverPoint = new IPEndPoint(IPAddress.Parse(serverAddress), serverPort);
            client = new UdpClient();
            messages = new ObservableCollection<MessageInfo>();
            this.DataContext = messages;
            name = GenerateRandomString(random.Next(5, 10));
        }
        // рандомний генератор імені
        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (msgTextBox.Text == string.Empty)
            {
                MessageBox.Show("Message is empty !!!");
            }
            else
            {
                if (nicknameTextBox.Text == string.Empty)
                {
                    string message = msgTextBox.Text + "!*" + this.name;
                    msgTextBox.Text = "";
                    SendMessage(message);
                }
                else
                {
                    string message_type_ = "$<Private>";
                    string nick = nicknameTextBox.Text;
                    string message = message_type_ + "!*" + msgTextBox.Text + "!*" + this.name + "!*" + nick;
                    msgTextBox.Text = "";
                    nicknameTextBox.Text = "";
                    SendMessage(message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "$<Join>";
            SendMessage(message + "!*" + name);
            Listener();
        }
        private async void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            await client.SendAsync(data, data.Length, serverPoint);
        }
        private async void Listener()
        {
            while (true)
            {
                var res = await client.ReceiveAsync();
                string message = Encoding.Unicode.GetString(res.Buffer);
                string new_msg = message.Replace("!*", "\t");
                if (new_msg == "$<Leave>")
                    break;
                messages.Add(new MessageInfo(new_msg));
            }
        }

        private void Leave_Buttom(object sender, RoutedEventArgs e)
        {
            string message = "$<Leave>";
            SendMessage(message + "!*" + name);
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