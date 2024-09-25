using AuthV4.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuthV4.Data
{
    public class BuzzDbContextXl:DbContext
    {
        public BuzzDbContextXl(DbContextOptions<BuzzDbContextXl> options): base (options)
        {
            
        }

        public DbSet <Vendor> Vendors { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vendor>().HasKey(x => x.Id).IsClustered(false);
            modelBuilder.Entity<Item>().HasKey(x => x.Id).IsClustered(false);
        }
    }
}
