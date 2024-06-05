using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public string message { get; set; }
        public MessageNotFoundException() { }
        public MessageNotFoundException(string message) : base(message)
        {
            this.message = message;
        }
    }
}
