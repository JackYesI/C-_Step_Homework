using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class ChatServer
{
    const short port = 8080;
    const string JOIN = "$<Join>";
    const string LEAVE = "$<Leave>";
    UdpClient server;
    IPEndPoint clientEndPoint = null;
    Dictionary<string, IPEndPoint> members;

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
        members.Add(name, clientEndPoint);
        Console.WriteLine("Member was added");
    }
    private void RemoveMember(string name, IPEndPoint iPEnd)
    {
        members.Remove(name);
        string rem_str = name;
        rem_str += "\t was deleted from server chat";
        byte[] bytes = Encoding.Unicode.GetBytes(rem_str);
        SendToAll(bytes);
        SendRemoveMessage(iPEnd);
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
}
internal class Program
{

    private static void Main(string[] args)
    {
        ChatServer server = new ChatServer();
        server.Start();
    }
}