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
    }
}