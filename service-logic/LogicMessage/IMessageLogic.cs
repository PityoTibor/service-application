using service_data.Models.DTOs.RequestDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicMessage
{
    public interface IMessageLogic
    {
        Task<Message> CreateAsync(CreateMessageEntityDto message);
        Task<Message> GetOneAsync(Guid Id);
        Task<IQueryable<Message>> GetAllAsync();
        Task<Message> UpdateAsync(Guid Id, CreateMessageEntityDto message);
        Task<bool> DeleteAsync(Guid Id);
    }
}
