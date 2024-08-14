using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic
{
    public interface IUserLogic
    {
        Task<User> CreateAsync(CreateUserEntityDto user);
        Task<User> GetOneAsync(Guid Id);
        Task<IQueryable<User>> GetAllAsync();
        Task<User> GetOneByEmailAsync(string email);
        Task<User> UpdateAsync(Guid Id, CreateUserEntityDto user);
        Task<bool> DeleteAsync(Guid Id);
    }
}
