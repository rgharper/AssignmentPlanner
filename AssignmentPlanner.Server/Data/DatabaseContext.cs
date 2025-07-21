using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AssignmentPlanner.Server.Model;

namespace AssignmentPlanner.Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
