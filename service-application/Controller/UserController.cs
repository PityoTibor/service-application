using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using service_data.Models.EntityModels;
using service_logic;

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
        public IActionResult CreateUser([FromBody] User user )
        {
            try
            {
                userLogic.CreateAsync(user);
                return Ok("User has been created.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

    }
}
