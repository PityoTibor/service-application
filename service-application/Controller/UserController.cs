using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using service_data.Models.EntityModels;
using service_logic;
using service_repository.Exceptions;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic userLogic;
        public UserController(IUserLogic userLogic)
        {
             this.userLogic = userLogic;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user )
        {
            try
            {
                var result = await userLogic.CreateAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
