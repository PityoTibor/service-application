using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoInterval
{
    public class Interval : IInterval
    {
        private readonly ServiceAppDbContext ServiceAppDbContext;
        public Interval(ServiceAppDbContext serviceAppDbContext)
        { 
            this.ServiceAppDbContext = serviceAppDbContext;
        }
        public Task<Interval> CreateAsync(CreateIntervalEntityDto message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Interval>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
