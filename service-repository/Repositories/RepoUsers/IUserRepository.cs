using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;

namespace service_repository.Repositories.RepoUsers
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(CreateUserEntityDto user);
        Task<User> GetOneAsync(Guid Id);
        Task<IQueryable<User>> GetAllAsync();
        Task<User> UpdateAsync(Guid Id, CreateUserEntityDto user);
        Task<bool> DeleteAsync(Guid Id);
    }
}
