using EFCore0000;

var context = new MyDbContext();

var user = new User()
{
    Name = "Ricardo",
    Password = "123"
};

var group = new Group()
{
    Name = "Administradores"
};

context.Users.Add(user);
context.Groups.Add(group);

user.Group = group;

group.Users.Add(new User() { Name = "Maria", Password = "123" });

context.SaveChanges();

Console.WriteLine("USERS");
foreach (var u in context.Users)
{
    Console.WriteLine("ID: {0} - Name: {1} - Group: {2} ", u.Id, u.Name, u.Group.Name);
}

Console.WriteLine("GROUPS");
foreach (var g in context.Groups)
{
    Console.WriteLine("ID: {0} - Name: {1}", g.Id, g.Name);
}