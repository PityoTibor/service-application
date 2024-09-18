using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.ResponseDto
{
    public class AdminResponseDto
    {
        public Guid Id { get; set; }
        public UserResponseDto User { get; set; }
    }
}
