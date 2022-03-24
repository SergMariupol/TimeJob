using Microsoft.EntityFrameworkCore;
using TimeJob.Data.Models;

namespace TimeJob.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {
        }
        public DbSet<Project> Project { get; set; }
        public DbSet<TaskJob> Task { get; set; }
        public DbSet<TaskComments> TaskComments { get; set; }
    }
}
