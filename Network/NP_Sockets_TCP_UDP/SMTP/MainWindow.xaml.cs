using Microsoft.Win32;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
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

namespace SMTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string server = "smtp.gmail.com";
        int port = 587;
        string userName = "denus.redchuch@gmail.com";
        string password = "uaky yifd jjjm plrj";
        bool flag = false;

        private List<Attachment> attachments;
        public MainWindow()
        {
            InitializeComponent();
            attachments = new List<Attachment>();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(fromObject.Text, toObject.Text, subject.Text, bodyObject.Text);
            SmtpClient smtpClient = new SmtpClient(server, port);
            smtpClient.Credentials = new NetworkCredential(userName, password);
          
            if (flag)
            {
                message.Priority = MailPriority.High;
                flag = false;
            }
            else
            {
                message.Priority = MailPriority.Low;
            }
            
            foreach (var item in attachments)
            {
                message.Attachments.Add(item);
            }
            smtpClient.EnableSsl = true;

            smtpClient.SendCompleted += Send_Completed;

            smtpClient.SendAsync(message, message);   
        }
        private void Send_Completed(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            MessageBox.Show($"Message status send is {state.Subject}");
        }

        private void Attach_Button(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    Attachment attachment = new Attachment(filePath);
                    attachments.Add(attachment);
                }

                AttachmentsListBox.ItemsSource = null;
                AttachmentsListBox.ItemsSource = attachments;
            }
        }

        private void Prioritty_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
        }
    }
}