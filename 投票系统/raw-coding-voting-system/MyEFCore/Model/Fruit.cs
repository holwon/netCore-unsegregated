using System.ComponentModel.DataAnnotations.Schema;

namespace MyEFCore.Model;

[Table("Fruits")]
public class Fruit
{
    public int Id { get; set; }

    [Column("FruitName", TypeName = "varchar(20)")]// 可以指定列名
    public string? Name { get; set; }
    public string? Weight { get; set; }

    [ForeignKey("AddressId")]
    [Column("AddressId", TypeName = "int")]
    public int? AddressId { get; set; }
    public Address Address { get; set; }// 地址, 我们有很多时候会用到一个类似地址的属性
}

public class Address
{
    public int AddressId { get; set; }
    public string PostCode { get; set; }
}
