using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_data.Models.Mappers;
using service_logic.LogicHandyman;
using service_logic.LogicInterval;
using service_logic.LogicMessage;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervalController : ControllerBase
    {
        private readonly IIntervalLogic IntervalLogic;
        public IntervalController(IIntervalLogic IntervalLogic)
        {
            this.IntervalLogic = IntervalLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIntervalEntityDto data)
        {
            try
            {
                var result = await IntervalLogic.CreateAsync(data);
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
                HeaderParameters parameters = new HeaderParameters();

                if (id != Guid.Empty)
                {
                    var result = await IntervalLogic.GetOneAsync(id);
                    return Ok(result);
                }
                return BadRequest();
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
                var result = await IntervalLogic.GetAllAsync();
                return Ok(result);
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
                var result = await IntervalLogic.DeleteAsync(Id);
                var allMessage = await GetAll();
                return Ok(allMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
