using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Fiap.Mongo000;

public class MongoContext : DbContext
{
    public MongoContext(DbContextOptions options)
        : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToCollection("User");
    }
}
