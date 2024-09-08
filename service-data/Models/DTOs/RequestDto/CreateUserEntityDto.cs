﻿using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateUserEntityDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum Role { get; set; }
    }
}
