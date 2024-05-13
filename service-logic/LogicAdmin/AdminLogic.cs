using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoAdmin;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicAdmin
{
    public class AdminLogic : IAdminLogic
    {
        public readonly IAdminRepository adminRepository;
        public readonly IUserRepository userRepository;
        public AdminLogic(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            this.adminRepository = adminRepository;
            this.userRepository = userRepository;
        }

        public Task<Admin> CreateAsync(AdminEntityDto adminUser)
        {
            var createdAdminUser = adminRepository.CreateAsync(adminUser);
            return createdAdminUser;
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Admin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetOneAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> UpdateAsync(Guid Id, AdminEntityDto adminUser)
        {
            throw new NotImplementedException();
        }
    }
}
