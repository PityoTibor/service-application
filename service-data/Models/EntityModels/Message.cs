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
        public Guid Message_Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Created_date { get; set; }
        public User Sender { get; set; }
        public Ticket Ticket { get; set; }

    }
}
