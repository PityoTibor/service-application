using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.EntityModels;

namespace service_repository.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetOneAsync(Guid Id);
        Task<IQueryable<User>> GetAllAsync();
        Task<User> UpdateAsync(Guid Id, User user);
        Task<bool> DeleteAsync(Guid Id);
    }
}
