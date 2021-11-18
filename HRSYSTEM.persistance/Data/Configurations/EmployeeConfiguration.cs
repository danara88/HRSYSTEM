using HRSYSTEM.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSYSTEM.persistance.Data.Configurations
{
    /// <summary>
    /// Configuration for employee entity DB
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(x => x.EmployeeID);
        }
    }
}
