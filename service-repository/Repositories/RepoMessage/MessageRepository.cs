using service_data.Models;
using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoUsers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return message;
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Message> GetOneAsync(Guid Id)
        {
            var result = await ctx.Message.FindAsync(Id);
            return result;
        }

        public Task<Message> UpdateAsync(Guid Id, CreateMessageEntityDto message)
        {
            throw new NotImplementedException();
        }
    }
}
