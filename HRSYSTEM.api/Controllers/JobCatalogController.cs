using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HRSYSTEM.application;

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

     
    }
}
