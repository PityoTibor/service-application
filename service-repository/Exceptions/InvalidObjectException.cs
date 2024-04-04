using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Exceptions
{
    public class InvalidObjectException : Exception
    {
        public string message { get; set; }
        public InvalidObjectException() { }
        public InvalidObjectException(string message)
        {
            this.message = message;
        }
    }
}
