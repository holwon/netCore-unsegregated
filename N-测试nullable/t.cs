
public class t
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Info { get; set; }

#nullable disable //在此处之后的属性全部不可空
    public string Description { get; set; }
    public string Message { get; set; }
    public string MessageType { get; set; }
}