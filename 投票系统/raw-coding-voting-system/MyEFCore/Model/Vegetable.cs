using System.ComponentModel.DataAnnotations.Schema;

namespace MyEFCore.Model;

[Table("Vegetables")]
public class Vegetable
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Weight { get; set; }
}
