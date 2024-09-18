using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoInterval
{
    public class IntervalRepository : IIntervalRepository
    {
        private readonly ServiceAppDbContext ctx;
        public IntervalRepository(ServiceAppDbContext ctx)
        { 
            this.ctx = ctx;
        }
        public async Task<Interval> CreateAsync(CreateIntervalEntityDto data)
        {
            try
            {
                if (data != null)
                {
                    Interval Interval = new Interval()
                    {
                        FromDate = data.From,
                        ToDate = data.To,
                        Priority = data.Priority,
                        Handyman_id = data.Handyman_id,
                    };
                    
                    ctx.Interval.Add(Interval);
                    ctx.SaveChanges();
                    return Interval;
                }

                throw new Exception("CreateIntervalEntityDto data - data null");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var Interval = await GetOneAsync(Id);
            if (Interval != null)
            {
                try
                {
                    ctx.Interval.Remove(Interval);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete Interval", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"Interval with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Interval>> GetAllAsync()
        {
            try
            {
                var query = ctx.Interval.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to Interval GetAllAsync", innerException: ex);
            }
        }

        public async Task<Interval> GetOneAsync(Guid Id)
        {
            var res = await ctx.Interval.FindAsync(Id);

            if (res == null)
            {
                throw new Exception(message: $"Interval with ID {Id} not found");
            }
            return res;
        }
    }
}
