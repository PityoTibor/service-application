using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Skill
    {
        [Key]
        public Guid Skill_id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HandymanSkill> HandymanSkills { get; set; }
    }
}
