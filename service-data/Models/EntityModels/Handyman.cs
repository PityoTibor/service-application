using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Handyman
    {
        [Key]
        public Guid Handyman_id { get; set; }
        public User Handyman_user_id { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
