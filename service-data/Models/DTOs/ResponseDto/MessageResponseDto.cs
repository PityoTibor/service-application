using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.ResponseDto
{
    public class MessageResponseDto
    {
        public Guid? Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Created_date { get; set; }
        public Guid? Handyman_id { get; set; }
        public Handyman? Handyman { get; set; }

        public Guid? Costumer_id { get; set; }
        public  Costumer? Costumer { get; set; }
        public Guid? Ticket_id { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
