using AutoMapper;
using HRSYSTEM.domain;
using HRSYSTEM.persistance;
using MediatR;
using Microsoft.Extensions.Options;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Handler to get all job catalogs
    /// </summary>
    public class GetJobCatalogsHandler : IRequestHandler<GetJobCatalogsQuery, PagedList<JobCatalogDTO>>
    {
        private readonly IJobCatalogRepository _jobCatalogRepository;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        public GetJobCatalogsHandler(IJobCatalogRepository jobCatalogRepository, IMapper mapper, IOptions<PaginationOptions> options)
        {
            _jobCatalogRepository = jobCatalogRepository;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }
        public async Task<PagedList<JobCatalogDTO>> Handle(GetJobCatalogsQuery request, CancellationToken cancellationToken)
        {
            request.Filters.PageNumber = request.Filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.Filters.PageNumber;
            request.Filters.PageSize = request.Filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.Filters.PageSize;

            var jobCatalogs = await _jobCatalogRepository.GetJobCatalogs();

            if (request.Filters.JobTitle != null)
            {
                jobCatalogs = jobCatalogs.Where(x => x.JobTitle.ToLower().Contains(request.Filters.JobTitle.ToLower()));
            }

            var jobCatalogsDTO = _mapper.Map<IEnumerable<JobCatalogDTO>>(jobCatalogs);

            PagedList<JobCatalogDTO> pagedJobCatalogs = PagedList<JobCatalogDTO>
                                            .Create(jobCatalogsDTO, request.Filters.PageNumber, request.Filters.PageSize);

            return pagedJobCatalogs;
        }
    }
}
