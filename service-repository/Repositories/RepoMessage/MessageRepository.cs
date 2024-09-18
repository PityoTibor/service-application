using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Exceptions;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Repositories.RepoMessage
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ServiceAppDbContext ctx;
        public MessageRepository(ServiceAppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Message> CreateAsync(CreateMessageEntityDto newMessage)
        {
            Message message = new Message()
            { 
                Message_id = Guid.NewGuid(),
                Content = newMessage.Content,
                Created_date = DateTime.Now,
                Handyman_id = newMessage.Handyman_id ?? null,
                Costumer_id = newMessage.Costumer_id ?? null,
                Ticket_id = newMessage.Ticket_id ?? null,
            };
            
            ctx.Message.Add(message);
            ctx.SaveChanges();

            var savesMessage = ctx.Message
                        .Include(c => c.Costumer)
                        .Include(h => h.Handyman)
                        .Include(t => t.Ticket)
                        .Where(x => x.Message_id == message.Message_id)
                        .FirstOrDefault();

            return savesMessage;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var message = await GetOneAsync(Id);
            if (message != null)
            {
                try
                {
                    ctx.Message.Remove(message);
                    await ctx.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DatabaseOperationException(message: "Failed to delete message", innerException: ex);
                }
            }
            else
            {
                throw new UserNotFoundException(message: $"message with ID {Id} not found");
            }
        }

        public async Task<IQueryable<Message>> GetAllAsync()
        {
            try
            {
                var query = ctx.Message.AsQueryable();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException(message: "Failed to retrieve message", innerException: ex);
            }
        }

        public async Task<Message> GetOneAsync(Guid id)
        {
            var result = await ctx.Message.FindAsync(id);
            return result;
        }

        public async Task<Message> UpdateAsync(Guid Id, CreateMessageEntityDto message)
        {
            if (true)
            {
                var existingMessage = await ctx.Message.FirstOrDefaultAsync(x => x.Message_id == Id);

                if (existingMessage == null)
                {
                    throw new MessageNotFoundException("Message not found");
                }

                existingMessage.Content = message.Content != null ? message.Content : existingMessage.Content;
                existingMessage.Handyman_id = message.Handyman_id != null ? message.Handyman_id : existingMessage.Handyman_id;
                existingMessage.Ticket_id = message.Ticket_id != null ? message.Ticket_id : existingMessage.Ticket_id;
                existingMessage.Costumer_id = message.Costumer_id != null ? message.Costumer_id : existingMessage.Costumer_id;


                try
                {
                    ctx.Message.Update(existingMessage);
                    await ctx.SaveChangesAsync();
                    return existingMessage;
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

        private bool IsValidMessage(Object message)
        {
            if (message is CreateMessageEntityDto)
            {
                return  (message as CreateMessageEntityDto).Content.GetType() == typeof(string) &&
                 (message as CreateMessageEntityDto).Costumer_id.GetType() == typeof(Guid) &&
                 (message as CreateMessageEntityDto).Ticket_id.GetType() == typeof(Guid) &&
                 (message as CreateMessageEntityDto).Handyman_id.GetType() == typeof(Guid);
            }
            else
            {
                throw new InvalidMessageException(message: "The object is not of the expected type.");
            }
        }
    }
}
