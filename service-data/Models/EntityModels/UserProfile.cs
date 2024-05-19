using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
