using System.Diagnostics;
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
using System.Windows.Threading;

namespace ProcessRefresh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();

            List<ProcessInfo> processes = GetProcessesInfo(); // Метод для отримання даних про процеси

            grid.ItemsSource = processes;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += refresh;
            timer.Start();
        }
        private void refresh(object sender, EventArgs arg)
        {
            grid.ItemsSource = Process.GetProcesses();
            MessageBox.Show("refresh");
        }

        private void sec2(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void sec5(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        private void sec10(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void Stop(object sender, RoutedEventArgs e)
        {

        }

        private void Start(object sender, RoutedEventArgs e)
        {

        }


        private void Info(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem != null)
            {
                ProcessInfo selectedProcess = (ProcessInfo)grid.SelectedItem;
                ShowProcessInfo(selectedProcess.Id);
            }
            else
            {
                MessageBox.Show("Нічого не виділено.");
            }
        }
        private void ShowProcessInfo(int processId)
        {
            string processInfo = GetProcessInfo(processId);

            MessageBox.Show(processInfo);
        }
        private string GetProcessInfo(int processId)
        {
            string info = string.Empty;

            try
            {
                Process process = Process.GetProcessById(processId);
                info += $"Process Name: {process.ProcessName}\n";
                info += $"PID: {process.Id}\n";
                info += $"Total Processor Time: {process.TotalProcessorTime}\n";
                info += $"Priority: {process.PriorityClass}\n";
                info += $"User Name: {process.StartInfo.UserName}\n";
                info += $"Process start time: {process.StartTime}\n";
               
            }
            catch (Exception ex)
            {
                info = "Помилка отримання інформації про процес: " + ex.Message;
            }

            return info;
        }
        public class ProcessInfo
        {
            public string ProcessName { get; set; }
            public int Id { get; set; }
            public TimeSpan TotalProcessorTime { get; set; }
            public ProcessPriorityClass PriorityClass { get; set; }
            public string UserName { get; set; }
            public DateTime StartTime { get; set; }

            
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}