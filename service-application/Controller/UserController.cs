using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
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

        [HttpGet]
        public async Task<IActionResult> GetOneUser(Guid id)
        {
            try
            {

                if (id == Guid.Empty)
                {
                    var result = await userLogic.GetAllAsync();
                    return Ok(result);
                }
                else
                {
                    var result = await userLogic.GetOneAsync(id);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            try
            {
                var result = await userLogic.DeleteAsync(Id);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                await userLogic.UpdateAsync(user.User_id, user);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
