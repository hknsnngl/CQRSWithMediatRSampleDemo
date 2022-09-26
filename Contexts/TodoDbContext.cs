using CQRSWithMediatRSampleDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Contexts;

public class TodoDbContext : DbContext, ITodoDbContext
{
    public const string DEFAULT_SCHEMA = "hkn";


    public TodoDbContext()
    {
    }

    public TodoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoListDb;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    public DbSet<TodoList> TodoLists { get; set; }

    public async Task<int> SaveChangeAsync()
    {
        return await base.SaveChangesAsync();
    }
}