using Microsoft.EntityFrameworkCore;

namespace HRSYSTEM.persistance.Context
{
    /// <summary>
    /// This class is to allow the communication with the DB
    /// </summary>
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
