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
        public Task<Skill> GetAsync();
    }
}
