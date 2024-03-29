﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public enum RoleEnum
    {
        admin = 0, handyman = 1, costumer = 2
    }
    public class User
    {
        [Key]
        public Guid User_Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public RoleEnum? Role { get; set;}

        [ForeignKey("Ticket_Id")]
        public Ticket ticket { get; set; }

    }
}
