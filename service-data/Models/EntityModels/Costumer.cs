using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    [Table("tbl_costumer")]
    public class Costumer
    {
        [Key]
        public Guid Costumer_id { get; set; }

        public Guid User_id { get; set; }
        [NotMapped]
        public virtual User User { get; set; }

        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [NotMapped]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
