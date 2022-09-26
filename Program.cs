using System.Reflection;
using CQRSWithMediatRSampleDemo.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var assembly = Assembly.GetExecutingAssembly();


services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<TodoDbContext>(options =>  
{
    options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"), 
        b => b.MigrationsAssembly(typeof(TodoDbContext).Assembly.FullName));
});
services.AddScoped<ITodoDbContext>(provider => provider.GetService<TodoDbContext>());
services.AddMediatR(assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
