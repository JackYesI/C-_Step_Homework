using System.ComponentModel;
using System.Net;

internal class Program
{
    static string decstop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    const string imgUrl1 = @"https://kinsta.com/wp-content/uploads/2020/08/tiger-jpg.jpg";
    const string imgUrl2 = @"https://thehilltoponline.com/wp-content/uploads/2022/08/unnamed-18-1024x683.jpg";
    private static async Task Main(string[] args)
    {
        // dowload file using HttpClient
        HttpClient client = new HttpClient();

        // way 1
        //HttpRequestMessage message = new HttpRequestMessage()
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri(imgUrl1),

        //};
        //var response = await client.SendAsync(message);
        //Console.WriteLine($"Status : {response.StatusCode}");
        //using (FileStream fs = new FileStream(decstop + "/image.jpg", FileMode.Create))
        //{
        //    await response.Content.CopyToAsync(fs);
        //}

        // way 2 array bytes in file
        //byte[] bufer = await client.GetByteArrayAsync(imgUrl2);
        //File.WriteAllBytes(decstop + "/" + Path.GetFileName(imgUrl2), bufer);

        // way 3
        WebClient web = new WebClient();
        // sync
        //web.DownloadFile(imgUrl1, Path.Combine(decstop, Path.GetFileName(imgUrl2)));
        //Console.WriteLine("file loaded");

        // async
        Console.WriteLine("File loading ...");

        DownloadFileAsync(imgUrl1);

        Console.ReadKey();
    }
    private static async void DownloadFileAsync(string adress)
    {
        WebClient client = new WebClient();

        client.DownloadFileCompleted += ClientDownloadFileCompleted;
        client.DownloadProgressChanged += ClientDownloadProgressChanged;

        string fileName = Path.GetFileName(adress);

        await client.DownloadFileTaskAsync(adress, Path.Combine(decstop, fileName));

        // cancel donload 
        //client.CancelAsync();


        Console.WriteLine("awreathing ok");
    }
    private static void ClientDownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Console.WriteLine("Loading was canceled !!!");
        }
        else
        {
            Console.WriteLine("File download succsesfuly !!!");
        }
    }
    private static void ClientDownloadProgressChanged(object? sender, DownloadProgressChangedEventArgs e)
    {
        //Console.Clear();
        Console.WriteLine($"Downloads.... {Math.Round((float)e.BytesReceived / 1024 / 1024, 2)} Mb of {Math.Round((float)e.TotalBytesToReceive / 1024 / 1024, 2)} MB {e.ProgressPercentage}");
    }
}