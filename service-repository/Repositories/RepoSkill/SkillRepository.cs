using service_data.Models;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoSkill
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ServiceAppDbContext ctx;
        public SkillRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Task<IQueryable<Skill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
