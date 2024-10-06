using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_data.Models.Mappers;
using service_logic.LogicSkill;
using service_logic.LogicTicket;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillLogic skillLogic;
        private readonly ISkillMapper skillMapper;
        public SkillController(ISkillLogic skillLogic)
        {
            this.skillLogic = skillLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillEntityDto ticket)
        {
            try
            {
                var result = await skillLogic.CreateAsync(ticket);
                return Ok(skillMapper.ToDto(result));
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
                var result = await skillLogic.GetOneAsync(id);
                var response = skillMapper.ToDto(result);
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
                var result = await skillLogic.GetAllAsync();
                SkillResponseDto response;
                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = skillMapper.ToDto(item);
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
                var result = await skillLogic.DeleteAsync(Id);
                var allTicket = await GetAll();
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateSkillEntityDto skillEntityDto)
        {
            try
            {
                var result = await skillLogic.UpdateAsync(id, skillEntityDto);
                var ticketDto = skillMapper.ToDto(result);
                return Ok(ticketDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
