using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoAdmin;
using service_repository.Repositories.RepoHandyman;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicHandyman
{
    public class HandymanLogic : IHandymanLogic
    {
        public readonly IHandymanRepository handymanRepository;
        public readonly IUserRepository userRepository;
        public HandymanLogic(IHandymanRepository handymanRepository, IUserRepository userRepository)
        {
            this.handymanRepository = handymanRepository;
            this.userRepository = userRepository;
        }

        public async Task<Handyman> CreateAsync(CreateHandymanEntityDto user)
        {
            var result = await handymanRepository.CreateAsync(user);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await handymanRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<IQueryable<Handyman>> GetAllAsync()
        {
            var result = await handymanRepository.GetAllAsync();
            return result;
        }

        public async Task<Handyman> GetOneAsync(Guid Id)
        {
            var result = await handymanRepository.GetOneAsync(Id);
            return result;
        }

        public async Task<Handyman> UpdateAsync(Guid Id, CreateHandymanEntityDto handyman)
        {
            var result = await handymanRepository.UpdateAsync(Id, handyman);
            return result;
        }
    }
}
