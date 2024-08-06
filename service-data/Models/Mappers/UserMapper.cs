using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.DTOs.ResponseDto;

namespace service_data.Models.Mappers
{
    public class UserMapper : IUserMapper
    {
        public UserResponseDto ToDto(User user)
        {
            return new UserResponseDto
            {
                Id = user.User_id.ToString(),
                Username = user.Username,
                Email = user.Email,
                Role = Enum.GetName(user.Role)
            };
        }
    }
}
