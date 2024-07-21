using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.Mappers;
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
        public TicketMapper TicketMapper = new();

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            try
            {
                var result = await ticketLogic.GetOneAsync(id);
                TicketResponseDto response = TicketMapper.ToDto(result);
                return Ok(response);
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
                var result = await ticketLogic.GetAllAsync();
                TicketResponseDto response;
                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = TicketMapper.ToDto(item);
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
