using Microsoft.EntityFrameworkCore;

namespace TestApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }
    }
}