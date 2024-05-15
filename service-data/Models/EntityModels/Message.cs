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
        
        [ForeignKey(nameof(Handyman))]
        public Guid HandymanId { get; set; }
        [NotMapped]
        public virtual Handyman? Handyman { get; set; }

        [ForeignKey(nameof(Costumer))]
        public Guid CostumerId { get; set; }
        [NotMapped]
        public virtual Costumer? Costumer { get; set; }

        [ForeignKey(nameof(Ticket))]
        public Guid TicketId { get; set; }
        [NotMapped]
        public virtual Ticket? Ticket { get; set; }

    }
}
