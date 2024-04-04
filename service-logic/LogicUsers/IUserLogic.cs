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
        Task<User> CreateAsync(User user);
        Task<User> GetOneAsync(Guid Id);
        Task<IQueryable<User>> GetAllAsync();
        Task<User> UpdateAsync(Guid Id, User user);
        Task<bool> DeleteAsync(Guid Id);
    }
}
