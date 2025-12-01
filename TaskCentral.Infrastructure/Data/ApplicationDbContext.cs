
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
        }
    }
}
