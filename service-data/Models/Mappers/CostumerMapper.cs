using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;

namespace service_data.Models.Mappers
{
    public class CostumerMapper : ICostumerMapper
    {
        public CostumerResponseDto ToDto(Costumer costumer)
        {
            UserMapper userMapper = new();
            return new CostumerResponseDto
            {
                Id = costumer.Costumer_id,
                User = userMapper.ToDto(costumer.User)
            };
        }
    }
}
