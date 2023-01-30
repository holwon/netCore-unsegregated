using System.ComponentModel.DataAnnotations.Schema;

namespace MyEFCore.Model;
public class FruitVM
{
    public int Id { get; set; }

    [Column("FruitVMName", TypeName = "varchar(20)")]// 可以指定列名
    public string? Name { get; set; }
    public string? Weight { get; set; }
}
