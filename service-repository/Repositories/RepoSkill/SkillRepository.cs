using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_data.Models.DTOs.RequestDto;
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

        public async Task<Skill> GetOneAsync(Guid id)
        {
            try
            {
                var result = await ctx.Skill.FindAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var skill = await GetOneAsync(Id);
            if (skill != null)
            {
                try
                {
                    ctx.Skill.Remove(skill);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete skill", innerException: ex);
                }
            }
            else
            {
                throw new Exception(message: $"skill with ID {Id} not found");
            }
        }

        public async Task<Skill> CreateAsync(CreateSkillEntityDto newSkill)
        {
            Skill skill = new Skill()
            { 
                Skill_id = Guid.NewGuid(),
                IsAutoAssing = newSkill.IsAutoAssing,
                Name = newSkill.Name,
                
            };

            ctx.Skill.Add(skill);
            ctx.SaveChanges();
            return skill;
        }

        public async Task<Skill> UpdateAsync(Guid Id, CreateSkillEntityDto newSkill)
        {
            if (true)
            {
                var existingSkill = await ctx.Skill.FirstOrDefaultAsync(x => x.Skill_id == Id);

                if (existingSkill == null)
                {
                    throw new MessageNotFoundException("Message not found");
                }

                existingSkill.Name = newSkill.Name != null ? newSkill.Name : existingSkill.Name;
                existingSkill.IsAutoAssing = newSkill.IsAutoAssing != null ? newSkill.IsAutoAssing : existingSkill.IsAutoAssing;

                try
                {
                    ctx.Skill.Update(existingSkill);
                    await ctx.SaveChangesAsync();
                    return existingSkill;
                }
                catch (DbUpdateException ex)
                {
                    throw new DatabaseOperationException("Error while updating message", ex);
                }
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }

    }
}
