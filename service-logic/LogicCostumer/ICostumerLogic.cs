using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicCostumer
{
    public interface ICostumerLogic
    {
        Task<Costumer> CreateAsync(CreateCostumerEntityDto createCostumerEntityDto);
        Task<Costumer> GetOneAsync(Guid Id);
        Task<IQueryable<Costumer>> GetAllAsync();
        Task<Costumer> UpdateAsync(Guid Id, CreateCostumerEntityDto createCostumerEntityDto);
        Task<bool> DeleteAsync(Guid Id);
    }
}
