using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace test.Database
{
    public class ApplicationContext : IdentityDbContext<UserDbModel>
    {
        public DbSet<QueueDbModel> Queues { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=123");
        }
        public QueueDbModel FindQueueById(int Id)
        {
            foreach (var i in Queues)
            {
                if (i.Id == Id) return i;
            }
            return null;
        }
    }
}