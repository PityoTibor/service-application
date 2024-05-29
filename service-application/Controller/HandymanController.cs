using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_data.Models.DTOs.RequestDto;
using service_logic.LogicAdmin;
using service_logic.LogicHandyman;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandymanController : ControllerBase
    {
        private readonly IHandymanLogic handymanLogic;
        public HandymanController(IHandymanLogic handymanLogic)
        {
            this.handymanLogic = handymanLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHandyman([FromBody] CreateHandymanEntityDto handyman)
        {
            try
            {
                var result = await handymanLogic.CreateAsync(handyman);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
