using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_data.Models.Mappers;
using service_logic;
using service_logic.LogicTicket;
using service_repository.Exceptions;
using System.Net.Http.Headers;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic userLogic;
        private readonly PasswordService passwordService;
        public UserController(IUserLogic userLogic, PasswordService passwordService)
        {
             this.userLogic = userLogic;
            this.passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserEntityDto user )
        {
            try
            {
                user.Password = passwordService.HashPassword(user.Password);
                var result = await userLogic.CreateAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            try
            {
                UserResponseDto response;
                var result = await userLogic.GetOneAsync(id);
                UserMapper mapper = new();
                UserResponseDto userResponse = mapper.ToDto(result);
                response = new UserResponseDto
                {
                    Id = result.User_id.ToString(),
                    Username = result.Username,
                    Email = result.Email,
                    Role = result.Role.ToString(),
                };
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet()]
        [Route("/GetUserTypes")]
        public async Task<IActionResult> GetUserTypes()
        {
            try
            {
                var obj = new { name = "handyman" };
                var obj2 = new {  name = "admin" };
                var obj3 = new {  name = "costumer" };

                var array = new object[] { obj, obj2, obj3 };

                return Ok(array);
            }

                
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();
                UserResponseDto response;

                var result = await userLogic.GetAllAsync();

                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = new UserResponseDto
                    {
                        Id = item.User_id.ToString(),
                        Username = item.Username,
                        Email = item.Email,
                        Role = item.Role.ToString(),
                    };
                    tm[i++] = response;
                }

                parameters.GetResponseWithHeaders(Response, result.Count());
                return Ok(tm);
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
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(Guid id, CreateUserEntityDto user)
        {
            try
            {
                await userLogic.UpdateAsync(id, user);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
