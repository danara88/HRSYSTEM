using HRSYSTEM.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSYSTEM.persistance
{
    /// <summary>
    /// DI JobCatalog Repository
    /// </summary>
    public interface IJobCatalogRepository
    {
        Task CreateJobCatalog(JobCatalogEntity jobCatalog);
        Task<IEnumerable<JobCatalogEntity>> GetJobCatalogs();

    }
}
