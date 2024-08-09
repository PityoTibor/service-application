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

namespace service_repository.Repositories.RepoTicket
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ServiceAppDbContext ctx;
        public TicketRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Ticket> CreateAsync(CreateTicketEntityDto newTicket)
        {
            Ticket ticket = new Ticket()
            { 
                Ticket_id = Guid.NewGuid(),
                Title = newTicket.Title,
                Description = newTicket.Description,
                Created_date = DateTime.Now,
                SeverityEnum = newTicket.SeverityEnum ?? SeverityEnum.low,
                StatusEnum = StatusEnum.ussigned,
                Costumer_id = newTicket.Costumer_id,
            };
            
            ctx.Ticket.Add(ticket);
            ctx.SaveChanges();

            var savedTicket = ctx.Ticket
                .Include(h => h.Handyman)
                .Include(c => c.Costumer)
                .Where(x => x.Ticket_id == ticket.Ticket_id)
                .FirstOrDefault();
            return ticket;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var ticket = await GetOneAsync(Id);
            if (ticket != null)
            {
                try
                {
                    ctx.Ticket.Remove(ticket);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete ticket", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"ticket with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Ticket>> GetAllAsync()
        {
            try
            {
                var query = ctx.Ticket.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve ticket", innerException: ex);
            }
        }

        public async Task<Ticket> GetOneAsync(Guid Id)
        {
            var result = await ctx.Ticket.FindAsync(Id);
            return result;
        }

        public async Task<Ticket> UpdateAsync(Guid Id, CreateTicketEntityDto ticket)
        {
            if (true)
            {
                var existingTicket = await ctx.Ticket.FirstOrDefaultAsync(x => x.Ticket_id == Id);

                if (existingTicket == null)
                {
                    throw new TicketNotFoundException("Ticket not found");
                }

                existingTicket.Title = ticket.Title != null ? ticket.Title : existingTicket.Title;
                existingTicket.Description = ticket.Description != null ? ticket.Description : existingTicket.Description;
                existingTicket.SeverityEnum = ticket.SeverityEnum != null ? ticket.SeverityEnum : existingTicket.SeverityEnum;
                existingTicket.Costumer_id = ticket.Costumer_id != null ? ticket.Costumer_id : existingTicket.Costumer_id;


                try
                {
                    ctx.Ticket.Update(existingTicket);
                    await ctx.SaveChangesAsync();
                    return existingTicket;
                }
                catch (DbUpdateException ex)
                {
                    throw new DatabaseOperationException("Error while updating ticket", ex);
                }
            }
            else
            {
                throw new InvalidUserException(message: "The object is not of the expected type.");
            }
        }
    }
}
