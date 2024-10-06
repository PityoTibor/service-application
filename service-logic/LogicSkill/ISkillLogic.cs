using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicSkill
{
    public interface ISkillLogic
    {
        Task<Skill> CreateAsync(CreateSkillEntityDto skill);
        Task<Skill> GetOneAsync(Guid Id);
        Task<IQueryable<Skill>> GetAllAsync();
        Task<Skill> UpdateAsync(Guid Id, CreateSkillEntityDto skill);
        Task<bool> DeleteAsync(Guid Id);
    }
}
