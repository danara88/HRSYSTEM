using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRSYSTEM.domain;
using HRSYSTEM.persistance;
using MediatR;

namespace HRSYSTEM.application
{
    /// <summary>
    /// This handler will create a new job catalog
    /// </summary>
    public class CreateJobCatalogHandler : IRequestHandler<CreateJobCatalogCommand, JobCatalogDTO>
    {
        private readonly IJobCatalogRepository _jobCatalogRepository;
        private readonly IMapper _mapper;
        public CreateJobCatalogHandler(IMapper mapper, IJobCatalogRepository jobCatalogRepository)
        {
            _mapper = mapper;
            _jobCatalogRepository = jobCatalogRepository;
        }
        public async Task<JobCatalogDTO> Handle(CreateJobCatalogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JobCatalogDTO jobCatalogDTO = new JobCatalogDTO
                {
                    JobFunction = request.JobFunction,
                    JobSubFunction = request.JobSubFunction,
                    JobTitle = request.JobTitle
                };

                JobCatalogEntity jobCatalog = _mapper.Map<JobCatalogEntity>(jobCatalogDTO);
                await _jobCatalogRepository.CreateJobCatalog(jobCatalog);

                return _mapper.Map<JobCatalogDTO>(jobCatalog);
            }
            catch (System.Exception)
            {
                throw new BusinessException("The job catalog was not created.");
            }
        }
    }
}
