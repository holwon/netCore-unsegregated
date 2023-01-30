using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace ContosoPizza.Models;

public class Topping // Topping 有蛋糕上面的配料的含义
{
    public int Id { get; set; }

    [Required] // 将属性标记为`必需`
    [MaxLength(100)] // 指定最大字符串长度 100。
    public string? Name { get; set; }
    public decimal Calories { get; set; } //卡路里

    [JsonIgnore] // 忽略此属性，因为它不应该在输出中出现。
    public ICollection<Pizza>? Pizzas { get; set; }
    // 添加 [JsonIgnore],这是为了防止 Topping 实体在 Web API 
    // 代码将响应序列化为 JSON 时包含 Pizzas 属性。 
    // 如果不这样做，配料的序列化集合将包括使用配料的每个披萨的集合。
    // 该集合中的每个披萨都将包含一个配料集合，每种配料又将包含一个披萨集合。 
    // 这种类型的无限循环称为“循环引用”，不能序列化。
}