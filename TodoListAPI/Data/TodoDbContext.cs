using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
        { 
        }

        public TodoDbContext()
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }
    }
}
