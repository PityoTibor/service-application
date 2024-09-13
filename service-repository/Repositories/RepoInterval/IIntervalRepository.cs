using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoInterval
{
    public interface IInterval
    {
        Task<Interval> CreateAsync(object message);
        Task<IQueryable<Interval>> GetAllAsync();
        Task<bool> DeleteAsync(Guid Id);
    }
}
