using Fiap.Mongo000;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MongoContext>(options =>
{
    var connectionString = builder.Configuration["MongoDbSettings:ConnectionString"];
    var databaseName = builder.Configuration["MongoDbSettings:DatabaseName"];

    if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
    {
        throw new InvalidOperationException(
            "MongoDbSettings não foi definido no arquivo de configurações ou user secrets."
        );
    }

    options.UseMongoDB(connectionString, databaseName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost(
    "/users",
    (MongoContext context, User user) =>
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
);

app.MapGet(
    "/users",
    (MongoContext context) =>
    {
        return context.Users.ToList();
    }
);

app.Run();
