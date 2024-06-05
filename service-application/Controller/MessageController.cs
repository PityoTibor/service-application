using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
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
        public MessageController(IMessageLogic messageLogic)
        {
            this.messageLogic = messageLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageEntityDto message)
        {
            try
            {
                var result = await messageLogic.CreateAsync(message);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOneMessage(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();

                if (id == Guid.Empty)
                {

                    MessageResponseDto response;
                    var result = await messageLogic.GetAllAsync();

                    object[] tm = new object[result.Count()];
                    int i = 0;
                    foreach (var item in result)
                    {
                        response = new MessageResponseDto
                        {
                            Message_id = item.Message_id,
                            Content = item.Content,
                            Created_date = item.Created_date,
                            Handyman = item.Handyman,
                            Handyman_id = item.Handyman_id,
                            Costumer = item.Costumer,
                            Costumer_id = item.Costumer_id,
                            Ticket = item.Ticket,
                            Ticket_id = item.Ticket_id,
                        };
                        tm[i++] = response;
                    }

                    parameters.GetResponseWithHeaders(Response, result.Count());
                    return Ok(tm);
                }
                else
                {
                    var result = await messageLogic.GetOneAsync(id);
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
        public async Task<IActionResult> DeleteMessage([FromRoute] Guid Id)
        {
            try
            {
                var result = await messageLogic.DeleteAsync(Id);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMessage(Guid id, CreateMessageEntityDto? messageEntityDto)
        {
            try
            {
                await messageLogic.UpdateAsync(id, messageEntityDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
