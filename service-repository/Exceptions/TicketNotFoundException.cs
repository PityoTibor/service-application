using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public string message { get; set; }
        public TicketNotFoundException() { }
        public TicketNotFoundException(string message): base(message)
        {
            this.message = message;
        }
    }
}
