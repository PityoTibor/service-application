using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Message
    {
        [Key]
        public Guid Message_id { get; set; }
        public string? Content { get; set; }
        public DateTime? Created_date { get; set; }
        public virtual User Sender { get; set; }
        [NotMapped]
        public virtual Ticket Ticket { get; set; }

    }
}
