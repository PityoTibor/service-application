﻿using asp.net_core_6_jwt_authentication.Models;
using Microsoft.AspNetCore.Http;
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
        public AuthController(IAuthService authService, IUserLogic userLogic)
        {
            this.authService = authService;
            this.userLogic = userLogic;
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

            bool isUsernamePasswordValid = false;

            if (login != null)
            {
                // make await call to the Database to check username and password. here we only checking if password value is admin
                isUsernamePasswordValid = loginrequest.Password == "admin" ? true : false;
            }
            // if credentials are valid
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
    }
}
