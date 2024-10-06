using service_data.Models.DTOs.ResponseDto;
using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.Mappers
{
    public class SkillMapper : ISkillMapper
    {
        public SkillResponseDto ToDto(Skill ticket)
        {
            return new SkillResponseDto()
            {
                Skill_id = ticket.Skill_id,
                Name = ticket.Name,
            };
        }
    }

    public interface ISkillMapper
    {
        public SkillResponseDto ToDto(Skill ticket);
    }
}
