using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using service_repository.Repositories.RepoMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicMessage
{
    public class MessageLogic : IMessageLogic
    {
        public readonly IMessageRepository messageRepository;
        public MessageLogic(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        public async Task<Message> CreateAsync(CreateMessageEntityDto message)
        {
            var result = await messageRepository.CreateAsync(message);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await messageRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<IQueryable<Message>> GetAllAsync()
        {
            var result = await messageRepository.GetAllAsync();
            return result;
        }

        public async Task<Message> GetOneAsync(Guid Id)
        {
            var result = await messageRepository.GetOneAsync(Id);
            return result;
        }

        public Task<Message> UpdateAsync(Guid Id, CreateMessageEntityDto message)
        {
            var result = messageRepository.UpdateAsync(Id, message);
            return result;
        }
    }
}
