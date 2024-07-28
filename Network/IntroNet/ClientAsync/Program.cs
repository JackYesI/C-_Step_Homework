using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static string address = "127.0.0.1";
    static int port = 8080;

    static async Task Main(string[] args)
    {
        try
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(address), port);
            UdpClient udpClient = new UdpClient();

            while (true)
            {
                Console.WriteLine("Enter a message (type 'end' to exit): ");
                string message = Console.ReadLine();
                byte[] buffer = Encoding.Unicode.GetBytes(message);

                await udpClient.SendAsync(buffer, buffer.Length, endPoint);

                // Receive response from the server
                UdpReceiveResult receivedResults = await udpClient.ReceiveAsync();
                byte[] responseBuffer = receivedResults.Buffer;

                string responseMsg = Encoding.Unicode.GetString(responseBuffer);
                Console.WriteLine($"Response from server: {responseMsg}");

                if (message == "end")
                    break;
            }
            udpClient.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
