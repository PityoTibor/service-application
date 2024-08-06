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
using service_logic.LogicHandyman;
using service_logic.LogicUsers;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandymanController : ControllerBase
    {
        private readonly IHandymanLogic handymanLogic;
        private readonly IPasswordService passwordService;
        private readonly IHandymanMapper handymanMapper;

        public HandymanController(IHandymanLogic handymanLogic, IPasswordService passwordService, IHandymanMapper handymanMapper)
        {
            this.handymanLogic = handymanLogic;
            this.passwordService = passwordService;
            this.handymanMapper = handymanMapper;   
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneHandyman(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();

                if (id != Guid.Empty)
                {
                    HandymanMapper handymanMapper = new HandymanMapper();
                    var result = await handymanLogic.GetOneAsync(id);
                    HandymanResponseDto response = handymanMapper.ToDto(result);
                    
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHandyman()
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();
                HandymanResponseDto response;
                var result = await handymanLogic.GetAllAsync();

                HandymanMapper handymanMapper = new HandymanMapper();   
                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = handymanMapper.ToDto(item);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHandyman(Guid id, CreateHandymanEntityDto adminEntityDto)
        {
            try
            {
                var result = await handymanLogic.UpdateAsync(id, adminEntityDto);
                var handymanDto = handymanMapper.ToDto(result);
                return Ok(handymanDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
