using System.Configuration;
using System.Net;
using System.Net.Sockets;

internal class Client
{
    private static void Main(string[] args)
    {
        string adress = "127.0.0.1";
        short port = 5000;
        

        IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse(adress), port);
        TcpClient client = new TcpClient();

        StreamWriter sw = null;
        StreamReader sr = null;
        NetworkStream stream = null;

        try
        {
            client.Connect(serverPoint);
            string messageFromServer = "";
            while (messageFromServer != "$<end>")
            {
                stream = client.GetStream();
                sr = new StreamReader(stream);
                string? str_ = sr.ReadLine();
                string[] split_str = str_.Split("!*");
                if (split_str[0] == "$<Start>")
                {
                    Console.Write(split_str[1]);
                    string message = "";
                    message = Console.ReadLine();
                    sw = new StreamWriter(stream);
                    sw.WriteLine(message);
                    sw.Flush();
                }
                else if (split_str[0] == "$<end>")
                {
                    Console.Write(split_str[1]);
                    break;
                }
                else
                {
                    string partWithoutLastChar = str_.Substring(0, str_.Length - 1);
                    char lastChar = str_[str_.Length - 1];
                    Console.Write("\t\t" + partWithoutLastChar);
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.Write(lastChar);
                    Console.ResetColor();
                    Console.WriteLine();
                    // readline from console
                    string message = Console.ReadLine();
                    sw = new StreamWriter(stream);
                    sw.WriteLine(message);
                    sw.Flush();
                }
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
        Console.ReadKey();

       
    }
}