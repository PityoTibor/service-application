using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicTicket
{
    public class TicketLogic : ITicketLogic
    {
        
        public Task<Ticket> CreateAsync(CreateTicketEntityDto message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Ticket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetOneAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> UpdateAsync(Guid Id, CreateTicketEntityDto message)
        {
            throw new NotImplementedException();
        }
    }
}
