using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.ResponseDto
{
    public class IntervalResponseDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Priority Priority { get; set; }
        public Handyman Handyman { get; set; }
    }
}
