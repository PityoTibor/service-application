using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    [Table("tbl_skill")]
    public class Skill
    {
        [Key]
        public Guid Skill_id { get; set; }
        public string Name { get; set; }
        public bool IsAutoAssign { get; set; }
        public virtual ICollection<HandymanSkill> HandymanSkills { get; set; }
        //public virtual ICollection<No_use_TicketSkill> TicketSkills { get; set; }

    }
}
