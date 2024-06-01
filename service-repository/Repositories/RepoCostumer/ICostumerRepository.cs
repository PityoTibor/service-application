using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoCostumer
{
    public interface ICostumerRepository
    {
        Task<Costumer> CreateAsync(CreateCostumerEntityDto user);
        Task<Costumer> GetOneAsync(Guid Id);
        Task<IQueryable<Costumer>> GetAllAsync();
        Task<Costumer> UpdateAsync(Guid Id, CreateCostumerEntityDto handyman);
        Task<bool> DeleteAsync(Guid Id);
    }
}
