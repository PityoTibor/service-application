using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoSkill;
using service_repository.Repositories.RepoTicket;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicSkill
{
    public class SkillLogic : ISkillLogic
    {
        public readonly SkillRepository skillRepository;
        public SkillLogic(SkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }
        public Task<Skill> CreateAsync(CreateSkillEntityDto skill)
        {
            return skillRepository.CreateAsync(skill);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            return skillRepository.DeleteAsync(Id);
        }

        public Task<IQueryable<Skill>> GetAllAsync()
        {
            return skillRepository.GetAllAsync();
        }

        public Task<Skill> GetOneAsync(Guid Id)
        {
            return skillRepository.GetOneAsync(Id);
        }

        public Task<Skill> UpdateAsync(Guid Id, CreateSkillEntityDto message)
        {
            return skillRepository.UpdateAsync(Id, message);
        }
    }
}
