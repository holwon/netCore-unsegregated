using System.ComponentModel.DataAnnotations.Schema;

public class Comments
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    [ForeignKey("Post")]
    public int PostId { get; set; }
    public List<Post> Post { get; internal set; }
}