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
        private readonly ITicketMapper ticketMapper;

        public TicketController(ITicketLogic ticketLogic, ITicketMapper ticketMapper)
        {
            this.ticketLogic = ticketLogic;
            this.ticketMapper = ticketMapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketEntityDto ticket)
        {
            try
            {
                var result = await ticketLogic.CreateAsync(ticket);
                return Ok(ticketMapper.ToDto(result));
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
                var response = ticketMapper.ToDto(result);
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
                    response = ticketMapper.ToDto(item);
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
                var result = await ticketLogic.DeleteAsync(Id);
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateTicketEntityDto? ticketEntityDto)
        {
            try
            {
                var result = await ticketLogic.UpdateAsync(id, ticketEntityDto);
                var ticketDto = ticketMapper.ToDto(result);
                return Ok(ticketDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
