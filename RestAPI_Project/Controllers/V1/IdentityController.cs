
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Project.Contract;
using RestAPI_Project.Contract.V1.Requests;
using RestAPI_Project.Contract.V1.Responses;

namespace RestAPI_Project.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Sucess)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSucessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}