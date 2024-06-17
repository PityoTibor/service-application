using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_logic.LogicCostumer;
using service_logic.LogicHandyman;
using service_logic.LogicMessage;
using service_logic.LogicTicket;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketLogic ticketLogic;

        public TicketController(ITicketLogic ticketLogic)
        {
            this.ticketLogic = ticketLogic;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketEntityDto ticket)
        {
            try
            {
                var result = await ticketLogic.CreateAsync(ticket);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOneTicket(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();

                if (id == Guid.Empty)
                {

                    TicketResponseDto response;
                    var result = await ticketLogic.GetAllAsync();

                    object[] tm = new object[result.Count()];
                    int i = 0;
                    foreach (var item in result)
                    {
                        response = new TicketResponseDto
                        {
                            Ticket_id = item.Ticket_id,
                            Title = item.Title,
                            Description = item.Description,
                            Created_date = DateTime.Now,
                            SeverityEnum = item.SeverityEnum,
                            StatusEnum = item.StatusEnum,
                            Costumer_id = item.Costumer_id,
                            Messages = item.Messages,
                        };
                        tm[i++] = response;
                    }

                    parameters.GetResponseWithHeaders(Response, result.Count());
                    return Ok(tm);
                }
                else
                {
                    var result = await ticketLogic.GetOneAsync(id);
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
        public async Task<IActionResult> DeleteCostumer([FromRoute] Guid Id)
        {
            try
            {
                var result = await ticketLogic.DeleteAsync(Id);
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMessage(Guid id, CreateTicketEntityDto? ticketEntityDto)
        {
            try
            {
                await ticketLogic.UpdateAsync(id, ticketEntityDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
