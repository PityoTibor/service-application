using service_data.Models.DTOs;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoAdmin
{
    public interface IAdminRepository
    {
        Task<Admin> CreateAsync(CreateAdminEntityDto admin);
        Task<Admin> GetOneAsync(Guid Id);
        Task<IQueryable<Admin>> GetAllAsync();
        Task<Admin> UpdateAsync(Guid Id, CreateAdminEntityDto admin);
        Task<bool> DeleteAsync(Guid Id);
    }
}
