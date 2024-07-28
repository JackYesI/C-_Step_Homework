using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_2_Protocol_console_CLIENT
{
    public class ClientContext
    {
        string? adress;
        short port;


        IPEndPoint serverPoint;
        TcpClient client;

        StreamWriter sw = null;
        StreamReader sr = null;
        NetworkStream stream = null;
        public ClientContext()
        {
            adress = ConfigurationManager.AppSettings["serverAdress"]!;
            port = short.Parse(ConfigurationManager.AppSettings["serverPort"]!);
            serverPoint = new IPEndPoint(IPAddress.Parse(adress), port);
            client = new TcpClient();
        }
        //public async void ReadLineAsync_My(NetworkStream ns)
        //{
        //    sr = new StreamReader(ns);
        //    string? line = await sr.ReadLineAsync();
        //    Console.WriteLine(line);
        //}
        public void Start()
        {
            try
            {
                client.Connect(serverPoint);
                string message = "";
                while (message != "end")
                {
                    Console.WriteLine("Enter a request :: ");
                    message = Console.ReadLine();

                    stream = client.GetStream();
                    sw = new StreamWriter(stream);
                    sw.WriteLine(message);
                    sw.Flush();
                    
                    sr = new StreamReader(stream);
                    string? response = sr.ReadLine();
                    Console.WriteLine($"Server response :: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
                sw.Close();
                sr.Close();
                stream.Close();
            }
        }
    }
}
