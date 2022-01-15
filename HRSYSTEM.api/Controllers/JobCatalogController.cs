using HRSYSTEM.application;
using HRSYSTEM.domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRSYSTEM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCatalogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobCatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// This action will create a JobCatalog
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/jobCatalogs")]
        public async Task<ActionResult<ApiResponse<JobCatalogDTO>>> CreateJobCatalog([FromBody] CreateJobCatalogCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            JobCatalogDTO response = await _mediator.Send(model);
            return Ok(new ApiResponse<JobCatalogDTO>(response));
        }
        
        /// <summary>
        /// This action will return all the jobCatalogs paginated
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/jobCatalogs")]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobCatalogDTO>>>> GetAllJobCatalogs([FromQuery] PaginateJobCatalogQueryFilter filters)
        {
            if (!ModelState.IsValid) return BadRequest();
            PagedList<JobCatalogDTO> jobCatalogsDTO = await _mediator.Send(new GetJobCatalogsQuery(filters));
            var metadata = new Metadata
            {
                TotalCount = jobCatalogsDTO.TotalCount,
                PageSize = jobCatalogsDTO.PageSize,
                CurrentPage = jobCatalogsDTO.CurrentPage,
                TotalPages = jobCatalogsDTO.TotalPages,
                HasNextPage = jobCatalogsDTO.HasNextPage,
                HasPreviousPage = jobCatalogsDTO.HasPreviousPage
            };
            var response = new ApiResponse<IEnumerable<JobCatalogDTO>>(jobCatalogsDTO)
            {
                Metadata = metadata
            };
            return Ok(response);
        }


    }
}
