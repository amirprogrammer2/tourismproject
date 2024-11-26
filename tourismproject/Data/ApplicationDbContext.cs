using Microsoft.EntityFrameworkCore;
using tourismproject.Entity;

namespace tourismproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } 
    }
}
