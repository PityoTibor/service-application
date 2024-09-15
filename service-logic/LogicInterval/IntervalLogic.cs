using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoInterval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicInterval
{
    public class IntervalLogic : IIntervalLogic
    {
        private readonly IIntervalRepository IntervalRepository;
        public IntervalLogic(IIntervalRepository IntervalRepository)
        {
            this.IntervalRepository = IntervalRepository;
        }
        public Task<Interval> CreateAsync(CreateIntervalEntityDto data)
        {
            return IntervalRepository.CreateAsync(data);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            return IntervalRepository.DeleteAsync(Id);
        }

        public Task<IQueryable<Interval>> GetAllAsync()
        {
            return IntervalRepository.GetAllAsync();
        }

        public Task<Interval> GetOneAsync(Guid Id)
        {
            return IntervalRepository.GetOneAsync(Id);
        }
    }
}
