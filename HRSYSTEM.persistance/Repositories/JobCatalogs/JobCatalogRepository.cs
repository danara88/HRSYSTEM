using HRSYSTEM.domain;
using HRSYSTEM.persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace HRSYSTEM.persistance
{
    /// <summary>
    /// Job Catalog Repository
    /// </summary>
    public class JobCatalogRepository : IJobCatalogRepository
    {
        private readonly ApplicationDbContext _context;
        public JobCatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateJobCatalog(JobCatalogEntity jobCatalog)
        {
            jobCatalog.CreatedOn = DateTime.Now;
            _context.Add(jobCatalog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobCatalogEntity>> GetJobCatalogs()
        {
            var jobCatalogs = await _context.JobCatalogs.ToListAsync();
            return jobCatalogs;
        }
    }
}
