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

                    HandymanResponseDto response;
                    var result = await ticketLogic.GetAllAsync();

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
    }
}
