using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.ResponseDto
{
    public class TicketResponseDto
    {
        public Guid Ticket_id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created_date { get; set; }
        public SeverityEnum? SeverityEnum { get; set; }
        public StatusEnum? StatusEnum { get; set; }

        public Guid? Handyman_id { get; set; }

        public Handyman? Handyman { get; set; }

        public Guid? Costumer_id { get; set; }

        public Costumer? Costumer { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
