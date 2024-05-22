using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
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
        public AdminController(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AdminEntityDto admin)
        {
            try
            {
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

        [HttpGet]
        public async Task<IActionResult> GetOneAdmin(Guid id)
        {
            try
            {

                int startByte = 0;
                int endByte = 500; // Example end byte
                //int contentLength = content.Length;

                if (id != Guid.Empty)
                {

                    UserResponseDto response;

                    var result = await adminLogic.GetAllAsync();
                    foreach (var item in result)
                    {
                        await Console.Out.WriteLineAsync(item.Admin_id.ToString() + "  "  + item.User_id.ToString() );
                    }
  

                    object[] tm = new object[1];
                    var a = new
                    {
                        id = 1,
                        username = "tibor",
                        email = "tibor@valami.hu",
                        role = 1,
                    };
                    //tm[0] = response;

                    return Ok(tm);
                }
                else
                {
                    //var result = await userLogic.GetOneAsync(id);
                    return Ok();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
