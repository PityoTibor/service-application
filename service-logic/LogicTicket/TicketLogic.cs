using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoMessage;
using service_repository.Repositories.RepoTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicTicket
{
    public class TicketLogic : ITicketLogic
    {

        public readonly ITicketRepository ticketRepository;
        public TicketLogic(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public async Task<Ticket> CreateAsync(CreateTicketEntityDto ticket)
        {
            var result = await ticketRepository.CreateAsync(ticket);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await ticketRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<IQueryable<Ticket>> GetAllAsync()
        {
            var result = await ticketRepository.GetAllAsync();
            return result;
        }

        public async Task<Ticket> GetOneAsync(Guid Id)
        {
            var result = await ticketRepository.GetOneAsync(Id);
            return result;
        }

        public async Task<Ticket> UpdateAsync(Guid Id, CreateTicketEntityDto message)
        {
            var result = await ticketRepository.UpdateAsync(Id, message);
            return result;
        }
    }
}
