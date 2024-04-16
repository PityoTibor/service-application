using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_logic;
using service_repository.Exceptions;
using System.Net.Http.Headers;

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

                int startByte = 0;
                int endByte = 500; // Example end byte
                //int contentLength = content.Length;

                if (id == Guid.Empty)
                {

                    UserResponseDto response;

                    var result = await userLogic.GetAllAsync();
                    response = new UserResponseDto
                    { 
                        Id = result.First().User_id.ToString(),
                        Username = result.First().Username,
                        Email = result.First().Email,
                        Role = result.First().Role.ToString(),
                    };
                    Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
                    Response.Headers.Add("Content-Range", $"User {startByte}-{endByte}/{result.Count()}");

                    object[] tm = new object[1];
                    var a = new
                    {
                        id = 1,
                        username = "tibor",
                        email = "tibor@valami.hu",
                        role = 1,
                    };
                    tm[0] = response;

                    return Ok(tm);
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
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute]Guid Id)
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
