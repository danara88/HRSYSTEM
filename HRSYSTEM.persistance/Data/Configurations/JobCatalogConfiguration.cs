using HRSYSTEM.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRSYSTEM.persistance.Data.Configurations
{
    /// <summary>
    /// Configuration for job catalog DB
    /// </summary>
    public class JobCatalogConfiguration : IEntityTypeConfiguration<JobCatalogEntity>
    {
        public void Configure(EntityTypeBuilder<JobCatalogEntity> builder)
        {
            builder.HasKey(x => x.JobCatalogID);
        }
    }
}
