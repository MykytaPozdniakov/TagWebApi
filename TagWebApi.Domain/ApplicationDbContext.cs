using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasForeignKey(ta => ta.TaskId);

            modelBuilder.Entity<TaskActivity>()
                .HasMany(ta => ta.Assignments)
                .WithOne(ta => ta.TaskActivity)
                .HasForeignKey(ta => ta.TaskActivityId);

            modelBuilder.Entity<TaskActivity>()
                .HasOne(ta => ta.Task)
                .WithMany(mt => mt.TaskActivities)
                .HasForeignKey(ta => ta.TaskId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCommunicationChannels)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProjectAssignments)
                .WithOne(pa => pa.User)
                .HasForeignKey(pa => pa.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TaskAssignments)
                .WithOne(ta => ta.User)
                .HasForeignKey(ta => ta.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Disputes)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<UserCommunicationChannel>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCommunicationChannels)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserRole>()
                .HasMany(ur => ur.Users)
                .WithOne(u => u.UserRole)
                .HasForeignKey(u => u.UserRoleId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectLabels)
                .WithOne(pl => pl.Project)
                .HasForeignKey(pl => pl.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Assignments)
                .WithOne(pa => pa.Project)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<ProjectLabel>()
                .HasOne(pl => pl.Project)
                .WithMany(p => p.ProjectLabels)
                .HasForeignKey(pl => pl.ProjectId);

            modelBuilder.Entity<DisputeRoot>()
                .HasMany(d => d.DisputeElements)
                .WithOne(e => e.Parent)
                .HasForeignKey(e => e.RootId);

            modelBuilder.Entity<DisputeRoot>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<DisputeRoot>()
                .HasOne(d => d.Activity)
                .WithMany()
                .HasForeignKey(d => d.ActivityId);

            modelBuilder.Entity<DisputeElement>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
        }
    }
}
