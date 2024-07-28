using System.Net;
using System.Net.Sockets;
using TCP_2_Protocol_console_SERVER;

internal class server
{
    private static void Main(string[] args)
    {
        //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        //TcpListener tcpListener = new TcpListener(ipPoint);
        //StreamReader sr = null;

        //try
        //{
        //    tcpListener.Start();

        //    Console.WriteLine("Server started connection !!!");

        //    TcpClient client = tcpListener.AcceptTcpClient();

        //    while (client.Connected)
        //    {
        //        NetworkStream ns = client.GetStream();
        //        sr = new StreamReader(ns);
        //        string line = sr.ReadLine();
        //        Console.WriteLine($"{client.Client.RemoteEndPoint} - {line} at {DateTime.Now.ToShortTimeString()}");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //finally
        //{
        //    tcpListener.Stop();
        //}


        // database
        MyDbContext db = new MyDbContext();
        //Console.WriteLine(db.GetAreaByCode(3));

        // main
        ServerContext context = new ServerContext();
        ServerContext.MyDelegate del = new ServerContext.MyDelegate(db.GetAreaByCode); // or db.GetCodeByArea for exercise *
        context.Start(del);


    }
}