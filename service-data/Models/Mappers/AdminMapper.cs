using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.Mappers
{
    public class AdminMapper
    {
        public AdminResponseDto ToDto(Admin admin)
        {
            return new AdminResponseDto
            {
                Id = admin.Admin_id
            };
        }
    }
}
