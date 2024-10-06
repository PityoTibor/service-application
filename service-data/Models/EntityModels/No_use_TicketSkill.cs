using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    [Table("tbl_ticketskill")]
    public class No_use_TicketSkill
    {
        [Key]
        public Guid TicketSkill_skill_id { get; set; }
        public Guid Ticket_id { get; set; }
        public virtual Ticket Ticket { get; set; }
        public Guid Skill_id { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
