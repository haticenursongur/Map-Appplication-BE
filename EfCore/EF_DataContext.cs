using Microsoft.EntityFrameworkCore;

namespace MapApi1.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
        
        public DbSet<Point> Points { get; set; }
    }
}

