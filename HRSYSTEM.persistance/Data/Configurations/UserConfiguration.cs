using HRSYSTEM.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSYSTEM.persistance.Data.Configurations
{

    /// <summary>
    /// Configuration for user entity DB
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.UserID);
        }
    }
}
