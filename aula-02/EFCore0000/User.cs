namespace EFCore0000;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }

    public int? GroupId { get; set; }
    public Group? Group { get; set; }
}
