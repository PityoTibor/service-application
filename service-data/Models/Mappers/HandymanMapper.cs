using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.Mappers
{
    public class HandymanMapper
    {
        public HandymanResponseDto ToDto(Handyman handyman)
        {
            UserMapper userMapper = new UserMapper();
            return new HandymanResponseDto
            {
                Id = handyman.Handyman_id,
                User_id = handyman.User_id,
                User = userMapper.ToDto(handyman.User)
            };
        }
    }
}
