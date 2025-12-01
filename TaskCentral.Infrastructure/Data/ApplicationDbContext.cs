
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskCentral.Domain.Entities;
using TaskCentral.Domain.Role;
using TaskCentral.Domain.User;

namespace TaskCentral.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project> Project { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskAssignment>()
                .HasKey(ta => new { ta.TaskId, ta.AppUserId });

            builder.Entity<TaskAssignment>()
                .HasOne(ta => ta.Tasks)
                .WithMany(t => t.TaskAssignments)
                .HasForeignKey(ta => ta.TaskId);

            builder.Entity<TaskAssignment>()
                .HasOne(ta => ta.AppUser)
                .WithMany()
                .HasForeignKey(ta => ta.AppUserId);
        }
    }
}
