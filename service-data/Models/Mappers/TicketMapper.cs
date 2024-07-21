﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;

namespace service_data.Models.Mappers
{
    public class TicketMapper
    {
        public TicketResponseDto ToDto(Ticket ticket)
        {
            CostumerMapper costumerMapper = new();
            return new TicketResponseDto
            {
                Id = ticket.Ticket_id,
                Title = ticket.Title,
                Description = ticket.Description,
                Created_date = DateTime.Now,
                SeverityEnum = ticket.SeverityEnum.ToString(),
                StatusEnum = ticket.StatusEnum.ToString(),
                Costumer = costumerMapper.ToDto(ticket.Costumer),
                Messages = ticket.Messages,
            };
        }
    }
}
