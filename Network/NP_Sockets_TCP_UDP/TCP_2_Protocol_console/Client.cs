using System.Configuration;
using System.Net;
using System.Net.Sockets;
using TCP_2_Protocol_console_CLIENT;

internal class Client
{
    private static void Main(string[] args)
    {
       // string? adress = ConfigurationManager.AppSettings["serverAdress"]!;
       // short port = short.Parse(ConfigurationManager.AppSettings["serverPort"]!);


       // IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(adress), port);
       // TcpClient client = new TcpClient();

       // StreamWriter sw = null;
       // StreamReader sr = null;

       // try
       // {
       //     client.Connect(serverPoint);
       //     string message = "";
       //     while (message != "end")
       //     {
       //         Console.WriteLine("Enter a message :: ");
       //         message = Console.ReadLine();

       //         NetworkStream stream = client.GetStream();
       //         sw = new StreamWriter(stream);
       //         sw.WriteLine(message);
       //         sw.Flush();
       //     }
       // }
       // catch (Exception ex)
       // {
       //     Console.WriteLine(ex.Message);
       // }
       // finally
       // {
       //     client.Close();
       // }
       //Console.ReadKey();

        ClientContext client = new ClientContext();
        client.Start();
    }
}