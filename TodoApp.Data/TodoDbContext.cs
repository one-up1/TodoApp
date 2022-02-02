using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
