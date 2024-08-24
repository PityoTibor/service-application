using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class HandymanSkill
    {
        [Key]
        public Guid Handyman_skill_id { get; set; }
        public Guid Handyman_id { get; set; }
        public virtual Handyman Handyman { get; set; }
        public Guid Skill_id { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
