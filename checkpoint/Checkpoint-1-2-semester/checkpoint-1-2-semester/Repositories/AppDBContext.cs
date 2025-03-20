using checkpoint_1_2_semester.Models;
using Microsoft.EntityFrameworkCore;

namespace checkpoint_1_2_semester.Repositories
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toy>().ToTable("TB_TOYS");
        }
    }
}
