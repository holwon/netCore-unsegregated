using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Sauce
{
    public int Id { get; set; }

    [Required] // 将属性标记为`必需`
    [MaxLength(100)] // 指定最大字符串长度 100。
    public string? Name { get; set; }
    public bool IsVegan { get; set; } //素食主义者  
}