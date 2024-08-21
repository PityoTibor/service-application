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
                Handyman = handymanMapper.ToDto(ticket.Handyman),
                Handyman_id = ticket.Handyman_id,
                Costumer = costumerMapper.ToDto(ticket.Costumer),
                Costumer_id = ticket.Costumer_id,
                Ticket = ticket.Ticket,
                Ticket_id = ticket.Ticket_id,
            };
        }
    }
}
