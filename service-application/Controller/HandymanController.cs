using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_logic;
using service_logic.LogicAdmin;
using service_logic.LogicHandyman;
using service_logic.LogicUsers;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandymanController : ControllerBase
    {
        private readonly IHandymanLogic handymanLogic;
        private readonly PasswordService passwordService;

        public HandymanController(IHandymanLogic handymanLogic)
        {
            this.handymanLogic = handymanLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHandyman([FromBody] CreateHandymanEntityDto handyman)
        {
            try
            {
                handyman.Password = passwordService.HashPassword(handyman.Password);
                var result = await handymanLogic.CreateAsync(handyman);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOneHandyman(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();

                if (id == Guid.Empty)
                {

                    HandymanResponseDto response;
                    var result = await handymanLogic.GetAllAsync();

                    object[] tm = new object[result.Count()];
                    int i = 0;
                    foreach (var item in result)
                    {
                        response = new HandymanResponseDto
                        {
                            Handyman_id = item.Handyman_id,
                            User_id = item.User_id,
                            User = item.User
                        };
                        tm[i++] = response;
                    }

                    parameters.GetResponseWithHeaders(Response, result.Count());
                    return Ok(tm);
                }
                else
                {
                    var result = await handymanLogic.GetOneAsync(id);
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
        public async Task<IActionResult> DeleteHandyman([FromRoute] Guid Id)
        {
            try
            {
                var result = await handymanLogic.DeleteAsync(Id);
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(Guid id, CreateHandymanEntityDto adminEntityDto)
        {
            try
            {
                await handymanLogic.UpdateAsync(id, adminEntityDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
