using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Handyman
    {
        [Key]
        [ForeignKey(nameof(User))]
        public Guid Handyman_id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid User_id { get; set; }
        [NotMapped]
        public virtual User User { get; set; }
        
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
