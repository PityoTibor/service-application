using Microsoft.AspNetCore.Mvc;
using service_application.Controller.Helper;
using service_application.Services;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using service_logic.LogicCostumer;
using service_logic.LogicHandyman;

namespace service_application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerLogic costumerLogic;
        private readonly PasswordService passwordService;
        public CostumerController(ICostumerLogic costumerLogic)
        {
            this.costumerLogic = costumerLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCostumer([FromBody] CreateCostumerEntityDto costumer)
        {
            try
            {
                costumer.Password = passwordService.HashPassword(costumer.Password);
                var result = await costumerLogic.CreateAsync(costumer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOneHandyman(Guid id)
        {
            try
            {
                HeaderParameters parameters = new HeaderParameters();

                if (id == Guid.Empty)
                {
                    CostumerResponseDto response;
                    var result = await costumerLogic.GetAllAsync();

                    object[] tm = new object[result.Count()];
                    int i = 0;
                    foreach (var item in result)
                    {
                        response = new CostumerResponseDto
                        {
                            Costumer_id = item.Costumer_id,
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
                    var result = await costumerLogic.GetOneAsync(id);
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
                var result = await costumerLogic.DeleteAsync(Id);
                //return StatusCode(200, "asdasd");
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(Guid id, CreateCostumerEntityDto costumerEntityDto)
        {
            try
            {
                await costumerLogic.UpdateAsync(id, costumerEntityDto);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
