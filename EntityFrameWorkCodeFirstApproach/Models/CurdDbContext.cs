using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCodeFirstApproach.Models
{
    public class CurdDbContext:DbContext
    {
        public CurdDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductFreshness> ProductFreshnesses { get; set; }
    }
}
