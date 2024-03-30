using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Costumer
    {
        [Key]
        public Guid Costumer_id { get; set; }
        public User Costumer_user_id { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
