using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.Mappers
{
    public class MessageMapper : IMessageMapper
    {
        public MessageResponseDto ToDto(Message ticket)
        {
            CostumerMapper costumerMapper = new CostumerMapper();
            HandymanMapper handymanMapper = new HandymanMapper();
            return new MessageResponseDto
            {
                Id = ticket.Message_id,
                Content = ticket.Content,
                Created_date = ticket.Created_date,
                Handyman = ticket.Handyman != null ? handymanMapper.ToDto(ticket.Handyman) : null,
                Handyman_id = ticket.Handyman_id != null ? ticket.Handyman_id : null,
                Costumer = ticket.Costumer_id != null ? costumerMapper.ToDto(ticket.Costumer) : null,
                Costumer_id = ticket.Costumer_id != null ? ticket.Costumer_id : null,
                Ticket = ticket.Ticket,
                Ticket_id = ticket.Ticket_id,
            };
        }
    }
}
