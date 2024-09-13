using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models.EntityModels
{
    public enum Priority
    {
        first = 1, second = 2, third = 3
    }
    public class Interval
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Priority Priority { get; set; }
        public Guid Handyman_id { get; set; }
        public virtual Handyman handyman { get; set; }
    }
}
