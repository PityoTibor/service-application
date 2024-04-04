using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public class Admin
    {
        [Key]
        public Guid Admin_id { get; set; }
        public User Admin_user_id { get; set;}
    }
}
