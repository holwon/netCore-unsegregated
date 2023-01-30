using System.ComponentModel.DataAnnotations;

public class Tag
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Article> Articles { get; set; }
}