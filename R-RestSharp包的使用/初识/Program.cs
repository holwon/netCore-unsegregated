// 加了两个包
// Newtonsoft.Json 方便序列化json
// RestSharp

using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using RestSharp;


var url = "https://jsonplaceholder.typicode.com/posts";
var client = new RestClient(url);

// 发送包含 title 和 body 的json
var payload = new JObject();
payload.Add("title", "post title");
payload.Add("body", "post body");

var request = new RestRequest();
// 这个 AddJsonBody()并不能添加 Newtonsoft.Json的JObject对象
/// <code> request.AddJsonBody(payload); </code>

// 使用JObject的话 需要使用 AddStringBody添加, 具体需要看 RestSharp的文档
request.AddStringBody(payload.ToString(), DataFormat.Json);

// request.AddParameter(payload.ToString(), DataFormat.Json);
var response1 = client.PostAsync(request).Result;
System.Console.WriteLine(response1.Content);
System.Console.WriteLine();
// 普通的话 可以新建一个和 json 对应的类
// 直接
var payload3 = new Post() { userId = 2, Title = "request3 title", Body = "request3 body" };

var json3 = System.Text.Json.JsonSerializer.Serialize(payload3);

// var request3 = new RestRequest().AddJsonBody(json3);
var request3 = new RestRequest().AddJsonBody(payload3);// 其实这里是隐式泛型了 AddJsonBody<Post>
var response3 = client.PostAsync(request3).Result;
System.Console.WriteLine("request3 result:\n" + response3.Content);
System.Console.WriteLine();

// AddQueryParameter AddParameter两者均可
// var request2 = new RestRequest().AddQueryParameter("id", 2);
var request2 = new RestRequest().AddParameter("id", 2);
var response2 = client.GetAsync(request2).Result;
Console.WriteLine(response2.Content);

public class Post
{
    // [JsonPropertyName("id")]
    public required int userId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }
    public required string Body { get; set; }
}