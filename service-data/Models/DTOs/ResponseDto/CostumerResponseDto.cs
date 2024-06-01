using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.ResponseDto
{
    public class CostumerResponseDto
    {
        public Guid Costumer_id { get; set; }
        public Guid User_id { get; set; }
        public User User { get; set; }
    }
}
