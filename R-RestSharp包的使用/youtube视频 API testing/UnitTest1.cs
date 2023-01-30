using RestSharp;

namespace youtube视频_API_testing;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com/");
        var request = new RestRequest("posts/{id}", Method.Get);
        // 指定UA
        request.AddHeader("user-agent", "vscode-restclient");
        // 指定查询参数匹配
        request.AddUrlSegment("id", 1);
        RestResponse response = client.Execute(request);
        // 也有异步的方式
        response = client.ExecuteAsync(request).Result;
        Console.WriteLine(response.Content);
    }
}