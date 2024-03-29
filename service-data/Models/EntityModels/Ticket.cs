﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid Ticket_Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created_date { get; set; }
        public User? Costumer { get; set; }
        public User? Handyman { get; set; }
        public SeverityEnum? Serverity { get; set; }
        public StatusEnum? statusEnum  { get; set; }
        public ICollection<Message>? Messages { get; set; }

    }
}
