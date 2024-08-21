using asp.net_core_6_jwt_authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using service_application.Services;
using service_logic;
using System.Net;
using System.Security.AccessControl;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserLogic userLogic;
        private readonly IPasswordService passwordService;
        public AuthController(IAuthService authService, IUserLogic userLogic, IPasswordService passwordService)
        {
            this.authService = authService;
            this.userLogic = userLogic;
            this.passwordService = passwordService;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Authenticate([FromBody] LoginRequest login)
        {
            var user = await userLogic.GetOneByEmailAsync(login.UserName);
            var loginResponse = new LoginResponse { };
            LoginRequest loginrequest = new()
            {
                UserName = login.UserName.ToLower(),
                Password = login.Password
            };

            bool isUsernamePasswordValid = passwordService.VerifyPassword(login.Password,user.Password);

            if (login == null)
            {
                throw new Exception();
            }
            
            if (isUsernamePasswordValid)
            {
                string token = authService.CreateToken(loginrequest.UserName);

                loginResponse.Token = token;
                loginResponse.responseMsg = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                //return the token
                return Ok(new { loginResponse });
            }
            else
            {
                // if username/password are not valid send unauthorized status code in response               
                return BadRequest("Username or Password Invalid!");
            }
        }

        [HttpGet("authTest")]
        [Authorize]
        public Task<IActionResult> AuthTest()
        {
            ;
            return null;
        }
    }
}
