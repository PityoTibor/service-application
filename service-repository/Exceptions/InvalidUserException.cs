using service_data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
    public class InvalidUserException : Exception
    {
        public string message { get; set; }
        public InvalidUserException() { }
        public InvalidUserException(string message)
        {
            this.message = message;
        }
    }
}
