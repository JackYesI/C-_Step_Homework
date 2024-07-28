using System.Net;
using System.Net.Sockets;
using System.Text;

public class Chat_Server
{
    const short port = 4040;
    TcpListener server = null;
    IPEndPoint IPEndPoint = null;
    StreamReader sr = null;
    StreamWriter sw = null;
    public Chat_Server()
    {
        server = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
    }
    public void Start()
    {
        server.Start();
        Console.WriteLine("Conected !!!");


        TcpClient tcpClient = server.AcceptTcpClient();
        while (true)
        {
            NetworkStream ns = tcpClient.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            string? message = sr.ReadLine();
            Console.WriteLine($"Message :: {message} from :: {tcpClient.Client.LocalEndPoint}");

            if (message == "close")
            {
                sw.WriteLine("Good");
                ns.Close();
                server.Stop();
                return;
            }

            sw.WriteLine(message);
            sw.Flush();
        }
    }
}

internal class Program
{
    
    private static void Main(string[] args)
    {
        Chat_Server server = new Chat_Server();
        server.Start();
    }
}