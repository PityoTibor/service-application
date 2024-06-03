using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateMessageEntityDto
    {
        public string? Content { get; set; }
        public Guid? Handyman_id { get; set; }
        public Guid? Costumer_id { get; set; }
        public Guid? Ticket_id { get; set; }
    }
}
