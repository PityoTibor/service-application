using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public enum Priority
    {
        first = 1, second = 2, third = 3
    }

    [Table("tbl_interval")]
    public class Interval
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Priority Priority { get; set; }
        public Guid Handyman_id { get; set; }
        public virtual Handyman Handyman { get; set; }
    }
}
