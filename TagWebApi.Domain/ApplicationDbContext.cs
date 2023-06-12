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
        public DbSet<Dispute> Disputes { get; set; }
    }
}
