using System.ComponentModel.DataAnnotations.Schema;

namespace ef2_mssql.Model;
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    [ForeignKey("Blog")]
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}