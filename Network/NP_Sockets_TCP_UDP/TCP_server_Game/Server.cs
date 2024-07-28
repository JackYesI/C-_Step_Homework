using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Server
{
    static List<TcpClient> clients = new List<TcpClient>();
    static TcpListener listener;
    static StreamReader sr = null;
    static StreamWriter sw = null;
    static NetworkStream stream = null;
    const int port = 5000;
    static bool start = false;

    static async Task Main(string[] args)
    {
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        try
        {
            listener.Start();
            Console.WriteLine("Server is listening...");

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected!");
                clients.Add(client);

                if (clients.Count == 2)
                {
                    Console.WriteLine("Two clients connected. Starting the server logic...");
                    StartServerLogic();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            listener.Stop();
            sr.Close();
            sw.Close();
            stream.Close();
        }
    }

    static void StartServerLogic()
    {
        bool flag = true;
        char last_s = '\0';
        while (clients[0].Connected && clients[1].Connected)
        {
            if (start == false)
            {
                stream = clients[0].GetStream();
                sw = new StreamWriter(stream);
                sw.WriteLine("$<Start>!*You start !!!  Write your first word :: ");
                sw.Flush();
                start = true;
            }
            else
                if (flag == true)
                {
                    stream = clients[0].GetStream();
                    sr = new StreamReader(stream);
                    string? str_ = sr.ReadLine();

                    if (last_s == '\0') { last_s = str_[0]; }

                    if (last_s != str_[0]) { sw = new StreamWriter(stream); sw.WriteLine("$<end>!*You lose"); sw.Flush(); stream = clients[1].GetStream(); sw = new StreamWriter(stream); sw.WriteLine("$<end>!*You Win!!!"); sw.Flush(); }

                    stream = clients[1].GetStream();
                    sw = new StreamWriter(stream);
                    sw.WriteLine(str_);
                    sw.Flush();
                    flag = false;
                    last_s = str_[str_.Length - 1];
                }
                else
                {
                    stream = clients[1].GetStream();
                    sr = new StreamReader(stream);
                    string? str_ = sr.ReadLine();

                    if (last_s != str_[0]) { sw = new StreamWriter(stream); sw.WriteLine("$<end>!*You lose"); sw.Flush(); stream = clients[0].GetStream(); sw = new StreamWriter(stream); sw.WriteLine("$<end>!*You Win!!!"); sw.Flush(); }

                    stream = clients[0].GetStream();
                    sw = new StreamWriter(stream);
                    sw.WriteLine(str_);
                    sw.Flush();
                    flag = true;
                    last_s = str_[str_.Length - 1];
                }
        }
        
    }
}