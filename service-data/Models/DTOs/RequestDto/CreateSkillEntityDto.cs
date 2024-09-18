using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateSkillEntityDto
    {
        public string Name { get; set; }
        public bool IsAutoAssing { get; set; }
    }
}
