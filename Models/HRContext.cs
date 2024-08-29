using Microsoft.EntityFrameworkCore;

namespace TreyJewett_TechAssessment.Models
{
    public class HRContext : DbContext
    {

        public HRContext(DbContextOptions<HRContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
