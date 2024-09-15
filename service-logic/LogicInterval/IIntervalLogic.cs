using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicInterval
{
    public interface IIntervalLogic
    {
        Task<Interval> CreateAsync(CreateIntervalEntityDto data);
        Task<IQueryable<Interval>> GetAllAsync();
        Task<Interval> GetOneAsync(Guid Id);
        Task<bool> DeleteAsync(Guid Id);
    }
}
