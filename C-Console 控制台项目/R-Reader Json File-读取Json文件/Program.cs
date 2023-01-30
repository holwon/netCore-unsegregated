using System.Text.Json;
using System.Text.Json.Serialization;



Services provider = new Services();

System.Console.WriteLine(provider.fileName);
IEnumerable<Product>? products = provider.GetProducts(provider.fileName);
// if (products == null)
// {
//     System.Console.WriteLine("null");
// }
Product product1 = new Product() { Id = "1", Maker = "t" };

var products2 = new List<Product> { product1 };

foreach (Product product in products ? products2)
{
    System.Console.WriteLine(product.ToString());
}


public class Product
{
    public string Id { get; set; }
    public string Maker { get; set; }

    [JsonPropertyName("img")]
    public string Image { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int[] Ratings { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Product>(this);
}

public class Services
{
    public string fileName { get => Path.Combine(Directory.GetCurrentDirectory(), "data", "Products.json"); }
    public IEnumerable<Product>? GetProducts(string fileName)
    {
        if (File.Exists(fileName))
        {
            using var jsonFileReader = File.OpenText(fileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
        else return null;
    }
}

