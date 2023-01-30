using System.ComponentModel.DataAnnotations.Schema;

public class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
}
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    // [ForeignKey(nameof(AppUser))]
    // public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}