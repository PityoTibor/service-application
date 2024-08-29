using service_data.Models;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
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

        public async Task<IQueryable<Skill>> GetAllAsync()
        {
            try
            {
                var query = ctx.Skill.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {

                throw new Exception(message: "Failed to retrieve skill", innerException: ex);
            }
        }

        public Task<Skill> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
