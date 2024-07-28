using Newtonsoft.Json;
using System.Text;

class Post
{
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
}
internal class Program
{
    private static async Task Main(string[] args)
    {
        // get
        string url = @"https://jsonplaceholder.typicode.com/users";

            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync(url);
            //    Console.WriteLine(response.StatusCode);
            //    var result = await response.Content.ReadAsStringAsync();

            //    Console.WriteLine(result);
            //}

            // post
            var post = new Post()
            {
                Title = "Blabla-bla",
                Body = "Blabody",
                UserId = 1
            };
        var json = JsonConvert.SerializeObject(post);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        var response = await client.PostAsync(url, data);
        Console.WriteLine(response.StatusCode);
        var result = await response.Content.ReadAsStringAsync();

        Console.WriteLine(result);
    }
}