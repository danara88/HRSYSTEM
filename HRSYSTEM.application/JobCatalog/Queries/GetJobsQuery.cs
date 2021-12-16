using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HRSYSTEM.application
{
    public class GetJobsQuery : IRequest<List<JobCatalogDTO>>
    {
    }
}
