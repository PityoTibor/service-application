using service_data.Models.EntityModels;
using service_data.Models.DTOs.ResponseDto;
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
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created_date { get; set; }
        public string? SeverityEnum { get; set; }
        public string? StatusEnum { get; set; }

        public Guid? Handyman_id { get; set; }

        public Handyman? Handyman { get; set; }

        public Guid? Costumer_id { get; set; }

        public CostumerResponseDto? Costumer { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
