using Microsoft.EntityFrameworkCore;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Data.Configurations;

namespace HRSYSTEM.persistance.Context
{
    /// <summary>
    /// This class enables DB configuration
    /// </summary>
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

    }
}
