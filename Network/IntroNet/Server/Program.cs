using Microsoft.EntityFrameworkCore;
using Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    static string adress = "127.0.0.1";
    static int port = 8080;
    private static void Main(string[] args)
    {
        var connectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Post_DB;integrated security=True;Connect Timeout=2;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var dbContext = new AppDbContext(optionsBuilder.Options))
        {
            dbContext.Database.EnsureCreated();







            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(adress), port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            //Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UdpClient listener = new UdpClient(iPEndPoint);
            Console.WriteLine("Server Started!! Waiting for connection .....");

            try
            {
                //listenSocket.Bind(iPEndPoint);

                while (true)
                {
                    // getting a massege
                    //int bytes = 0;
                    //byte[] buffer = new byte[1024];
                    //bytes = listenSocket.ReceiveFrom(buffer, ref remoteEndPoint);
                 
                    byte[] buffer = listener.Receive(ref remoteEndPoint);
                    string msg = Encoding.Unicode.GetString(buffer);
                    Console.WriteLine($"{DateTime.Now.ToShortDateString()} : {msg} from {remoteEndPoint}");

                    // id
                    var postalCodeEntity = dbContext.PostalCodes.FirstOrDefault(p => p.Code == msg);

                    if (postalCodeEntity != null)
                    {
                        // Streets
                        var streetsForPostalCode = dbContext.Streets
                                                            .Where(s => s.PostalCodeId == postalCodeEntity.Id)
                                                            .ToList();

                        string[] send_string = new string[streetsForPostalCode.Count];
                        for (global::System.Int32 i = 0; i < streetsForPostalCode.Count; i++)
                        {
                            send_string[i] = streetsForPostalCode[i].Name;
                        }

                        string combinedMessage = string.Join("!", send_string);

                        buffer = Encoding.Unicode.GetBytes(combinedMessage);
                        //for (global::System.Int32 i = 0; i < 100000; i++)
                        //{
                        //    Console.WriteLine(i);
                        //}
                        listener.Send(buffer, buffer.Length, remoteEndPoint);
                    }
                    else
                    {
                        //for (global::System.Int32 i = 0; i < 100000; i++)
                        //{
                        //    Console.WriteLine(i);
                        //}
                        string message = "Post not found.";
                        buffer = Encoding.Unicode.GetBytes(message);
                        listener.Send(buffer, buffer.Length, remoteEndPoint);
                    }

                    // server's answer
                    //string message = "Message was send !!!";
                    //buffer = Encoding.Unicode.GetBytes(message);
                    //listener.Send(buffer, buffer.Length, remoteEndPoint);
                    //listenSocket.SendTo(buffer, remoteEndPoint);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //listenSocket.Shutdown(SocketShutdown.Both);
            //listenSocket.Close();
            listener.Close();
        }
    }
}