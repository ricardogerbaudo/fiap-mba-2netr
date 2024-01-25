namespace EFCore0000;

public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<User> Users { get; set; } = [];
}
