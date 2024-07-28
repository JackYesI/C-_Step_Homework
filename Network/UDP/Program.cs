using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks.Dataflow;


// Додано + обмеження по кількості учасників
// Додано + перевірку чи вже є в бесіді даний учасник
// Додано - можливість надсилання приватних повідомлень
public class ChatServer
{
    const short port = 8080;
    const string JOIN = "$<Join>";
    const string LEAVE = "$<Leave>";
    const string PRIVATE = "$<Private>";
    UdpClient server;
    IPEndPoint clientEndPoint = null;
    Dictionary<string, IPEndPoint> members;
    const uint MAX_CLIENT = 3;

    public ChatServer()
    {
        server = new UdpClient(port);
        members = new Dictionary<string, IPEndPoint>();
    }
    public void Start()
    {
        while (true)
        {
            byte[] data = server.Receive(ref clientEndPoint);
            string message = Encoding.Unicode.GetString(data);
            string[] strings = message.Split("!*");
            switch (strings[0])
            {
                case JOIN:
                    AddMember(strings[1], clientEndPoint);
                    break;
                case LEAVE:
                    RemoveMember(strings[1], clientEndPoint);
                    break;
                case PRIVATE:
                    SendPrivate(strings[3], strings[1], strings[2], clientEndPoint);
                    break;
                default:
                    if (members.ContainsKey(strings[1])) {
                        Console.WriteLine($"Got message {strings[0],-20} from : {clientEndPoint} name {strings[1]} at {DateTime.Now.ToShortTimeString()}");
                        SendToAll(data);
                    }
                    else
                    {
                        Console.WriteLine($"Got message {strings[0],-20} from : {clientEndPoint} at {DateTime.Now.ToShortTimeString()}");
                        SendToAll(data);
                    }
                    break;
            }
        }
    }
    private void AddMember(string name, IPEndPoint clientEndPoint)
    {
        if (members.ContainsKey(name))
        {
            Console.WriteLine("This client exist !!!");
            return;
        }
        if (members.Values.Count == MAX_CLIENT)
        {
            SendMessage(name, clientEndPoint, "MAX COUNT OF CLIENT\nimpossible add new one!!!");
            return;
        }
        members.Add(name, clientEndPoint);
        Console.WriteLine("Member was added");
    }
    private void RemoveMember(string name, IPEndPoint iPEnd)
    {
        if (members.Remove(name))
        {
            string rem_str = name;
            rem_str += "\t was deleted from server chat";
            byte[] bytes = Encoding.Unicode.GetBytes(rem_str);
            SendToAll(bytes);
            SendRemoveMessage(iPEnd);
        }
    }
    private async void SendMessage(string name, IPEndPoint iPEnd, string massege)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(massege);
        await server.SendAsync(bytes, bytes.Length, iPEnd);
    }
    private async void SendToAll(byte[] data)
    {
        foreach (var member in members)
        {
            await server.SendAsync(data, data.Length, member.Value);
        }
    }
    private async void SendRemoveMessage(IPEndPoint iPEnd)
    {
        await server.SendAsync(Encoding.Unicode.GetBytes(LEAVE), LEAVE.Length, iPEnd);
    }
    private async void SendPrivate(string nick, string massege, string name, IPEndPoint sender)
    {
        if (members.ContainsKey(nick))
        {
            byte[] bytes = Encoding.Unicode.GetBytes(massege + " from nickname(" + name + ")");
            IPEndPoint iP = members[nick];
            await server.SendAsync(bytes, bytes.Length, iP);
        }
        else
        {
            byte[] messCross = Encoding.Unicode.GetBytes("not found the client !!!");
            await server.SendAsync(messCross, messCross.Length, sender);
        }
    }
}
internal class Program
{

    private static void Main(string[] args)
    {
        ChatServer server = new ChatServer();
        server.Start();
    }
}