using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace service_data.Models.DTOs.RequestDto
{
    public class CreateHandymanEntityDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum Role { get; set; }
    }
}
