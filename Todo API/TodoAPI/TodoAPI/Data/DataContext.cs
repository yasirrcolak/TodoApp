using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Todo> Todos { get;set; } 
        public DbSet<Category> Categories { get;set; }

    }
}
