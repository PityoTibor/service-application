﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public enum SeverityEnum
    {
        low = 0, mid = 1, high = 2
    }

    public enum StatusEnum
    {
        unassigned = 0, ussigned = 1, work_in_progress = 2, pending = 3, resolved = 4
    }
    public class Ticket
    {
        [Key]
        public Guid Ticket_id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created_date { get; set; }
        public SeverityEnum? Severity { get; set; }
        public StatusEnum? statusEnum  { get; set; }

        [ForeignKey(nameof(Handyman))]
        public Guid HandymanId { get; set; }
        [NotMapped]
        public virtual Handyman? Handyman { get; set; }

        [ForeignKey(nameof(Costumer))]
        public int CostumerId { get; set; }
        [NotMapped]
        public virtual Costumer? Costumer { get; set; }
        
        [NotMapped]
        public virtual ICollection<Message>? Messages { get; set; }

    }
}
