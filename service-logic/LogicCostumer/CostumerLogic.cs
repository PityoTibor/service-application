using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoCostumer;
using service_repository.Repositories.RepoHandyman;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicCostumer
{
    public class CostumerLogic : ICostumerLogic
    {
        public readonly ICostumerRepository costumerRepository;
        public readonly IUserRepository userRepository;
        public CostumerLogic(ICostumerRepository costumerRepository, IUserRepository userRepository)
        {
            this.costumerRepository = costumerRepository;
            this.userRepository = userRepository;
        }
        public async Task<Costumer> CreateAsync(CreateCostumerEntityDto createCostumerEntityDto)
        {
            var result = await costumerRepository.CreateAsync(createCostumerEntityDto);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await costumerRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<IQueryable<Costumer>> GetAllAsync()
        {
            var result = await costumerRepository.GetAllAsync();
            return result;
        }

        public async Task<Costumer> GetOneAsync(Guid Id)
        {
            var result = await costumerRepository.GetOneAsync(Id);
            return result;
        }

        public async Task<Costumer> UpdateAsync(Guid Id, CreateCostumerEntityDto createCostumerEntityDto)
        {
            var result = await costumerRepository.UpdateAsync(Id, createCostumerEntityDto);
            return result;
        }
    }
}
