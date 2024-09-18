using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    [Table("tbl_handyman")]
    public class Handyman
    {
        [Key]
        public Guid Handyman_id { get; set; }

        public Guid User_id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public virtual User User { get; set; }

        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [NotMapped]
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<HandymanSkill> HandymanSkills { get; set; }
        public virtual ICollection<Interval> Intervals { get; set; }
    }
}
