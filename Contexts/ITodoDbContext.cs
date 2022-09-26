using CQRSWithMediatRSampleDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Contexts;

public interface ITodoDbContext
{
    DbSet<TodoList> TodoLists { get; set; }

    Task<int> SaveChangeAsync();
}