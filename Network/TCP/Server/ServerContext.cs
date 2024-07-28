using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_2_Protocol_console_SERVER
{
    public class ServerContext
    {
        IPEndPoint ipPoint = null;
        TcpListener tcpListener = null;
        StreamReader sr = null;
        StreamWriter sw = null;
        //MyDbContext db;
        NetworkStream ns = null;
        public delegate string MyDelegate(string something);

        public ServerContext()
        {
            ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            tcpListener = new TcpListener(ipPoint);
            //db = new MyDbContext();
        }
        public void Start(MyDelegate Myfunck)
        {
            try
            {
                tcpListener.Start();

                Console.WriteLine("Server started connection !!!");

                TcpClient client = tcpListener.AcceptTcpClient();

                while (client.Connected)
                {
                    ns = client.GetStream();
                    sr = new StreamReader(ns);
                    string? line = sr.ReadLine();
                    string Area = Myfunck(line);
                    Console.WriteLine($"{client.Client.RemoteEndPoint} - {line} at {DateTime.Now.ToShortTimeString()}");
                    
                    sw = new StreamWriter(ns);
                    sw.WriteLine(Area);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                tcpListener.Stop();
                //db.Dispose();
                sr.Close();
                sw.Close();
                ns.Close();
            }
        }
    }
}
