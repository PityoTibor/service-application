using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions 
{
    public class InvalidMessageException : Exception
    {
        public string message { get; set; }
        public InvalidMessageException() { }
        public InvalidMessageException(string message) : base(message)
        {
            this.message = message;
        }
    }
}
