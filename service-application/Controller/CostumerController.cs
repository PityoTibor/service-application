using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_logic.LogicCostumer;
using service_logic.LogicHandyman;
using service_data.Models.Mappers;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerLogic costumerLogic;
        private readonly IPasswordService passwordService;
        private readonly ICostumerMapper costumerMapper;
        public CostumerController(ICostumerLogic costumerLogic, IPasswordService passwordService, ICostumerMapper costumerMapper)
        {
            this.costumerLogic = costumerLogic;
            this.passwordService = passwordService;
            this.costumerMapper = costumerMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCostumerEntityDto costumer)
        {
            try
            {
                costumer.Password = passwordService.HashPassword(costumer.Password);
                var result = await costumerLogic.CreateAsync(costumer);
                return Ok(costumerMapper.ToDto(result));
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
                    var result = await costumerLogic.GetOneAsync(id);
                    CostumerMapper mapper = new();
                    CostumerResponseDto response = mapper.ToDto(result);


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
                CostumerResponseDto response;
                var result = await costumerLogic.GetAllAsync();

                CostumerMapper costumerMapper = new();
                object[] tm = new object[result.Count()];
                int i = 0;
                foreach (var item in result)
                {
                    response = costumerMapper.ToDto(item);
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
                var result = await costumerLogic.DeleteAsync(Id);
                var allCostumer = await GetAll();
                return Ok(allCostumer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateCostumerEntityDto costumerEntityDto)
        {
            try
            {
                var result = await costumerLogic.UpdateAsync(id, costumerEntityDto);
                var costumerDto = costumerMapper.ToDto(result);
                return Ok(costumerDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
