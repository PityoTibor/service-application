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
        Task<IQueryable> GetOneAsync(Guid Id);
        Task<IQueryable> GetAllAsync();
        Task<User> UpdateAsync(Guid Id);
        Task<User> DeleteAsync(Guid Id);
    }
}
