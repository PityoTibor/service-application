using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateTicketEntityDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public SeverityEnum? SeverityEnum { get; set; }
        public Guid Costumer_id { get; set; }
    }
}
