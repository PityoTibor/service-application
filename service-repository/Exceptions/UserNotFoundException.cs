using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string message { get; set; }
        public UserNotFoundException() { }
        public UserNotFoundException(string message)
        {
            this.message = message;
        }
    }
}
