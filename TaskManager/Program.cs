using Microsoft.EntityFrameworkCore;
using TaskManager.DbContexts;
using TaskManager.Extensions;
using TaskManager.DbUtils;

var builder = WebApplication.CreateBuilder(args);

// register the DbContext on the container, getting the
// connection string from appSettings   
builder.Services.AddDbContext<TaskManagerDbContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:TaskManagerDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterTaskEndpoints();
app.RegisterUsersEndpoints();

//Automatically apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<TaskManagerDbContext>();
    await AutoMigrateDatabase.MigrateDatabase(dbContext);
}

app.Run();