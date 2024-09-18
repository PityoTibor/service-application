using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    [Table("tbl_admin")]
    public class Admin
    {
        [Key]
        public Guid Admin_id { get; set; }

        public Guid User_id { get; set; }
        [NotMapped]
        public virtual User User { get; set; }

    }
}
