using HRSYSTEM.application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSYSTEM.api.Controllers
{
    /// <summary>
    /// This is the auth controller to manage auth actions
    /// </summary>
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AuthController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }
        
        /// <summary>
        /// This action will log in the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/auth/login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginUserCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            AuthResponseDTO response = await _mediator.Send(model);
            return response;
        }
    }
}
