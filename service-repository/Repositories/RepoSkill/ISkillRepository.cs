using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoSkill
{
    public interface ISkillRepository
    {
        public Task<IQueryable<Skill>> GetAllAsync();
        public Task<Skill> GetOneAsync(Guid id);
        public Task<Skill> CreateAsync(CreateMessageEntityDto message);
        public Task<Skill> UpdateAsync(Guid Id, CreateMessageEntityDto message);
        public Task<bool> DeleteAsync(Guid Id);

    }
}
