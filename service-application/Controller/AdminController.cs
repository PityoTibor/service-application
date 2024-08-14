using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_data.Models.Mappers;
using service_logic;
using service_logic.LogicAdmin;
using service_logic.LogicUsers;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogic adminLogic;
        private readonly IPasswordService passwordService;
        private readonly IAdminMapper adminMapper;
        public AdminController(IAdminLogic adminLogic, IPasswordService passwordService, IAdminMapper adminMapper)
        {
            this.adminLogic = adminLogic;
            this.adminMapper = adminMapper;
            this.passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminEntityDto admin)
        {
            try
            {
                admin.Password = passwordService.HashPassword(admin.Password);
                var result = await adminLogic.CreateAsync(admin);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid Id)
        {
            try
            {
                var result = await adminLogic.DeleteAsync(Id);
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAdmin(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();
                if (id != Guid.Empty)
                {
                    AdminResponseDto response;

                    var result = await adminLogic.GetOneAsync(id);
                    /*foreach (var item in result)
                    {
                        await Console.Out.WriteLineAsync(item.ToString());
                    }
                    */
                    response = new AdminResponseDto
                    {
                        Id = result.Admin_id,
                        //kellene majd wrapper
                        //UserModelDto = item.User;
                    };

                    return Ok(response);
                }
                return BadRequest(500);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmin()
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();
                AdminResponseDto response;

                var result = await adminLogic.GetAllAsync();
                /*foreach (var item in result)
                {
                    await Console.Out.WriteLineAsync(item.ToString());
                }
                */
                object[] tm = new object[result.Count()];
                int i = 0;  
                foreach (var item in result)
                {
                    response = new AdminResponseDto
                    {
                        Id = item.Admin_id,
                        //kellene majd wrapper
                        //UserModelDto = item.User;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(Guid id, CreateAdminEntityDto adminEntityDto)
        {
            try
            {
                var result = await adminLogic.UpdateAsync(id, adminEntityDto);
                var adminDto = adminMapper.ToDto(result);
                return Ok(adminDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
