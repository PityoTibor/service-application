using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicAdmin
{
    public interface IAdminLogic
    {
        Task<Admin> CreateAsync(CreateAdminEntityDto user);
        Task<Admin> GetOneAsync(Guid Id);
        Task<IQueryable<Admin>> GetAllAsync();
        Task<Admin> UpdateAsync(Guid Id, CreateAdminEntityDto user);
        Task<bool> DeleteAsync(Guid Id);
    }
}
