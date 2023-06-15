using Microsoft.EntityFrameworkCore;

namespace TagWebApi.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserCommunicationChannel> UserCommunicationChannels { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }

        public DbSet<TaskActivity> TaskActivities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<MainTask> Tasks { get; set; }
        public DbSet<DisputeRoot> Disputes { get; set; }

        public DbSet<DisputeElement> DisputeElements { get; set; }

        public DbSet<ProjectLabel> ProjectLabels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainTask>()
                .HasMany(mt => mt.TaskActivities)
                .WithOne(ta => ta.Task)
                .HasForeignKey(ta => ta.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskActivity>()
                .HasMany(ta => ta.Assignments)
                .WithOne(ta => ta.TaskActivity)
                .HasForeignKey(ta => ta.TaskActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCommunicationChannels)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProjectAssignments)
                .WithOne(pa => pa.User)
                .HasForeignKey(pa => pa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TaskAssignments)
                .WithOne(ta => ta.User)
                .HasForeignKey(ta => ta.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.DisputeElements)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.DisputeRoots)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasMany(ur => ur.Users)
                .WithOne(u => u.UserRole)
                .HasForeignKey(u => u.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectLabels)
                .WithOne(pl => pl.Project)
                .HasForeignKey(pl => pl.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Assignments)
                .WithOne(pa => pa.Project)
                .HasForeignKey(pa => pa.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
