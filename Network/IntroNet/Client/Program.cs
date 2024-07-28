using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    // adress and port of server for including
    static string address = "127.0.0.1";
    static int port = 8080; // 1000 ... 60000
    //static async void ReceiveAsync()
    //{
    //    UdpReceiveResult res = await udpClient.ReceiveAsync();
    //    string response = Encoding.Unicode.GetString(res.Buffer);
    //    string[] catchAnswer = response.Split("!");

    //    Console.WriteLine("Streats: ");
    //    foreach (var item in catchAnswer)
    //    {
    //        Console.WriteLine($"\t{item}");
    //    }
    //}
    private static void Main(string[] args)
    {
        try
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string message = "";

            UdpClient udpClient = new UdpClient();

            while (message != "end")
            {
                Console.WriteLine("Enter a message :: ");
                message = Console.ReadLine();
                byte[] buffer = Encoding.Unicode.GetBytes(message);

                //socket.SendTo(buffer, iPEndPoint);
                udpClient.Send(buffer, buffer.Length, iPEndPoint);

                // getting servers's answer
                int bytes = 0;
                string response = "";
                buffer = new byte[1024];
                //do 
                //{
                //    bytes = socket.ReceiveFrom(buffer, ref remoteEndPoint);
                //    response += Encoding.Unicode.GetString(buffer);
                //}
                //while (socket.Available > 0);

                buffer = udpClient.Receive(ref remoteEndPoint);
                response = Encoding.Unicode.GetString(buffer);
                string[] catchAnswer = response.Split("!");

                Console.WriteLine("Streats: ");
                foreach (var item in catchAnswer)
                {
                    Console.WriteLine($"\t{item}");
                }

                //ReceiveAsync();
            }
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();

            udpClient.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}