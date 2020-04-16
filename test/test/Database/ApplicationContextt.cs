using Microsoft.EntityFrameworkCore;

namespace test.Database
{
    public class ApplicationContextt : DbContext
    {
        public DbSet<QueueDbModel> Queues { get; set; }

        public ApplicationContextt()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=queuedb;Username=postgres;Password=123");
        }
    }
}