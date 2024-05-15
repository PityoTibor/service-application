using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_data.Models.DTOs.RequestDto;
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
    }
}
