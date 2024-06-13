using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoTicket
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateAsync(CreateTicketEntityDto message);
        Task<Ticket> GetOneAsync(Guid Id);
        Task<IQueryable<Ticket>> GetAllAsync();
        Task<Ticket> UpdateAsync(Guid Id, CreateTicketEntityDto message);
        Task<bool> DeleteAsync(Guid Id);
    }
}
