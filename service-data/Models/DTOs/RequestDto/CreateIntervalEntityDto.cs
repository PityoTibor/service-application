using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateIntervalEntityDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Priority Priority { get; set; }
        public Guid Handyman_id { get; set; }
    }
}
