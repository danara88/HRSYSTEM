using HRSYSTEM.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSYSTEM.persistance.Data.Configurations
{

    /// <summary>
    /// Configuration for role entity DB
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x => x.RoleID);
        }
    }
}
