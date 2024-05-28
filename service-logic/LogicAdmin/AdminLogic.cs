using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoAdmin;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Task<Admin> CreateAsync(CreateAdminEntityDto adminUser)
        {
            var createdAdminUser = adminRepository.CreateAsync(adminUser);
            return createdAdminUser;
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            var result = adminRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<IQueryable<Admin>> GetAllAsync()
        {
            var result = await adminRepository.GetAllAsync();
            return result;
        }

        public async Task<Admin> GetOneAsync(Guid Id)
        {
            var result = await adminRepository.GetOneAsync(Id);
            return result;
        }

        public async Task<Admin> UpdateAsync(Guid Id, CreateAdminEntityDto adminUser)
        {
            return await adminRepository.UpdateAsync(Id, adminUser);  
        }
    }
}
