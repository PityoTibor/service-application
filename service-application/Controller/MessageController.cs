using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.Mappers;
using service_logic.LogicAdmin;
using service_logic.LogicHandyman;
using service_logic.LogicMessage;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageLogic messageLogic;
        private readonly IMessageMapper messageMapper;
        public MessageController(IMessageLogic messageLogic, IMessageMapper messageMapper)
        {
            this.messageLogic = messageLogic;
            this.messageMapper = messageMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageEntityDto message)
        {
            try
            {
                var result = await messageLogic.CreateAsync(message);
                return Ok(messageMapper.ToDto(result));
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
                HeaderParameters parameters = new HeaderParameters();

                if (id != Guid.Empty)
                {
                    MessageResponseDto response;
                    var result = await messageLogic.GetOneAsync(id);
                    MessageMapper messageMapper = new MessageMapper();
                    response = messageMapper.ToDto(result);

                    //parameters.GetResponseWithHeaders(Response, result.Count());
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();
                MessageResponseDto response;
                var result = await messageLogic.GetAllAsync();

                MessageMapper messageMapper = new MessageMapper();
                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = messageMapper.ToDto(item);
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
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            try
            {
                var result = await messageLogic.DeleteAsync(Id);
                var allMessage = await GetAll();
                return Ok(allMessage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateMessageEntityDto? messageEntityDto)
        {
            try
            {
                var result = await messageLogic.UpdateAsync(id, messageEntityDto);
                var messageDto = messageMapper.ToDto(result);
                return Ok(messageDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
