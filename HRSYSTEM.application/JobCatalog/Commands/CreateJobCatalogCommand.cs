using MediatR;

namespace HRSYSTEM.application
{
    public class CreateJobCatalogCommand : IRequest<JobCatalogDTO>
    {
        public string JobTitle { get; set; }
        public string JobFunction { get; set; }
        public string JobSubFunction { get; set; }
    }
}
