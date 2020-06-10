using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace test.Database
{
    public partial class OnlineQueueDbContext : IdentityDbContext<UserDbModel>
    {
        public OnlineQueueDbContext(DbContextOptions<OnlineQueueDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<QueueDbModel> Queues { get; set; }
        public virtual DbSet<UserQueueDbModel> UserQueue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<QueueDbModel>(entity =>
            {
                entity.HasIndex(e => e.TeacherId);

                entity.HasIndex(e => e.AuthorId);
                
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.QueuesAsTeacher)
                    .HasForeignKey(d => d.TeacherId);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.QueuesAsAuthor)
                    .HasForeignKey(d => d.AuthorId);
            });

            modelBuilder.Entity<UserQueueDbModel>(entity =>
            {
                entity.HasIndex(e => e.QueueDbModelId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.QueueDbModel)
                    .WithMany(p => p.UsersQueues)
                    .HasForeignKey(d => d.QueueDbModelId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersQueues)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
